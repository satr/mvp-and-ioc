using Tetris.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.Interfaces;

namespace TetrisTests
{
    
    
    /// <summary>
    ///This is a test class for ScorePresenterTest and is intended
    ///to contain all ScorePresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ScorePresenterTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            IScoreView view = new MockScoreView();
            ScorePresenter target = new ScorePresenter(view); // TODO: Initialize to an appropriate value
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CountBrick
        ///</summary>
        [TestMethod()]
        public void CountBrickTest()
        {
            target.CountBrick();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Start
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            target.Start();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ShowTotal
        ///</summary>
        [TestMethod()]
        public void ShowTotalTest()
        {
            target.ShowTotal();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [TestMethod()]
        public void InitTest()
        {
            target.Init();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
