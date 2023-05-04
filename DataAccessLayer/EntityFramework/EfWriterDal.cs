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
    //EFWriterDal, GenericRepository içerisindeki Writer sınıfında yer alan komutu kullanıcak.
    //GenericRepository<Writer> yanına IWriterDal yazıyoruz. Çünkü IWriterDal daki değerleride çekmek istiyoruz.
    public class EFWriterDal : GenericRepository<Writer>, IWriterDal
    {
    }
}
