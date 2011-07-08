using System;
using System.Collections.Generic;
using GenericEntities;
using GenericUI.Interfaces;
using GenericUI.Properties;
using GenericUI.ViewProperties;

namespace GenericUI.Presenters
{
    public abstract class AbstractPresenter<TView, TPropertyNames> : IPresenter
        where TView: IView
        where TPropertyNames: PropertyNames, new()
    {
        private List<IViewProperty> _viewProperties;

        protected AbstractPresenter(TView view)
        {
            View = view;
            Names = new TPropertyNames();
        }

        protected TView View { get; set; }
        protected TPropertyNames Names { get; private set; }

        public virtual void Init()
        {
            View.Init();
        }

        public abstract void Start();

        public List<IViewProperty> ViewProperties
        {
            get
            {
                if (_viewProperties == null)
                {
                    _viewProperties = new List<IViewProperty>();
                    InitViewProperties();
                }
                return _viewProperties;
            }
        }
        
        protected abstract void InitViewProperties();

        protected ActionViewProperty AddActionViewProperty(string title)
        {
            return new ActionViewProperty(title);
        }

        protected TextViewProperty AddTextViewProperty(string name, string title)
        {
            return AddTextViewProperty(name, title, false);
        }

        protected TextViewProperty AddTextViewProperty(string name, string title, bool readOnly)
        {
            if (ViewProperties.Exists(property => property.Name == name))
                throw new InvalidOperationException(string.Format(Properties.Resources.Error_ViewProperty_with_name_N_already_exists, name));
            var viewProperty = new TextViewProperty(name, title) { ReadOnly = readOnly };
            ViewProperties.Add(viewProperty);
            return viewProperty;
        }

//        public void InitViewProperties()
//        {
//            var viewProperties = new List<IViewProperty>();
//            const string format = "Prop {0}";
//            var viewProperty1 = new TextViewProperty("Prop11");
//            var viewProperty2 = new TextViewProperty("Prop22");
//            viewProperty1.ValueChanged += (s, e) => viewProperty2.Title = e.Value;
//            viewProperties.Add(viewProperty1);
//            viewProperties.Add(viewProperty2);
//            for (int i = 0; i < 3; i++)
//                viewProperties.Add(new TextViewProperty(string.Format(format, i))
//                                       {
//                                           ReadOnly = true,
//                                           Attributes = {MaxLength = 2 * i}
//                                       });
//            var actionViewProperty1 = new ActionViewProperty("Do it1");
//            actionViewProperty1.Performed += (v, e) => MessageBox.Show(((IViewProperty)v).Title);
//            viewProperties.Add(actionViewProperty1);
//            var actionViewProperty2 = new ActionViewProperty("Do it2"){ShiftColumnsCount = 1};
//            actionViewProperty2.Performed += (v, e) => MessageBox.Show(((IViewProperty)v).Title + "-123");
//            viewProperties.Add(actionViewProperty2);
//            var actionViewProperty3 = new ActionViewProperty("Do it3"){ShiftColumnsCount = 1};
//            actionViewProperty3.FixedSize = false;
//            actionViewProperty3.Performed += (v, e) => MessageBox.Show(((IViewProperty)v).Title + "-123");
//            viewProperties.Add(actionViewProperty3);
//            for (int i = 0; i < 3; i++)
//            {
//                viewProperties.Add(new NumberViewProperty(string.Format(format, i))
//                                       {
//                                           ReadOnly = true, 
//                                           Attributes = { DecimalPlaces = i, MaxValue = 100 * i}
//                                       });
//            }
//            for (int i = 0; i < 3; i++)
//                viewProperties.Add(new TextViewProperty(string.Format(format, i) + " 123 45"));
//            return viewProperties;
//        }
        protected TextViewProperty GetTextViewProperty(string name)
        {
            return GetViewProperty<TextViewProperty>(name);
        }

        private TViewProperty GetViewProperty<TViewProperty>(string name)
            where TViewProperty: class, IViewProperty
        {
            var textViewProperty = (TViewProperty) ViewProperties.Find(vp => vp.Name == name);
            if(textViewProperty == null)
                throw new InvalidOperationException(string.Format(Resources.Error_ViewProperty_was_not_found_by_name_N, name));
            return textViewProperty;
        }
    }
}