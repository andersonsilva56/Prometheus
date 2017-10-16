using System;
using System.Web;


namespace LOGAN.Prometheus.Pagina
{
	/// <summary>
	/// Summary description for BasePage
	/// </summary>
	public class BasePage : System.Web.UI.Page
	{
		#region Properties		

		#endregion

		#region Constructor

		public BasePage()
		{
           
		}

		#endregion
        
		#region Event Handlers

		public void Page_Load(object sender, EventArgs e)
		{
            ClearCache();            
			//this.MasterPage.AddCSS("base.css");
        }


        private void ClearCache()
        {
            Response.Cache.SetExpires(DateTime.Parse(DateTime. Now.ToString()));
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.Cache.SetNoStore();
            Response.AppendHeader("Pragma", "no-cache");
        }


		#endregion
	}
}