using InvestingAPI;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;

namespace FinanceScrapper.Tests
{
    [TestFixture]
    public class YahooFinanceTests
    {
        private readonly YahooFinance _yahooFinance;
        private readonly SeleniumScrapper _seleniumScrapper;

        public YahooFinanceTests()
        {
            _yahooFinance = new YahooFinance();
            _seleniumScrapper = new SeleniumScrapper();
        }

        [Test]
        public void Initialise_Should_Set_Cookies_And_Crumb_When_Token_Refreshed()
        {
            // Act
            _yahooFinance.Initialise();

            // Assert
            ClassicAssert.IsNotNull(Token.CookieCollectionData);  // Ensure cookies were set
            ClassicAssert.IsNotNull(Token.Crumb);                // Ensure crumb was set
        }

        [Test]
        public void GetAllHistoricalYahooData_Should_Return_Valid_Data()
        {
            // Arrange
            _yahooFinance.Initialise();

            // Act
            var result = _yahooFinance.GetAllHistoricalYahooData("AAPL");

            // Assert
            ClassicAssert.IsNull(result.chartData.chart.error);
        }

        [Test]
        public void GetHistoricalYahooDataBetweenDates_Should_Return_Valid_Data()
        {
            // Arrange
            _yahooFinance.Initialise();
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2020, 1, 7);

            // Act
            var result = _yahooFinance.GetHistoricalYahooDataBetweenDates("AAPL", startDate, endDate);

            // Assert
            ClassicAssert.IsNull(result.chartData.chart.error);
        }


        [Test]
        public void GetYahooQuoteType()
        {
            // Arrange
            _yahooFinance.Initialise();
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2023, 1, 1);

            // Act
            var result = _yahooFinance.GetQuoteType("AAPl");

            // Assert
            ClassicAssert.IsNull(result.QuoteType.Error);  
        }
        [Test]
        public void GetYahooQuoteSummary()
        {
            // Arrange
            _yahooFinance.Initialise();
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2023, 1, 1);

            // Act
            var result = _yahooFinance.GetQuoteSummary("AAPl", new string[3]{ "price", "earnings", "quoteType"});

            // Assert
            ClassicAssert.IsNull(result.QuoteSummary.Error);
        }

        [Test]
        public void GetInvestingData()
        {
            // Act
            var result = _seleniumScrapper.GetFinancialData("2");

            // Assert
            ClassicAssert.IsNotNull(result);  
        }
    }
}
