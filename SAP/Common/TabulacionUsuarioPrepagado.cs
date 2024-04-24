using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
    public class TabulacionUsuarioPrepagado
    {
        public long ID { get; set; }
        public string Vehiculo { get; set; }
        public int Canal { get; set; }
        public string Fecha { get; set; }
        public int Turno { get; set; }
        public string FormaPago { get; set; }
    }
}
