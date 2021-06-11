using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace iCollections.BDDTests.Steps
{
    [Binding]
    public class FavoriteCollectionsPageSteps
    {
        private readonly ScenarioContext _ctx;
        private string _hostBaseName = @"https://localhost:5001/";
        private readonly IWebDriver _driver;

        public string coll_id;

        public FavoriteCollectionsPageSteps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _ctx = scenarioContext;
            _driver = driver;
        }
        
        [When(@"I navigate to the '(.*)' page with '(.*)'")]
        public void WhenINavigateToThePageWith(string page, string username)
        {
            page = "MyFavorites";
            if (page.Equals("MyFavorites"))
            {
                _driver.Navigate().GoToUrl(_hostBaseName + @"Collections" + username + "/MyFavorites");
            }
            else
            {
                ScenarioContext.StepIsPending();
            }
        }
        
        [When(@"Have favorited collections")]
        public void WhenHaveFavoritedCollections()
        {
            var head = _driver.FindElement(By.TagName("thead"));
            Assert.That(head, Is.Not.Null);
        }
        
        [When(@"I click on a keyword associated with a favorite collection")]
        public void WhenIClickOnAKeywordAssociatedWithAFavoriteCollection()
        {
            _driver.FindElement(By.Id("kw_link")).Click();
        }
        
        [When(@"I click on the remove button that corresponds to any of my favorite collections")]
        public void WhenIClickOnTheRemoveButtonThatCorrespondsToAnyOfMyFavoriteCollections()
        {
            coll_id = _driver.FindElement(By.ClassName("rem_fav")).GetAttribute("id");
            _driver.FindElement(By.ClassName("rem_fav")).Click();
        }
        
        [Then(@"I will find all of my favorites collections with details such as name, owner, keyword, and date created")]
        public void ThenIWillFindAllOfMyFavoritesCollectionsWithDetailsSuchAsNameOwnerKeywordAndDateCreated()
        {
            var name = _driver.FindElement(By.Id("coll_name"));

            var owner = _driver.FindElement(By.Id("coll_owner"));

            var keyword = _driver.FindElement(By.Id("coll_kw"));

            var datecreated = _driver.FindElement(By.Id("coll_date"));

            Assert.That(name, Is.Not.Null);
            Assert.That(owner, Is.Not.Null);
            Assert.That(keyword, Is.Not.Null);
            Assert.That(datecreated, Is.Not.Null); ;
        }
        
        [Then(@"I will be redirected to the browse page with a search corresponding to that '(.*)'")]
        public void ThenIWillBeRedirectedToTheBrowsePageWithASearchCorrespondingToThat(string keyword)
        {
            _driver.Navigate().GoToUrl(_hostBaseName + @"Browse?keywords=" + keyword);
        }
        
        [Then(@"the page will be reloaded")]
        public void ThenThePageWillBeReloaded()
        {
        }
        
        [Then(@"the removed collection no longer be displayed")]
        public void ThenTheRemovedCollectionNoLongerBeDisplayed()
        {
            var collection = _driver.FindElement(By.Id(coll_id));

            Assert.That(collection, Is.Null);
        }
    }
}
