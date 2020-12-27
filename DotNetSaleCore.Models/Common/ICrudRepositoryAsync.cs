using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetSaleCore.Models
{
    /// <summary>
    /// Generic Repository Interface
    /// </summary>
    public interface ICrudRepositoryAsync<T>
    {
        Task<T> AddAsync(T model);     // 입력
        Task<List<T>> GetAllAsync();   //출력
        Task<T> GetAsync(int id);      // 상세 
        Task<bool> EditAsync(T model); // 수정 
        Task<bool> DeleteAsync(int id); // 삭제

    }


}
