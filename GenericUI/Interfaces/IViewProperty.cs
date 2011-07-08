using System;
using GenericUI.Views;

namespace GenericUI.Interfaces
{
    public interface IViewProperty
    {
        string Name { get; set; }
        string Title { get; set; }
        Type Type { get; }
        bool ReadOnly { get; set; }
        event EventHandler<ValueEventArgs<string>> TitleChanged;
        event EventHandler<ValueEventArgs<bool>> ReadOnlyChanged;
    }
}