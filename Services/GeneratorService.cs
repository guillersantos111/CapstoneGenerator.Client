using CapstoneGenerator.Client.Services.Interfaces;
using CapstoneGenerator.Client.Models.DTO;
using System.Net.Http.Json;

namespace CapstoneGenerator.Client.Services
{
    public class GeneratorService : IGeneratorService
    {
        private readonly HttpClient httpClient;

        public GeneratorService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<string>> GetAllCategories()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<string>>("/api/Generator/categories");
        }

        public async Task<CapstonesDTO> GetByCategoryOrGenerateIdea(string category)
        {
            return await httpClient.GetFromJsonAsync<CapstonesDTO>($"/api/Generator/idea/{category}");
        }
    }
}
