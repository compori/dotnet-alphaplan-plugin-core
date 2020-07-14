using DryIoc;
using Compori.Alphaplan.Plugin.Support.Common;
using Xunit;

namespace SupportTests.Common
{
    public class ErrorScopeFactoryTest
    {
        /// <summary>
        /// Gets the DI container.
        /// </summary>
        /// <value>The DI container.</value>
        private IContainer Container { get; } = DataContext.Container;

        [Fact()]
        public void TestResolveITableFactory()
        {
            var sut1 = this.Container.Resolve<IErrorScopeFactory>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IErrorScopeFactory>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IErrorScopeFactory>(sut1);
        }
    }
}
