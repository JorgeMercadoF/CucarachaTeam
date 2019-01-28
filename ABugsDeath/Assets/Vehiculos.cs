using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Assets
{
    public class Vehiculos : IRecurso
    {
        //Atributos
        private string marca;
        private string modelo;
        private int plazas;
        private decimal precio;

        //Constructor
        public Vehiculos(string marca, string modelo, int plazas, decimal precio)
        {
            if (marca.Equals(""))
            {
                throw new Exception("Se debe informar la Marca del vehiculo");
            }
            else
            {
                if (modelo.Equals(""))
                {
                    throw new Exception("Se debe informar el Modelo del vehiculo");
                }
                else
                {
                    if (plazas.Equals(0) || plazas < 0)
                    {
                        throw new Exception("El numero de Plazas del vehiculo debe ser superior a 0");
                    }
                    else
                    {
                        if (precio.Equals(0) || precio < 0)
                        {
                            throw new Exception("El Precio del vehiculo debe ser superior a 0");
                        }
                        else
                        {
                            this.marca = marca;
                            this.modelo = modelo;
                            this.plazas = plazas;
                            this.precio = precio;
                        }
                    }
                }
            }
        }

        //Setters
        public void SetMarca(string marca)
        {
            if (marca.Equals(""))
            {
                throw new Exception("Se debe informar la Marca del vehiculo");
            }
            else
            {
                this.marca = marca;
            }
        }
        public void SetModelo(string modelo)
        {
            if (modelo.Equals(""))
            {
                throw new Exception("Se debe informar el Modelo del vehiculo");
            }
            else
            {
                this.modelo = modelo;
            }
        }
        public void SetPlazas(int plazas)
        {
            if (plazas.Equals(0) || plazas < 0)
            {
                throw new Exception("El numero de Plazas del vehiculo debe ser superior a 0");
            }
            else
            {
                this.plazas = plazas;
            }
        }
        public void SetPrecio(decimal precio)
        {
            if (precio.Equals(0) || precio < 0)
            {
                throw new Exception("El Precio del vehiculo debe ser superior a 0");
            }
            else
            {
                this.precio = precio;
            }
        }

        //Getters
        public string GetMarca()
        {
            return marca;
        }
        public string GetModelo()
        {
            return modelo;
        }
        public int GetPlazas()
        {
            return plazas;
        }

        //Métodos de la Interfaz
        public decimal GetPrecioRecurso()
        {
            return precio;
        }
        public string GetNombreRecurso()
        {
            return (marca + " " + modelo);
        }
    }
}
