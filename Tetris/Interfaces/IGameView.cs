using GenericUI.Interfaces;

namespace Tetris.Interfaces
{
    public interface IGameView : IContainerView
    {
        void HideStartActionControl();
        IGamePresenter Presenter { get; }
    }
}