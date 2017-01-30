using FluentValidation.Attributes;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kronos.Models
{
    /// <summary>
    /// Rezerwacja
    /// </summary>
    [Validator(typeof(ReservationValidator))]
    public class Reservation
    {
        /// <summary>
        /// Identyfikator
        /// </summary>
        [Display(Name = "Identyfikator")]
        public int? Id { get; set; }

        /// <summary>
        /// Nazwisko klienta
        /// </summary>
        [Display(Name = "Klient")]
        public string ClientName { get; set; }

        /// <summary>
        /// Opis
        /// </summary>
        [Display(Name = "Dodatkowy opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Początek rezerwacji
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        [Display(Name = "Początek rezerwacji (dd.mm.yyyy hh:mm)")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Koniec rezerwacji
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        [Display(Name = "Koniec rezerwacji (dd.mm.yyyy hh:mm)")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Typ rezerwacji
        /// </summary>
        [Display(Name = "Typ rezerwacji")]
        public ReseravtionType? ReseravtionType { get; set; }

        /// <summary>
        /// Rezerwowany stół
        /// </summary>
        [Display(Name = "Rezerwowany stół")]
        public virtual Table Table { get; set; }

        /// <summary>
        /// Wybrany numer stołu
        /// </summary>
        public int? TableNumber { get; set; }

        /// <summary>
        /// Nazwa wydarzenia
        /// </summary>
        [NotMapped]
        public string EventName { get; set; }
    }

    

    public enum ReseravtionType
    {
        [Description("Stół")]
        Stół,
        [Description("Sala")]
        Sala,
        [Description("Impreza")]
        Impreza,
        [Description("Inne")]
        Inne
    }
}