using System;
using System.Collections.Generic;
using System.Text;

namespace TP10
{
    class Helpers
    {
        enum tipoDeOperacion
        {
            Venta = 0,
            Alquiler = 1,
        }

        enum tipoDePropiedad
        {
            Departamento = 0,
            Casa = 1,
            Duplex = 2,
            PentHouse = 3,
            Terreno = 4,
        }

        public class Propiedad
        {
            int id;
            tipoDeOperacion operacion;
            tipoDePropiedad tipoPropiedad;
            float tamanio;
            int cantBanios;
            int cantHabitac;
            string domicilio;
            int precio;
            bool estado;

            public int Id { get => id; set => id = value; }
            public float Tamanio { get => tamanio; set => tamanio = value; }
            public int CantBanios { get => cantBanios; set => cantBanios = value; }
            public int CantHabitac { get => cantHabitac; set => cantHabitac = value; }
            public string Domicilio { get => domicilio; set => domicilio = value; }
            public int Precio { get => precio; set => precio = value; }
            public bool Estado { get => estado; set => estado = value; }
            private tipoDeOperacion Operacion { get => operacion; set => operacion = value; }
            private tipoDePropiedad TipoPropiedad { get => tipoPropiedad; set => tipoPropiedad = value; }

            float valorDelInmueble()
            {
                float valor;
                float IVA = precio * 21 / 100;
                float ingresosBrutos = (precio + IVA) * 10 / 100;
                float costoTransferencia = 10000;
                double costos = precio * 0.5 / 100; //costos de sellado y contrato

                if (operacion == tipoDeOperacion.Venta) //Si la operacion es una VENTA
                {
                    valor = precio + IVA + ingresosBrutos + costoTransferencia;
                }
                else
                {
                    valor = Convert.ToSingle(precio * 2 / 100 + costos);
                }

                return valor;
            }
        }
    }
}
