using System;
using System.Data;
using System.Web.UI;
using Modelo;
using LOGAN.Prometheus.Pagina;
using System.Web.UI.WebControls;

public partial class page_administracao_comissao : BaseAutPage
{
    #region Eventos

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            CarregaGrid();            
        }
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        divConsulta.Visible = false;
        divCadastro.Visible = true;
    }

    #endregion

    #region Metodos Privados

    private void CarregaGrid()
    {
        ViewState["VW_COMISSAO"] = ComissaoTecnicaModelo.CarregaDadosComissao();

        gvComissao.DataSource = ViewState["VW_COMISSAO"];
        gvComissao.DataBind();
    }

    private void CarregaDadosComissao(decimal pCodigo)
    {
        DataSet lTabela = ComissaoTecnicaModelo.CarregaDadosComissao(pCodigo);

        if(lTabela.Tables[0].Rows.Count > 0)
        {
            ImgFoto.ImageUrl = "../administracao/foto.aspx?p=" + pCodigo + "";

            hfCodigoPessoa.Value = lTabela.Tables[0].Rows[0]["CODIGO"].ToString();
            hfCodigoComissao.Value = lTabela.Tables[0].Rows[0]["CODIGO_ATLETA"].ToString();

            txtNome.Text = lTabela.Tables[0].Rows[0]["NOME"].ToString();
            txtNascimento.Text = lTabela.Tables[0].Rows[0]["NASCIMENTO"].ToString();
            txtProfissao.Text = lTabela.Tables[0].Rows[0]["PROFISSAO"].ToString();
            txtEmail.Text = lTabela.Tables[0].Rows[0]["EMAIL"].ToString();
            txtTelefone.Text = lTabela.Tables[0].Rows[0]["TELEFONE"].ToString();
            ddlEscolaridade.SelectedValue = lTabela.Tables[0].Rows[0]["ESCOLARIDADE"].ToString();
            txtCpf.Text = lTabela.Tables[0].Rows[0]["CPF"].ToString();
            txtRg.Text = lTabela.Tables[0].Rows[0]["RG"].ToString();
            TxtCelular.Text = lTabela.Tables[0].Rows[0]["CELULAR"].ToString();
            txtPlanoSaude.Text = lTabela.Tables[0].Rows[0]["PLANOSAUDE"].ToString();
            txtContato.Text = lTabela.Tables[0].Rows[0]["CONTATO"].ToString();
            
            divConsulta.Visible = false;
            divCadastro.Visible = true;
        }
    }

    private void Include()
    {
        decimal pRetorno = 0;

        try
        {
            if (ValidaDados() == "")
            {
                PessoaEntidade.codigo_tipopessoa = decimal.Parse("2");
                PessoaEntidade.nome = txtNome.Text.ToUpper();
                PessoaEntidade.nacimento = DateTime.Parse(txtNascimento.Text);
                PessoaEntidade.foto = fuImagem.FileBytes;
                PessoaEntidade.email = txtEmail.Text;
                PessoaEntidade.cpf = txtCpf.Text;
                PessoaEntidade.rg = txtRg.Text;
                PessoaEntidade.profissao = txtProfissao.Text.ToUpper();
                PessoaEntidade.escolaridade = ddlEscolaridade.SelectedItem.Text;
                PessoaEntidade.planosaude = txtPlanoSaude.Text.ToUpper();
                PessoaEntidade.contato = txtContato.Text.ToUpper();
                PessoaEntidade.telefone = txtTelefone.Text;
                PessoaEntidade.celular = TxtCelular.Text;

                pRetorno = PessoaModelo.Include();

                if (pRetorno != 0)
                {                    
                    LimparCampos();
                    exibirMensagem("Ok", "Cadastro efetuado com sucesso", "ok");
                }
            }
            else
                exibirMensagem("Aviso", ValidaDados(), "alerta");
        }
        catch (Exception err)
        {
            exibirMensagem("Erro", err.Message.ToString(), "erro");
        }
    }

    private void Update()
    {
        string pRetorno = "";
        
        try
        {
            PessoaEntidade.codigo = decimal.Parse(hfCodigoPessoa.Value);
            PessoaEntidade.codigo_tipopessoa = decimal.Parse("2");
            PessoaEntidade.nome = txtNome.Text.ToUpper();
            PessoaEntidade.nacimento = DateTime.Parse(txtNascimento.Text);
            if (fuImagem.FileName != "")
                PessoaEntidade.foto = fuImagem.FileBytes;
            else
            {
                PessoaEntidade.codigo = decimal.Parse(hfCodigoPessoa.Value);
                DataSet lFoto = PessoaModelo.Foto();
                foreach (DataRow ors in lFoto.Tables[0].Rows)
                {
                    PessoaEntidade.foto = (byte[])ors[0];
                }
            }
                
            PessoaEntidade.email = txtEmail.Text;
            PessoaEntidade.cpf = txtCpf.Text;
            PessoaEntidade.rg = txtRg.Text;
            PessoaEntidade.profissao = txtProfissao.Text.ToUpper();
            PessoaEntidade.escolaridade = ddlEscolaridade.SelectedItem.Text;
            PessoaEntidade.planosaude = txtPlanoSaude.Text.ToUpper();
            PessoaEntidade.contato = txtContato.Text.ToUpper();
            PessoaEntidade.telefone = txtTelefone.Text;
            PessoaEntidade.celular = TxtCelular.Text;

            pRetorno = PessoaModelo.Update();

            if (pRetorno == "")
            {
                exibirMensagem("Ok", "Cadastro atualizado com sucesso", "ok");
                divConsulta.Visible = true;
                divCadastro.Visible = false;
                CarregaGrid();
            }
        }
        catch (Exception err)
        {
            exibirMensagem("Erro", err.Message.ToString(), "erro");
        }
    }    

    private string ValidaDados()
    {
        string lMensagem = "";

        if (txtNome.Text == "")
        {
            lMensagem += " - Informe o nome do atleta. <br>";
        }

        if (txtNascimento.Text == "")
        {
            lMensagem += " - Informe a data de nascimento dp atleta. <br>";
        }

        //if (txtObservacao.Text == "")
        //{
        //    lMensagem += " - Informe a observação para o atendimento. <br>";
        //}

        return lMensagem;
    }

    private void LimparCampos()
    {
        txtNome.Text = "";
        txtNascimento.Text = "";
        txtProfissao.Text = "";
        txtEmail.Text = "";
        txtTelefone.Text = "";
        txtRg.Text = "";
        txtCpf.Text = "";
        TxtCelular.Text = "";
        txtPlanoSaude.Text = "";
        txtContato.Text = "";
    }

    #endregion

    #region Eventos

    protected void btnSalvar_Click(object sender, EventArgs e)
    {

        if (hfCodigoPessoa.Value == "")
        {
            if (fuImagem.FileName != "")
                Include();
        }
        else
        {
            Update();
        }
    }

    protected void gvComissao_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                int i = (((GridView)sender).PageIndex * ((GridView)sender).PageSize) + int.Parse(e.CommandArgument.ToString());
                DataSet lTabela = (DataSet)ViewState["VW_ATLETA"];

                switch (e.CommandName)
                {
                    case "Visualizar":
                        CarregaDadosComissao(decimal.Parse(lTabela.Tables[0].Rows[i]["CODIGO"].ToString()));
                        break;
                }
            }
        }
        catch (Exception err)
        {
            avisocadastro.Visible = true;
            lblMotivo.InnerText = err.Message;
        }
    }

    #endregion
}