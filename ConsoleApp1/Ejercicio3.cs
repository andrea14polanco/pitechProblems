using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Ejercicio3 : IExerciseGenerator
    {
        private static readonly string instruction = "Completa correctamente la oracion arrastrando al espacio en blanco la cantidad que corresponda";
        private static readonly int problemLimit = 1;
        private static readonly int optionLimit = 4;
        public ExerciseGeneratorObject e;
        private static int percentage;

        public Ejercicio3()
        {
            e = new ExerciseGeneratorObject
            {
                instruction = instruction,
                problem = new string[problemLimit],
                options = new string[optionLimit]
            };
            percentage = 0;
        }
        public void GenerateExercises(int cantEjercicios)
        {
            Random rnd = new Random();

            for (int i = 0; i < cantEjercicios; i++)
            {
                //Just hasta 100%
                percentage = rnd.Next(101);

                int limit = 45000;

                int randomResPos = rnd.Next(optionLimit + 1);

                randomResPos = randomResPos == 0 ? 0 : randomResPos - 1;

                int randomNumber = rnd.Next(limit);

                string problemNumber = String.Format("{0:n0}", randomNumber);

                string problem= $"Aumentar en un {percentage}% la cantidad de {problemNumber}, resulta en:";

                 e.result = String.Format("{0:n0}", randomNumber + (randomNumber * (percentage / 100.0)));
                for (int j = 0; j < optionLimit; j++)
                {
                    if (!j.Equals(randomResPos))
                    {

                        e.options[j] = String.Format("{0:n}", rnd.Next(limit));
                    }

                }

                e.options[randomResPos] = e.result;

                var serializador = JsonConvert.SerializeObject(e).Replace("\"problem\":[null]", $"\"problem\":\"{problem}\"");

                Console.WriteLine(serializador + "\n");


            }


        }



    }
}
