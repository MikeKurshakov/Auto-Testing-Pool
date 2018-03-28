using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestChek
{
        [TestFixture]
        public class Test
        {
            [OneTimeSetUp] // вызывается перед началом запуска всех тестов
            public void OneTimeSetUp()
            {
                // ТУТ КОД
            }

            [OneTimeTearDown] //вызывается после завершения всех тестов
            public void OneTimeTearDown()
            {
                // ТУТ КОД
            }

            [SetUp] // вызывается перед каждым тестом
            public void SetUp()
            {
                // ТУТ КОД
            }

            [TearDown] // вызывается после каждого теста
            public void TearDown()
            {
                // ТУТ КОД
            }

            [Test]
            public void TEST_1()
            {
                // ТУТ КОД
            }

            [Test]
            public void TEST_2()
            {
                // ТУТ КОД
            }
    }
}
