using System;
using System.Data;
using System.Web.UI.WebControls;
using Modelo;
using LOGAN.Prometheus.Pagina;

public partial class page_frequencia_presenca : BaseAutPage
{
    #region Eventos

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (DiaCheck())
            {
                CarregaGridFrequencia("");
                CarregaListaAtletaStatus();
                CarregaListaPosicao();
                divListaFrequencia.Visible = true;
            }
            else
                avisoLista.Visible = true;
        }
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        CarregaGridFrequencia(MontaQuery());
    }

    protected void btnLimpar_Click(object sender, EventArgs e)
    {
        StatusCheck(false);
    }

    protected void btnSelecionar_Click(object sender, EventArgs e)
    {
        StatusCheck(true);
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string pRetorno = "";

        try
        {
            foreach (GridViewRow row in gvAtleta.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("cbRow");

                if (cb != null && cb.Checked)
                {
                    AtletaFrequenciaEntidade.codigo_atleta = decimal.Parse(row.Cells[1].Text);
                    AtletaFrequenciaEntidade.codigo_frequencia = decimal.Parse(hfCodigo.Value);
                    AtletaFrequenciaEntidade.tipo = 1;
                    AtletaFrequenciaEntidade.observacao = "OK";

                    pRetorno = AtletaFrequenciaModelo.Include();
                }
            }

            exibirMensagem("Ok", "Registro feito com sucesso", "ok");
            CarregaGridFrequencia("");
        }
        catch (Exception)
        {
            exibirMensagem("Erro", pRetorno, "erro");
        }        
    }

    #endregion

    #region Metodos

    private void CarregaGridFrequencia(string pQuery)
    {
        AtletaFrequenciaEntidade.codigo = decimal.Parse(hfCodigo.Value);

        ViewState["VW_ATLETA"] = AtletaFrequenciaModelo.AtletaFrequenciaPresenca(pQuery);

        gvAtleta.DataSource = ViewState["VW_ATLETA"];
        gvAtleta.DataBind();        
    }
    
    private string MontaQuery()
    {
        string pQuery = "";

        if (TxtNomePesquisa.Text != "")
            pQuery += "AND PES.NOME LIKE '" + TxtNomePesquisa.Text.ToUpper() + "%'";

        if (ddlPesquisaPosicao.SelectedValue != "0")
            pQuery += "AND ATL.CODIGO_POSICAO = " + ddlPesquisaPosicao.SelectedValue + "";

        if (ddlPesquisaStatus.SelectedValue != "0")
            pQuery += "AND ATL.CODIGO_ATLETASTATUS = " + ddlPesquisaStatus.SelectedValue + "";

        return pQuery;
    }

    private void StatusCheck(bool status)
    {
        foreach (GridViewRow row in gvAtleta.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("cbRow");
            if (cb != null)
                cb.Checked = status;
        }
    }
    
    private void CarregaListaPosicao()
    {        
        ddlPesquisaPosicao.DataSource = PosicaoModelo.PossicaoLista();
        ddlPesquisaPosicao.DataValueField = "CODIGO";
        ddlPesquisaPosicao.DataTextField = "DESCRICAO";
        ddlPesquisaPosicao.DataBind();

        ddlPesquisaPosicao.Items.Insert(0, new ListItem("--Selecione Aqui--", "0"));
    }

    private void CarregaListaAtletaStatus()
    {
        ddlPesquisaStatus.DataSource = AtletaStatusModelo.AtletaStatusLista();
        ddlPesquisaStatus.DataValueField = "CODIGO";
        ddlPesquisaStatus.DataTextField = "DESCRICAO";
        ddlPesquisaStatus.DataBind();

        ddlPesquisaStatus.Items.Insert(0, new ListItem("--Selecione Aqui--", "0"));
    }

    private bool DiaCheck()
    {
        string pData = DateTime.Now.Date.ToShortDateString();

        DataTable lTabela = FrequenciaModelo.FrequenciaLista(DateTime.Parse(pData));

        if (lTabela.Rows.Count > 0)
        {
            hfCodigo.Value = lTabela.Rows[0]["CODIGO"].ToString();
            return true;
        }
        else
            return false;
    }

    #endregion        
}