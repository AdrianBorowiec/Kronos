using FluentValidation.Attributes;
using Kronos.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kronos.Models
{
    [Validator(typeof(UserValidator))]
    public class User
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
}