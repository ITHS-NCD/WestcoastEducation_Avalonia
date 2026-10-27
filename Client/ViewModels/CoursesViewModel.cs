using System;
using System.Collections.ObjectModel;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{

    [ObservableProperty]
    public partial ObservableCollection<Course> Courses { get; set; } = [];

    public CoursesViewModel()
    {
        PageTitle = "Våra kurser";
    }
}
