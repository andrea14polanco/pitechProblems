using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        public static string filePath = @"..\..\..\Ejercicio1.csv";

        static void Main(string[] args)
        {
            //Crea archivo con nombre y la cedula de la persona ordenado por cedula ascendentemente (siendo el caracter de mayor peso el el de la derecha)
            Console.WriteLine("******EJERCICIO 1******");
            Ejercicio1.Execute(filePath);
            Console.WriteLine();
            /** A TODOS LOS TIPOS DE GENERADORES DE EJERCICIOS SE LE PUEDE MANDAR LA CANTIDAD QUE SE DESEA Y POSEEN UN LIMITE DE 45000 C/U*/

            Console.WriteLine("******EJERCICIO 2******");

            //Generador de  ejercicios 2
            var ejericio2 = new Ejercicio2();
            ejericio2.GenerateExercises(1);

            Console.WriteLine("******EJERCICIO 3******");

            //Generador de  ejercicios 3
            var ejericio3 = new Ejercicio3();
            ejericio3.GenerateExercises(1);

            Console.WriteLine("******EJERCICIO 4******");

            //Generador de  ejercicios 4
            var ejericio4 = new Ejercicio4();
            ejericio4.GenerateExercises(1);

        }


    }
}
