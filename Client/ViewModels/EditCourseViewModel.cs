using System;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class EditCourseViewModel : ViewModelBase
{
    private readonly ICourseService _courseService;
    private string _courseId { get; set; } = string.Empty;
    private string _objectId { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string CourseNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string CourseTitle { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Length { get; set; } = string.Empty;

    [ObservableProperty]
    public partial bool ClassRoom { get; set; }

    [ObservableProperty]
    public partial string? Start { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string? End { get; set; } = string.Empty;

    public EditCourseViewModel()
    {
        PageTitle = "Uppdatera kurs";
    }

    public EditCourseViewModel(ICourseService courseService, string courseId)
    {
        _courseService = courseService;
        PageTitle = "Uppdatera: " + CourseTitle;
        _courseId = courseId;
        Init();
    }

    private async void Init() => await GetCourse();

    private async Task GetCourse()
    {
        try
        {
            var course = await _courseService.Find(_courseId);

            _objectId = course._id;

            CourseNumber = course.CourseNumber;
            CourseTitle = course.CourseTitle;
            Length = course.Length;
            Start = course.Start;
            End = course.End;
            ClassRoom = course.ClassRoom;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [RelayCommand]
    public async Task Save()
    {
        Course course = new()
        {
            CourseNumber = CourseNumber,
            CourseTitle = CourseTitle,
            Length = Length,
            Start = Start,
            End = End,
            ClassRoom = ClassRoom
        };

        await _courseService.Update(course, _objectId);
    }

}
