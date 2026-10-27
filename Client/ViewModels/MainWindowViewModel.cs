using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly CoursesViewModel _courseView = new();
    private readonly StudentsViewModel _studentView = new();
    private readonly TeachersViewModel _teacherView = new();

    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; }
    public MainWindowViewModel()
    {
        CurrentView = _courseView;
    }

    [RelayCommand]
    public void GoToHome() => Console.WriteLine("Gå till hem");

    [RelayCommand]
    public void GoToCourses() => CurrentView = _courseView;

    [RelayCommand]
    public void GoToStudents() => CurrentView = _studentView;

    [RelayCommand]
    public void GoToTeachers() => CurrentView = _teacherView;



}
