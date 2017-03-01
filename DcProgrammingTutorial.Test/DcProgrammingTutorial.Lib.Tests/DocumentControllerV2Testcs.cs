// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentControllerV2Testcs.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the DocumentControllerV2Testcs type.
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

    using NUnit.Framework;
    using NUnit.Framework.Constraints;
    using NUnit.Framework.Internal;

    /// <summary>
    /// The document controller v 2 testcs.
    /// </summary>
    [TestFixture]
    public class DocumentControllerV2Testcs
    {
        /// <summary>
        /// The controller v 2.
        /// </summary>
        private DocumentControllerV2 controllerV2 = new DocumentControllerV2();

        /// <summary>
        /// The obj document.
        /// </summary>
        private ChangesOnDocuments objDocument = new ChangesOnDocuments();

        /// <summary>
        /// The calculate average balance.
        /// </summary>
        [Test]
        public virtual void CalculateAverageBalance()
        {
            this.objDocument.DocumentList = new BindingList<Document>();
            var document = new Document { Name = "Alex" , Balance = 10 };
            this.objDocument.Document = document;
            this.controllerV2.AddDocumentToList(this.objDocument);
            Assert.AreEqual(this.controllerV2.CalculateAverageBalance(this.objDocument.DocumentList) , 10);
        }
        
        /// <summary>
        /// The calculate average balance list null.
        /// </summary>
        [Test]
        public virtual void CalculateAverageBalanceListNull()
        {
            this.objDocument.DocumentList = null;
            var document = new Document { Name = "Alex" , Balance = 10 };
            this.objDocument.Document = document;
            //Act
            ActualValueDelegate<object> testDelegate = () => this.controllerV2.CalculateAverageBalance(this.objDocument.DocumentList);

            //Assert
            Assert.That(testDelegate , Throws.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// The calculate tax.
        /// </summary>
        [Test]
        public void CalculateTax()
        {
            var document = new Document { Name = "Alex" , Balance = 100 };
            Assert.AreEqual(this.controllerV2.CalculateTax(document) , 20);
        }

        /// <summary>
        /// The calculate tax.
        /// </summary>
        [Test]
        public void CalculateTaxDocumentNull()
        {
            //Act
            ActualValueDelegate<float> testDelegate = () => this.controllerV2.CalculateTax(null);

            //Assert
            Assert.That(testDelegate , Throws.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// The calculate tax.
        /// </summary>
        [Test]
        public void CalculateTaxDocumentOverZero()
        {
            var document = new Document { Name = "Alex", Balance = 100, Created = DateTime.Now };

            Assert.AreEqual(this.controllerV2.CalculateTax(document), 40);
        }
    }
}
