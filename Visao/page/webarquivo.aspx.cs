using System;
using System.Data;
using System.Web.UI;
using Modelo;
using LOGAN.Prometheus.Pagina;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;



namespace web2ViaEst
{
    /// <summary>
    /// Summary description for webfoto.
    /// </summary>
    public partial class webfoto : System.Web.UI.Page
	{
		public byte[] myfoto;		
		protected void Page_Load(object sender, System.EventArgs e)
		{			
			AtletaAnexoEntidade.codigo = decimal.Parse(Request.QueryString[0].ToString());
            string tipo = Request.QueryString[1].ToString();

            DataTable lTable = AtletaAnexoModelo.AtletaAnexoByte();

            foreach (DataRow ors in lTable.Rows)
			{
				myfoto = (byte[]) ors[0];
			}

            if (tipo == ".JPG")
                Response.ContentType = "Image/JPG";
            else if (tipo == ".PNG")
                Response.ContentType = "Image/PNG";
            else if (tipo == ".BMP")
                Response.ContentType = "Image/BMP";
            else if (tipo == ".PDF")
                Response.ContentType = "Application/pdf";            

            Response.BinaryWrite(myfoto);
		}        
    }
}
