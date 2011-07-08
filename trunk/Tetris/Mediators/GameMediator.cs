using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GenericUI.Interfaces;
using Tetris.Interfaces;
using Tetris.Properties;
using Tetris.Views;

namespace Tetris.Mediators
{
    public class GameMediator
    {
        private readonly IContainerView _containerView;
        private readonly List<IPresenter> _presenters = new List<IPresenter>();

        public GameMediator()
        {
            _containerView = AddFormView<GameView>();
            var fieldPresenter = AddNestedViewTo<FieldView>(_containerView).Presenter;
            var scorePresenter = AddNestedViewTo<ScoreView>(_containerView).Presenter;

            var gamePresenter = (IGamePresenter) _containerView.Presenter;
            gamePresenter.OnStart += Start;
            gamePresenter.OnLeft += fieldPresenter.MoveLeft;
            gamePresenter.OnRight += fieldPresenter.MoveRight;

            fieldPresenter.OnBrickGotDown += scorePresenter.CountBrick;
            fieldPresenter.OnFinish += scorePresenter.ShowTotal;

            Init();
        }

        public Form GetContainerView()
        {
            var form = _containerView as Form;
            if (form == null)
                throw new InvalidOperationException(Resources.Error_Container_view_is_invalid);
            return form;
        }

        private IContainerView AddFormView<TFormView>()
            where TFormView: IContainerView, new()
        {
            var formView = new TFormView();
            _presenters.Add(formView.Presenter);
            return formView;
        }

        private TNestedView AddNestedViewTo<TNestedView>(IContainerView containerView)
            where TNestedView: INestedView, new()
        {
            var nestedView = new TNestedView();
            containerView.AddNestedView(nestedView);
            _presenters.Add(nestedView.Presenter);
            return nestedView;
        }

        private void Start()
        {
            _presenters.ForEach(pres => pres.Start());
        }

        private void Init()
        {
            _presenters.ForEach(pres => pres.Init());
        }
    }
}