// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DcProgrammingTutorial.Lib.TestClass.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the DcProgrammingTutorialTestClass type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace DcProgrammingTutorial.Lib.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DcProgrammingTutorial.Lib.Classes;
    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Interfaces;

    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    /// <summary>
    /// The dc programming tutorial test class.
    /// </summary>
    [TestFixture]
    public class DcProgrammingTutorialTestClass
    {
        /// <summary>
        /// The obj document.
        /// </summary>
        private ChangesOnDocuments objDocument;

        /// <summary>
        /// The controller.
        /// </summary>
        private IDocumentController controller;

        /// <summary>
        /// The company.
        /// </summary>
        private Company company = new Company();

        /// <summary>
        /// The setup test.
        /// </summary>
        [SetUp]
        public void SetupTest()
        {
            this.controller = new DocumentController();
            this.objDocument = new ChangesOnDocuments();
        }

        /// <summary>
        /// The add document to list.
        /// </summary> 
        [Test]
        public void AddDocumentToList()
        {
            this.controller = new DocumentControllerV2();
            var document = new Document { Name = "Kwstas" };
            this.objDocument.DocumentList = new BindingList<Document>();
            this.objDocument.Document = document;
            this.objDocument.DocumentList.Add(this.objDocument.Document);
            this.objDocument.Done = this.objDocument.DocumentList.Contains(this.objDocument.Document);
            Assert.AreEqual(this.objDocument.Document.Name, "Kwstas");
            Assert.AreEqual(this.objDocument.Done, true);
        }

        /// <summary>
        /// The calculate average balance.
        /// </summary>
        [Test]
        public virtual void CalculateAverageBalance()
        {
            this.objDocument.DocumentList = new BindingList<Document>();
            var document = new Document { Name = "Alex", Balance = 10 };
            this.objDocument.Document = document;
            this.controller.AddDocumentToList(this.objDocument);
            Assert.AreEqual(this.controller.CalculateAverageBalance(this.objDocument.DocumentList), 10);
        }

        /// <summary>
        /// The calculate average balance.
        /// </summary>
        [Test]
        public virtual void CalculateAverageBalance1()
        {
            this.objDocument.DocumentList = new BindingList<Document>();
            var document = new Document { Name = "Alex" };
            this.objDocument.Document = document;
            this.controller.AddDocumentToList(this.objDocument);
            Assert.AreEqual(this.controller.CalculateAverageBalance(this.objDocument.DocumentList), 0);
        }

        /// <summary>
        /// The calculate average balance list null.
        /// </summary>
        [Test]
        public virtual void CalculateAverageBalanceListNull()
        {
            this.objDocument.DocumentList = null;
            var document = new Document { Name = "Alex", Balance = 10 };
            this.objDocument.Document = document;
            //Act
            ActualValueDelegate<object> testDelegate = () => this.controller.CalculateAverageBalance(this.objDocument.DocumentList);

            //Assert
            Assert.That(testDelegate, Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// The calculate average balance list null.
        /// </summary>
        [Test]
        public virtual void CalculateAverageBalanceListIsEmpty()
        {
            this.objDocument.DocumentList = new BindingList<Document>();
            var document = new Document { Name = "Alex" , Balance = 10 };
            this.objDocument.Document = document;
            //Act
            ActualValueDelegate<object> testDelegate = () => this.controller.CalculateAverageBalance(this.objDocument.DocumentList);

            //Assert
            Assert.That(testDelegate , Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// The create new document.
        /// </summary>
        [Test]
        public void CreateNewDocument()
        {
            var document = this.controller.CreateNewDocument("delegates", this.company);
            Assert.AreEqual(document.Name, "delegates");
        }

        /// <summary>
        /// The remove document from list.
        /// </summary>
        [Test]
        public void RemoveDocumentFromList()
        {
            var document = new Document { Name = "Alex" };
            this.objDocument.DocumentList = new BindingList<Document>();
            this.controller.AddDocumentToList(this.objDocument);
            this.controller.RemoveDocumentFromList(this.objDocument.DocumentList, this.objDocument.Document);
            var removeChecker = !this.objDocument.DocumentList.Contains(document);
            Assert.AreEqual(removeChecker, true);
        }

        /// <summary>
        /// The calculate tax.
        /// </summary>
        [Test]
        public void CalculateTax()
        {
            var document = new Document { Name = "Alex", Balance = 100 };
            Assert.AreEqual(this.controller.CalculateTax(document), 20);
        }

        /// <summary>
        /// The calculate tax.
        /// </summary>
        [Test]
        public void CalculateTaxBalanceNull()
        {
            var document = new Document { Name = "Alex" };
            Assert.AreEqual(this.controller.CalculateTax(document), 0);
        }
    }
}
