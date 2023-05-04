using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //Repository için oluşacak temel interface. 
    //IRepository<T> ye T değerini göderiyoruz çünkü burdaki T değeri bizim type mız oluyor ve bir entity i karşılıyor, hangi entity getirmek istiyorsak, sql den o entityi bu şekilde getirebiliriz.
    public interface IRepository<T>
    { 
        //List içerisine T den gelen değeri çağırıyoruz
        List<T> List();

        //Eklemek için T den parametre alıyoruz.
        void Insert (T p);

        //Get isminde metod tanımlıyoruz
        T Get(Expression<Func<T, bool>> filter);

        //Silmek için T den parametre alıyoruz.
        void Delete (T p);

        //Güncellemek için T den parametre alıyoruz.
        void Update (T p);

        //Verileri filtreleme için kullanacağımız metod.
        //Aşağıda yapılan işlem de şartlı listeleme yapılıyor.Bizim istediğimiz ifadedeki değerleri getirmemizi sağlıyor.
        //Bu yaptığımız metod ile diğer interfacelerde yapmış olduğumuz IRepository<> kalıtım ı ile aynı filtreleme şartı, oradaki interfaceler için de uygulanmış oldu.Yani IRepository<> içinde  ne varsa diğerlerinin içinde de o var.
        //Syntax kuralı aşağıdaki gibidir.Filter bir isimdir farklı bir isimde verebilirdik
        List<T> List (Expression<Func<T,bool>> filter);
    }
}
