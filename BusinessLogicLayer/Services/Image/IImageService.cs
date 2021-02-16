using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Image
{
    public interface IImageService
    {
        IEnumerable<string> GetImagesPath(int carId);
    }
}