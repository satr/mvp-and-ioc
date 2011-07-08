using GenericUI.Views;
using Tetris.Interfaces;
using Tetris.Presenters;

namespace Tetris.Views
{
    public class GameView : AbstractContainerView<IGamePresenter>, IGameView
    {
        public GameView()
        {
            Presenter = new GamePresenter(this);
        }

        public void HideStartActionControl()
        {
            //TODO
        }
    }
}