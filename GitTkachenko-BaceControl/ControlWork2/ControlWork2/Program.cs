using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Kharkiv=1431000,Kiev=2804000,Las Vegas=603400";
            Console.WriteLine($"Enter the string as - {input}");
            input = Console.ReadLine();

            try
            {
                var cities = ParseStringAndAddObjectToList(input);

                var cityMostPopulated = GetCityWithMostPopulated(cities);
                var cityWithLongestName = GetCityWithLongestName(cities);

                Console.WriteLine($"Most populated: {cityMostPopulated.Name}" +
                                $"({cityMostPopulated.Population} people)");
                Console.WriteLine($"Longest name: {cityWithLongestName.Name}" +
                                $"({cityWithLongestName.Name.Length} letters)");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }


        }

        private static List<City> ParseStringAndAddObjectToList(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                throw new Exception($"Please check the input string. It's empty." + Environment.NewLine +
                                    $"Type of input string must be as: \"Kharkiv=1431000,Kiev=2804000,Las Vegas=603400\"");
            }

            var citys = new List<City>();
            var arrayCityes = input.Split(',');

            foreach (string city in arrayCityes)
            {
                var cityAndPopulation = city.Split('=');
                citys.Add(new City(cityAndPopulation[0], Convert.ToInt32(cityAndPopulation[1])));
            }
            return citys;
        }

        private static City GetCityWithMostPopulated(List<City> citys)
        {
            City result = citys[0];

            for (int i = 0; i < citys.Count - 1; i++)
            {
                if (citys[i].Population < citys[i + 1].Population)
                {
                    result = citys[i + 1];
                }

            }
            return result;
        }

        private static City GetCityWithLongestName(List<City> citys)
        {
            City result = citys[0];

            for (int i = 0; i < citys.Count - 1; i++)
            {
                if (citys[i].Name.Length < citys[i + 1].Name.Length)
                {
                    result = citys[i + 1];
                }

            }
            return result;
        }
    }
}
