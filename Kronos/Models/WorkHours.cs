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
    /// Godziny pracy
    /// </summary>
    [Validator(typeof(WorkHoursValidator))]
    public class WorkHours
    {
        /// <summary>
        /// Identyfikator
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Nazwa wydarzenia
        /// </summary>
        [Display(Name = "Pracownik")]
        public string Employee { get; set; }

        /// <summary>
        /// Opis
        /// </summary>
        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Początek wydarzenia
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        [Display(Name = "Początek pracy (dd.mm.yyyy hh.mm)")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Koniec wydarzenia
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        [Display(Name = "Koniec pracy (dd.mm.yyyy hh.mm)")]
        public DateTime? EndDate { get; set; }
    }
}