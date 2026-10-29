using System;
using Client.Factories;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collention)
    {
        collention.AddSingleton<MainWindowViewModel>();
        collention.AddSingleton<IPageViewFactory, PageViewFactory>();
        collention.AddTransient<CoursesViewModel>();
        collention.AddTransient<StudentsViewModel>();
        collention.AddTransient<TeachersViewModel>();
        collention.AddTransient<HomeViewModel>();
        collention.AddTransient<AddStudentViewModel>();
        collention.AddTransient<ICourseService, CourseService>();
        collention.AddTransient<IStudentService, StudentService>();
        collention.AddTransient<ITeacherService, TeacherService>();
    }
}
