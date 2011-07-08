namespace GenericUI.Interfaces
{
    public interface IView
    {
        string Title { get; set; }
        void Init();
        IPresenter Presenter { get; }
        int Height { get; set; }
    }
}