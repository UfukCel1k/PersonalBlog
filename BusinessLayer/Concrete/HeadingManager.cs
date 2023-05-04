using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    //HeadingManager interfacenin de tanımlı metodları kalıtsal yollarla çağırıyoruz..
    public class HeadingManager : IHeadingService
    {
        //IHeadingDal dan bir _headingdal ismine bir field türet.
        IHeadingDal _headingdal;

        //Constructor metodunu hazır getirmek için HeadingManager üzerine (ctrl + .) yaptıktan sonra (Generate constructor) seçiyoruz. Çıkan ekran ok diyerek constructor ı oluştutyoruz.
        public HeadingManager(IHeadingDal headingdal)
        {
            _headingdal = headingdal;
        }

        public Heading GetByID(int id)
        {
            //_headingdal sınıfı GenericRepository deki değerleri alıyor.
            //x öyleki HeadingID id'den gelen değere eşit olmalı.
            return _headingdal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingdal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingdal.List(x => x.WriterID == id);
        }

        //Ekleme işlemi için insert kullanıyoruz.
        public void HeadingAdd(Heading heading)
        {
            _headingdal.Insert(heading);
        }

        //Silme işlemi için yazılan metod.
        public void HeadingDelete(Heading heading)
        {
            _headingdal.Update(heading);
        }

        //Güncelleme işlemi için metodu dolduruyoruz.
        public void HeadingUpdate(Heading heading)
        {
            _headingdal.Update(heading);
        }
    }
}
