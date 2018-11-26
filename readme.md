## TestingBot - SpecFlow

TestingBot provides an online grid of browsers and mobile devices to run Automated tests on via Selenium WebDriver.
This example demonstrates how to use SpecFlow to run a test in parallel across several browsers.

### Environment Setup

1. Global Dependencies
    * MS Visual Studio 2015 or later.
    * Install the SpecFlow extension in Visual Studio
    ```

2. TestingBot Credentials
    * Add your TestingBot Key and Secret as environmental variables. You can find these in the [TestingBot Dashboard](https://testingbot.com/members/).
    ```
    $ export TB_KEY=<your TestingBot Key>
    $ export TB_SECRET=<your TestingBot Secret>
    ```

3. Setup
    * Clone the repo
	* Open the solution `SpecFlow-TestingBot.sln` in Visual Studio 2015 or higher
	* Build the solution
	* Update `App.config` file with your [TestingBot Key and Secret](https://testingbot.com/members/)

    ```

### Running your tests from Test Explorer via NUnit Test Adapter
- To run a single test, run test with fixture `single`
- To run parallel tests, run tests with fixture `parallel`

You will see the test result in the [TestingBot Dashboard](https://testingbot.com/members/)

### Resources
##### [TestingBot Documentation](https://testingbot.com/support/)

##### [SeleniumHQ Documentation](http://www.seleniumhq.org/docs/)

##### [SpecFlow Documentation](https://specflow.org/docs/)