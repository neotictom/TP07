using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace TP07.Models;
public class BD{

    private static string _connectionString = @"Server=DESKTOP-6QK3E9R\SQLEXPRESS01; Database=Preguntados; Trusted_Connection=True";
    
    public static List<Categoria> ObtenerCategorias(){
        using (SqlConnection conexion = new SqlConnection(_connectionString))
        {
            string sql = "SELECT [IdCategoria], [Nombre], [Foto] FROM [dbo].[Categorias];";
            return conexion.Query<Categoria>(sql).ToList();
        }
    }
    public static List<Dificultad> ObtenerDificultades(){
        using (SqlConnection conexion = new SqlConnection(_connectionString))
        {
            string sql = "SELECT [IdDificultad], [nombre] FROM [dbo].[Dificultades];";
            return conexion.Query<Dificultad>(sql).ToList();
        }
    }
    public static List<Pregunta> ObtenerPreguntas(int idDificultad, int idCategoria){
        List<Pregunta> info = new List<Pregunta>{};
        if (idDificultad == -1 && idCategoria == -1)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string sql = "SELECT [IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto] FROM [dbo].[Preguntas];";
                info = conexion.Query<Pregunta>(sql).ToList();
            }  
        }
        else if(idDificultad == -1)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string sql = "SELECT [IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto] FROM [dbo].[Preguntas] WHERE IdCategoria = @idCategoria;";
                info = conexion.Query<Pregunta>(sql, new { IdCategoria = idCategoria }).ToList();
            }  
        }
        else if(idCategoria == -1)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string sql = "SELECT [IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto] FROM [dbo].[Preguntas] WHERE IdDificultad = @idDificultad;";
                info = conexion.Query<Pregunta>(sql, new { idDificultad = idDificultad }).ToList();
            }  
        }
        else
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string sql = "SELECT [IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto] FROM [dbo].[Preguntas] WHERE IdCategoria = @idCategoria AND IdDificultad = @idDificultad";
                info = conexion.Query<Pregunta>(sql, new { IdCategoria = idCategoria, idDificultad = idDificultad }).ToList();
            }   
        }
        return info;
    }
    public static List<Respuesta> ObtenerRespuestas() {
        List<Respuesta> info = new List<Respuesta>{};
        using (SqlConnection conexion = new SqlConnection(_connectionString))
        {
            string sql = "SELECT [IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto] FROM [dbo].[Respuestas]";
            info = conexion.Query<Respuesta>(sql).ToList();
        }
        return info;
    }
}