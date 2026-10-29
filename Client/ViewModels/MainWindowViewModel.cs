using System;
using Client.Factories;
using Client.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IPageViewFactory _pageViewFactory;

    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; } = new();

    public MainWindowViewModel()
    {
        _pageViewFactory = new PageViewFactory();
        GoToHome();
    }

    public MainWindowViewModel(IPageViewFactory pageViewFactory)
    {
        _pageViewFactory = pageViewFactory;
        GoToHome();
    }

    [RelayCommand]
    public void GoToHome() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.Home);

    [RelayCommand]
    public void GoToCourses() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.Courses);

    [RelayCommand]
    public void GoToStudents() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.Students);

    [RelayCommand]
    public void GoToTeachers() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.Teachers);

    [RelayCommand]
    public void GoToAddStudent() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.AddStudent);

    [RelayCommand]
    public void GoToAddCourse() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.AddCourse);

    [RelayCommand]
    public void GoToEditStudent(string id) => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.EditStudent, id);



}
