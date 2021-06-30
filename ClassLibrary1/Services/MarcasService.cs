using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MarcasService
    {
        public bool CadastroMarca(int Codigo, string Nome)
        {
            StringBuilder query = new StringBuilder();
            var session = new DBSession();

            query.Append("EXEC InserirMarca @Codigo = " + Codigo.ToString() + ", @Nome = '" + Nome + "';");

            try
            {
                session.ExecuteSqlTransaction(query.ToString());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;

        }

        public bool excluirMarca(int Codigo)
        {
            StringBuilder query = new StringBuilder();
            var session = new DBSession();

            query.Append("EXEC ExcluirMarca @Codigo = " + Codigo.ToString());

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

        public bool alterarMarca(int Codigo, string Nome)
        {
            StringBuilder query = new StringBuilder();
            var session = new DBSession();

            query.Append("EXEC AlterarMarca @Codigo = " + Codigo.ToString() + ", @Nome = '" + Nome + "';");

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

        public IDataReader listarMarcas()
        {
            StringBuilder query = new StringBuilder();
            var session = new DBSession();

            query.Append("Exec ListarMarcas");

            Query executar = session.CreateQuery(query.ToString());
            IDataReader reader = executar.ExecuteQuery();

            return reader;            
            
        }
    }
}
