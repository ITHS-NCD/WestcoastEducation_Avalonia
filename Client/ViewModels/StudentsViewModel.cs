using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial ObservableCollection<Student> Students { get; set; } = [];
    public StudentsViewModel()
    {
        PageTitle = "Våra elever";
    }
}
