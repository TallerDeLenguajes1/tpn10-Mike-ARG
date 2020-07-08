using System;
using System.IO;

namespace TP10
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombreDeArchivo = "ListadoInmuebles.csv";
            string rutaDeArchivo = @"c:\Repogit\tp10\";


            FileStream MiArchivo = new FileStream(rutaDeArchivo + nombreDeArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);

            string linea = "";
            
            while ((linea = StrReader.ReadLine()) != null)
            {
                Console.WriteLine(linea);
            }
        }
    }
}
