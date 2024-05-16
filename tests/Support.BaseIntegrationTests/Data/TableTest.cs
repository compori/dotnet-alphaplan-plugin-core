using System;
using System.Collections.Generic;
using System.Linq;
using Compori.Alphaplan.Plugin.Support.Data;
using DryIoc;
using Xunit;

namespace Support.BaseIntegrationTests.Data
{
    public class TableTest
    {
        /// <summary>
        /// Gets the DI container.
        /// </summary>
        /// <value>The DI container.</value>
        private IContainer Container { get; } = DataContext.Container;

        [Fact]
        public void TestCreateReadUpdateDelete()
        {
            long id;

            var expectedBitValue = new Random().Next(0, 1) > 0;
            var expectedByteValue = (byte) new Random().Next(byte.MinValue, byte.MaxValue);
            var expectedIntegerValue = (short) new Random().Next(short.MinValue, short.MaxValue);
            var expectedLongValue = new Random().Next();
            var expectedSingleValue = Convert.ToSingle(new Random().NextDouble());
            var expectedDoubleValue = new Random().NextDouble();
            var expectedString30Value = Guid.NewGuid().ToString("N").Substring(0, 30);
            var expectedString255Value = Guid.NewGuid().ToString("N") + " - " + Guid.NewGuid().ToString("N");
            var expectedMemoValue = Guid.NewGuid().ToString("N") + " - " + Guid.NewGuid().ToString("N") + " - " + Guid.NewGuid().ToString("N").PadRight(1000, '*');
            var expectedBinaryValue = new byte[] {0, 1, 2, 3};
            var expectedDateTimeValue = new DateTime(2020, 6, 1, 10, 20, 30);

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                sut.Create()
                    .Set("K_BitValue", expectedBitValue)
                    .Set("K_ByteValue", expectedByteValue)
                    .Set("K_IntegerValue", expectedIntegerValue)
                    .Set("K_LongValue", expectedLongValue)
                    .Set("K_SingleValue", expectedSingleValue)
                    .Set("K_DoubleValue", expectedDoubleValue)
                    .Set("K_TextValue30", expectedString30Value)
                    .Set("K_TextValue255", expectedString255Value)
                    .Set("K_MemoValue", expectedMemoValue)
                    .Set("K_BinaryValue", expectedBinaryValue)
                    .Set("K_DateTimeValue", expectedDateTimeValue)
                    .Update();
                id = sut.Id;
                Assert.True(id > 0);
            }

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                sut.Seek(id);
                Assert.Equal(expectedBitValue, sut.Get<bool>("K_BitValue"));
                Assert.Equal(expectedByteValue, sut.Get<byte>("K_ByteValue"));
                Assert.Equal(expectedIntegerValue, sut.Get<short>("K_IntegerValue"));
                Assert.Equal(expectedLongValue, sut.Get<int>("K_LongValue"));
                Assert.Equal(expectedLongValue, sut.Get<long>("K_LongValue"));
                Assert.True(Math.Abs(expectedSingleValue - sut.Get<float>("K_SingleValue")) < 0.0001);
                Assert.True(Math.Abs(expectedDoubleValue - sut.Get<double>("K_DoubleValue")) < 0.0000001);
                Assert.Equal(expectedString30Value, sut.Get<string>("K_TextValue30"));
                Assert.Equal(expectedString255Value, sut.Get<string>("K_TextValue255"));
                Assert.Equal(expectedMemoValue, sut.Get<string>("K_MemoValue"));
                Assert.Equal(expectedBinaryValue, sut.Get<byte[]>("K_BinaryValue"));
                Assert.Equal(expectedDateTimeValue, sut.Get<DateTime>("K_DateTimeValue"));

                sut.Set("K_MemoValue", null as string);
                sut.Set("K_BinaryValue", null as byte[]);
                sut.Update();
                Assert.Equal(expectedBitValue, sut.Get<bool>("K_BitValue"));
                Assert.Equal(expectedByteValue, sut.Get<byte>("K_ByteValue"));
                Assert.Equal(expectedIntegerValue, sut.Get<short>("K_IntegerValue"));
                Assert.Equal(expectedLongValue, sut.Get<int>("K_LongValue"));
                Assert.Equal(expectedLongValue, sut.Get<long>("K_LongValue"));
                Assert.True(Math.Abs(expectedSingleValue - sut.Get<float>("K_SingleValue")) < 0.0001);
                Assert.True(Math.Abs(expectedDoubleValue - sut.Get<double>("K_DoubleValue")) < 0.0000001);
                Assert.Equal(expectedString30Value, sut.Get<string>("K_TextValue30"));
                Assert.Equal(expectedString255Value, sut.Get<string>("K_TextValue255"));
                
