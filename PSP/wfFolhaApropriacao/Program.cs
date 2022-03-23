using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GridCarregamento.Negocio;


namespace wfFolhaApropriacao
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TabelaNeg tabelaNeg = new TabelaNeg();
            if (tabelaNeg.DomainGroupsNet("CN=FG_APP_TIME_APPROPRIATION"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);


                Application.Run(new MDIGeral());
            }
            else
            {
                MessageBox.Show("Usuario não possui acesso ao sistema. Favor solicitar acesso ao administrador do sistema");
            }
        }
    }
}
