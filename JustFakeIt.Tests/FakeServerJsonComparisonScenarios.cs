using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JustFakeIt.Tests
{
    public class FakeServerJsonComparisonScenarios
    {
        [Fact]
        public async Task FakeServer_ExpectPostWithPartialExpectedJsonBody_ResponseMatchesExpected()
        {
            const string expectedResult = "Some String Data";

            const string path = "/some-path";

            var content = @"{{ Key: ""Value"", Key2: ""Value"" }}";
            var expectedContent = new StringContent(@"{{ Key: ""Value"" }}");

            using (var fakeServer = new FakeServer())
            {
                fakeServer.Expect.Post(path, content).Returns(expectedResult);

                fakeServer.Start();

                var resp = await fakeServer.Client.PostAsync(path, expectedContent);
                var result = await resp.Content.ReadAsStringAsync();

                result.Should().Be(expectedResult);
            }
        }
    }
}
