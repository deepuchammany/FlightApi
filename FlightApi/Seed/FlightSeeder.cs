using CsvHelper;
using FlightApi.Data;
using FlightApi.Models;
using System.Globalization;

namespace FlightApi.Seed
{
    /// <summary>
    /// Seeds the database with initial flight data from a CSV file.
    /// </summary>
    public static class FlightSeeder
    {
        /// <summary>
        /// Seeds the Flights table if it is empty.
        /// </summary>
        /// <param name="context">Database context.</param>
        public static void SeedFlights(FlightContext context)
        {
            if (context.Flights.Any()) return;

            using var reader = new StreamReader("SeedData/FlightInformation.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var flights = csv.GetRecords<Flight>().ToList();

            context.Flights.AddRange(flights);
            context.SaveChanges();
        }
    }
}
