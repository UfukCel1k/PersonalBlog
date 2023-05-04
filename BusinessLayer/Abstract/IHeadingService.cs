using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        //Başlıkları listelememizi sağlar.
        //İsmine GetList koyuyoruz.
        List<Heading> GetList();

        //Yazara göre listeyi getirecek.
        List<Heading> GetListByWriter(int id);

        //Başlık ekleme yapmamızı sağlar.
        //Başlıktan bir başlık parametresi alıcak.
        void HeadingAdd(Heading heading);

        //Silme işlemi ID e göre yapmamızı sağlar.
        //GetByID id ye göre değişken alıcak.
        Heading GetByID(int id);

        //Silme işlemi yapmamızı sağlar.
        void HeadingDelete(Heading heading);

        //Güncelleme işlemi yapmamızı sağlar.
        void HeadingUpdate(Heading heading);
    }
}
