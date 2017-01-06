using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Imię.
        /// </summary>
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko.
        /// </summary>
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        /// <summary>
        /// Hasło.
        /// </summary>
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}