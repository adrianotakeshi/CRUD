using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Services;

namespace TesteAccessBrasil
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcasService service = new MarcasService();
                ddlMarca.DataSource = service.listarMarcas();
                ddlMarca.DataTextField = "Nome";
                ddlMarca.DataValueField = "Codigo";
                ddlMarca.DataBind();
                ddlMarca.Items.Insert(0, new ListItem("Selecione uma marca"));  
                btnSalvar.CommandName = "I";
            }

            carregarCarros();
            
        }

        private void carregarCarros()
        {
            CarrosService service2 = new CarrosService();
            gridCarros.DataSource = service2.listarCarros();
            gridCarros.DataBind();
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
                    if (ddlMarca.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Validacao", "alert('Campo Marca Obrigatório')", true);
                        ddlMarca.Focus();
                    }
                    else
                    {
                        if (txtModelo.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Validacao", "alert('Campo Modelo Obrigatório')", true);
                            txtModelo.Focus();
                        }
                        else
                        {
                            if (txtAno.Text == "")
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Validacao", "alert('Campo Ano Obrigatório')", true);
                                txtAno.Focus();
                            }
                            else
                            {
                                CarrosService service = new CarrosService();
                                service.CadastroCarro(int.Parse(txtCodigo.Text), int.Parse(ddlMarca.SelectedItem.Value), txtCor.Text,
                                    int.Parse(txtAno.Text), txtModelo.Text);
                                limpar();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Sucesso", "alert('Cadastro realizado com sucesso')", true);

                            }
                        }
                    }
                }
                
            }
            else
            {
                if (ddlMarca.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Validacao", "alert('Campo Marca Obrigatório')", true);
                    ddlMarca.Focus();
                }
                else
                {
                    if (txtModelo.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Validacao", "alert('Campo Modelo Obrigatório')", true);
                        txtModelo.Focus();
                    }
                    else
                    {
                        if (txtAno.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Validacao", "alert('Campo Ano Obrigatório')", true);
                            txtAno.Focus();
                        }
                        else
                        {
                            CarrosService service = new CarrosService();
                            service.alterarCarro(int.Parse(txtCodigo.Text), int.Parse(ddlMarca.SelectedItem.Value), txtCor.Text,
                                int.Parse(txtAno.Text), txtModelo.Text);
                            limpar();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Sucesso", "alert('Alteração realizada com sucesso')", true);

                        }
                    }
                }
            }

            carregarCarros();
          

        }

        private void limpar()
        {
            txtCodigo.Text = "";
            txtCor.Text = "";
            txtModelo.Text = "";
            txtAno.Text = "";
            ddlMarca.SelectedIndex = 0;
            txtCodigo.Enabled = true;
            btnSalvar.CommandName = "I";
            ddlMarca.SelectedIndex = 0;
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void excluirCarro(int cod)
        {
            CarrosService servico = new CarrosService();
            servico.excluirCarros(cod);
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[3].Text;
                foreach (Button button in e.Row.Cells[7].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Deseja excluir " + item + "?')){ return false; };";
                    }
                }
            }
        }


        protected void gridCarros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableCell cell = gridCarros.Rows[e.RowIndex].Cells[0];
            excluirCarro(int.Parse(cell.Text));
            carregarCarros();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Sucesso", "alert('Exclusão realizada com sucesso')", true);

        }

        protected void gridCarros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.CompareTo("Editar") == 0)
            {
                int i = int.Parse(e.CommandArgument.ToString());
                TableCell cellcod = gridCarros.Rows[i].Cells[0];
                TableCell cellcodmarca = gridCarros.Rows[i].Cells[1];
                TableCell cellmarca = gridCarros.Rows[i].Cells[2];
                TableCell cellmodelo = gridCarros.Rows[i].Cells[3];
                TableCell cellano = gridCarros.Rows[i].Cells[4];
                TableCell cellcor = gridCarros.Rows[i].Cells[5];
                txtCodigo.Text = cellcod.Text;
                txtModelo.Text = cellmodelo.Text;
                txtAno.Text = cellano.Text;
                txtCor.Text = cellcor.Text;
                ddlMarca.SelectedValue = cellcodmarca.Text;
                btnSalvar.CommandName = "A";
                txtCodigo.Enabled = false;
            }
        }
    }
}