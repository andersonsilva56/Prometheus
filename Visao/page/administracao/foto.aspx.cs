using System.Data;
using Modelo;

public partial class page_administracao_foto : System.Web.UI.Page
{
    public byte[] myfoto;
    protected void Page_Load(object sender, System.EventArgs e)
    {
        PessoaEntidade.codigo = decimal.Parse(Request.QueryString[0].ToString());

        DataTable lFoto = PessoaModelo.Foto();

        foreach (DataRow ors in lFoto.Rows)
        {
            myfoto = (byte[])ors[0];
        }
        
        Response.BinaryWrite(myfoto);
    }
}