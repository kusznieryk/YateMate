using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace YateMate.Components.Account.Pages;

public class CustomValidator : ComponentBase
{
    private ValidationMessageStore _messageStore;

    [CascadingParameter]
    public EditContext CurrentEditContext { get; set; } = null!;

    protected override void OnInitialized()
    {
        if (CurrentEditContext == null)
        {
            throw new InvalidOperationException("To use validator component your razor page should have the edit component");
        }
        _messageStore = new ValidationMessageStore(CurrentEditContext);
        CurrentEditContext.OnValidationRequested += (s, e) => _messageStore.Clear();
        CurrentEditContext.OnFieldChanged += (s, e) => _messageStore.Clear(e.FieldIdentifier);
    }

    public void DisplayErrors(Dictionary<string, List<string>> errors)
    {
        foreach (var error in errors)
        {
            _messageStore.Add(CurrentEditContext.Field(error.Key), error.Value);
        }
        CurrentEditContext.NotifyValidationStateChanged();
    }
}