using System.Windows.Forms;

namespace GenericUI.Interfaces
{
    public interface INestedView : IView
    {
        void AddControl(Control control);
    }
}