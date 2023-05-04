using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        //Kategorileri listelememizi sağlar.
        List<Category> GetList();

        //Kategori ekleme yapmamızı sağlar.
        void CategoryAddBL(Category category);

        //Silme işlemi ID e göre yapmamızı sağlar.
        //GetByID, id ye göre değişken alıcak.
        Category GetByID(int id);   

        //Silme işlemi yapmamızı sağlar.
        void CategoryDelete(Category category);

        //Güncelleme işlemi yapmamızı sağlar.
        void CategoryUpdate(Category category);
    }
}
