using System.Collections;

namespace RecipeGenerator.Utility.Tests.Validation
{
    public class InvalidValidationObjectsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { ValidationObject.Invalid_Default };
            yield return new object[] { ValidationObject.Invalid_Null! };

            yield return new object[] { ValidationObject.Invalid_Description_Null };

            yield return new object[] { ValidationObject.Invalid_Name_Null };
            yield return new object[] { ValidationObject.Invalid_Name_Empty };

            yield return new object[] { ValidationObject.Invalid_Coefficient_ExceedsMaximum };
            yield return new object[] { ValidationObject.Invalid_Coefficient_Negative };

            yield return new object[] { ValidationObject.Invalid_Index_ExceedsMaximum };
            yield return new object[] { ValidationObject.Invalid_Index_Minimum };
            yield return new object[] { ValidationObject.Invalid_Index_Negative };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
