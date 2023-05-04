using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        //Validator sınıfları içerisinde kullanacağımız.Doğrulama kurallarını bir constructor metodun içerisine yazacağız.
        public WriterValidator()
        {
            //Kuralları oluşturabilmemiz için (RuleFor) komutunu kullanıyoruz.
            //(x.) dedikten sonra AbstractValidator içerine göndermiş olduğumuz T entitisine ait propertylere erişim sağlıyabiliyoruz.
            //RuleFor(x => x.CategoryName) den sonra nokta koyarsak kullanabileceğimiz kural propertyleri görmüş oluruz.
            //NotEmpty() = Boş bırakılamaz kuralı
            //WithMessage() = Kullanıcıya yansıtacağımız mesaj.
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");

            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz.");

            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz.");

            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmını boş geçemezsiniz.");

            //MinimumLength() = Minimum karater sınırını belirliyoruz.
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");

            //MaximumLength() = Maximum karater sınırını belirliyoruz.
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Lütfen 50 karakterden fazla giriş yapmayınız.");
        }
    }
}
