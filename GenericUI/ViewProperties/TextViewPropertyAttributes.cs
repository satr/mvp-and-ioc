namespace GenericUI.ViewProperties
{
    public class TextViewPropertyAttributes: IViewPropertyAttributes
    {
        public TextViewPropertyAttributes()
        {
            MaxLength = 1000;
        }

        public decimal MaxLength;
    }
}