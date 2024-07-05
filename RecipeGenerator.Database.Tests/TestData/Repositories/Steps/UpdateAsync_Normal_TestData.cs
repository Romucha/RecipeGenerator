using RecipeGenerator.Models.Steps;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.TestData.Repositories.Steps
{
    public class UpdateAsync_Normal_TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Step()
                {
                    Name = "Step",
                    Description = "Step",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Index = 1,
                    Photos = [],
                },
                "",
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
