using System;
using System.Data;
using System.Web.UI;
using Modelo;
using LOGAN.Prometheus.Pagina;
using System.Web.UI.WebControls;

public partial class page_administracao_atletas : BaseAutPage
{    
    #region Metodos Privados

    private void CarregaListaPosicao()
    {
        ddlPosicao.DataSource = PosicaoModelo.PossicaoLista();
        ddlPosicao.DataValueField = "CODIGO";
        ddlPosicao.DataTextField = "DESCRICAO";
        ddlPosicao.DataBind();

        ddlPesquisaPosicao.DataSource = PosicaoModelo.PossicaoLista();
        ddlPesquisaPosicao.DataValueField = "CODIGO";
        ddlPesquisaPosicao.DataTextField = "DESCRICAO";
        ddlPesquisaPosicao.DataBind();
    }   

    private void CarregaListaAtletaStatus()
    {
        ddlAtletaStatus.DataSource = AtletaStatusModelo.AtletaStatusLista();
        ddlAtletaStatus.DataValueField = "CODIGO";
        ddlAtletaStatus.DataTextField = "DESCRICAO";
        ddlAtletaStatus.DataBind();

        ddlPesquisaStatus.DataSource = AtletaStatusModelo.AtletaStatusLista();
        ddlPesquisaStatus.DataValueField = "CODIGO";
        ddlPesquisaStatus.DataTextField = "DESCRICAO";
        ddlPesquisaStatus.DataBind();
    }

    private void CarregaListaNumeracao()
    {
        ddlNumeracao.DataSource = NumeracaoModelo.NumeracaoLista();
        ddlNumeracao.DataTextField = "NUMEROCONT";
        ddlNumeracao.DataValueField = "NUMERO";
        ddlNumeracao.DataBind();
    }

    private void CarregaGrid()
    {
        ViewState["VW_ATLETA"] = PessoaModelo.CarregaDadosPessoaAtleta();

        gvAtleta.DataSource = ViewState["VW_ATLETA"];
        gvAtleta.DataBind();
    }

    private void CarregaDadosAtleta(decimal pCodigo)
    {
        DataSet lTabela = PessoaModelo.CarregaDadosPessoaAtleta(pCodigo);

        if(lTabela.Tables[0].Rows.Count > 0)
        {
            ImgFoto.ImageUrl = "../administracao/foto.aspx?p=" + pCodigo + "";

            hfCodigoPessoa.Value = lTabela.Tables[0].Rows[0]["CODIGO"].ToString();
            hfCodigoAtleta.Value = lTabela.Tables[0].Rows[0]["CODIGO_ATLETA"].ToString();

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

            if (hfCodigoAtleta.Value != "")
            {
                DataSet lTabelaAtleta = AtletaModelo.CarregaDadosAtleta(decimal.Parse(hfCodigoAtleta.Value));

                if (lTabelaAtleta.Tables[0].Rows.Count > 0)
                {
                    ddlAtletaStatus.SelectedValue = lTabelaAtleta.Tables[0].Rows[0]["ATLETASTATUS"].ToString();
                    ddlPosicao.SelectedValue = lTabelaAtleta.Tables[0].Rows[0]["POSICAO"].ToString();

                    NumeracaoIncluir.Visible = false;
                    NumeracaoVisualizar.Visible = true;

                    txtNumeracao.Text = lTabelaAtleta.Tables[0].Rows[0]["NUMERO"].ToString() + "|" + lTabelaAtleta.Tables[0].Rows[0]["CONTADOR"].ToString();
                    hfNumeracao.Value = lTabelaAtleta.Tables[0].Rows[0]["NUMERO"].ToString();
                    hfContador.Value = lTabelaAtleta.Tables[0].Rows[0]["CONTADOR"].ToString();

                    txtAltura.Text = lTabelaAtleta.Tables[0].Rows[0]["ALTURA"].ToString();
                    txtPeso.Text = lTabelaAtleta.Tables[0].Rows[0]["PESO"].ToString();
                    txtTamUniforme.Text = lTabelaAtleta.Tables[0].Rows[0]["TAMANHOUNIFORME"].ToString();
                }
            }

            divConsulta.Visible = false;
            divCadastro.Visible = true;
        }
    }

