using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Business.Services;
using System.Data;

namespace TesteAccessBrasil
{
    public partial class CadastroMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregarMarcas();
                btnSalvar.CommandName = "I";
            }
        }

        private void carregarMarcas()
        {
            MarcasService servico = new MarcasService();
            IDataReader listaMarca = servico.listarMarcas();

            GridView1.DataSource = listaMarca;
            GridView1.DataBind();
            
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[1].Text;
                foreach (Button button in e.Row.Cells[3].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Deseja excluir " + item + "?')){ return false; };";
                    }
                }
            }
        }

        private void excluirMarca(int cod)
        {
            MarcasService servico = new MarcasService();
            servico.excluirMarca(cod);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Sucesso", "alert('Exclusão realizada com sucesso')", true);

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (btnSalvar.CommandName.CompareTo("I") == 0)
            {
                if (txtCodigo.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Validacao", "alert('Campo Codigo Obrigatório')", true);
                    txtCodigo.Focus();
                }
                else
                {
                    if (txtNome.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Validacao", "alert('Campo Nome Obrigatório')", true);
                        txtNome.Focus();
                    }
                    else
                    {
                        MarcasService servico = new MarcasService();
                        servico.CadastroMarca(Int32.Parse(txtCodigo.Text), txtNome.Text);
                        carregarMarcas();
                        limpar();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Sucesso", "alert('Cadastro realizado com sucesso')", true);

                    }
                }
            }
            else
            {
                if (txtNome.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Validacao", "alert('Campo Nome Obrigatório')", true);
                    txtNome.Focus();
                }
                else
                {
                    MarcasService servico = new MarcasService();
                    servico.alterarMarca(Int32.Parse(txtCodigo.Text), txtNome.Text);
                    carregarMarcas();
                    limpar();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Sucesso", "alert('Alteração realizada com sucesso')", true);

                }
            }

       


        }

        private void limpar()
        {
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtNome.Text = "";
            btnSalvar.CommandName = "I";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           if (e.CommandName.CompareTo("Editar") == 0)
            {
                int i = int.Parse(e.CommandArgument.ToString());
                TableCell cellcod = GridView1.Rows[i].Cells[0];
                TableCell cellnome = GridView1.Rows[i].Cells[1];
                txtCodigo.Text = cellcod.Text;
                txtNome.Text = cellnome.Text;
                btnSalvar.CommandName = "A";
                txtCodigo.Enabled = false;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
            excluirMarca(int.Parse(cell.Text));
            carregarMarcas();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            limpar();
        }
    }
}