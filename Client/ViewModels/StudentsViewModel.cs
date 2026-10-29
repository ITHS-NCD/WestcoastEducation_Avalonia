using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    private readonly IStudentService _studentService;
    private string id = string.Empty;

    [ObservableProperty]
    public partial bool ShowDialog { get; set; } = false;

    [ObservableProperty]
    public partial ObservableCollection<Student> Students { get; set; } = [];

    //TODO: Ta bort
    public StudentsViewModel()
    {
        _studentService = new StudentService();
        PageTitle = "Våra elever";
    }
    /***************************************************/

    public StudentsViewModel(IStudentService service)
    {
        _studentService = service;
        PageTitle = "Våra elever";
        Init();
    }

    [RelayCommand]
    private async Task Delete(string identification)
    {
        try
        {
            id = identification;
            ShowDialog = true;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    [RelayCommand]
    private async Task Confirm()
    {
        var student = await _studentService.Find(id);
        var _studentId = student._id;
        await _studentService.Delete(_studentId);
        ShowDialog = false;
    }

    [RelayCommand]
    private void Cancel()
    {
        ShowDialog = false;
    }

    private async void Init() => await LoadProducts();

    private async Task LoadProducts()
    {
        try
        {
            Students = new ObservableCollection<Student>(await _studentService.List());
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
