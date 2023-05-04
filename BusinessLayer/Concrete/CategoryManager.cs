using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    //CategoryManager interfacenin de tanımlı metodları kalıtsal yollarla çağırıyoruz..
    public class CategoryManager : ICategoryService
    {
        //ICategoryDal dan bir _categoryDal ismine bir field türet.
        ICategoryDal _categoryDal;

        //Constructor metodunu hazır getirmek için CategoryManager üzerine (ctrl + .) yaptıktan sonra (Generate constructor) seçiyoruz. Çıkan ekran ok diyerek constructor ı oluştutyoruz.
        public CategoryManager(ICategoryDal categoryDal)
        {
            //_categoryDal a ICategoryDal dan başka categoryDal değerinin ataması gerçekleşmiş oldu. 
            _categoryDal = categoryDal;
        }

        //Ekleme işlemi için insert kullanıyoruz.
        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        //Silme işlemi için yazılan metod.
        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        //Güncelleme işlemi için metodu dolduruyoruz.
        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            //_categoryDal sınıfı GenericRepository deki değerleri alıyor.
            //x öyleki CategoryID id'den gelen değere eşit olmalı.
            return _categoryDal.Get(x => x.CategoryID== id);
        }

        //Listeleme işlemii.
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }


    }
}
        
