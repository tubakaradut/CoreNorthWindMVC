using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUIMVC.Models;

namespace WebUIMVC.ValidationRules.FluentValidation
{
    public class ShippingDetailValidator: AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Adı Gereklidir!");
            RuleFor(x => x.FirstName).MinimumLength(2);
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyadı Gereklidir!");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres Gereklidir!");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Gereklidir!");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Yaş Gereklidir!");
            RuleFor(x => x.City).NotEmpty().When(x => x.Age < 18).WithMessage("Şehir Gereklidir!");
           
        }
    }
}
