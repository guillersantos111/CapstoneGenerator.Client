using CapstoneGenerator.Client.Models.DTO;
using CapstoneGenerator.Client.Services.Interfaces;
using CapstoneGenerator.Models.DTO;
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
        public bool isLoading { get; set; } = false;
        public bool isGenerated = false;


        protected override async Task OnInitializedAsync()
        {
            try
            {
                isLoading = true;
                categories = await generatorService.GetAllCategories();
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Error Fetching Categories: {ex.Message}", Severity.Error);
            }
            finally
            {
                isLoading = false;
            }
        }


        public async Task GenerateIdea()
        {
            if (string.IsNullOrEmpty(selectedCategory))
            {
                Snackbar.Add("Please Select A Category", Severity.Warning);
                return;
            }
            else if (isIdeaGenerated && selectedCategory == generatedCapstone?.Categories)
            {
                return;
            }

            try
            {
                isLoading = true;
                isGenerated = true;
                generatedCapstone = await generatorService.GetByCategoryOrGenerateIdea(selectedCategory!);
                isIdeaGenerated = true;
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Error Generating Idea: {ex.Message}", Severity.Error);
            }
            finally
            {
                isLoading = false;
            }
        }


        public async Task NextIdea()
        {
            try
            {
                isGenerated = true;
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
