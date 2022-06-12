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
    internal class EscolaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Escola escola)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO escola VALUES " +
                "(null, @nome_esc, @razao_social_esc, @cnpj_esc, @inscricao_esc, @tipo_esc, @data_criacao_esc, @resp_esc, @resp_tel_esc, " +
                "@email_esc, @telefone_esc, @rua_esc, @numero_esc, @bairro_esc, @complemento_esc, @cidade_esc, @estado_esc);";

                comando.Parameters.AddWithValue("@nome_esc", escola.NomeFantasia);
                comando.Parameters.AddWithValue("@razao_social_esc", escola.RazaoSocial);
                comando.Parameters.AddWithValue("@cnpj_esc", escola.Cnpj);
                comando.Parameters.AddWithValue("@inscricao_esc", escola.InscEstadual);
                comando.Parameters.AddWithValue("@tipo_esc", escola.Tipo);
                comando.Parameters.AddWithValue("@data_criacao_esc", escola.DataCriacao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@resp_esc", escola.Responsavel);
                comando.Parameters.AddWithValue("@resp_tel_esc", escola.ResponsavelTelefone);
                comando.Parameters.AddWithValue("@email_esc", escola.Email);
                comando.Parameters.AddWithValue("@telefone_esc", escola.Telefone);
                comando.Parameters.AddWithValue("@rua_esc", escola.Rua);
                comando.Parameters.AddWithValue("@numero_esc", escola.Numero);
                comando.Parameters.AddWithValue("@bairro_esc", escola.Bairro);
                comando.Parameters.AddWithValue("@complemento_esc", escola.Complemento);
                //comando.Parameters.AddWithValue("@cep_esc", escola.CEP);
                comando.Parameters.AddWithValue("@cidade_esc", escola.Cidade);
                comando.Parameters.AddWithValue("@estado_esc", escola.Numero);

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

        public List<Escola> List()
        {
            try
            {
                var lista = new List<Escola>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM escola";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var escola = new Escola();
                    escola.Id = reader.GetInt32("id_esc");
                    escola.NomeFantasia = DAOHelpers.GetString(reader, "nome_esc");
                    escola.RazaoSocial = DAOHelpers.GetString(reader, "razao_social_esc");
                    escola.Cnpj = DAOHelpers.GetString(reader, "cnpj_esc");
                    escola.InscEstadual = DAOHelpers.GetString(reader, "inscricao_esc");
                    escola.Tipo = DAOHelpers.GetString(reader, "cnpj_esc");
                    escola.DataCriacao = DAOHelpers.GetDateTime(reader, "data_criacao_esc");
                    escola.Responsavel = DAOHelpers.GetString(reader, "resp_esc");
                    escola.ResponsavelTelefone = DAOHelpers.GetString(reader, "resp_tel_esc");
                    escola.Email = DAOHelpers.GetString(reader, "email_esc");
                    escola.Telefone = DAOHelpers.GetString(reader, "telefone_esc");
                    escola.Rua = DAOHelpers.GetString(reader, "rua_esc");
                    escola.Numero = DAOHelpers.GetString(reader, "numero_esc");
                    escola.Bairro = DAOHelpers.GetString(reader, "bairro_esc");
                    escola.Complemento = DAOHelpers.GetString(reader, "complemento_esc");
                    //escola.CEP  = DAOHelpers.GetString(reader, "cnpj_esc");
                    escola.Cidade = DAOHelpers.GetString(reader, "cidade_esc");
                    escola.Estado = DAOHelpers.GetString(reader, "estado_esc");

                    lista.Add(escola);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }
        public void Delete(Escola escola)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM escola WHERE (id_esc = @id)";

                comando.Parameters.AddWithValue("@id", escola.Id);

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
