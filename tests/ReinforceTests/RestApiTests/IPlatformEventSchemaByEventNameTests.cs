using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IPlatformEventSchemaByEventNameTests
    {
        [Theory, AutoData]
        public async Task IPlatformEventSchemaByEventName(string expected, string eventName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IPlatformEventSchemaByEventName>();
                var result = await api.GetAsync<string>(eventName);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{eventName}/eventSchema");
            }
        }

        [Theory, AutoData]
        public async Task IPlatformEventSchemaByEventName_PayloadFormat(string expected, string eventName, string payloadFormat)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IPlatformEventSchemaByEventName>();
                var result = await api.GetAsync<string>(eventName, payloadFormat, CancellationToken.None);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{eventName}/eventSchema?payloadFormat={payloadFormat}");
            }
        }
    }
}