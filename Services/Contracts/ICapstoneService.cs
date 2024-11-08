using CapstoneGenerator.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CapstoneGenerator.Client.Services.Contracts
{
    public interface ICapstoneService
    {
        Task<IEnumerable<CapstonesDTO>> GetAll();
        Task<CapstonesDTO> GetById(int id);
        Task Add(CapstonesDTO capstones);
        Task Update(int id, CapstonesDTO capstones);
        Task Remove(int id);
    }
}
