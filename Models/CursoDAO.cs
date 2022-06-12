using System;
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

                comando.CommandText = "INSERT INTO Curso VALUES (null,@nome_curso,@carga_horaria_curso,@turno_curso,@descricao_curso);";

                comando.Parameters.AddWithValue("@nome_curso", curso.Nome);
                comando.Parameters.AddWithValue("@carga_horaria_curso", curso.CargaHoraria);
                comando.Parameters.AddWithValue("turno_curso", curso.Turno);
                comando.Parameters.AddWithValue("@descricao_curso", curso.Descricao);

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
                    curso.Id = reader.GetInt32("id_curso");
                    curso.Nome = DAOHelpers.GetString(reader,"nome_curso");
                    curso.CargaHoraria = DAOHelpers.GetString(reader,"carga_horaria_curso");
                    curso.Turno = DAOHelpers.GetString(reader,"turno_curso");
                    curso.Descricao = DAOHelpers.GetString(reader,"descricao_curso");
  
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

                comando.CommandText = "DELETE FROM curso WHERE (id_curso = @id)";

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
    }
    
}
