using System;
using System.Windows.Forms;
using GenericUI.Interfaces;

namespace GenericUI.Views
{
    public abstract class AbstractNestedView<TPresenter>: AbstractUserControl, INestedView
        where TPresenter: IPresenter
    {
        //TODO - add title bar?
        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public virtual void Init()
        {
            SuspendLayout();
            Height = 0;
            ViewBuilder.Build(this, Presenter.ViewProperties);
            ResumeLayout(false);
        }

        protected IViewBuilder ViewBuilder { 
            get { return new ViewBuilder();}
        }

        public TPresenter Presenter { get; protected set; }

        public void AddControl(Control control)
        {
            Controls.Add(control);
            Height += control.Height;
        }

        IPresenter IView.Presenter
        {
            get { return Presenter; }
        }
    }
}