using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    private readonly ICourseService _courseService;
    private string _courseId = string.Empty;

    [ObservableProperty]
    public partial bool ShowDialog { get; set; } = false;

    [ObservableProperty]
    public partial ObservableCollection<Course> Courses { get; set; } = [];

    public CoursesViewModel()
    {
        _courseService = new CourseService();
        PageTitle = "Våra kurser";
    }

    public CoursesViewModel(ICourseService courseService)
    {
        _courseService = courseService;
        PageTitle = "Våra kurser";
        Init();
    }

    [RelayCommand]
    private async Task Delete(string courseId)
    {
        try
        {
            _courseId = courseId;
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
        var course = await _courseService.Find(_courseId);
        var courseId = course._id;
        await _courseService.Delete(courseId);
        Init();
        ShowDialog = false;
    }

    [RelayCommand]
    private void Cancel()
    {
        ShowDialog = false;
    }

    private async void Init() => await LoadCourses();

    private async Task LoadCourses()
    {
        try
        {
            Courses = new ObservableCollection<Course>(await _courseService.List());
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
