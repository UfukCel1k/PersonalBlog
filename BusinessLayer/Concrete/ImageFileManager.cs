using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _ImageFileDal;

        //Constructor metodunu hazır getirmek için ImageFileManager üzerine (ctrl + .) yaptıktan sonra (Generate constructor) seçiyoruz. Çıkan ekran ok diyerek constructor ı oluştutyoruz.
        public ImageFileManager(IImageFileDal ımageFileDal)
        {
            _ImageFileDal = ımageFileDal;
        }

        public List<ImageFile> GetList()
        {
            return _ImageFileDal.List();
        }
    }
}
