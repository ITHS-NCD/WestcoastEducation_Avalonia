using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    private readonly IStudentService _studentService;

    [ObservableProperty]
    public partial ObservableCollection<Student> Students { get; set; } = [];

    public StudentsViewModel()
    {
        _studentService = new StudentService();
        PageTitle = "Våra elever";
    }
    public StudentsViewModel(IStudentService service)
    {
        _studentService = service;
        PageTitle = "Våra elever";
    }

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
