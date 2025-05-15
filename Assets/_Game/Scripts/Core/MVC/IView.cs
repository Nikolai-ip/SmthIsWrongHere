using System;
using _Game.Scripts.Core.Signals;

namespace _Game.Scripts.Core.MVC
{
    public interface IView<in TViewData>:IView where TViewData : IViewData
    {
        void SetData(TViewData viewData);
    }
    public interface IView:IViewEnable { }

    public interface IViewEnable
    {
        void Show();
        void Hide();
    }

    public interface IActionsHandler<in TActions> where TActions : ISignal
    { 
        void Handle(TActions actionsData);
    }
    public interface IViewInteractive<TActions> where TActions : ISignal
    {
        event Action<TActions> OnInteract;
    }
    public interface IViewData { }
}