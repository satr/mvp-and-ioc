using GenericUI.Presenters;
using Tetris.Interfaces;
using Tetris.Models;
using Tetris.Properties;
using Tetris.PropertyNameSets;

namespace Tetris.Presenters
{
    public class ScorePresenter : AbstractPresenter<IScoreView, ScorePropertyNames>, IScorePresenter
    {
        public ScorePresenter(IScoreView view): base(view)
        {
            Model = new ScoreModel();
        }

        protected ScoreModel Model { get; set; }

        public void ShowTotal()
        {
            View.DrawTotalScore(Model.TotalScore);
        }

        public void CountBrick()
        {
            Model.AddBrick();
            View.DrawCurrentScore(Model.CurrentScore);
        }

        public override void Init()
        {
            base.Init();
            Model.Init();
        }

        public override void Start()
        {
            Model.ResetCurrentScore();
            View.DrawCurrentScore(Model.CurrentScore);
        }

        protected override void InitViewProperties()
        {
            AddTextViewProperty(Names.CurrentScore, Resources.Title_Current_score)
                .ReadOnly = true;
            AddTextViewProperty(Names.TotalScore, Resources.Title_Total_score)
                .ReadOnly = true;
        }
    }
}