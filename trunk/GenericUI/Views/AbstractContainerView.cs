using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GenericUI.Interfaces;

namespace GenericUI.Views
{
    public abstract class AbstractContainerView<TPresenter> : AbstractWindowsForm, IContainerView
        where TPresenter : IPresenter
    {
        private readonly List<INestedView> _nestedViews = new List<INestedView>();

        public void AddNestedView(INestedView nestedView)
        {
            _nestedViews.Add(nestedView);
            var userControl = nestedView as UserControl;
            if (userControl == null) 
                return;
            Controls.Add(userControl);
            userControl.Dock = DockStyle.Top;
        }

        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public virtual void Init()
        {
        }

        public TPresenter Presenter { get; protected set; }
        
        IPresenter IView.Presenter
        {
            get { return Presenter; }
        }

    }
}