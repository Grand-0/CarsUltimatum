using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using DataAccessLayer.Repository.UnitOfWork;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Image
{
    public class ImageService : IImageService
    {
        private IUnitOfWork Database;
        private IMapper _mapper;
        public ImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<string> GetImagesPath(int carId)
        {
            IEnumerable<ImageDTO> images = _mapper.Map<IEnumerable<ImageDTO>>(Database.ImagesRepository.GetImagesByCar(carId));

            List<string> imagesPath = new List<string>();

            foreach(ImageDTO image in images)
            {
                imagesPath.Add(image.Path);
            }

            return imagesPath;
        }
    }
}
