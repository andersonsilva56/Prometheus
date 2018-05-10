using System;
using System.Data;
using System.Configuration;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;


namespace APB.Mercury.WebInterface.SCPWeb.Www.Pages
{
    public partial class Aut_Reports_LoadReport : System.Web.UI.Page
    {
        #region Private Methods

        ReportDocument myReportDocument = new ReportDocument();

        private void loadReport()
        {
            string lLocalRptFiles;
            DataTable lData;
            
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue dctField = new ParameterDiscreteValue();

            if (Session["SES_RELATORIO"] != null)
            {
                lData = ((DataTable)Session["SES_RELATORIO"]);

                if (lData.Rows.Count > 0)
                {
                    lLocalRptFiles = ConfigurationManager.AppSettings["SourceRPTFiles"];

                    DataTable lDataTable = lData;

                    string lPathReport = @"" + lLocalRptFiles + hidReportName.Value.ToString();

                    myReportDocument.Load(lPathReport);
                    myReportDocument.Database.Tables[0].SetDataSource(lDataTable);
                    myReportDocument.SetDataSource(lData);                

                    // utilizando o ExportToStream.
                    System.IO.Stream st = myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    
                    // criar um Leitor de Binários para receber o stream
                    System.IO.BinaryReader br = new System.IO.BinaryReader(st);

                    // cria um vetor de bytes do tamanho do stream
                    byte[] vet = new byte[st.Length];

                    // Carrega o vetor de bytes
                    for (int x = 0; x < (st.Length); ++x)
                        vet[x] = br.ReadByte();

                    // Limpa o cabeçalho da página de saída
                    Response.ClearContent();
                    Response.ClearHeaders();
                    // Altera o tipo de saída para pdf.
                    Response.ContentType = "application/pdf";
                    // escreve o vetor na saída
                    Response.BinaryWrite(vet);
                    // exibe
                    Response.Flush();
                    // Fecha o Response (se não dá erro de arquivo não finalizado)
                    Response.Close();

                    myReportDocument.Close();
                }
                else
                {
                    msgErro.Visible = true;
                }
            }
            else
            {
                msgErro.Visible = true;
            }
        }

        #endregion

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string x = Request["ReportName"];
                hidReportName.Value = Request["ReportName"];
                if(Request["Data"] != null)
                    HidData.Value = Request["Data"];                
                loadReport();
            }           
            catch (Exception err)
            {
                
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            myReportDocument.Close();
            myReportDocument.Dispose();
        }  
        #endregion
    }

}