using GenericUI.Interfaces;
using Tetris.Interfaces;
using Tetris.Presenters;

namespace TetrisTests.Mocks
{
    public class MockScoreView : IScoreView
    {
        public MockScoreView()
        {
            Presenter = new ScorePresenter(this);
        }

        public string Title { get; set; }
        
        public void Init()
        {
            TestIsInitialized = true;
        }

        public IPresenter Presenter { get; set; }

        public int Height { get; set; }

        public void DrawTotalScore(int value)
        {
            TestDrawnTotalScore = value;
        }

        public void DrawCurrentScore(int value)
        {
            TestDrawnCurrentScore = value;
        }

        public int TestDrawnTotalScore { get; set; }
        public int TestDrawnCurrentScore { get; set; }
        public bool TestIsInitialized { get; set; }
    }
}