using System.Net;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Moq.Protected;
using ServicesIfs;
using Xunit;
using Times = Moq.Times;

namespace SesamResponseServices.UnitTests.Services;

public class AccessTokenServiceTests
{
    [Fact]
    public async Task GetAccessToken_Checks_CacheForToken()
    {
        // Arrange
        var basicMocks = new BasicMocks();
        var underTest = CreateUnderTest(basicMocks);
        object anOut;
        basicMocks.MemoryCache.Setup(c => c.TryGetValue(BasicMocks.MemoryCacheKey, out anOut)).Returns(true);

        // Act
        await underTest.GetAccessToken();

        // Assert
        basicMocks.MemoryCache.Verify(c => c.TryGetValue(BasicMocks.MemoryCacheKey, out anOut), Times.Once);
    }

    [Fact]
    public async Task GetAccessToken_Returns_CachedToken()
    {
        // Arrange
        var basicMocks = new BasicMocks();
        var underTest = CreateUnderTest(basicMocks);
        object expected = "THisIsTheCachedToken";
        basicMocks.MemoryCache.Setup(c => c.TryGetValue(BasicMocks.MemoryCacheKey, out expected)).Returns(true);

        // Act
        var actual = await underTest.GetAccessToken();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetAccessToken_Calls_HttpClient()
    {
        // Arrange
        var basicMocks = new BasicMocks();
        var underTest = CreateUnderTest(basicMocks);

        // Act
        await underTest.GetAccessToken();

        // Assert
        var mockedProtected = basicMocks.MessageHandler.Protected();
        mockedProtected.Verify("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GetAccessToken_Caches_Token()
    {
        // Arrange
        var basicMocks = new BasicMocks();
        var underTest = CreateUnderTest(basicMocks);

        // Act
        await underTest.GetAccessToken();

        // Assert
        basicMocks.MemoryCache.Verify(c => c.CreateEntry(BasicMocks.MemoryCacheKey), Times.Once);
    }

    [Fact]
    public async Task GetAccessToken_Returns_Token()
    {
        // Arrange
        var basicMocks = new BasicMocks();
        var underTest = CreateUnderTest(basicMocks);

        // Act
        var actual = await underTest.GetAccessToken();

        // Assert
        Assert.Equal(BasicMocks.AccessToken, actual);     
    }

    private static AccessTokenService CreateUnderTest(BasicMocks basicMocks)
    {
        return new AccessTokenService(
            basicMocks.Client.Object,
            basicMocks.ClientCredentialsConfiguration.Object,
            basicMocks.MemoryCache.Object    
        );
    }

    private class BasicMocks
    {
        public readonly Mock<IClientCredentialsConfiguration> ClientCredentialsConfiguration;
        public readonly Mock<IMemoryCache> MemoryCache;
        public readonly Mock<HttpClient> Client;
        public readonly Mock<HttpMessageHandler> MessageHandler;
        public static string AccessToken => "ElTokeno";

        public static string MemoryCacheKey => "AccessTokenMemoryCacheKey";

        public BasicMocks()
        {
            ClientCredentialsConfiguration = new Mock<IClientCredentialsConfiguration>();
            MemoryCache = new Mock<IMemoryCache>();
            MessageHandler = new Mock<HttpMessageHandler>();
            Client = new Mock<HttpClient>(MessageHandler.Object);
            ClientCredentialsConfiguration.Setup(c => c.TokenEndpoint()).Returns("https://www.fakeweb.no");

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"access_token\":\""+AccessToken+"\",\"expires_in\":1234}")
            };
            var mockedProtected = MessageHandler.Protected();
            mockedProtected.Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage);

            object anOut;
            MemoryCache.Setup(c => c.TryGetValue(MemoryCacheKey, out anOut)).Returns(false);
            var value = new Mock<ICacheEntry>();
            MemoryCache.Setup(c => c.CreateEntry(It.IsAny<object>())).Returns(value.Object);
        }
    }
}