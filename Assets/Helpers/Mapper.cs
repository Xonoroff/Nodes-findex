using System.Linq;

namespace Helpers
{
    /// <summary>
    /// Mapper is used to map from one type to another one using reflection.
    /// To increase performance better to create straight mapper. For example mapping via ctor
    /// </summary>
    /// <typeparam name="T">type from</typeparam>
    /// <typeparam name="U">type to</typeparam>
    public class Mapper<T, U>
    {
        public U Map(T source, U direct)
        {
            var sourceFields = source.GetType().GetFields();
            var directFields = direct.GetType().GetFields();

            foreach (var sourceField in sourceFields)
            {
                var commonField = directFields.FirstOrDefault(directField => directField.Name == sourceField.Name);
                if (commonField != null)
                {
                    var sourceValue = sourceField.GetValue(source);
                    commonField.SetValue(direct, sourceValue);
                }
            }

            return direct;
        }
    }
}
