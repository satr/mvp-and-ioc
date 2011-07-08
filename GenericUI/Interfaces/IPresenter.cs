using System.Collections.Generic;

namespace GenericUI.Interfaces
{
    public interface IPresenter
    {
        void Init();
        void Start();
        List<IViewProperty> ViewProperties { get; }
    }
}