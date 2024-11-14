using CapstoneGenerator.Client.Models.DTO;

namespace CapstoneGenerator.Client.Services.Interfaces
{
    public interface ICapstoneService
    {
        Task<IEnumerable<CapstonesDTO>> GetAllCapstones();
        Task<CapstonesDTO> GetCapstoneById(int id);
        Task AddCapstone(CapstonesDTO capstones);
        Task UpdateCapstone(int id, CapstonesDTO capstones);
        Task RemoveCapstone(int id);
    }
}
