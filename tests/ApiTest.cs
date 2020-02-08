using System;
using Xunit;
using RA;

namespace tests
{
    public class ApiTest
    {
        [Fact]
        public void GenerateTest1()
        {
            var body = new
            {
                Url = "https://www.alibaba.ir"
            };
            new RestAssured()
              .Given()
                .Header("Content-Type", "application/json")
                .Body(body)
              .When()
                .Post("localhost:5000/urls")
              .Then()
                .TestStatus("test status", x => x == 200)
                .Assert("test status");

        }

        [Fact]
        public void GenerateTest2()
        {
            var body = new
            {
                Url = "foo"
            };
            new RestAssured()
              .Given()
                .Header("Content-Type", "application/json")
                .Body(body)
              .When()
                .Post("localhost:5000/urls")
              .Then()
                .TestStatus("test status", x => x == 400)
                .Assert("test status");

        }

    }
}
