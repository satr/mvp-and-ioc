using System;
using GenericEntities;
using GenericUI.Presenters;
using Tetris.Common;
using Tetris.Interfaces;
using Tetris.Properties;

namespace Tetris.Presenters
{
    public class GamePresenter: AbstractPresenter<IGameView, PropertyNames>, IGamePresenter
    {
        public event TetrisActionEventHandler OnStart;
        public event TetrisActionEventHandler OnLeft;
        public event TetrisActionEventHandler OnRight;

        public GamePresenter(IGameView view): base(view)
        {
            View.Title = Resources.Title_Tetris;
        }

        public override void Start()
        {
            View.HideStartActionControl();
        }

        protected override void InitViewProperties()
        {
            AddActionViewProperty(Resources.Title_Start).Performed += (p, v) => FireOnStart();
        }

        private void FireOnStart()
        {
            if (OnStart != null)
                OnStart();
        }
    }

}