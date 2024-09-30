using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMars.Helpers;
using SeleniumExtras.WaitHelpers;

namespace ProjectMars.Utils
{
    public enum LocatorType
    {
        Id,
        xPath,
        CssSelector,
        Name,
        ClassName
    }

    internal class WaitHelper : Driver
    {
        public static void WaitToBeClickable(LocatorType locatorType, string locatorValue, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            if (locatorType == LocatorType.Id)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            }
            else if (locatorType == LocatorType.xPath)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
            else if (locatorType == LocatorType.CssSelector)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
            }
            else if (locatorType == LocatorType.Name)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(locatorValue)));
            }
            else if (locatorType == LocatorType.ClassName)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(locatorValue)));
            }
        }

        public static void WaitToBeVisible(LocatorType locatorType, string locatorValue, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            if (locatorType == LocatorType.Id)

            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
            }
            else if (locatorType == LocatorType.xPath)
            {

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));

            }
            else if (locatorType == LocatorType.CssSelector)
            {

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));

            }
            else if (locatorType == LocatorType.Name)
            {

                wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locatorValue)));

            }
            else if (locatorType == LocatorType.ClassName)
            {

                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));

            }
        }

        public static void WaitToBeInvisibleElement(LocatorType locatorType, string locatorValue, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            if (locatorType == LocatorType.Id)

            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(locatorValue)));
            }
            else if (locatorType == LocatorType.xPath)
            {

                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(locatorValue)));

            }
            else if (locatorType == LocatorType.CssSelector)
            {

                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(locatorValue)));

            }
            else if (locatorType == LocatorType.Name)
            {

                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Name(locatorValue)));

            }
            else if (locatorType == LocatorType.ClassName)
            {

                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName(locatorValue)));

            }
        }

    }
}
