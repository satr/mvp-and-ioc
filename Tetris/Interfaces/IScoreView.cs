using GenericUI.Interfaces;

namespace Tetris.Interfaces
{
    public interface IScoreView: IView
    {
        void DrawTotalScore(int value);
        void DrawCurrentScore(int value);
    }
}