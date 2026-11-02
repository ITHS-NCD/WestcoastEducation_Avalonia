using System;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class EditTeacherViewModel : ViewModelBase
{
    private readonly ITeacherService _teacherService;
    private string _teacherId { get; set; } = string.Empty;
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


    public EditTeacherViewModel(ITeacherService teacherService, string teacherId)
    {
        _teacherService = teacherService;
        PageTitle = "Uppdatera: " + FirstName + " " + LastName;
        _teacherId = teacherId;
        Init();
    }

    private async void Init()
    {
        await GetTeacher();
    }


    private async Task GetTeacher()
    {
        try
        {
            var teacher = await _teacherService.Find(_teacherId);

            _objectId = teacher._id;

            PersonNumber = teacher.PersonNumber;
            FirstName = teacher.FirstName;
            LastName = teacher.LastName;
            Email = teacher.Email;
            PhoneNumber = teacher.PhoneNumber;
            Address = teacher.Address;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [RelayCommand]
    public async Task Save()
    {
        Teacher teacher = new()
        {
            PersonNumber = PersonNumber,
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            Address = Address
        };

        await _teacherService.Update(teacher, _objectId);
    }
}
