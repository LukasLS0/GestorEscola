using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.DataBase;

namespace ProjetoEscola.Models
{
    internal class EscolaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Escola escola)
        {
            try
            {
                var comando = _conn.Query();

                var data = escola.DataCriacao?.ToString("yyyy-MM-dd");
                comando.CommandText = "INSERT INTO Escola values (null, @nome, @razao, @cnpj, @inscricao, @tipo, @data_criacao, @resp, @resp_tel, " +
                    "@email, @telefone, @rua, @numero, @bairro, @complemento,@cep, @cidade, @estado);";

                comando.Parameters.AddWithValue("@nome", escola.NomeFantasia);
                comando.Parameters.AddWithValue("@razao", escola.RazaoSocial);
                comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
                comando.Parameters.AddWithValue("@inscricao", escola.Inscricao);
                comando.Parameters.AddWithValue("@tipo", escola.Tipo);
                comando.Parameters.AddWithValue("@data_criacao", escola.DataCriacao);
                comando.Parameters.AddWithValue("@resp", escola.Resp);
                comando.Parameters.AddWithValue("@resp_tel", escola.RespTel);
                comando.Parameters.AddWithValue("@email", escola.Email);
                comando.Parameters.AddWithValue("@telefone", escola.Telefone);
                comando.Parameters.AddWithValue("@rua", escola.Rua);
                comando.Parameters.AddWithValue("@numero", escola.Numero);
                comando.Parameters.AddWithValue("@bairro", escola.Bairro);
                comando.Parameters.AddWithValue("@complemento", escola.Complemento);
                comando.Parameters.AddWithValue("@cep", escola.Cep);
                comando.Parameters.AddWithValue("@cidade", escola.Cidade);
                comando.Parameters.AddWithValue("@estado", escola.Estado);

                var resultado = comando.ExecuteNonQuery();

                if (resultado > 0)
                {
                    //MessageBox.Show("Registro salvo com sucesso");
                }

            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);

            }
        }
    }
}
