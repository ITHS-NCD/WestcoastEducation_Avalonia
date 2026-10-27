using System;
using Client.Enums;
using Client.ViewModels;

namespace Client.Interfaces;

public interface IPageViewFactory
{
    ViewModelBase LoadPageViewModel(PageViewsEnum pageEnum);
    ViewModelBase LoadPageViewModel(PageViewsEnum pageEnum, string itemNumber);
}
