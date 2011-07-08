using Tetris.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.Interfaces;
using TetrisTests.Mocks;

namespace TetrisTests.PresenterTests
{
    
    
    /// <summary>
    ///This is a test class for ScorePresenterTest and is intended
    ///to contain all ScorePresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ScorePresenterTestSuite
    {

        const int TestInitialDrawnCurrentScore = 10;
        const int TestInitialDrawnTotalScore = 20;

        private TestContext testContextInstance;
        private MockScoreView _view;
        private ScorePresenter _presenter;

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
            _view = new MockScoreView();
            _presenter = new ScorePresenter(_view);
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
            Assert.AreEqual(0, _view.TestDrawnCurrentScore);
            Assert.AreEqual(0, _view.TestDrawnTotalScore);
            _presenter.CountBrick();
            Assert.AreEqual(1, _view.TestDrawnCurrentScore);
            Assert.AreEqual(0, _view.TestDrawnTotalScore);
        }

        /// <summary>
        ///A test for Start
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            _view.TestDrawnCurrentScore = TestInitialDrawnCurrentScore;
            _view.TestDrawnTotalScore = TestInitialDrawnTotalScore;

            Assert.AreEqual(TestInitialDrawnCurrentScore, _view.TestDrawnCurrentScore);
            Assert.AreEqual(TestInitialDrawnTotalScore, _view.TestDrawnTotalScore);
            _presenter.Start();
            Assert.AreEqual(0, _view.TestDrawnCurrentScore);
            Assert.AreEqual(TestInitialDrawnTotalScore, _view.TestDrawnTotalScore);
        }

        /// <summary>
        ///A test for ShowTotal
        ///</summary>
        [TestMethod()]
        public void ShowTotalTest()
        {
            _presenter.ShowTotal();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [TestMethod()]
        public void InitTest()
        {
            Assert.IsFalse(_view.TestIsInitialized);
            _presenter.Init();
            Assert.IsTrue(_view.TestIsInitialized);
        }
    }
}
