using AutoMapper;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.ModelsDTO;
using DataAccessLayer.Repository.UnitOfWork;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.CarClass
{
    public class CarClassService : ICarClassService
    {
        private IUnitOfWork Database;
        private IMapper _mapper;
        public CarClassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<CarClassDTO> GetAllClass()
        {
            return _mapper.Map<IEnumerable<CarClassDTO>>(Database.CarClassesRepository.GetAll());
        }

        public CarClassDTO GetCarClass(int id)
        {
            CarClassDTO classDTO = _mapper.Map<CarClassDTO>(Database.CarClassesRepository.GetClassByID(id));
            
            if(classDTO == null)
            {
                throw new ValidationException("Класса с таким ключом не существует", "");
            }

            return classDTO; 
        }
    }
}
