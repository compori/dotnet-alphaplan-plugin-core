using Compori.Alphaplan.Plugin.Support.Data;
using DryIoc;
using Xunit;

namespace SupportTests.Data
{
    public class TableFactoryTest
    {
        /// <summary>
        /// Gets the DI container.
        /// </summary>
        /// <value>The DI container.</value>
        private IContainer Container { get; } = DataContext.Container;

        [Fact()]
        public void TestResolveITableFactory()
        {
            var sut1 = this.Container.Resolve<ITableFactory>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ITableFactory>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ITableFactory>(sut1);
        }

        [Fact]
        public void TestCreate()
        {
            var sut = this.Container.Resolve<ITableFactory>();

            using (var table1 = sut.Create(Base.ApDataTables.Versions))
            {
                using (var table2 = sut.Create(Base.ApDataTables.Versions))
                {
                    Assert.NotSame(table1, table2);

                    Assert.Equal(Base.ApDataTables.Versions, table1.Name);
                    Assert.Equal(Base.ApDataTables.Versions, table2.Name);
                    Assert.Equal(Base.ApDataFields.Versions.VersionsID, table1.PrimaryKeyField);
                    Assert.Equal(Base.ApDataFields.Versions.VersionsID, table2.PrimaryKeyField);
                }
            }

            using (var table1 = sut.Create(Base.ApDataTables.Versions, Base.ApDataFields.Versions.VersionsID))
            {
                using (var table2 = sut.Create(Base.ApDataTables.Versions, Base.ApDataFields.Versions.VersionsID))
                {
                    Assert.NotSame(table1, table2);

                    Assert.Equal(Base.ApDataTables.Versions, table1.Name);
                    Assert.Equal(Base.ApDataTables.Versions, table2.Name);
                    Assert.Equal(Base.ApDataFields.Versions.VersionsID, table1.PrimaryKeyField);
                    Assert.Equal(Base.ApDataFields.Versions.VersionsID, table2.PrimaryKeyField);
                }
            }

            using (var table1 = sut.Create(Base.ApDataTables.Versions, Base.ApDataFields.Versions.VersionsID, 1))
            {
                using (var table2 = sut.Create(Base.ApDataTables.Versions, Base.ApDataFields.Versions.VersionsID, 1))
                {
                    Assert.NotSame(table1, table2);

                    Assert.Equal(Base.ApDataTables.Versions, table1.Name);
                    Assert.Equal(Base.ApDataTables.Versions, table2.Name);
                    Assert.Equal(Base.ApDataFields.Versions.VersionsID, table1.PrimaryKeyField);
                    Assert.Equal(Base.ApDataFields.Versions.VersionsID, table2.PrimaryKeyField);
                }
            }
        }
    }
}
