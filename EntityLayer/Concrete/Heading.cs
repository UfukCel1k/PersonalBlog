using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }

        public DateTime HeadingDate{ get; set;}

        //Oluşturacağımız ilişkili tablonun anahtar sütunuyla aynısını veriyoruz CategoryID
        //Hangi kategoriyi başlığını vereceksek onun ID si yazılır.
        public int CategoryID { get; set; }

        //İlişki alanındaki CategoryID ile HeadingID eşitlenecek.
        //Burada CategoryID ile HeadingID alasında tam anlamıyla ilişki kuruluyor
        public virtual Category Category { get; set; }

        public bool HeadingStatus { get; set; }

        //Content ve Heading tablosu arasında ilişki kuruluyor.
        //Hangi sınıfla ilişkili olunacaksa ICollection<> içeisine o sınıf yazılır.
        public ICollection<Content> Contets { get; set; }

        //Başlığı açan kişinin Id sini görebilmek için aşağıdakileri yapıyoruz
        //Temel sınıftan türetilmiş sınıflara aktarılan metotları her zaman olduğu gibi kullanmak istemeyebiliriz. Bu metotları türetilmiş sınıfın içerisinden yeniden tanımlayabilmek için virtual ve override anahtar sözcüklerini kullanırız. Virtual metotlar Inheritance(Kalıtım) yoluyla aktarıldıkları sınıfların içerisinden override edilerek değiştirilebilirler.Eğer override edilmezlerse temel sınıf içerisinde tanımladıkları şekilde çalışırlar.virtual anahlarını atadığımız metot sanal olur ve aynı isimde farklı bir metot tarafından override edilebilir.
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
 