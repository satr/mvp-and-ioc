namespace GenericUI.ViewProperties
{
    public class NumberViewPropertyAttributes : IViewPropertyAttributes
    {
        public NumberViewPropertyAttributes()
        {
            MinValue = 0;
            MaxValue = int.MaxValue;
        }

        public int DecimalPlaces;
        public decimal MinValue;
        public decimal MaxValue;
    }
}