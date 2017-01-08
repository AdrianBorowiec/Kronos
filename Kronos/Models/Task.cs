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
    /// Zadania pracowników.
    /// </summary>
    [Validator(typeof(TaskValidator))]
    public class Task
    {
        /// <summary>
        /// Identyfikator
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Pracownik
        /// </summary>
        [Display(Name = "Pracownik")]
        public string Employee { get; set; }

        /// <summary>
        /// Opis zadania
        /// </summary>
        [Display(Name = "Opis zadania")]
        public string TaskDescription { get; set; }

        /// <summary>
        /// Data wykonania zadania
        /// </summary>
        [Display(Name = "Data wykonania zadania")]
        public DateTime? TaskDate { get; set; }

        /// <summary>
        /// Status zadania
        /// </summary>
        [Display(Name = "Status zadania")]
        public bool Status { get; set; }
    }
}