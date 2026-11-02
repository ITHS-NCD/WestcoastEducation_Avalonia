using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class TeachersViewModel : ViewModelBase
{
    private readonly ITeacherService _teacherService;
    private string id = string.Empty;

    [ObservableProperty]
    public partial bool ShowDialog { get; set; } = false;

    [ObservableProperty]
    public partial ObservableCollection<Teacher> Teachers { get; set; } = [];

    public TeachersViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
        PageTitle = "Våra lärare";
        Init();
    }

    private async void Init() => await LoadTeachers();

    [RelayCommand]
    private async Task LoadTeachers()
    {
        try
        {
            Teachers = new ObservableCollection<Teacher>(await _teacherService.List());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [RelayCommand]
    public async Task Delete(string identification)
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
        var teacher = await _teacherService.Find(id);
        var teacherId = teacher._id;
        await _teacherService.Delete(teacherId);
        Init();
        ShowDialog = false;
    }

    [RelayCommand]
    private void Cancel()
    {
        ShowDialog = false;
    }
}
