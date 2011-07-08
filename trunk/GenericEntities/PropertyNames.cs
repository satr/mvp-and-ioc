using System.Linq;

namespace GenericEntities
{
    public class PropertyNames
    {
        public PropertyNames()
        {
            GetType().GetFields()
                     .Where(property => property.FieldType == typeof (string))
                     .ToList()
                     .ForEach(property => property.SetValue(this, property.Name));
        }
    }
}
