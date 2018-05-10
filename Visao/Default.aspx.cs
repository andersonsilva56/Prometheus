using System;
using LOGAN.Prometheus.Pagina;
using Modelo;
using System.Data;

public partial class _Default : BaseAutPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        try
        {
            UsuarioEntidade.email = login.Value.ToUpper();
            UsuarioEntidade.senha = senha.Value;
            DataTable lTabela = UsuarioModelo.Acesso();

            if (lTabela.Rows.Count > 0)
            {
                Session["SE_USUARIO"] = lTabela.Rows[0]["NOME"].ToString();
                Response.Redirect("~/page/Index.aspx");                
            }
            else
                exibirMensagem("Aviso", "Usuário sem acesso.", "alerta");
        }
        catch (Exception err)
        {
            exibirMensagem("Erro", err.Message.ToString(), "erro");
        }
    }
}