using ApiProjectKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjectKampi.WebApi.ValidationRules
{
    public class ProductValidatior : AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Alanı Boş Geçilemez")
                .GreaterThan(0).WithMessage("Ürün Fiyatı 0'dan Büyük Olmalı.").
                LessThan(1000).WithMessage("Ürün Fiyatı 1000'den Küçük Olmalı.");

            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün Adı Minimum 2 Karakter İçermelidir.");
            RuleFor(x => x.ProductName).MaximumLength(100).WithMessage("Ürün Adı Maximum 100 Karakter İçermelidir.");
            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün Açıklaması Boş Geçilemez");
        }
    }
}
