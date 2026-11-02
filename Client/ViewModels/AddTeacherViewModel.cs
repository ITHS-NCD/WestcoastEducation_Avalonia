using System;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddTeacherViewModel : ViewModelBase
{
    private readonly ITeacherService _teacherService;

    [ObservableProperty]
    public partial string PersonNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string FirstName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string LastName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Email { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string PhoneNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string AddressLine { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string PostalCode { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string City { get; set; } = string.Empty;


    public AddTeacherViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
        PageTitle = "Lägg till en lärare";
    }

    [RelayCommand]
    private async Task Save()
    {
        Teacher teacher = new()
        {
            PersonNumber = PersonNumber,
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            Address = new Address { AddressLine = AddressLine, PostalCode = PostalCode, City = City }
        };

        await _teacherService.Add(teacher);

        ClearData();
    }

    private void ClearData()
    {
        PersonNumber = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        PhoneNumber = string.Empty;
        AddressLine = string.Empty;
        PostalCode = string.Empty;
        City = string.Empty;
    }
}
