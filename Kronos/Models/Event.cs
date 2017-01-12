using FluentValidation.Attributes;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kronos.Models
{
    /// <summary>
    /// Wydarzenie
    /// </summary>
    [Validator(typeof(EventValidator))]
    public class Event
    {
        /// <summary>
        /// Identyfikator
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Nazwa wydarzenia
        /// </summary>
        [Display(Name = "Nazwa wydarzenia")]
        public string Name { get; set; }

        /// <summary>
        /// Opis
        /// </summary>
        [Display(Name = "Opis")]
        public string Description { get; set; }

        /// <summary>
        /// Początek wydarzenia
        /// </summary>
        [Display(Name = "Początek wydarzenia")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Koniec wydarzenia
        /// </summary>
        [Display(Name = "Koniec wydarzenia")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Rodzaj wydarzenia
        /// </summary>
        [Display(Name = "Rodzaj wydarzenia")]
        public EventType? EventType { get; set; }
    }

    public enum EventType
    {
        Stol,
        Sala,
        Inne
    }
}