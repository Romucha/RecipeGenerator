using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace RecipeGenerator.Localization.Attributes
{
    public class NotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
                return false;

            if (value is IEnumerable collection)
                return count(collection) > 0;

            return false;
        }

        private int count(IEnumerable source)
        {
            int c = 0;
            var e = source.GetEnumerator();
            while (e.MoveNext())
                c++;

            return c;
        }
    }
}
