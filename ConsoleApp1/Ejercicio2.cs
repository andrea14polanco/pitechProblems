using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Ejercicio2 : IExerciseGenerator
    {
        private static readonly string instruction = "Selecciona el resultado de la siguiente suma.";
        private static readonly int problemLimit = 2;
        private static readonly int optionLimit = 4;
        public ExerciseGeneratorObject e;

        public Ejercicio2()
        {
            e = new ExerciseGeneratorObject
            {
                instruction = instruction,
                problem = new string[problemLimit],
                options = new string[optionLimit]
            };
        }
        public void GenerateExercises(int cantEjercicios)
        {

            Random rnd = new Random();

            for (int i = 0; i < cantEjercicios; i++)
            {
                int limit = 45000;

                int randomResPos = rnd.Next(optionLimit + 1);

                randomResPos = randomResPos == 0 ? 0 : randomResPos - 1;

                long a = rnd.Next(limit);

                long b = rnd.Next(limit);

                e.problem[0] = String.Format("{0:n0}", a);
                
                e.problem[1] = String.Format("{0:n0}", b);

                e.result = String.Format("{0:n0}", a + b);

                for (int j = 0; j < optionLimit; j++)
                {
                    if (!j.Equals(randomResPos))
                    {
                        int randomNumber = rnd.Next(limit);

                        e.options[j] = String.Format("{0:n0}", randomNumber);

                    }
                }


                e.options[randomResPos] = e.result;

                //Imprimer el json

                var serializador = JsonConvert.SerializeObject(e);

                Console.WriteLine(serializador + "\n");

            }


        }




    }
}
