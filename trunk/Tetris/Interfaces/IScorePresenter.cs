using GenericUI.Interfaces;

namespace Tetris.Interfaces
{
    public interface IScorePresenter: IPresenter
    {
        void CountBrick();
        void ShowTotal();
    }
}