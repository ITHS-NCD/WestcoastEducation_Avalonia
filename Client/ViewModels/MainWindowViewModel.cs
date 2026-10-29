using System;
using Client.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IPageViewFactory _pageViewFactory;

    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; } = new();

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
    public void GoToEditStudent() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.EditStudent);



}
