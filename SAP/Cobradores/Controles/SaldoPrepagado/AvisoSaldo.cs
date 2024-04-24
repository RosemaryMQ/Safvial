using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Cobradores.Controles.SaldoPrepagado
{
    public partial class AvisoSaldo : Form
    {
        public AvisoSaldo()
        {
            InitializeComponent();
            aviso.Text = "Deuda Actual: "+string.Format("{0:n}", SAP.Cobradores.Controles.V2.Prepagado.Saldo) + " Bs.S";
        }

        private void AvisoSaldo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
