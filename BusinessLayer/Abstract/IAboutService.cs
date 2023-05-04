using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        //Hakkında listelememizi sağlar.
        List<About> GetList();

        //Hakkında kısmına ekleme yapmamızı sağlar.
        void AboutAdd(About about);

        //Silme işlemi ID e göre yapmamızı sağlar.
        //GetByID id ye göre değişken alıcak.
        About GetByID(int id);

        //Silme işlemi yapmamızı sağlar.
        void AboutDelete(About about);

        //Güncelleme işlemi yapmamızı sağlar.
        void AboutUpdate(About about);
    }
}
