using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Projeto_Biblioteca.DAL
{
    public class Connection
    {
        protected SqlConnection conexao;
        protected SqlCommand command;
        protected SqlDataReader dataReader;

        protected void Conectar()
        {
            try
            {
                conexao = new SqlConnection(
                    @"Data Source=(localdb)\MSSQLLocalDB;
                    Initial Catalog=Projeto_Biblioteca;
                    Integrated Security = true");
                conexao.Open();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        protected void Desconectar()
        {
            try
            {
                conexao.Close();
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }
    }
}
