using System;
using GenericUI.Views;

namespace GenericUI.ViewProperties
{
    public class ActionViewProperty: AbstractViewProperty<object, ActionViewPropertyAttributes>
    {
        public event EventHandler<ValueEventArgs<object>> Performed;

        public ActionViewProperty(string title) : base(title)
        {
            FixedSize = true;
        }

        public bool FixedSize { get; set; }
        public int ShiftColumnsCount { get; set; }

        public void Perform()
        {
            var handler = Performed;
            if (handler != null)
                handler(this, new ValueEventArgs<object>(Value));
        }
    }
}