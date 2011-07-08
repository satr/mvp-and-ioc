using System;
using GenericUI.Interfaces;
using GenericUI.Views;

namespace GenericUI.ViewProperties
{
    public abstract class AbstractViewProperty<TValue, TViewPropertyAttributes> : IViewProperty
        where TViewPropertyAttributes: class, IViewPropertyAttributes, new()
    {
        public event EventHandler<ValueEventArgs<TValue>> ValueChanged;
        public event EventHandler<ValueEventArgs<string>> TitleChanged;
        public event EventHandler<ValueEventArgs<bool>> ReadOnlyChanged;

        private TValue _value;
        private string _title;
        private bool _readOnly;

        protected AbstractViewProperty(string title): this(Guid.NewGuid().ToString(), title)
        {
        }

        protected AbstractViewProperty(string name, string title)
        {
            Name = name;
            Title = title;
            Type = typeof (TValue);
            Attributes = new TViewPropertyAttributes();
        }

        public string Name { get; set; }

        public string Title
        {
            get { return _title; }
            set
            {
                if(_title == value)
                    return;
                _title = value;
                FireEvent(TitleChanged, _title);
            }
        }

        public Type Type { get; private set; }

        public TValue Value
        {
            get { return _value; }
            set
            {
                if(Equals(_value, value))
                    return;
                _value = value;
                FireEvent(ValueChanged, _value);
            }
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                if(_readOnly == value)
                    return;
                _readOnly = value;
                FireEvent(ReadOnlyChanged, _readOnly);
            }
        }

        public TViewPropertyAttributes Attributes { get; private set; }

        private void FireEvent<T>(EventHandler<ValueEventArgs<T>> eventHandler, T value)
        {
            if(eventHandler != null)
                eventHandler(this, new ValueEventArgs<T>(value));
        }
    }
}
