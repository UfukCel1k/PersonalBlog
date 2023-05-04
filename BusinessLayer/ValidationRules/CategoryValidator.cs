using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    //CategoryValidatior da Category için gerekli olan doğrulama kurallarını yazıcağız  .
    public class CategoryValidator:AbstractValidator<Category>
    {
        //Validator sınıfları içerisinde kullanacağımız.Doğrulama kurallarını bir constructor metodun içerisine yazacağız.
        public CategoryValidator()
        {
            //Kuralları oluşturabilmemiz için (RuleFor) komutunu kullanıyoruz.
            //(x.) dedikten sonra AbstractValidator içerine göndermiş olduğumuz T entitisine ait propertylere erişim sağlıyabiliyoruz.
            //RuleFor(x => x.CategoryName) den sonra nokta koyarsak kullanabileceğimiz kural propertyleri görmüş oluruz.
            //NotEmpty() = Boş bırakılamaz kuralı
            //WithMessage() = Kullanıcıya yansıtacağımız mesaj.
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz.");

            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz.");

            //MinimumLength() = Minimum karater sınırını belirliyoruz.
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");

            //MaximumLength() = Maximum karater sınırını belirliyoruz.
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla giriş yapmayınız.");
        }
    }
}
