using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        //İçerikleri listelememizi sağlar.
        List<Content> GetList(string p);

        //Yazara göre içerikleri getir.
        List<Content> GetListByWriter(int id);

        //Id'ye göre bize tüm listeyi döndürür.
        List<Content> GetListByHeadingID(int id);  

        //İçerik ekleme yapmamızı sağlar.
        //Content den bir kategori parametresi alıcak.
        void ContentAdd(Content content);

        //Silme işlemi ID e göre yapmamızı sağlar.
        //GetByID id ye göre değişken alıcak.,
        //GetByID sadece tek değer döndürür.
        Content GetByID(int id);

        //Silme işlemi yapmamızı sağlar.
        void ContentDelete(Content content);

        //Güncelleme işlemi yapmamızı sağlar.
        void ContentUpdate(Content content);
    }
}
