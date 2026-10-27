using System;
using System.Collections.ObjectModel;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class TeachersViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial ObservableCollection<Teacher> Teachers { get; set; } = [];

    public TeachersViewModel()
    {
        PageTitle = "Våra lärare";
    }
}
