using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.DTO.Patients;

namespace Application.Patient
{
    public interface IPatientRepository
    {
        //  Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<PatientDTO>> GetAllPatients();
        //Task<int> AddAsync(T entity);
        //Task<int> UpdateAsync(T entity);
        //Task<int> DeleteAsync(int id);

    }
}
