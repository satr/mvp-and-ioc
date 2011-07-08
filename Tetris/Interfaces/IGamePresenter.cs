using GenericUI.Interfaces;
using Tetris.Common;

namespace Tetris.Interfaces
{
    public interface IGamePresenter: IPresenter
    {
        event TetrisActionEventHandler OnStart;
        event TetrisActionEventHandler OnLeft;
        event TetrisActionEventHandler OnRight;
    }
}