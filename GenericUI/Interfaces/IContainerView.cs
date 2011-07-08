namespace GenericUI.Interfaces
{
    public interface IContainerView: IView
    {
        void AddNestedView(INestedView nestedView);
    }
}