                // Assert.Null(sut.Get<string>("K_MemoValue")); -> empty :-(
                // Assert.Null(sut.Get<byte[]>("K_BinaryValue")); -> zero size byte array :-(

                Assert.Equal(expectedDateTimeValue, sut.Get<DateTime>("K_DateTimeValue"));
            }

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                sut.Seek(id);
                sut.Delete();
                sut.Clear();
                Assert.Throws<TableFilterException>(() => sut.Seek(id));
            }
        }

        [Fact]
        public void TestMovement()
        {
            var unique = Guid.NewGuid().ToString("N");
            var idList = new HashSet<long>();
            const int records = 10;

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                for(var i = 0; i < records; i++)
                {
                    sut.Create()
                        .Set("K_LongValue", 0)
                        .Set("K_TextValue255", unique);
                    sut.Update();
                    var id = sut.Id;
                    Assert.True(id > 0);
                    idList.Add(id);
                }
            }

            var forwardIdList = new HashSet<long>();

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                sut.Where("K_TextValue255", unique);
                Assert.True(sut.First());
                do
                {
                    var id = sut.Id;
                    Assert.Contains(id, idList);
                    forwardIdList.Add(sut.Id);
                } while (sut.Next());

                Assert.Equal(idList.OrderBy(v => v), forwardIdList.OrderBy(v => v));
            }

            var backwardIdList = new HashSet<long>();

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                sut.Where("K_TextValue255", unique);
                Assert.True(sut.Last());
                do
                {
                    var id = sut.Id;
                    Assert.Contains(id, idList);
                    backwardIdList.Add(sut.Id);
                } while (sut.Previous());
                
                Assert.Equal(idList.OrderBy(v => v), backwardIdList.OrderBy(v => v));
            }

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                foreach (var id in idList)
                {
                    sut.Seek(id);
                    sut.Delete();
                }
            }

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                Assert.Throws<TableFilterException>(() => sut.Where("K_TextValue255", unique));
                Assert.False(sut.First());
                Assert.False(sut.Last());
            }
        }

        [Fact]
        public void TestFilter()
        {
            var unique = Guid.NewGuid().ToString("N");
            var idList = new Dictionary<int, HashSet<long>>();
            const int records = 10;

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                for(var i = 0; i < records; i++)
                {
                    var modulus = i % 2;

                    sut.Create()
                        .Set("K_LongValue", modulus)
                        .Set("K_TextValue255", unique);
                    sut.Update();
                    var id = sut.Id;
                    Assert.True(id > 0);
                    if (!idList.ContainsKey(modulus))
                    {
                        idList.Add(modulus, new HashSet<long>());
                    }
                    idList[modulus].Add(id);
                }
            }

            var forwardIdList = new HashSet<long>();

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                var modulus = 0;
                sut
                    .Where("K_TextValue255", unique)
                    .AndWhere("K_LongValue", modulus);

                Assert.True(sut.First());
                do
                {
                    var id = sut.Id;
                    Assert.Contains(id, idList[modulus]);
                    forwardIdList.Add(sut.Id);
                } while (sut.Next());

                Assert.Equal(idList[modulus].OrderBy(v => v), forwardIdList.OrderBy(v => v));

                forwardIdList.Clear();

                modulus = 1;
                sut
                    .Where("K_TextValue255", unique)
                    .AndWhere("K_LongValue", modulus);

                Assert.True(sut.First());
                do
                {
                    var id = sut.Id;
                    Assert.Contains(id, idList[modulus]);
                    forwardIdList.Add(sut.Id);
                } while (sut.Next());

                Assert.Equal(idList[modulus].OrderBy(v => v), forwardIdList.OrderBy(v => v));
            }

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                foreach (var idList2 in idList)
                {
                    foreach (var id in idList2.Value)
                    {
                        sut.Seek(id);
                        sut.Delete();
                    }
                }
            }

            using (var sut = this.Container.Resolve<ITableFactory>().Create("K_Tests_DataTable"))
            {
                Assert.Throws<TableFilterException>(() => sut.Where("K_TextValue255", unique));
                Assert.False(sut.First());
                Assert.False(sut.Last());
            }
        }
    }
}
