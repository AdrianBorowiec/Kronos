using FluentValidation.Attributes;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Models
{
    /// <summary>
    /// Stół bilardowy
    /// </summary>
    [Validator(typeof(TableValidator))]
    public class Table
    {
        /// <summary>
        /// Identyfikator
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Numer stolu
        /// </summary>
        public int? TableNumber { get; set; }

        /// <summary>
        /// Czy stół jest dostępny?
        /// </summary>
        public bool IsFree { get; set; }
    }
}