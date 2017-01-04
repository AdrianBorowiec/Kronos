using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Models
{
    /// <summary>
    /// Pracownik.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Imię.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Hasło.
        /// </summary>
        public string Password { get; set; }
    }
}