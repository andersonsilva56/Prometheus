using System;
using System.Web.UI.WebControls;
using Modelo;
using System.Data;
using LOGAN.Prometheus.Pagina;

public partial class page_frequencia_Relatorio : BaseAutPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlMes.SelectedValue = DateTime.Now.ToString("MM");
            txtAno.Text = DateTime.Now.Year.ToString();
            CarregaData("WHERE TO_CHAR(DIA, 'MM') = '" + ddlMes.SelectedValue + "' AND TO_CHAR(DIA, 'YYYY') = '" + txtAno.Text + "' AND STATUS = 'A'");
        }
    }

    private string MontaQuery()
    {
        string pQuery = "";


        
        return pQuery;
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
        }
        else
        {
            ddlDia.Items.Clear();            
        }
    }

    protected void ddlDia_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        string pQuery = "WHERE TO_CHAR(DIA, 'MM') = '" + ddlMes.SelectedValue + "' AND TO_CHAR(DIA, 'YYYY') = '" + txtAno.Text + "' AND STATUS = 'A'";
        CarregaData(pQuery);
    }
}