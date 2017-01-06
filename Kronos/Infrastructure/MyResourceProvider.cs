using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace Kronos.Infrastructure
{
    public class MyResourceProvider
    {
        public static string notempty_error
        {
            get
            {
                return "Pole \"{PropertyName}\" nie może być puste.";
            }
        }

        public static string greaterthanorequal_error
        {
            get
            {
                return "Wartość pola \"{PropertyName}\" musi być większa lub równa {ComparisonValue}.";
            }
        }

        public static string greaterthan_error
        {
            get
            {
                return "Wartość pola \"{PropertyName}\" musi być większa niż {ComparisonValue}.";
            }
        }

        public static string lessthanorequal_error
        {
            get
            {
                return "Wartość pola \"{PropertyName}\" musi być mniejsza lub równa {ComparisonValue}.";
            }
        }

        public static string lessthan_error
        {
            get
            {
                return "Wartość pola \"{PropertyName}\" musi być mniejsza niż {ComparisonValue}.";
            }
        }
    }
}