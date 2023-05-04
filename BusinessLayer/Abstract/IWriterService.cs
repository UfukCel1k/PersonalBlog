using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        //Yazarı listelememize yarar.
        //İsmine GetList koyuyoruz.
        List<Writer> GetList();

        //Yazar eklemmizi sağlar sağlar.
        //Kategoriden bir kategori parametresi alıcak.
        void WriterAdd(Writer writer);

        //Silme işlemi yapmamızı sağlar.
        void WriterDelete(Writer writer);

        //Güncelleme işlemi yapmamızı sağlar.
        void WriterUpdate(Writer writer);

        //Yazar silme işlemi için ID değerini getirme işlemi
        //GetByID id ye göre değişken alıcak.
        Writer GetByID(int id);
    }
}
