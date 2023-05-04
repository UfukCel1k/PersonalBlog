using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        //Kategorileri listelememizi sağlar.
        List<Admin> GetList();

        //Kategori ekleme yapmamızı sağlar.
        void AdminAdd(Admin Admin);

        //Silme işlemi ID e göre yapmamızı sağlar.
        //GetByID, id ye göre değişken alıcak.
        Admin GetByID(int id);

        //Silme işlemi yapmamızı sağlar.
        void AdminDelete(Admin Admin);

        //Güncelleme işlemi yapmamızı sağlar.
        void AdminUpdate(Admin Admin);
    }
}
