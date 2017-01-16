﻿using FluentValidation.Attributes;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public string ClientName { get; set; }

        /// <summary>
        /// Opis
        /// </summary>
        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Początek rezerwacji
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        [Display(Name = "Początek pracy (dd.mm.yyyy hh.mm)")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Koniec rezerwacji
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        [Display(Name = "Koniec pracy (dd.mm.yyyy hh.mm)")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Typ rezerwacji
        /// </summary>
        [Display(Name = "Typ rezerwacji")]
        public ReseravtionType? ReseravtionType { get; set; }

        /// <summary>
        /// Rezerwowany stół
        /// </summary>
        public virtual Table Table { get; set; }
    }

    public enum ReseravtionType
    {
        [Description("Stół")]
        Stol,
        [Description("Sala")]
        Sala,
        [Description("Impreza")]
        Impreza,
        [Description("Inne")]
        Inne
    }
}