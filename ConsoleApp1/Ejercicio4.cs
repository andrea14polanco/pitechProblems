using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Humanizer;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Ejercicio4 : IExerciseGenerator
    {
        private static readonly string instruction = "Escriba el numero siguiente presionando los botones en el orden correcto.";
        private static readonly int problemLimit = 1;
        private static readonly int optionLimit = 6;
        public ExerciseGeneratorObject e;

        public Ejercicio4()
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
            for (int cont = 0; cont < cantEjercicios; cont++)
            {
                //para usar Humanizer con el CultureInfo
                CultureInfo current = CultureInfo.GetCultureInfo("es-MX");

                Random rnd = new Random();

                int limit = 45000;

                int number = rnd.Next(limit);

                int wrongAnswer = rnd.Next(limit*10); ;

                e.result = number.ToWords(current);

                String[] words = number.ToWords(current).Split(" ");

                String[] wrongWords = wrongAnswer.ToWords(current).Split(" ");

                int combinacionPosiblesWords = (int)Math.Ceiling(words.Length / 3.0);

                int pivot = 0;
                //Este for llena las posiciones vacias con las opciones correctas
                for (int i = 0; i < optionLimit; i++)
                {
                    int j = combinacionPosiblesWords;
                
                    while (j > 0 && pivot < words.Length)
                    {

                        e.options[i] = e.options[i] + " " + words[pivot];
                        pivot++;
                        j--;
                    }
                }
                
                pivot = 0;
                //Este for llena las posiciones vacias con opciones random
                for (int i = 0; i < optionLimit; i++)
                {
                    if (e.options[i] == null)
                    {
                        int j = combinacionPosiblesWords;
                
                        while (j > 0 && pivot < wrongWords.Length)
                        {

                            e.options[i] = e.options[i] + " " + wrongWords[pivot];
                            pivot++;
                            j--;
                        }
                    }
                }

                e.options = ShuffleArray(e.options);

                string problemNumber = String.Format("{0:n0}", number);
                                
                var serializador = JsonConvert.SerializeObject(e).Replace("\"problem\":[null]", $"\"problem\":\"{problemNumber}\"");

                Console.WriteLine(serializador + "\n");

            }
        }

        public static String[] ShuffleArray(String[] arr)
        {

            Random rnd = new Random();

            return arr.OrderBy(x => rnd.Next()).ToArray();
            
        }

    }
}
