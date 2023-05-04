    using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListBox(string p);

        List<Message> GetListSendBox(string p);

        //Mesajlara ekleme yapmamızı sağlar.
        void MessageAdd(Message message);

        //Silme işlemi ID e göre yapmamızı sağlar.
        //GetByID id ye göre değişken alıcak.
        Message GetByID(int id);

        //Silme işlemi yapmamızı sağlar.
        void MessageDelete(Message message);

        //Güncelleme işlemi yapmamızı sağlar.
        void MessageUpdate(Message message);
    }
}
