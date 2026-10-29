using System;
using Client.Enums;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;

namespace Client.Factories;

public class PageViewFactory : IPageViewFactory
{
    public ViewModelBase LoadPageViewModel(PageViewsEnum pageEnum)
    {
        return pageEnum switch
        {
            PageViewsEnum.Courses => new CoursesViewModel(new CourseService()),
            PageViewsEnum.Home => new HomeViewModel(),
            PageViewsEnum.Students => new StudentsViewModel(new StudentService()),
            PageViewsEnum.Teachers => new TeachersViewModel(),
            PageViewsEnum.AddStudent => new AddStudentViewModel(new StudentService()),
            PageViewsEnum.AddCourse => new AddCourseViewModel(new CourseService()),

            _ => throw new InvalidOperationException("Det fanns inte det du ville ha")
        };
    }

    public ViewModelBase LoadPageViewModel(PageViewsEnum pageEnum, string id)
    {
        return pageEnum switch
        {
            PageViewsEnum.EditStudent => new EditStudentViewModel(new StudentService(), id),
            PageViewsEnum.EditCourse => new EditCourseViewModel(new CourseService(), id),
            _ => throw new InvalidOperationException("Det fanns inte det du ville ha")
        };
    }
}
