using CapstoneGenerator.Client.Services.Interfaces;
using CapstoneGenerator.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CapstoneGenerator.Client.Pages.GeneratorPage
{
    public class GeneratorBase : ComponentBase
    {
        [Inject] private IGeneratorService generatorService { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }

        public IEnumerable<string> categories { get; private set; } = new List<string>();
        public string? selectedCategory;
        public CapstonesDTO? generatedCapstone;
        public bool isIdeaGenerated = false;


        protected override async Task OnInitializedAsync()
        {
            try
            {
                categories = await generatorService.GetAllCategories();
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
                generatedCapstone = await generatorService.GetByCategoryOrGenerateIdea(selectedCategory!);
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Error Generating Idea: {ex.Message}", Severity.Error);
            }
        }


        public async Task NextIdea()
        {
            if (generatedCapstone == null)
            {
                Snackbar.Add($"Please Generate Idea First", Severity.Warning);
                return;
            }
            try
            {
                generatedCapstone = await generatorService.GetByCategoryOrGenerateIdea(selectedCategory!);
                StateHasChanged();
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Error Generating Next Idea: {ex.Message}", Severity.Error);
            }
        }

    }
}
