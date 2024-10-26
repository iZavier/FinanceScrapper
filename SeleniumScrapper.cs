using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace InvestingAPI
{
    internal class SeleniumScrapper
    {

        public SeleniumScrapper()
        {
        }

        public string GetFinancialData(string PID)
        {
            // Initialize the response data
            string responseData = string.Empty;

            try
            {

                // Define the Firefox profile path and target URL
                string profilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Mozilla\Firefox\Profiles\r6rr6v50.Scapper");
                string url = $"view-source:https://api.investing.com/api/financialdata/table/list/{PID}"; // I'm not happy about this :(

                // Set up Firefox options
                FirefoxOptions options = new FirefoxOptions();
                options.AddArguments("-profile", profilePath);
                options.AddArgument("--start-maximized"); 
                options.AddArgument("--disable-gpu");     
                options.AddArgument("--no-sandbox");      
                //options.AddArgument("--headless");

                // Create Firefox driver service and hide the command prompt window
                FirefoxDriverService driverService = FirefoxDriverService.CreateDefaultService();
                driverService.SuppressInitialDiagnosticInformation = true;
                driverService.HideCommandPromptWindow = true;

                // Initialize the Firefox driver with the options
                using (FirefoxDriver driver = new FirefoxDriver(driverService, options))
                { 

                    // Navigate to the URL and retrieve the data
                    driver.Navigate().GoToUrl(url);
                    // Spoof navigator properties to avoid detection
                    IJavaScriptExecutor js = driver;
                    js.ExecuteScript(@"
                        Object.defineProperty(navigator, 'webdriver', { get: () => false });
                        Object.defineProperty(navigator, 'languages', { get: () => ['en-US', 'en'] });
                        Object.defineProperty(navigator, 'platform', { get: () => 'Win32' });
                        Object.defineProperty(navigator, 'userAgent', { 
                            get: () => 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36' 
                        });
                    ");

                    // Debugging: log spoofed properties (can be removed in production)
                    bool isWebdriver = (bool)js.ExecuteScript("return navigator.webdriver;");
                    Console.WriteLine("navigator.webdriver: " + isWebdriver);  // Should print "false"

                    string languages = (string)js.ExecuteScript("return navigator.languages.toString();");
                    Console.WriteLine("navigator.languages: " + languages);  // Should print "en-US,en"

                    Thread.Sleep(3000);  
                    // Get the raw data from the <pre> tag
                    string response = driver.FindElement(By.TagName("pre")).Text;
                    responseData = response;

                    // Close the browser
                    driver.Quit();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                // Log the exception stack trace during debugging
                Console.WriteLine($"PID: {PID}\r\n{ex.StackTrace}");
#endif
            }

            // Return the retrieved data
            return responseData;
        }


    }

}

