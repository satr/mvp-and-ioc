using GenericUI.Interfaces;
using Tetris.Common;

namespace Tetris.Interfaces
{
    public interface IFieldPresenter: IPresenter
    {
        void MoveLeft();
        void MoveRight();
        event TetrisActionEventHandler OnBrickGotDown;
        event TetrisActionEventHandler OnFinish;
    }
}