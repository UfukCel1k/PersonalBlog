using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    //EfCategoryDal, GenericRepository içerisindeki Category sınıfında yer alan komutu kullanıcak.
    //GenericRepository<Category> yanına ICategoryDal yazıyoruz. Çünkü ICategoryDal daki değerleride çekmek istiyoruz.
    public class EfCategoryDal:GenericRepository<Category>,ICategoryDal
    {
    }
}
