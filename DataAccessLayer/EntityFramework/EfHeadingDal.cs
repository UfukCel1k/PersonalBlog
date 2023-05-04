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
    //EfHeadingDal, GenericRepository içerisindeki Heading sınıfında yer alan komutu kullanıcak.
    //GenericRepository<Heading> yanına IHeadingDal yazıyoruz. Çünkü IHeadingDal daki değerleride çekmek istiyoruz.
    public class EfHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
    }

}

