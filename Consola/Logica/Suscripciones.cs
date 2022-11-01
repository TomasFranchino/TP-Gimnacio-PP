using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Suscripciones
    {
        public string fechaSuscripcion { get; set; }
        public string finSuscripcion { get; set; }
        public int idSuscripciones { get; set; }
        public int idCliente { get; set; }
        public int idActividad { get; set; }
        public bool pagado { get; set; }

        public Suscripciones() 
        {
        }
    }
}
