using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContetID { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }

        public DateTime ContentDate { get; set; }

        public bool ContentStatus { get; set; }

        //Oluşturacağımız ilişkili tablonun anahtar sütunuyla aynısını veriyoruz.
        //Hangi Başığı getireceksek onun ID si yazılır.
        public int HeadingID { get; set; }  

        public bool HeadingStatus { get; set; }

        //İlgili sınıftan değer alarak ve Category türünde bir property tanımlanıyor.
        //İlişki alanındaki CategoryID ile HeadingID eşitlenecek.
        //Burada CategoryID ile HeadingID arasında tam anlamıyla bir ilişki kuruluyor
        //Heading tablosunda heading türünden bir property tanımlamış olduk 
        public virtual Heading Heading { get; set; }

       
        //Yazarlarların yazılarını görebilmek için aşagıdakini yazıyoruz.
        //Temel sınıftan türetilmiş sınıflara aktarılan metotları her zaman olduğu gibi kullanmak istemeyebiliriz. Bu metotları türetilmiş sınıfın içerisinden yeniden tanımlayabilmek için virtual ve override anahtar sözcüklerini kullanırız. Virtual metotlar Inheritance(Kalıtım) yoluyla aktarıldıkları sınıfların içerisinden override edilerek değiştirilebilirler.Eğer override edilmezlerse temel sınıf içerisinde tanımladıkları şekilde çalışırlar.virtual anahlarını atadığımız metot sanal olur ve aynı isimde farklı bir metot tarafından override edilebilir.
        //Boş bırakılabilen tip olduğu için başına int veriyoruz.
        //Hangi yazar oluşturduysa onun Id gelir
        public int? WriterID { get; set; }
        public virtual Writer Writer{ get; set; }
    }
}
