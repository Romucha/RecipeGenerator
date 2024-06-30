using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
