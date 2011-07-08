using System;
using GenericUI.Interfaces;
using Tetris.Interfaces;

namespace TetrisTests
{
    public class MockScoreView : IScoreView
    {
        public string Title { get; set; }
        
        public void Init()
        {
            throw new NotImplementedException();
        }

        public IPresenter Presenter
        {
            get { throw new NotImplementedException(); }
        }

        public int Height { get; set; }

        public void DrawTotalScore(int total)
        {
            throw new NotImplementedException();
        }

        public void DrawCurrentScore(int currentScore)
        {
            throw new NotImplementedException();
        }
    }
}