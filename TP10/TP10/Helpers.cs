using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TP10
{
    class Helpers
    {
        public enum TipoDeOperacion
        {
            Venta = 0,
            Alquiler = 1,
        }

        public enum TipoDePropiedad
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
            TipoDeOperacion operacion;
            TipoDePropiedad tipoPropiedad;
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
            public TipoDeOperacion Operacion { get => operacion; set => operacion = value; }
            public TipoDePropiedad TipoPropiedad { get => tipoPropiedad; set => tipoPropiedad = value; }

            public float valorDelInmueble()
            {
                float valor;
                float IVA = precio * 21 / 100;
                float ingresosBrutos = (precio + IVA) * 10 / 100;
                float costoTransferencia = 10000;
                double costos = precio * 0.5 / 100; //costos de sellado y contrato

                if (operacion == TipoDeOperacion.Venta) //Si la operacion es una VENTA
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
    public static class ConversorDeMorse
    {

        static Dictionary<string, string> DiccionarioMorse = new Dictionary<string, string>()
        {
            {"a", ".-"}, {"b", "-..."}, {"c", "-.-."}, {"d", "-.."}, {"e", "."},
            {"f", "..-." }, {"g", "--."}, {"h", "...."}, {"i", ".."}, {"j", ".---"},
            {"k", "-.-" }, {"l", ".-.."}, {"m", "--"}, {"n", "-."}, {"ñ", "--.--"},
            {"o", "---"}, {"p", ".--."}, {"q", "--.-"}, {"r", ".-."}, {"s", "..."},
            {"t", "-"}, {"u", "..-"}, {"v", "...-"}, {"w", ".--"}, {"x", "-..-"},
            {"y", "-.--"}, {"z","--.."}, {"1", ".----"}, {"2", "..---"}, {"3", "...--"},
            {"4", "....-"}, {"5", "....."}, {"6", "-...."}, {"7", "--..."}, {"8", "---.."},
            {"9", "----."}, {"0", "-----"}, {" ", "/"}
        };


        public static string MorseATexto(string cadena)
        {
            string traduccion = "";
            string[] Morse = cadena.Split(" ");

            foreach (string simbolo in Morse)
            {
                foreach (KeyValuePair<string, string> elemento in DiccionarioMorse)
                {
                    if (elemento.Value == simbolo.ToString())
                    {
                        traduccion = traduccion + elemento.Key;
                        //break;
                    }
                }
            }

            return traduccion;
        }

        public static string TextoAMorse(string cadena)
        {
            string traduccion = "";

            cadena = cadena.ToLower();

            foreach (char letra in cadena)
            {
                Console.WriteLine(letra);
                foreach (KeyValuePair<string, string> elemento in DiccionarioMorse)
                {
                    if (elemento.Key == letra.ToString())
                    {
                        traduccion = traduccion + elemento.Value + " ";
                        //break;
                    }
                }
            }
            return traduccion;
        }

        public static void MorseAAudio(string ArchivoInicial, string ArchivoFinal)
        {
            FileStream ArchivoMorse = new FileStream(ArchivoInicial, FileMode.Open);
            StreamReader StrReader = new StreamReader(ArchivoMorse);

            FileStream ArchivoAudio = new FileStream(ArchivoFinal, FileMode.Create);
            StreamWriter StrWriter = new StreamWriter(ArchivoAudio);

            string cadena = StrReader.ReadLine();
            string[] Morse = cadena.Split(" ");

            string cad1 = @"‪c:\Repogit\tp10\punto.mp3";
            string cad2 = @"c:\Repogit\tp10\raya.mp3";

            byte[] punto = File.ReadAllBytes(cad1);           
            byte[] raya = File.ReadAllBytes(cad2‪);

            string puntoString = "";
            string rayaString = "";

            foreach(byte Byt in punto)
            {
                puntoString = puntoString + Byt.ToString();
            }

            foreach (byte Byt in raya)
            {
                rayaString = rayaString + Byt.ToString();
            }


            foreach (string letra in Morse)
            {
                foreach(char simbolo in letra)
                {
                    if (simbolo == '-')
                    {
                        StrWriter.Write(Convert.ToString(raya), 0, raya.Length);
                    } else if (simbolo == '.')
                    {
                        StrWriter.Write(Convert.ToString(punto), 0, punto.Length);
                    }
                }
            }
            StrReader.Close();
            StrWriter.Close();
        }
    }
}
