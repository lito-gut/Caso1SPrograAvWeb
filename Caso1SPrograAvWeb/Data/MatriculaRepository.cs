﻿using Caso1SPrograAvWeb.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Caso1SPrograAvWeb.Data
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly IConexionSQL _conexion;

        public MatriculaRepository(IConexionSQL conexion)
        {
            _conexion = conexion;
        }

        public async Task<bool> RegistrarMatriculaAsync(MatriculaModel model)
        {
            using var db = _conexion.CrearConexion();

            var parametros = new DynamicParameters();
            parametros.Add("@Nombre", model.NombreEstudiante);
            parametros.Add("@Monto", model.Monto);
            parametros.Add("@TipoCurso", model.TipoCurso);
            parametros.Add("@Fecha", model.Fecha);

            var resultado = await db.ExecuteScalarAsync<int>(
                "sp_RegistrarMatricula",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            return resultado > 0;
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerTiposCursosAsync()
        {
            using var db = _conexion.CrearConexion();

            var datos = await db.QueryAsync<(int, string)>(
                "sp_ObtenerTiposCursos", commandType: CommandType.StoredProcedure
                );

            return await db.QueryAsync<SelectListItem>(
                "sp_ObtenerTiposCursos", commandType: CommandType.StoredProcedure);
        }

        public async Task<int> ContarMatriculasPorEstudianteAsync(string nombreEstudiante)
        {
            using var db = _conexion.CrearConexion();

            var cantidad = await db.ExecuteScalarAsync<int>(
                "sp_ContarMatriculasPorEstudiante",
                new { Nombre = nombreEstudiante },
                commandType: CommandType.StoredProcedure
            );

            return cantidad;
        }

        public async Task<bool> TipoCursoExisteAsync(int tipoCursoId)
        {
            using var db = _conexion.CrearConexion();

            var existe = await db.ExecuteScalarAsync<int>(
                "sp_ExisteTipoCurso",
                new { TipoCurso = tipoCursoId },
                commandType: CommandType.StoredProcedure
            );

            return existe > 0;
        }

        public async Task<IEnumerable<ConsultaMatriculaModel>> ObtenerConsultasAsync()
        {
            using var db = _conexion.CrearConexion();

            var resultado = await db.QueryAsync<ConsultaMatriculaModel>(
                "sp_ConsultarMatriculas",
                commandType: CommandType.StoredProcedure);

            return resultado;
        }
    }

    public interface IMatriculaRepository
    {
        Task<bool> RegistrarMatriculaAsync(MatriculaModel model);
        Task<int> ContarMatriculasPorEstudianteAsync(string nombreEstudiante);
        Task<bool> TipoCursoExisteAsync(int tipoCursoId);
        Task<IEnumerable<ConsultaMatriculaModel>> ObtenerConsultasAsync();
        Task<IEnumerable<SelectListItem>> ObtenerTiposCursosAsync();
    }
}