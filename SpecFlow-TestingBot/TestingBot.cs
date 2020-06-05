using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Specialized;
using System.IO;

namespace SpecFlow_TestingBot
{
  [Binding]
  public sealed class SpecFlow_TestingBot
  {
    private TestingBotDriver tbDriver;
    private string[] tags;

    [BeforeScenario]
    public void BeforeScenario()
    {
      tbDriver = new TestingBotDriver(ScenarioContext.Current);
      ScenarioContext.Current["tbDriver"] = tbDriver;
    }

    [AfterScenario]
    public void AfterScenario()
    {
      tbDriver.Cleanup();
    }
  }


  public class TestingBotDriver
  {
    private IWebDriver driver;
    private string profile;
    private string environment;
    private ScenarioContext context;

    public TestingBotDriver(ScenarioContext context)
    {
      this.context = context;
    }

    public IWebDriver Init(string profile, string environment)
    {
      NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + profile) as NameValueCollection;
      NameValueCollection settings = ConfigurationManager.GetSection("environments/" + environment) as NameValueCollection;

      DesiredCapabilities capability = new DesiredCapabilities();

      foreach (string key in caps.AllKeys)
      {
        capability.SetCapability(key, caps[key]);
      }

      foreach (string key in settings.AllKeys)
      {
        capability.SetCapability(key, settings[key]);
      }

      String key = Environment.GetEnvironmentVariable("TESTINGBOT_KEY");
      if (key == null)
      {
        key = ConfigurationManager.AppSettings.Get("key");
      }

      String secret = Environment.GetEnvironmentVariable("TESTINGBOT_SECRET");
      if (secret == null)
      {
        secret = ConfigurationManager.AppSettings.Get("secret");
      }

      capability.SetCapability("client_key", key);
      capability.SetCapability("client_secret", secret);

      driver = new RemoteWebDriver(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability);
      return driver;
    }

    public void Cleanup()
    {
      driver.Quit();
    }
  }
}
