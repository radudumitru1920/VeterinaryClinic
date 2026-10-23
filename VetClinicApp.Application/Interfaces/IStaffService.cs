
using VetClinicApp.Application.Dtos;
using VetClinicApp.Domain.Entities;
using VetClinicApp.Domain.Enums;

namespace VetClinicApp.Application.Interfaces
{

        public interface IStaffService
    {
         
         Task<List<MedicDto>> GetAllMedicsAsync (Role role);

    }

}