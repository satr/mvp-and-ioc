using System;
using System.Threading;
using GenericUI.Presenters;
using Tetris.Common;
using Tetris.Interfaces;
using Tetris.Models;
using Tetris.PropertyNameSets;

namespace Tetris.Presenters
{
    public class FieldPresenter : AbstractPresenter<IFieldView, FieldPropertyNames>, IFieldPresenter
    {
        private Timer _timer;
        public event TetrisActionEventHandler OnBrickGotDown;
        public event TetrisActionEventHandler OnFinish;

        public FieldPresenter(IFieldView view): base(view)
        {
            Model = new GameModel();
            Model.OnFinished += Finish;
            _timer = new Timer(TimerTicked);
        }

        private void Finish()
        {
            View.DrawGameFinished();
            if (OnFinish != null)
                OnFinish();
        }

        protected GamePresenter GamePresenter { get; set; }

        protected GameModel Model { get; set; }

        public void MoveLeft()
        {
            //TODO - changes state in model
        }

        public void MoveRight()
        {
            //TODO - changes state in model
        }

        public override void Start()
        {
            Model.Init();
            StartTimer();
        }

        protected override void InitViewProperties()
        {
            AddTextViewProperty(Names.VerticalPosition, "Vertical position", true);
        }

        private void StartTimer()
        {
            _timer.Change(1, 500);
        }

        private void TimerTicked(object state)
        {
            Console.Write(1);
            Model.ChangeBrickState();
            if (Model.IsBrickGotDown && OnBrickGotDown != null)
                OnBrickGotDown();
            GetTextViewProperty(Names.VerticalPosition).Value = Model.CurrentVerticalPosition.ToString();
        }
    }
}