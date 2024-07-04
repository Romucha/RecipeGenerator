using RecipeGenerator.Models.Steps;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.TestData.Repositories.Steps
{
    public class GetAllAsync_Normal_TestData : IEnumerable<object[]>
    {
        private static List<Step> normalSteps = new List<Step>()
        {
            new Step()
            {
                Name = "Step 1",
                Description = "Step 1",
                Index = 0
            },
            new Step()
            {
                Name = "Step 2",
                Description = "Step 2",
                Index = 1
            },
            new Step()
            {
                Name = "Step 3",
                Description = "Step 3",
                Index = 2
            }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] 
            {
                new List<Step>(normalSteps),
                0,
                0,
                3
            };

            yield return new object[]
            {
                new List<Step>(normalSteps),
                1,
                1,
                1
            };

            yield return new object[]
            {
                new List<Step>(normalSteps),
                1,
                2,
                1
            };


            yield return new object[]
            {
                new List<Step>(normalSteps),
                1,
                3,
                0
            };

            yield return new object[]
            {
                new List<Step>(normalSteps),
                0,
                3,
                3
            };

            yield return new object[]
            {
                new List<Step>(normalSteps),
                2,
                1,
                1
            };

            yield return new object[]
            {
                new List<Step>(normalSteps),
                -1,
                -1,
                3
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
