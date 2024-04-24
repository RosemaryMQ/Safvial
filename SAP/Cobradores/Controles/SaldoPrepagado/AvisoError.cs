using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAP.Cobradores.Controles.SaldoPrepagado
{
    public partial class AvisoError : Form
    {
        public AvisoError()
        {
            InitializeComponent();
        }

        private void label2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
