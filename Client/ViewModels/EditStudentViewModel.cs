using System;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class EditStudentViewModel : ViewModelBase
{
    private readonly IStudentService _studentService;
    private string _studentId { get; set; } = string.Empty;
    private string _objectId { get; set; } = string.Empty;

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
    public partial Address Address { get; set; } = new() { AddressLine = string.Empty, PostalCode = string.Empty, City = string.Empty };


    public EditStudentViewModel()
    {
        PageTitle = "Uppdatera student";
    }

    public EditStudentViewModel(IStudentService studentService, string studentId)
    {
        _studentService = studentService;
        PageTitle = "Uppdatera: " + FirstName + " " + LastName;
        _studentId = studentId;
        Init();
    }

    private async void Init()
    {
        await GetStudent();
    }


    private async Task GetStudent()
    {
        try
        {
            var student = await _studentService.Find(_studentId);

            _objectId = student._id;

            PersonNumber = student.PersonNumber;
            FirstName = student.FirstName;
            LastName = student.LastName;
            Email = student.Email;
            PhoneNumber = student.PhoneNumber;
            Address = student.Address;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [RelayCommand]
    public async Task Save()
    {
        Student student = new()
        {
            PersonNumber = PersonNumber,
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            Address = Address
        };

        await _studentService.Update(student, _objectId);
    }

}
