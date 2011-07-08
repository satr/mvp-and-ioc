using System;

namespace GenericUI.Views
{
    public class ValueEventArgs<T>: EventArgs
    {
        public ValueEventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
        
    }
}