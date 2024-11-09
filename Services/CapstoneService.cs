using CapstoneGenerator.Client.Services.Interfaces;
using System.Net.Http.Json;
using CapstoneGenerator.Shared.Models;
namespace CapstoneGenerator.Client.Services
{
    public class CapstoneService : ICapstoneService
    {
        private readonly HttpClient httpClient;

        public CapstoneService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private List<CapstonesDTO> Capstones = new();


        public async Task<IEnumerable<CapstonesDTO>> GetAllCapstones()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<CapstonesDTO>>("/api/Capstone") ?? new List<CapstonesDTO>();
        }


        public async Task<CapstonesDTO> GetCapstoneById(int Id)
        {
            return await httpClient.GetFromJsonAsync<CapstonesDTO>($"/api/Capstone/{Id}");
        }


        public async Task AddCapstone(CapstonesDTO capstones)
        {
            var response = await httpClient.PostAsJsonAsync("/api/Capstone", capstones);
            response.EnsureSuccessStatusCode();
        }


        public async Task UpdateCapstone(int Id, CapstonesDTO capstones)
        {
            var response = await httpClient.PutAsJsonAsync($"/api/Capstone/{Id}", capstones);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveCapstone(int Id)
        {
            var response = await httpClient.DeleteAsync($"/api/Capstone/{Id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
