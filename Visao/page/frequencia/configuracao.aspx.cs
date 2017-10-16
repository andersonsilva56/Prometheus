using System;
using System.Data;
using System.Web.UI;
using Modelo;
using LOGAN.Prometheus.Pagina;
using System.Web.UI.WebControls;


public partial class page_frequencia_configuracao : BaseAutPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlMes.SelectedValue = DateTime.Now.ToString("MM");
            txtAno.Text = DateTime.Now.Year.ToString();
        }
    }
}