using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Ejercicio1
    {
        
        private static readonly string outputFilePath = @"..\..\..\Respuesta1.csv";

        public static void Execute(string filePath)
        {

            CreateCsvFile(BubleSort(ReadCsvFile(filePath)));
            Console.WriteLine("Archivo de respuesta listo. Verificar dentro de la carpeta del proyecto");
        }

        //Read a cvs file and return a map<string, (string a, string b)>
        public static Dictionary<string, (string a, long b)> ReadCsvFile(string filePath)
        {
            StreamReader lector = new StreamReader(File.OpenRead(filePath));

            var map = new Dictionary<string, (string a, long b)>();

            while (!lector.EndOfStream)
            {
                string linea = lector.ReadLine();

                map.Add(linea.Split(",")[0], (linea.Split(",")[1], Int64.Parse(ReverseString(linea.Split(",")[1].Replace("-", "")))));
            }

            return map;
        }

        //Order a map<string, (string a, string b)> using linq and returns a map<string, string>
        private static Dictionary<string, string> BubleSort(Dictionary<string, (string a, long b)> map)
        {

            var result = new Dictionary<string, string>();

            var maps = from row in map
                       orderby row.Value.b ascending
                       select row;

            maps.ToList().ForEach(x => {
                result.Add(x.Key, x.Value.a);
             });

            return result;
        }

        //Reverse a string
        private static string ReverseString(string a)
        {
            var x = a.ToCharArray().Reverse().ToArray();
            
            return new string(x);
        }

        //Create a cvs file with the correct string
        private static void CreateCsvFile(Dictionary<string, string> map)
        {
            var csv = new StringBuilder();

            map.ToList().ForEach(x => {
                //Using regex for the format
                var newLine = string.Format("{0},{1}", x.Key, x.Value);

                csv.AppendLine(newLine);

            });

            File.WriteAllText(outputFilePath, csv.ToString());
        }

    }




}

