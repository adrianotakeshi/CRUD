using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Business.Services
{
    public class CarrosService
    {
        public bool CadastroCarro(int Codigo, int CodigoMarca, string Cor, int Ano, string Modelo)
        {
            StringBuilder query = new StringBuilder();
            var session = new DBSession();

            query.Append("Exec InserirCarro @Codigo = " + Codigo.ToString()
                + ", @CodigoMarca = " + CodigoMarca.ToString() + ", @Modelo = '" + Modelo + "', @Ano = " 
                + Ano.ToString() + ", @Cor = '" + Cor + "'"); 

            try
            {
                session.ExecuteSqlTransaction(query.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        public bool alterarCarro(int Codigo, int CodigoMarca, string Cor, int Ano, string Modelo)
        {
            StringBuilder query = new StringBuilder();
            var session = new DBSession();

            query.Append("Exec AlterarCarro @Codigo = " + Codigo.ToString()
              + ", @CodigoMarca = " + CodigoMarca.ToString() + ", @Modelo = '" + Modelo + "', @Ano = "
              + Ano.ToString() + ", @Cor = '" + Cor + "'");
            try
            {
                session.ExecuteSqlTransaction(query.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        public bool excluirCarros(int Codigo)
        {
            StringBuilder query = new StringBuilder();
            var session = new DBSession();

            query.Append("Exec ExcluirCarro @Codigo = " + Codigo);

            try
            {
                session.ExecuteSqlTransaction(query.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        public IDataReader listarCarros()
        {
            StringBuilder query = new StringBuilder();
            var session = new DBSession();

            query.Append("Exec ListarCarros");

            Query executar = session.CreateQuery(query.ToString());
            IDataReader reader = executar.ExecuteQuery();

            return reader;

        }
    }
}
