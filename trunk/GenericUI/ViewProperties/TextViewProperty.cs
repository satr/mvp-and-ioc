namespace GenericUI.ViewProperties
{
    public class TextViewProperty: AbstractViewProperty<string, TextViewPropertyAttributes>
    {
        public TextViewProperty(string title) : base(title)
        {
        }

        public TextViewProperty(string name, string title) : base(name, title)
        {
        }
    }
}