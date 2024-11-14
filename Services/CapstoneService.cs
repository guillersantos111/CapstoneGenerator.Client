using CapstoneGenerator.Client.Services.Interfaces;
using System.Net.Http.Json;
using CapstoneGenerator.Client.Models.DTO;
namespace CapstoneGenerator.Client.Services
{
    public class CapstoneService : ICapstoneService
    {
        private readonly HttpClient httpClient;

        public CapstoneService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private List<CapstonesDTO> CapstonesDTOs = new();


        public async Task<IEnumerable<CapstonesDTO>> GetAllCapstones()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<CapstonesDTO>>("/api/Capstone") ?? new List<CapstonesDTO>();
        }


        public async Task<CapstonesDTO> GetCapstoneById(int id)
        {
            return await httpClient.GetFromJsonAsync<CapstonesDTO>($"/api/Capstone/{id}");
        }


        public async Task AddCapstone(CapstonesDTO capstones)
        {
            var response = await httpClient.PostAsJsonAsync("/api/Capstone", capstones);
            response.EnsureSuccessStatusCode();
        }


        public async Task UpdateCapstone(int id, CapstonesDTO capstones)
        {
            var response = await httpClient.PutAsJsonAsync($"/api/Capstone/{id}", capstones);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveCapstone(int id)
        {
            var response = await httpClient.DeleteAsync($"/api/Capstone/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
