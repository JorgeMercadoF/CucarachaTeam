using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Assets
{
    public class Materiales: IRecurso
    {
        //Atributos
        private string nombreMaterial;
        private decimal precio;

        //Constructor
        public Materiales(string nombreMaterial, decimal precio)
        {
            if(nombreMaterial.Equals(""))
            {
                throw new Exception("Se debe informar el nombre del material");
            }
            else
            {
                if(precio.Equals(0) || precio < 0)
                {
                    throw new Exception("El precio del material ha de ser superior a 0");
                }
                else
                {
                    this.nombreMaterial = nombreMaterial;
                    this.precio = precio;
                }
            }
        }

        //Setters
        public void SetNombreMaterial(string nuevoNombre)
        {
            if (nombreMaterial.Equals(""))
            {
                throw new Exception("Se debe informar el nombre del material");
            }
            else
            {
                this.nombreMaterial = nuevoNombre;
            }
        }

        public void SetPrecioMaterial(decimal nuevoPrecio)
        {
            if (nuevoPrecio.Equals(0) || nuevoPrecio < 0)
            {
                throw new Exception("El precio del material ha de ser superior a 0");
            }
            else
            {
                this.precio = nuevoPrecio;
            }
        }

        //Métodos de la Interfaz
        public decimal GetPrecioRecurso()
        {
            return precio;
        }
        public string GetNombreRecurso()
        {
            return nombreMaterial;
        }
    }
}
