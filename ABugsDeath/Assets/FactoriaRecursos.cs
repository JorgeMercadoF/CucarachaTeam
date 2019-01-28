using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Assets
{
    public class FactoriaRecursos
    {
        // Atributos
        private List<Materiales> materiales = new List<Materiales>();
        private List<Vehiculos> vehiculos = new List<Vehiculos>();
        private List<PoisonBase> venenos = new List<PoisonBase>();

        //Constructor
        public FactoriaRecursos(){}

        //Factoria
        public List<Materiales> CrearMaterial(string nombre, decimal precio, int cantidad)
        {
            if (nombre.Equals(""))
            {
                throw new Exception("Se debe informar el nombre del material a crear");
            }
            else
            {
                if(cantidad.Equals(0) || cantidad < 0)
                {
                    throw new Exception("La cantidad de materiales a crear debe ser superior a 0");
                }
                else
                {
                    for (int i = 0; i < cantidad; i++)
                    {
                        materiales.Add(new Materiales(nombre, precio));
                    }
                    return materiales;
                }
            }
        }
        public List<Vehiculos> CrearVehiculo(string marca, string modelo, int plazas, decimal precio, int cantidad)
        {
            if (modelo.Equals(""))
            {
                throw new Exception("Se debe informar la marca del vehiculo a crear");
            }
            else
            {
                if (cantidad.Equals(0) || cantidad < 0)
                {
                    throw new Exception("La cantidad de vehiculos a crear debe ser superior a 0");
                }
                else
                {
                    for (int i = 0; i < cantidad; i++)
                    {
                        vehiculos.Add(new Vehiculos(marca, modelo, plazas, precio));
                    }
                    return vehiculos;
                }
            }
        }
        public List<PoisonBase> CrearVeneno(string nombre, decimal precio, int cantidad)
        {
            if (nombre.Equals(""))
            {
                throw new Exception("Se debe informar el nombre del material a crear");
            }
            else
            {
                if (cantidad.Equals(0) || cantidad < 0)
                {
                    throw new Exception("La cantidad de materiales a crear debe ser superior a 0");
                }
                else
                {
                    for (int i = 0; i < cantidad; i++)
                    {
                        venenos.Add(new PoisonBase(nombre, precio));
                    }
                    return venenos;
                }
            }
        }
    }
}
