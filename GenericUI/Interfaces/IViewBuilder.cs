using System.Collections.Generic;

namespace GenericUI.Interfaces
{
    public interface IViewBuilder
    {
        void Build(INestedView nestedView, List<IViewProperty> viewProperties);
    }
}