using System;
namespace BolsadeEmpleo
{
    public class Oferta
    {
        private string cargo;
        private string fecha;
        private string ciudad;

        public Oferta(string cargo, string fecha, string ciudad)
        {
            this.cargo = cargo;
            this.fecha = fecha;
            this.ciudad = ciudad;

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
