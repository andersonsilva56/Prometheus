using System;
using System.Web.UI.WebControls;
using Modelo;
using System.Data;
using LOGAN.Prometheus.Pagina;

public partial class page_frequencia_justificados : BaseAutPage
{
    #region Eventos

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlMes.SelectedValue = DateTime.Now.ToString("MM");
            txtAno.Text = DateTime.Now.Year.ToString();
            CarregaData("WHERE TO_CHAR(DIA, 'MM') = '" + ddlMes.SelectedValue + "' AND TO_CHAR(DIA, 'YYYY') = '" + txtAno.Text + "' AND STATUS = 'A'");
            CarregaListaAtletaStatus();
            CarregaListaPosicao();                
        }
    }

    protected void btnLimparJus_Click(object sender, EventArgs e)
    {
        StatusCheckJust(false);
    }

    protected void btnTodosJus_Click(object sender, EventArgs e)
    {
        StatusCheckJust(true);
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        CarregaGridJustificativas(MontaQuery());
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string pRetorno = "";

        try
        {
            foreach (GridViewRow row in gvJustificados.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("cbRow");

                if (cb != null && cb.Checked)
                {
                    TextBox txtJustificativa = (TextBox)row.FindControl("txtJustificativa");

                    AtletaFrequenciaEntidade.codigo_atleta = decimal.Parse(row.Cells[1].Text);
                    AtletaFrequenciaEntidade.codigo_frequencia = decimal.Parse(ddlDia.SelectedValue);
                    AtletaFrequenciaEntidade.tipo = 2;
                    AtletaFrequenciaEntidade.observacao = txtJustificativa.Text.ToUpper();

                    pRetorno = AtletaFrequenciaModelo.Include();
                }
            }

            exibirMensagem("Ok", "Registro feito com sucesso", "ok");
            CarregaGridJustificativas("");
        }
        catch (Exception)
        {
            exibirMensagem("Erro", pRetorno, "erro");
        }
    }

    protected void ddlDia_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregaGridJustificativas("");
    }

    protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        string pQuery = "WHERE TO_CHAR(DIA, 'MM') = '" + ddlMes.SelectedValue + "' AND TO_CHAR(DIA, 'YYYY') = '" + txtAno.Text + "' AND STATUS = 'A'";
        CarregaData(pQuery);
    }

    #endregion

    #region Metodos

    private void CarregaGridJustificativas(string pQuery)
    {
        AtletaFrequenciaEntidade.codigo = decimal.Parse(ddlDia.SelectedValue);

        ViewState["VW_JUSTIFICADOS"] = AtletaFrequenciaModelo.AtletaFrequenciaPresenca(pQuery);

        gvJustificados.DataSource = ViewState["VW_JUSTIFICADOS"];
        gvJustificados.DataBind();
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

    private void StatusCheckJust(bool status)
    {
        foreach (GridViewRow row in gvJustificados.Rows)
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

    private void CarregaData(string pQuery)
    {
        DataTable lTabela = FrequenciaModelo.FrequenciaDataJustificativa(pQuery);

        if (lTabela.Rows.Count > 0)
        {
            ddlDia.DataSource = lTabela;
            ddlDia.DataTextField = "DIA";
            ddlDia.DataValueField = "CODIGO";
            ddlDia.DataBind();

            CarregaGridJustificativas("");
        }
        else
        {
            ddlDia.Items.Clear();

            ViewState["VW_JUSTIFICADOS"] = null;
            gvJustificados.DataSource = ViewState["VW_JUSTIFICADOS"];
            gvJustificados.DataBind();
        }
    }

    #endregion
}