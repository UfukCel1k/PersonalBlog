using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        //Mesajların yönlendirmesini id'ye göre yapıyoruz.
        public int MessageID { get; set; }

        //Gönderen kişi
        [StringLength(50)]
        public string SenderMail { get; set; }

        //Alıcı kişi
        [StringLength(50)]
        public string ReceiverMail { get; set; }

        //Konu
        [StringLength(100)]
        public string Subject { get; set; }

        //Mesaj içeriği
        public string MessageContent { get; set; }

        //Mesaj tarihi
        public DateTime MessageDate { get; set; }
    }
}
