using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // [ObservableProperty]
    // public partial ViewModelBase CurrentView { get; set; } = new ();

    public MainWindowViewModel()
    {

    }

    [RelayCommand]
    public void GoToHome() => Console.WriteLine("Gå till hem");

    [RelayCommand]
    public void GoToCourses() => Console.WriteLine("Gå till kurser");
    [RelayCommand]
    public void GoToStudents() => Console.WriteLine("Gå till elever");
    [RelayCommand]
    public void GoToTeachers() => Console.WriteLine("Gå till lärare");



}
