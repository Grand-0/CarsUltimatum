using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository.ImageRepository
{
    public class ImagesRepository : IImageRepository
    {
        private readonly CarsUltimatedb _db;
        public ImagesRepository(CarsUltimatedb db)
        {
            _db = db;
        }

        public void Add(IEnumerable<Image> images)
        {
            _db.Images.AddRange(images);
        }

        public void Delete(int carId)
        {
            IEnumerable<Image> images = _db.Images.Where(i => i.CarID == carId).ToList();
            _db.Images.RemoveRange(images);
        }

        public Image GetImageByID(int id)
        {
            return _db.Images.Find(id);
        }

        public IEnumerable<Image> GetImagesByCar(int carId)
        {
            return _db.Images.Where(i => i.CarID == carId);
        }

        public void Update(Image image)
        {
            _db.Entry(image).State = EntityState.Modified;
        }

        public void Update(IEnumerable<Image> images)
        {
            foreach(Image i in images)
            {
                _db.Entry(i).State = EntityState.Modified;
            }
        }
    }
}
