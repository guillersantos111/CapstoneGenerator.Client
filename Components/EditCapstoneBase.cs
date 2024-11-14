using CapstoneGenerator.Client.Models.DTO;
using CapstoneGenerator.Client.Pages.CapstonePage;
using CapstoneGenerator.Client.Services.Interfaces;
using CapstoneGenerator.Models.DTO;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CapstoneGenerator.Client.Components
{
    public class EditCapstoneBase : ComponentBase
    {
        [Parameter] public CapstonesDTO capstones { get; set; } = new CapstonesDTO();

        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        [Inject] private ICapstoneService CapstoneService { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }

        public async Task Save()
        {
            if (capstones != null)
            {
                if (capstones.CapstoneId == 0)
                {
                    await CapstoneService.AddCapstone(capstones);
                }
                else
                {
                    await CapstoneService.UpdateCapstone(capstones.CapstoneId, capstones);
                }
            }
            else
            {
                Snackbar.Add("Error: Capstone Not Found", Severity.Error);
            }

            MudDialog.Close(DialogResult.Ok(true));
        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }
    }
}