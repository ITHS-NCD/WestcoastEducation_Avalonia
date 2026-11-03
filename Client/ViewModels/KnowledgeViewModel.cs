using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class KnowledgeViewModel : ViewModelBase
{
    private readonly ITeacherService _teacherService;
    // public string _id = string.Empty;
    private string knowledge = string.Empty;

    [ObservableProperty]
    public partial string Id { get; set; } = string.Empty;

    [ObservableProperty]
    public partial bool ShowDialog { get; set; }
    [ObservableProperty]
    public partial bool ShowWarning { get; set; }

    [ObservableProperty]
    public partial List<string> Knowledge { get; set; } = [];

    public KnowledgeViewModel()
    {

    }

    public KnowledgeViewModel(ITeacherService teacherService, string id)
    {
        _teacherService = teacherService;
        Id = id;
        PageTitle = "Kunskapområden";
        Init();
    }

    private async void Init() => await LoadKnowledge();

    [RelayCommand]
    private async Task LoadKnowledge()
    {
        try
        {
            var teacher = await _teacherService.Find(Id);
            Knowledge = teacher.Knowledge!;
            if (teacher.Knowledge is null)
            {
                ShowDialog = true;
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [RelayCommand]
    private async Task Delete(string knowledgearea)
    {
        knowledge = knowledgearea;
        ShowWarning = true;
    }

    [RelayCommand]
    private async Task ConfirmWarning()
    {
        var teacher = await _teacherService.Find(Id);

        teacher.Knowledge!.Remove(knowledge);
        await _teacherService.Update(teacher, teacher._id);
        Init();
        ShowWarning = false;
    }

    [RelayCommand]
    private void Cancel()
    {
        ShowWarning = false;
        ShowDialog = false;
    }
}
