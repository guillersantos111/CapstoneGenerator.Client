using CapstoneGenerator.Client.Services.Interfaces;
using CapstoneGenerator.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CapstoneGenerator.Client.Presentations.Pages.GeneratorPage
{
    public class GeneratorBase : ComponentBase
    {
        public IEnumerable<string> Categories { get; private set; } = new List<string>();

        [Inject] private IGeneratorService generatorService { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }
        public bool IsLoading { get; set; } = false;
        


        private string selectedCategory;

        private CapstonesDTO generatedCapstone;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Categories = await generatorService.GetAllCategories();
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Error Fetching Categories: {ex.Message}", Severity.Error);
            }
        }


        public async Task GenerateIdea()
        {
            if (string.IsNullOrEmpty(selectedCategory))
            {
                Snackbar.Add("Please Select A Category", Severity.Warning);
                return;
            }

            try
            {
                generatedCapstone = await generatorService.GetByCategoryOrGenerateIdea(selectedCategory);

                Snackbar.Add($"Generated Idea: {generatedCapstone?.Description}", Severity.Success);
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Error Generating Idea: {ex.Message}", Severity.Error);
            }
        }
    }
}
