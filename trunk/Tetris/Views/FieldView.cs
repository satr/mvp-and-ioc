using System;
using System.Windows.Forms;
using GenericUI.Views;
using Tetris.Interfaces;
using Tetris.Presenters;

namespace Tetris.Views
{
    public class FieldView : AbstractNestedView<IFieldPresenter>, IFieldView
    {
        public FieldView()
        {
            Presenter = new FieldPresenter(this);
            KeyDown += FieldView_KeyDown;
        }

        private void FieldView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Presenter.MoveLeft();
                    break;
                case Keys.Right:
                    Presenter.MoveRight();
                    break;
            }
        }

        public override void Init()
        {
            base.Init();
            DrawField();
        }

        private void DrawField()
        {
            //TODO
        }

        public void DrawGameFinished()
        {
            //TODO
        }
    }
}