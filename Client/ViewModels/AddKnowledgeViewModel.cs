using System;
using System.Threading.Tasks;
using Client.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddKnowledgeViewModel : ViewModelBase
{
    private readonly ITeacherService _teacherService;
    private string _teacherid;
    private string _id = string.Empty;

    [ObservableProperty]
    public partial bool ShowDialog { get; set; } = false;

    [ObservableProperty]
    public partial string KnowledgeArea { get; set; } = string.Empty;


    public AddKnowledgeViewModel(ITeacherService teacherService, string id)
    {
        _teacherService = teacherService;
        _teacherid = id;
        PageTitle = "Lägg till ett kunskapområde";
    }

    [RelayCommand]
    private async Task Save()
    {
        var teacher = await _teacherService.Find(_teacherid);

        _id = teacher._id;

        if (!string.IsNullOrWhiteSpace(KnowledgeArea))
        {
            teacher.Knowledge!.Add(KnowledgeArea);
            await _teacherService.Update(teacher, _id);
            ClearData();
        }
        else
        {
            ShowDialog = true;
        }
    }

    private void ClearData()
    {
        KnowledgeArea = string.Empty;
    }

    [RelayCommand]
    private void Ok()
    {
        ShowDialog = false;
    }
}
