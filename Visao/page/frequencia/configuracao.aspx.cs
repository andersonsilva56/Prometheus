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

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        divConsulta.Visible = false;
        divCadastro.Visible = true;
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        try
        {
            DataSet lTableDataProgressao = (DataSet)ViewState["WRK_DATAPROGRESSAO"];

            if (lTableDataProgressao != null)
            {
                for (int i = 0; i < lTableDataProgressao.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToDateTime(lTableDataProgressao.Tables[0].Rows[i]["DIA"].ToString()) == e.Day.Date)
                    {
                        if (lTableDataProgressao.Tables[0].Rows[i]["TIPO"].ToString() == "1")
                            e.Cell.BackColor = System.Drawing.Color.FromName("#95FF95");
                        else if (lTableDataProgressao.Tables[0].Rows[i]["TIPO"].ToString() == "2")
                            e.Cell.BackColor = System.Drawing.Color.FromName("#77ADFF");                        
                    }
                }
            }
        }
        catch (Exception err)
        {
            exibirMensagem("Erro", err.Message.ToString(), "erro");
        }
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        //if (txtDataPesquisa.Text != "")
        //{
        //    pDataMarcada = txtDataPesquisa.Text;
        //    Calendar1.SelectedDate = Convert.ToDateTime(txtDataPesquisa.Text);
        //    Calendar1.TodaysDate = Convert.ToDateTime(txtDataPesquisa.Text);
        //    txtDataPesquisa.Text = "";
        //}
        //else
        //{
        //    pDataMarcada = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        //    Calendar1.TodaysDate = Convert.ToDateTime(pDataMarcada);
        //}

        //CarregaDataProgressao();
        //CarregaInfoPanel(pDataMarcada);
        //LoadInfoProgressao(pDataMarcada);
        //LoadInfoNotas(pDataMarcada);
    }
}