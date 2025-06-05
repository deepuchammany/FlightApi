using FlightApi.Validation;
using System.ComponentModel.DataAnnotations;

namespace FlightApi.Models
{
    /// <summary>
    /// Represents a flight with details such as flight number, airline, airports, times, and status.
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Gets or sets the unique identifier for the flight.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the flight number.
        /// </summary>
        [Required]
        [StringLength(10)]
        public string FlightNumber { get; set; }

        /// <summary>
        /// Gets or sets the airline operating the flight.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Airline { get; set; }

        /// <summary>
        /// Gets or sets the IATA or ICAO code of the departure airport.
        /// </summary>
        [Required]
        [StringLength(5, MinimumLength = 3)]
        public string DepartureAirport { get; set; }

        /// <summary>
        /// Gets or sets the IATA or ICAO code of the arrival airport.
        /// </summary>
        [Required]
        [StringLength(5, MinimumLength = 3)]
        public string ArrivalAirport { get; set; }

        /// <summary>
        /// Gets or sets the scheduled departure time of the flight.
        /// </summary>
        [Required]
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// Gets or sets the scheduled arrival time of the flight.
        /// Must be after <see cref="DepartureTime"/>.
        /// </summary>
        [Required]
        [DateGreaterThan("DepartureTime", ErrorMessage = "ArrivalTime must be after DepartureTime.")]
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// Gets or sets the current status of the flight.
        /// </summary>
        [Required]
        [EnumDataType(typeof(FlightStatus))]
        public FlightStatus Status { get; set; }
    }
}
