using System;
using System.Collections.Generic;

class City
{
    public string name;
    public int outbreakLevel;
    public List<int> contacts;
}

class Program
{
    static void Main(string[] args)
    {
        int numCities;

        Console.Write("Enter the number of cities: ");
        numCities = int.Parse(Console.ReadLine());

        List<City> cities = new List<City>(numCities);

        for (int i = 0; i < numCities; i++)
        {
            City city = new City();

            Console.Write($"Enter the name of city {i + 1}: ");
            city.name = Console.ReadLine();

            Console.Write($"Enter the number of cities in contact with {city.name}: ");
            int numContacts = int.Parse(Console.ReadLine());

            city.contacts = new List<int>(numContacts);

            for (int j = 0; j < numContacts; j++)
            {
                Console.Write($"Enter the city ID of city {j + 1}: ");
                int contact = int.Parse(Console.ReadLine());

                if (contact < 0 || contact >= numCities || cities.Exists(c => c.contacts.Contains(contact)))
                {
                    Console.WriteLine("Invalid ID. Please enter again.");
                    j--;
                }
                else
                {
                    city.contacts.Add(contact);
                }
            }

            city.outbreakLevel = 0;

            cities.Add(city);
        }

        Console.WriteLine("\nCity Details:");
        foreach (City city in cities)
        {
            Console.WriteLine($"City {cities.IndexOf(city)} - Name: {city.name}, Outbreak Level: {city.outbreakLevel}");
        }

        bool exit = false;
        while (!exit)
        {
            Console.Write("\nEnter event (Outbreak, Vaccinate, Lockdown, Spread, Exit): ");
            string eventName = Console.ReadLine();
            int cityId;

            switch (eventName)
            {
                case "Outbreak":
                case "Vaccinate":
                case "Lockdown":
                    Console.Write("Enter the city ID: ");
                    cityId = int.Parse(Console.ReadLine());
                                        if (cityId >= 0 && cityId < numCities)
                    {
                        PerformEvent(eventName, cityId, cities);
                        DisplayCityDetails(cities);
                    }
                    else
                    {
                        Console.WriteLine("Invalid city ID.");
                    }
                    break;

                case "Spread":
                    SpreadOutbreak(cities);
                    DisplayCityDetails(cities);
                    break;

                case "Exit":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid event. Please enter again.");
                    break;
            }
        }
    }

    static void PerformEvent(string eventName, int cityId, List<City> cities)
    {
        switch (eventName)
        {
            case "Outbreak":
                if (cities[cityId].outbreakLevel <= 3)
                {
                    cities[cityId].outbreakLevel += 2;
                    foreach (int contact in cities[cityId].contacts)
                    {
                        if (cities[contact].outbreakLevel < 3)
                        {
                            cities[contact].outbreakLevel++;
                        }
                    }
                }
                break;

            case "Vaccinate":
                cities[cityId].outbreakLevel = 0;
                break;

            case "Lockdown":
                break;
        }
    }

    static void SpreadOutbreak(List<City> cities)
    {
        foreach (City city in cities)
        {
            if (city.outbreakLevel < 3)
            {
                foreach (int contact in city.contacts)
                {
                    if (cities[contact].outbreakLevel > city.outbreakLevel)
                    {
                        city.outbreakLevel++;
                        break;
                    }
                }
            }
        }
    }

    static void DisplayCityDetails(List<City> cities)
    {
        Console.WriteLine("\nCity Details:");
        foreach (City city in cities)
        {
            Console.WriteLine($"City {cities.IndexOf(city)} - Name: {city.name}, Outbreak Level: {city.outbreakLevel}");
        }
    }
}

                   
