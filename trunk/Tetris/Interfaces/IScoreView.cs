using GenericUI.Interfaces;

namespace Tetris.Interfaces
{
    public interface IScoreView: IView
    {
        void DrawTotalScore(int total);
        void DrawCurrentScore(int currentScore);
    }
}