using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        //Mesajları listelememizi sağlar.
        List<Contact> GetList();

        //Mesaj ekleme yapmamızı sağlar.
        void ContactAdd(Contact contact);

        //Silme işlemi ID e göre yapmamızı sağlar.
        //GetByID id ye göre değişken alıcak.
        Contact GetByID(int id);

        //Silme işlemi yapmamızı sağlar.
        void ContactDelete(Contact contact);

        //Güncelleme işlemi yapmamızı sağlar.
        void ContactUpdate(Contact contact);
    }
}
