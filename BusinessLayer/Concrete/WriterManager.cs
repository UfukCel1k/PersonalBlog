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
    public class WriterManager : IWriterService
    {
        //ICategoryDal dan bir _categoryDal ismine bir field türet.
        IWriterDal _writerDal;

        //Constructor metodunu hazır getirmek için WriterManager üzerine (ctrl + .) yaptıktan sonra (Generate constructor) seçiyoruz. Çıkan ekran ok diyerek constructor ı oluştutyoruz.
        public WriterManager(IWriterDal writerDal)
        {
            // _writerDal a ICategoryDal dan başka categoryDal değerinin ataması gerçekleşmiş oldu.
            _writerDal = writerDal;
        }


        public Writer GetByID(int id)
        {
            //_writerDal sınıfı GenericRepository deki değerleri alıyor.
            //x öyleki WriterID id'den gelen değere eşit olmalı.
            return _writerDal.Get(x => x.WriterID == id);
        }

        //Listeleme işlemi
        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        //Yazar Ekleme işlemi için insert kullanıyoruz.
        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        //Silme işlemi için yazılan metod.
        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        //Güncelleme işlemi için metodu dolduruyoruz.
        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
