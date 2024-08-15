using System.Collections;

namespace RecipeGenerator.Utility.Tests.Validation
{
    public class NormalValidationObjectsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { ValidationObject.Normal };
            yield return new object[] { ValidationObject.Normal_Description_Empty };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
