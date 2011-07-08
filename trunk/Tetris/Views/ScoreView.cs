using GenericUI.Views;
using Tetris.Interfaces;
using Tetris.Presenters;

namespace Tetris.Views
{
    public class ScoreView : AbstractNestedView<IScorePresenter>, IScoreView
    {
        public ScoreView()
        {
            Presenter = new ScorePresenter(this);
        }

        public override void Init()
        {
            base.Init();
            DrawScore();           
        }

        private static void DrawScore()
        {
            //TODO
        }

        public void DrawTotalScore(int total)
        {
            //TODO
        }

        public void DrawCurrentScore(int currentScore)
        {
            //TODO
        }
    }
}