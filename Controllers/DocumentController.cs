// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentController.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   A controller that that manipulates the documents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Controllers
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using DcProgrammingTutorial.Lib.Classes;
    using DcProgrammingTutorial.Lib.Interfaces;

    /// <summary>
    /// A delegate that holds an evnt each time a document is added to list.
    /// </summary>
    public delegate void DocumentAddedToList();
   
    /// <summary>
    /// The document controller.
    /// </summary>
    public class DocumentController : IDocumentController
    {
        #region Const Messages

        /// <summary>
        /// The message that is displayed every time our list is empty.
        /// </summary>
        private const string DocumentListEmptyErrorMessage = "The provided list has no documents!";

        #endregion

        #region Private Variables

        /// <summary>
        /// The counter that increases the document id.
        /// </summary>
        private int counterId;

        #endregion 

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentController"/> class.
        /// </summary>
        public DocumentController()
        {
            this.counterId = 1;
        }

        #region Public Methods

        /// <summary>
        /// A list that contains our current documents.
        /// </summary>
        public event DocumentAddedToList DocumentAddedToList;

        /// <summary>
        /// A method which adds a new document to list.
        /// </summary>
        /// <param name="objDocument">
        /// An object which holds our new document.
        /// </param>
        /// <returns>
        /// The <see cref="BindingList{Document}"/>.
        /// Returns an object with our document list, a flag which checks if the document is added succesfuly and our current document,
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1614:ElementParameterDocumentationMustHaveText", Justification = "Reviewed. Suppression is OK here.")]
        public ChangesOnDocuments AddDocumentToList(ChangesOnDocuments objDocument)
        {
            objDocument.DocumentList.Add(objDocument.Document);
            objDocument.Done = objDocument.DocumentList.Contains(objDocument.Document);
            return objDocument;
        }

        /// <summary>
        /// A method that calculates the average balance of the documents in our current list.
        /// </summary>
        /// <param name="list">
        /// The cells binding list.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// Returns the value of the average of our current documents.
        /// </returns>
        /// <exception cref="ArgumentException"> Fired when given list is empty.</exception>
        public virtual float CalculateAverageBalance(BindingList<Document> list)
        {
            if (list.Count > 0)
            {
                return list.Average(document => document.Balance);
            }
            else
            {
                throw new NullReferenceException(DocumentListEmptyErrorMessage);
            }
        }

        /// <summary>
        /// A method that creates a new document.
        /// </summary>
        /// <param name="name">
        /// The name of the document.
        /// </param>
        /// <param name="company">
        /// The company name.
        /// </param>
        /// <returns>
        /// The <see cref="Document"/>.
        /// Returns the new document.
        /// </returns>
        public Document CreateNewDocument(string name, Company company)
        {
            var id = this.counterId++;
            var myDocument = new Document
            {
                Name = name,
                Company = company,
                Id = id,
                Code = id.ToString(),
                Balance = id + 10,
                CreatedBy = Environment.UserName,
                Created = DateTime.Now
            };
            return myDocument;
        }

        /// <summary>
        /// A method that removes the selected document from list.
        /// </summary>
        /// <param name="list">
        /// Our list of documents.
        /// </param>
        /// <param name="document">
        /// The document name.
        /// </param>
        /// <returns>
        /// The <see cref="Tuple"/>.
        /// Returns a tuple with a bool that checks if the document is removed successfully and our list with the rest documents.
        /// </returns>
        public Tuple<bool, BindingList<Document>, Document> RemoveDocumentFromList(BindingList<Document> list, Document document)
        {
            list.Remove(document);
            var removeChecker = !list.Contains(document);
            return new Tuple<bool, BindingList<Document>, Document>(removeChecker, list, document);
        }

        /// <summary>
        /// A method that calculates the tax of the selected document.
        /// </summary>
        /// <param name="document">
        /// The selected document.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// Returns the value of the selected document tax.
        /// </returns>
        public virtual float CalculateTax(Document document)
        {
            return document.Balance * 0.2f;
        }

        /// <summary>
        /// Adds a new document to our list.
        /// </summary>
        /// <param name="objDocument">
        /// The document name.
        /// </param>
        /// <returns>
        /// The <see cref="Tuple"/>.
        /// Returns a tuple with a bool that checks if the document is added successfully,a list that contains our documents and our new document.
        /// </returns>
        Tuple<bool, BindingList<Document>, Document> IDocumentController.AddDocumentToList(ChangesOnDocuments objDocument)
        {
            objDocument.DocumentList.Add(objDocument.Document);
            objDocument.Done = objDocument.DocumentList.Contains(objDocument.Document);
            this.OnDocumentAddedToList();
            return new Tuple<bool, BindingList<Document>, Document>(objDocument.Done, objDocument.DocumentList, objDocument.Document);
        }

        #endregion

        /// <summary>
        /// Invokes an event every time a document is added to our list.
        /// </summary>
        protected virtual void OnDocumentAddedToList()
        {
            this.DocumentAddedToList?.Invoke();
        }
    }
}