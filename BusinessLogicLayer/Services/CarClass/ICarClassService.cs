using BusinessLogicLayer.ModelsDTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.CarClass
{
    public interface ICarClassService
    {
        CarClassDTO GetCarClass(int id);
        IEnumerable<CarClassDTO> GetAllClass(); 
    }
}
