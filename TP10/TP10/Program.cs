using System;
using System.IO;
using System.Collections.Generic;
using static TP10.Helpers;

namespace TP10
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombreDeArchivo = "ListadoInmuebles.csv";
            string rutaDeArchivo = @"c:\Repogit\tp10\";

            List<Propiedad> ListaDePropiedades = new List<Propiedad>();

            if (!Directory.Exists(rutaDeArchivo + @"Archivos\"))
            {
                Directory.CreateDirectory(rutaDeArchivo + @"Archivos\");
            }

            rutaDeArchivo = @"c:\Repogit\tp10\" + @"Archivos\";

            FileStream MiArchivo = new FileStream(rutaDeArchivo + nombreDeArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);

            while (!StrReader.EndOfStream)
            {
                Propiedad Prop = new Propiedad();
                string linea = StrReader.ReadLine();
                string[] Filas = linea.Split(";");
                Prop.Domicilio = Filas[0];
                Prop.TipoPropiedad = (TipoDePropiedad)Convert.ToInt32(Filas[1]);
                ListaDePropiedades.Add(Prop);
            }

            StrReader.Close();

            // Cargando el resto de los datos

            string nombreDeArchivo2 = "ListadoInmuebles2.csv";

            FileStream MiArchivo2 = new FileStream(rutaDeArchivo + nombreDeArchivo2, FileMode.Create);
            StreamWriter StrReader2 = new StreamWriter(MiArchivo2);

            int contador = -1;
            bool[] booleano = { true, false };

            foreach (Propiedad Prop in ListaDePropiedades)
            {
                Random Rand = new Random();
                
                Prop.Id = contador + 1;
                Prop.Operacion = (TipoDeOperacion)Rand.Next(2);
                Prop.Tamanio = Rand.Next(86) + 15; // en m2
                Prop.CantBanios = Rand.Next(4) + 1;
                Prop.CantHabitac = Prop.CantBanios + Rand.Next(10) + 1;
                Prop.Precio = Rand.Next(200000); //cien millones de pesos
                Prop.Estado = booleano[Rand.Next(2)];

                StrReader2.WriteLine(Prop.Id.ToString() + ";" + Prop.Operacion.ToString() + ";" + Prop.Tamanio.ToString() + ";" + Prop.CantBanios.ToString() + ";" + Prop.CantHabitac.ToString() + ";" + Prop.Precio.ToString() + ";" +
                    Prop.Estado.ToString() + ";");

                Console.WriteLine("Valor de propiedad de ID " + Prop.Id + ": " + Prop.valorDelInmueble());
                contador++;
            }
            StrReader2.Close();

        }

            string ArchivoMorse = @"c:\RepoGit\‪tp9\Morse\prueba.txt"; //El código Morse que voy a traducir a audio
            string ArchivoAudio = @"c:\RepoGit\tp10\Archivos\ArchivoMP3.mp3"; //El archivo .mp3 que tendrá el audio producto de la traducción

            ConversorDeMorse.MorseAAudio(ArchivoMorse, ArchivoAudio);
        }
    }
}
