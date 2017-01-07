using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Validators;
using System.Reflection;

namespace Kronos.Infrastructure
{
    /// <summary>
    /// Sprawdzanie unikalności w bazie danych.
    /// 
    /// http://www.damirscorner.com/blog/posts/20140519-EnsuringUniquePropertyValueUsingFluentValidation.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UniqueValidator<T> : PropertyValidator
      where T : class
    {
        private readonly IEnumerable<T> _items;

        public UniqueValidator(IEnumerable<T> items)
          : base("Podana pozycja \"{PropertyName}\" już istnieje z bazie danych.")
        {
            _items = items;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var editedItem = context.Instance as T;
            var newValue = context.PropertyValue as string;
            var property = typeof(T).GetTypeInfo().GetDeclaredProperty(context.PropertyName);
            return _items.All(item =>
              item.Equals(editedItem) || property.GetValue(item).ToString() != newValue);
        }
    }
}