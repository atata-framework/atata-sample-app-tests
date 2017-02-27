using NUnit.Framework;

namespace Atata.SampleApp.AutoTests
{
    public class PlanTest : AutoTest
    {
        [Test]
        public void Plans()
        {
            Go.To<PlansPage>().
                PlanItems.Count.Should.Equal(3).

                PlanItems[0].Title.Should.Equal("Basic").
                PlanItems[0].Price.Should.Equal(0).
                PlanItems[0].NumberOfProjects.Should.Equal(1).

                PlanItems[1].Title.Should.Equal("Plus").
                PlanItems[1].Price.Should.Equal(19.99m).
                PlanItems[1].NumberOfProjects.Should.Equal(3).

                PlanItems[2].Title.Should.Equal("Premium").
                PlanItems[2].Price.Should.Equal(49.99m).
                PlanItems[2].NumberOfProjects.Should.Equal(10);
        }
    }
}
