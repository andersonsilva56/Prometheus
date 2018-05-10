using System;
using System.Web.UI;
using Modelo;

namespace LOGAN.Prometheus.Pagina
{
    /// <summary>
	/// Summary description for BaseAutPage
	/// </summary>
	public class BaseAutPage : BasePage
    {
		#region Constructors

		public BaseAutPage()
		{
		}

		#endregion        

        #region Event Handlers

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);            
        }
        
        protected void Page_Load(object sender, EventArgs e)
		{
			 
		}

        #endregion

        /// <summary>
        /// Exibe mensagem modal bootstrap
        /// </summary>
        /// <param name="painel">UpdatePanel da pagina</param>
        /// <param name="titulo">Label da mensagem</param>
        /// <param name="mensagem">Corpo da mensagem</param>
        /// <param name="tipo">Pode ser: erro, alerta, info, ok</param>
        protected void exibirMensagem(String titulo, String mensagem, String tipo)
        {
            String img = "";
            String tagImg = "";
            String path = ResolveClientUrl("~/img/");
            switch (tipo)
            {
                case "erro": img = path + @"ico_error.png"; break;
                case "alerta": img = path + @"ico_alert.png"; break;
                case "info": img = path + @"ico_info.png"; break;
                case "ok": img = path + @"ico_success.png"; break;
                default: img = ""; break;
            }
            if (img != "")
                tagImg = "<img src=\"" + img + "\" />";

            img = "<div class=\"row\"><div class=\"col-md-2\">" + tagImg + "</div>";
            mensagem = "<div class=\"col-md-6\">" + mensagem + "</div></div>";

            String comando = "$('#modalRespostaBody').html(' " + img + mensagem + "');";
            comando += "$('#modalRespostaLabel').html('" + titulo + "');";
            comando += "$('#modalResposta').modal('show');";

            //ScriptManager.RegisterClientScriptBlock(painel, typeof(Page), "modal", comando, true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NomedaJanela", "$(function(){" + comando + "});", true);

        }
        /// <summary>
        /// Exibe mensagem modal bootstrap
        /// </summary>
        /// <param name="painel">UpdatePanel da pagina</param>
        /// <param name="titulo">Label da mensagem</param>
        /// <param name="mensagem">Corpo da mensagem</param>
        /// <param name="tipo">Pode ser: erro, alerta, info, ok</param>
        /// <param name="url">URL para a qual será direcionada</param>
        protected void exibirMensagem(String titulo, String mensagem, String tipo, String url)
        {
            String img = "";
            String tagImg = "";
            String path = ResolveClientUrl("~/img/");
            switch (tipo)
            {
                case "erro": img = path + @"ico_error.png"; break;
                case "alerta": img = path + @"ico_alert.png"; break;
                case "info": img = path + @"ico_info.png"; break;
                case "ok": img = path + @"ico_success.png"; break;
                default: img = ""; break;
            }
            if (img != "")
                tagImg = "<img src=\"" + img + "\" />";

            img = "<div class=\"row\"><div class=\"col-md-2\">" + tagImg + "</div>";
            mensagem = "<div class=\"col-md-6\">" + mensagem + "</div></div>";

            String comando = "$('#modalRespostaBody').html(' " + img + mensagem + "');";
            comando += "$('#modalRespostaLabel').html('" + titulo + "');";
            comando += "$('#modalResposta').modal('show');";
            comando += "$('#modalResposta').on('hide.bs.modal', function(e){window.location = '" + url + "'});";

            //ScriptManager.RegisterClientScriptBlock(painel, typeof(Page), "modalResposta", comando, true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NomedaJanela", "$(function(){" + comando + "});", true);
        }		

        protected void Log(String desricao)
        {
            LogEntidade.descricao = desricao;
            string pRetorno = LogModelo.Include();
        }
	}
}