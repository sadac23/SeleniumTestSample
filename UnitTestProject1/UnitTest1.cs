using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;

// Seleniumサンプルクラス
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver;

        [TestMethod]
        public void TestMethod1()
        {
            using(this._driver = new ChromeDriver())
            {
                this._driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

                // サンプルページを開く
                this._driver.Navigate().GoToUrl("C:\\github\\sadac23\\webdb-selenium-sample\\index.html");

                // ユーザ名とパスワードのinput要素を取得する
                IWebElement usernameInput = this._driver.FindElement(By.Id("username"));
                IWebElement passwordInput = this._driver.FindElement(By.Id("password"));

                // ユーザ名とパスワードを入力する
                usernameInput.SendKeys("user1");
                passwordInput.SendKeys("p@ssword");

                // ログインボタン要素を取得する
                IWebElement loginButton = this._driver.FindElement(By.Id("login"));

                // ログインボタンをクリックする
                loginButton.Click();

                // コメントのinput要素を取得する
                IWebElement commentInput = this._driver.FindElement(By.Id("comment-text"));

                // コメントを入力する
                commentInput.SendKeys("Hello World!");

                // 投稿ボタン要素を取得する
                IWebElement postButton = this._driver.FindElement(By.Id("post"));

                // 投稿ボタンをクリックする
                postButton.Click();

                // コメント要素を取得する
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> comments = this._driver.FindElements(By.ClassName("comment"));

                // コメントが投稿されていることをテストする
                Assert.AreEqual(comments.Count, 1);
                Assert.AreEqual(comments[0].Text, "Hello World!");

            }
        }
    }
}
