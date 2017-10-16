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
            DataSet lTabela = UsuarioModelo.Acesso();            

            if (lTabela.Tables.Count > 0)
            {
                if (lTabela.Tables[0].Rows.Count > 0)
                    Response.Redirect("~/page/Index.aspx");
                else
                    exibirMensagem("Aviso", "Usuário sem acesso.", "alerta");
            }
            else
                exibirMensagem("Erro", Conexao.excecao, "erro");
        }
        catch (Exception err)
        {
            exibirMensagem("Erro", err.Message.ToString(), "erro");
        }
    }
}