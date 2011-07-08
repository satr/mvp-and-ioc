using Tetris.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TetrisTests
{
    
    
    /// <summary>
    ///This is a test class for ScoreModelTest and is intended
    ///to contain all ScoreModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ScoreModelTest
    {


        private TestContext testContextInstance;
        private ScoreModel _model;

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
            _model = new ScoreModel(); // TODO: Initialize to an appropriate value

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
        ///A test for AddBrick
        ///</summary>
        [TestMethod()]
        public void AddBrickTest()
        {
            Assert.AreEqual(0, _model.CurrentScore);
            Assert.AreEqual(0, _model.TotalScore);
            _model.AddBrick();
            Assert.AreEqual(1, _model.CurrentScore);
            Assert.AreEqual(1, _model.TotalScore);
        }

        [TestMethod()]
        public void ResetCurrentScoreTest()
        {
            _model.AddBrick();
            Assert.AreEqual(1, _model.CurrentScore);
            Assert.AreEqual(1, _model.TotalScore);
            _model.ResetCurrentScore();
            Assert.AreEqual(0, _model.CurrentScore);
            Assert.AreEqual(1, _model.TotalScore);
        }

        [TestMethod()]
        public void InitTest()
        {
            _model.AddBrick();
            Assert.AreEqual(1, _model.CurrentScore);
            Assert.AreEqual(1, _model.TotalScore);
            _model.Init();
            Assert.AreEqual(0, _model.CurrentScore);
            Assert.AreEqual(0, _model.TotalScore);
        }

    }
}