    private void Include()
    {
        decimal pRetorno = 0;

        try
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
                  if (cbDadosAtleta.Checked)
                  {
                      AtletaEntidade.codigo_pessoa = pRetorno;
                      AtletaEntidade.codigo_posicao = decimal.Parse(ddlPosicao.SelectedValue);
                      AtletaEntidade.codigo_atletastatus = decimal.Parse(ddlAtletaStatus.SelectedValue);
                      AtletaEntidade.altura = txtAltura.Text;
                      AtletaEntidade.peso = txtPeso.Text;
                      AtletaEntidade.apelido = txtApelido.Text;
                      AtletaEntidade.numeracao = int.Parse(ddlNumeracao.SelectedValue);
                      UpdateNumeracaoMais(ddlNumeracao.SelectedItem.Text, decimal.Parse(ddlNumeracao.SelectedItem.Text));
                      AtletaEntidade.tamanhouniforme = txtTamUniforme.Text;

                      pRetorno = AtletaModelo.Include();
                  }

                  LimparCampos();
                  exibirMensagem("Ok", "Cadastro efetuado com sucesso", "ok");
              }
              else
                exibirMensagem("Erro", Conexao.excecao.Replace("@", "").Replace("'", ""), "erro");

        }
        catch (Exception err)
        {
            exibirMensagem("Erro", err.Message.ToString(), "erro");
        }
    }

    private void Update()
    {
        string pRetorno = "";
        decimal pRetornoInc = 0;

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
                if (hfCodigoAtleta.Value != "")
                {
                    AtletaEntidade.codigo = decimal.Parse(hfCodigoAtleta.Value);
                    AtletaEntidade.codigo_posicao = decimal.Parse(ddlPosicao.SelectedValue);
                    AtletaEntidade.codigo_atletastatus = decimal.Parse(ddlAtletaStatus.SelectedValue);
                    AtletaEntidade.altura = txtAltura.Text;
                    AtletaEntidade.peso = txtPeso.Text;
                    AtletaEntidade.apelido = txtApelido.Text;
                    if ((ddlNumeracao.SelectedValue == hfNumeracao.Value) && (int.Parse(hfContador.Value) < 1))
                        AtletaEntidade.numeracao = int.Parse(hfNumeracao.Value);
                    else
                    {
                        AtletaEntidade.numeracao = int.Parse(ddlNumeracao.SelectedValue);
                        UpdateNumeracaoMenos(int.Parse(hfContador.Value), decimal.Parse(hfNumeracao.Value));
                        UpdateNumeracaoMais(ddlNumeracao.SelectedItem.Text, decimal.Parse(ddlNumeracao.SelectedValue));
                    }
                    AtletaEntidade.tamanhouniforme = txtTamUniforme.Text;

                    pRetorno = AtletaModelo.Update();
                }
                else
                {
                    AtletaEntidade.codigo_pessoa = decimal.Parse(hfCodigoPessoa.Value);
                    AtletaEntidade.codigo_posicao = decimal.Parse(ddlPosicao.SelectedValue);
                    AtletaEntidade.codigo_atletastatus = decimal.Parse(ddlAtletaStatus.SelectedValue);
                    AtletaEntidade.altura = txtAltura.Text;
                    AtletaEntidade.peso = txtPeso.Text;
                    AtletaEntidade.apelido = txtApelido.Text;
                    AtletaEntidade.numeracao = int.Parse(ddlNumeracao.SelectedValue);
                    UpdateNumeracaoMais(ddlNumeracao.SelectedItem.Text, decimal.Parse(ddlNumeracao.SelectedValue));
                    AtletaEntidade.tamanhouniforme = txtTamUniforme.Text;

                    pRetornoInc = AtletaModelo.Include();
                }
            }

            exibirMensagem("Ok", "Cadastro atualizado com sucesso", "ok");
            divConsulta.Visible = true;
            divCadastro.Visible = false;
            CarregaGrid();
        }
        catch (Exception err)
        {
            exibirMensagem("Erro", err.Message.ToString(), "erro");
        }
    }

    private void UpdateNumeracaoMais(string pContador, decimal pNumero)
    {
        int pContadorUp = 0;
        string[] pCont = pContador.Split('|');

        pContadorUp = int.Parse(pCont[1]) + 1;
        string pRetorno = NumeracaoModelo.Update(pContadorUp, pNumero);
    }

    private void UpdateNumeracaoMenos(int pContador, decimal pNumero)
    {
        pContador -=  1;
        string pRetorno = NumeracaoModelo.Update(pContador, pNumero);
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
            lMensagem += " - Informe a data de nascimento do atleta. <br>";
        }
               
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
        txtAltura.Text = "";
        txtPeso.Text = "";
        txtTamUniforme.Text = "";
    }

    #endregion

    #region Eventos

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cbDadosAtleta.Checked = true;
            CarregaGrid();
            CarregaListaPosicao();
            CarregaListaNumeracao();
            CarregaListaAtletaStatus();
        }
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        divConsulta.Visible = false;
        divCadastro.Visible = true;
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {

        if (hfCodigoPessoa.Value == "")
        {
            if (ValidaDados() == "")
                Include();
            else
                exibirMensagem("Alerta", ValidaDados(), "alerta");
        }
        else
        {
            Update();
        }
    }

    protected void gvAtleta_RowCommand(object sender, GridViewCommandEventArgs e)
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
                        CarregaDadosAtleta(decimal.Parse(lTabela.Tables[0].Rows[i]["CODIGO"].ToString()));
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

    protected void cbDadosAtleta_CheckedChanged(object sender, EventArgs e)
    {
        if (cbDadosAtleta.Checked)
            divCadastroAtleta.Visible = true;
        else
            divCadastroAtleta.Visible = false;
    }

    protected void cbNumeracao_CheckedChanged(object sender, EventArgs e)
    {
        if (cbNumeracao.Checked)
        {
            NumeracaoIncluir.Visible = true;
            NumeracaoVisualizar.Visible = false;
        }
        else
        {
            NumeracaoIncluir.Visible = false;
            NumeracaoVisualizar.Visible = true;
        }
    }

    #endregion    
}