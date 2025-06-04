using System.ComponentModel.DataAnnotations;

namespace FlightApi.Models
{
    public class Flight
    {
        public int Id { get; set; }
        [Required] public string FlightNumber { get; set; }
        [Required] public string Airline { get; set; }
        [Required] public string DepartureAirport { get; set; }
        [Required] public string ArrivalAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public FlightStatus Status { get; set; }
    }
}