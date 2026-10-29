using System;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddCourseViewModel : ViewModelBase
{
    private ICourseService _courseService { get; set; }

    [ObservableProperty]
    public partial string CourseNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string CourseTitle { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Length { get; set; } = string.Empty;
    [ObservableProperty]
    public partial bool ClassRoom { get; set; }
    [ObservableProperty]
    public partial string Start { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string End { get; set; } = string.Empty;

    public AddCourseViewModel()
    {
        _courseService = new CourseService();
        PageTitle = "Lägg till en kurs";
    }

    public AddCourseViewModel(ICourseService courseService)
    {
        _courseService = courseService;
        PageTitle = "Lägg till en kurs";
    }

    [RelayCommand]
    private async Task Save()
    {
        Course course = new()
        {
            CourseNumber = CourseNumber,
            CourseTitle = CourseTitle,
            Length = Length,
            ClassRoom = ClassRoom,
            Start = Start,
            End = End
        };

        await _courseService.Add(course);

        ClearData();
    }

    private void ClearData()
    {
        CourseNumber = string.Empty;
        CourseTitle = string.Empty;
        Length = string.Empty;
        Start = string.Empty;
        End = string.Empty;
    }

}
