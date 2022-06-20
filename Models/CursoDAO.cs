﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetinhoEscola.DataBase;
using MySql.Data.MySqlClient;
using ProjetinhoEscola.Helpers;

namespace ProjetinhoEscola.Models
{
    internal class CursoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Curso curso)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Curso VALUES (null,@nome,@descricao,@carga_horaria,@turno);";

                comando.Parameters.AddWithValue("@nome", curso.Nome);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);
                comando.Parameters.AddWithValue("@carga_horaria", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@turno", curso.Turno);
                
                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Curso> List()
        {
            try
            {
                var lista = new List<Curso>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM curso";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var curso = new Curso();
                    curso.Id = reader.GetInt32("id_cur");
                    curso.Nome = DAOHelpers.GetString(reader,"nome_cur");
                    curso.Descricao = DAOHelpers.GetString(reader, "descricao_cur");
                    curso.CargaHoraria = DAOHelpers.GetString(reader,"carga_horaria_cur");
                    curso.Turno = DAOHelpers.GetString(reader,"turno_cur");
                    
  
                    lista.Add(curso);
                }
                reader.Close();
                return lista;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Curso curso)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM curso WHERE (id_cur = @id)";

                comando.Parameters.AddWithValue("@id", curso.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao deletar as informações");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(Curso curso)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "update curso set " +
                    "nome_cur = @nome, descricao_cur = @descricao, carga_horaria_cur = @carga_horaria, turno_cur = @turno;";

                comando.Parameters.AddWithValue("@nome", curso.Nome);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);
                comando.Parameters.AddWithValue("@carga_horaria", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@turno", curso.Turno);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}
