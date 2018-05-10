using System;
using System.Data;
using System.Web.UI;
using Modelo;
using LOGAN.Prometheus.Pagina;
using System.Web.UI.WebControls;


public partial class page_frequencia_configuracao : BaseAutPage
{
    #region Eventos

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlMes.SelectedValue = DateTime.Now.ToString("MM");
            txtAno.Text = DateTime.Now.Year.ToString();
            txtPeso.Text = "1";
            CarregaGrid(MontaQuery());
        }
    }
    
    protected void btnNovo_Click(object sender, EventArgs e)
    {
        divConsulta.Visible = false;
        divCadastro.Visible = true;
    }

    protected void btnSalvarNota_Click(object sender, EventArgs e)
    {
        if ((txtObservacao.Text != "") && (txtPeso.Text != ""))
        {
            FrequenciaEntidade.dia = DateTime.Parse(Calendar1.SelectedDate.Date.ToShortDateString());
            FrequenciaEntidade.observacao = txtObservacao.Text.ToUpper();
            FrequenciaEntidade.tipo = int.Parse(ddlTipo.SelectedValue);
            FrequenciaEntidade.peso = int.Parse(txtPeso.Text);

            if (hfCodigo.Value == "")
            {
                string pRetorno = FrequenciaModelo.Include();

                if (pRetorno == "")
                    exibirMensagem("Ok", "Registro incluido com sucesso.", "ok");
                else
                    exibirMensagem("erro", pRetorno, "erro");
            }
            else
            {
                FrequenciaEntidade.codigo = decimal.Parse(hfCodigo.Value);
                FrequenciaEntidade.dia = DateTime.Parse(Calendar1.SelectedDate.Date.ToShortDateString());
                FrequenciaEntidade.observacao = txtObservacao.Text.ToUpper();
                FrequenciaEntidade.tipo = int.Parse(ddlTipo.SelectedValue);
                FrequenciaEntidade.peso = int.Parse(txtPeso.Text);

                string pRetorno = FrequenciaModelo.Update();

                if (pRetorno == "")
                    exibirMensagem("Ok", "Registro atualizado com sucesso.", "ok");
                else
                    exibirMensagem("erro", pRetorno, "erro");
            }
        }
        else
            exibirMensagem("Aviso", "Preencha todos os campos!", "alerta");
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        try
        {
            DataTable lTableData = (DataTable)ViewState["VW_FREQUENCIA"];

            if (lTableData != null)
            {
                for (int i = 0; i < lTableData.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(lTableData.Rows[i]["DIA"].ToString()) == e.Day.Date)
                    {
                        if (lTableData.Rows[i]["TIPOPARAM"].ToString() == "1")
                            e.Cell.BackColor = System.Drawing.Color.FromName("#95FF95");
                        else if (lTableData.Rows[i]["TIPOPARAM"].ToString() == "2")
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
        CarregaInfo(Calendar1.SelectedDate.Date.ToShortDateString());
    }

    protected void gvFrequencia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                int iIndice = (((GridView)sender).PageIndex * ((GridView)sender).PageSize) + int.Parse(e.CommandArgument.ToString());
                DataTable lTabela = (DataTable)ViewState["VW_FREQUENCIA"];

                if (e.CommandName == "Visualizar")
                {
                    CarregaInfo(lTabela.Rows[iIndice]["DIA"].ToString());
                }

                if (e.CommandName == "Excluir")
                {
                    FrequenciaEntidade.codigo = decimal.Parse(lTabela.Rows[iIndice]["CODIGO"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NomedaJanela", "$(function(){$('#modalConfirma').modal('show');});", true);
                }
            }

        }
        catch (Exception err)
        {
        }
    }    

    protected void btnSim_Click(object sender, EventArgs e)
    {
        string pRetorno = FrequenciaModelo.Delete();

        if (pRetorno == "")
        {
            CarregaGrid(MontaQuery());
            exibirMensagem("Ok", "Registro excluído com sucesso.", "ok");
        }
        else
            exibirMensagem("erro", pRetorno, "erro");

    }

    protected void btnNao_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NomedaJanela", "$(function(){$('#modalConfirma').modal('close');});", true);
    }

    #endregion

    #region Metodos

    private void CarregaGrid(string pQuery)
    {
        ViewState["VW_FREQUENCIA"] = FrequenciaModelo.FrequenciaListaParametro(pQuery);

        gvFrequencia.DataSource = ViewState["VW_FREQUENCIA"];
        gvFrequencia.DataBind();
    }

    private string MontaQuery()
    {
        string pQuery = "";

        if (txtData.Text != "")
            pQuery += "AND DIA = '"+ txtData.Text + "' ";

        if(ddlMes.SelectedValue != "00")
            pQuery += "AND TO_CHAR(DIA, 'MM') = '"+ ddlMes.SelectedValue + "'";

        if(txtAno.Text != "")
            pQuery += "AND TO_CHAR(DIA, 'YYYY') = '" + txtAno.Text + "' ";

        return pQuery;
    }

    private void CarregaInfo(string pData)
    {
        DataTable lTableData = FrequenciaModelo.FrequenciaLista(DateTime.Parse(pData));

        if (lTableData.Rows.Count > 0)
        {
            txtObservacao.Text = lTableData.Rows[0]["OBSERVACAO"].ToString();
            ddlTipo.SelectedValue = lTableData.Rows[0]["TIPO"].ToString();
            txtPeso.Text = lTableData.Rows[0]["PESO"].ToString();
            hfCodigo.Value = lTableData.Rows[0]["CODIGO"].ToString();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NomedaJanela", "$(function(){$('#myModalFrequencia').modal('show');});", true);
        }
        else
        {
            txtObservacao.Text = "";
            txtPeso.Text = "1";
            hfCodigo.Value = "";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NomedaJanela", "$(function(){$('#myModalFrequencia').modal('show');});", true);
        }
    }

    #endregion    
}