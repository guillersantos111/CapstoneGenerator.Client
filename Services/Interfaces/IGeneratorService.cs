using CapstoneGenerator.Client.Models.DTO;

namespace CapstoneGenerator.Client.Services.Interfaces
{
    public interface IGeneratorService
    {
        Task<IEnumerable<string>> GetAllCategories();
        Task<CapstonesDTO> GetByCategoryOrGenerateIdea(string category);
    }
}
