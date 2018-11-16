using System;
using System.Collections.Generic;

namespace BolsadeEmpleo
{
    public class Ciudad
    {

        private string nombre;
        public Ciudad(){

        }

        public Ciudad(string nombre)
        {
            this.nombre = nombre;
        }
        public override string ToString()
        {
            return this.nombre;
        }
        public List<Ciudad> getCiudades(){
            List<Ciudad> ciudades = new List<Ciudad>
            {
                new Ciudad("Bogotá"),
                new Ciudad("Medellín"),
                new Ciudad("Cali"),
                new Ciudad("Cartagena"),
                new Ciudad("Barranquilla"),
                new Ciudad("Todas las Ciudades")
            };
            return ciudades;
        }
    }
}
