using System;
using System.Collections.Generic;

namespace GeneratorLiczbLosowych
{
    class Program
    {
        static void Main(string[] args)
        {
            Mechanics m = new Mechanics();
            ShowResult();


            void ShowResult()
            {
                Console.WriteLine("Wygenerowane liczby: ");

                foreach (int number in m.generatedNumbers)
                {
                    Console.Write(number + " ");
                }
            }
        }

    }

    class Mechanics
    {
        private List<Tuple<int, int>> ranges = new List<Tuple<int, int>>();
        public List<int> generatedNumbers = new List<int>();

        public int numberOfDices { get; }
        public Mechanics()
        {
            SetRanges();
            numberOfDices = GetInput("Podaj ilość kostek użytych do losowania");
            ShowRanges();
            Console.Clear();
        }

        public int GetInput(string message)
        {
            int output;
            Console.WriteLine(message);
            if (!int.TryParse(Console.ReadLine(), out output) || output <= 0)
            {
                return GetInput(message);
            }

            return output;
        }

        private void SetRanges()
        {
            ranges.Add(new Tuple<int, int>(1, 6));
            ranges.Add(new Tuple<int, int>(1, 8));
            ranges.Add(new Tuple<int, int>(1, 10));
            ranges.Add(new Tuple<int, int>(1, 12));
            ranges.Add(new Tuple<int, int>(1, 20));
        }

        private void ShowRanges()
        {
            Console.Clear();
            Console.WriteLine("Wybierz zakres losowania kostek");
            int i = 1;
            foreach(Tuple<int, int> range in ranges)
            {
                Console.WriteLine(i + ".  " + range.Item1 + " - " + range.Item2);
                i++;
            }

            int option = GetInput("");

            generatedNumbers = GenerateRandomNumbers(ranges[option - 1]);
        }

        private List<int> GenerateRandomNumbers(Tuple<int,int> range)
        {
            List<int> numbers = new List<int>(numberOfDices);
            Random rnd = new Random();
            for(int i = 0; i < numberOfDices; i++)
            {
                numbers.Add(rnd.Next(range.Item1, range.Item2 + 1));
            }

            return numbers;
        }
    }
}