using CapstoneGenerator.Client.Services.Contracts;
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


        public async Task<IEnumerable<CapstonesDTO>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<CapstonesDTO>>("/api/Capstone") ?? new List<CapstonesDTO>();
        }


        public async Task<CapstonesDTO> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<CapstonesDTO>($"/api/Capstone/{id}");
        }


        public async Task Add(CapstonesDTO capstones)
        {
            var response = await httpClient.PostAsJsonAsync("/api/Capstone", capstones);
            response.EnsureSuccessStatusCode();
        }


        public async Task Update(int id, CapstonesDTO capstones)
        {

            var response = await httpClient.PutAsJsonAsync($"/api/Capstone/{id}", capstones);
            response.EnsureSuccessStatusCode();
        }

        public async Task Remove(int id)
        {
            var response = await httpClient.DeleteAsync($"/api/Capstone/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
