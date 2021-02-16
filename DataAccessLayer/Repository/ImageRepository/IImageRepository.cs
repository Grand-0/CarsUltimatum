using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository.ImageRepository
{
    public interface IImageRepository
    {
        void Add(IEnumerable<Image> images);
        void Delete(int carId);
        void Update(IEnumerable<Image> images);
        void Update(Image image);

        Image GetImageByID(int id);
        IEnumerable<Image> GetImagesByCar(int carId);
    }
}
