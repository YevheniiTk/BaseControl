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

            try
            {
                var citys = ParseStringAndAddObjectToList(input);

                var cityWithMostPopulated = GetCityWithMostPopulated(citys);
                var cityWithLongestName = GetCityWithLongestName(citys);

                Console.WriteLine($"Most populated: {cityWithMostPopulated.Name}" +
                                $"({cityWithMostPopulated.Population} people)");
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

            foreach (var i in arrayCityes)
            {
                var cityAndPopulate = i.Split('=');
                citys.Add(new City(cityAndPopulate[0], Convert.ToInt32(cityAndPopulate[1])));
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
