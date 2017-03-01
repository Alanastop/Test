// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentController.cs" company="DataCommunication">
//  DcProgrammingTutorial 
// </copyright>
// <summary>
//   Defines the IDocumentController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Interfaces
{
    using System;
    using System.ComponentModel;

    using DcProgrammingTutorial.Lib.Classes;
    using DcProgrammingTutorial.Lib.Controllers;

    /// <summary>
    /// The DocumentController interface.
    /// </summary>
    public interface IDocumentController
    {
        /// <summary>
        /// An event that is invoked every time a document is added to list.
        /// </summary>
        event DocumentAddedToList DocumentAddedToList;

        /// <summary>
        /// A method which adds a document to list.
        /// </summary>
        /// <param name="objDocument">
        /// An object which holds a bool that checks if document is added successfully, a list with our current documents and our new document.
        /// </param>
        /// <returns>
        /// The <see cref="Tuple"/>.
        /// Returns a Tuple which holds the value of the flag, our list of documents and our newly added document.
        /// </returns>
        Tuple<bool, BindingList<Document>, Document> AddDocumentToList(ChangesOnDocuments objDocument);

        /// <summary>
        /// A method that calculates the average balance of our current documents in list.
        /// </summary>
        /// <param name="list">
        /// A list with our current documents.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// Returns the value of the average balance of our documents in list.
        /// </returns>
        float CalculateAverageBalance(BindingList<Document> list);

        /// <summary>
        /// A method that creates a new document.
        /// </summary>
        /// <param name="name">
        /// The document name.
        /// </param>
        /// <param name="company">
        /// The company where the document belongs.
        /// </param>
        /// <returns>
        /// The <see cref="Document"/>.
        /// Returns the newly created document.
        /// </returns>
        Document CreateNewDocument(string name, Company company);
        
        /// <summary>
        /// A method which removes a document from list.
        /// </summary>
        /// <param name="list">
        /// The list of our current documents.
        /// </param>
        /// <param name="document">
        /// The selected document name which shall be removed.
        /// </param>
        /// <returns>
        /// The <see cref="Tuple"/>.
        /// Returns a tuple which holds the value of the flag, our list of documents and our newly added document.
        /// </returns>
        Tuple<bool, BindingList<Document>, Document> RemoveDocumentFromList(BindingList<Document> list, Document document);

        /// <summary>
        /// A method which calculates the tax of the current document.
        /// </summary>
        /// <param name="document">
        /// The selected document name.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// Returns the value of the tax of the selected document.
        /// </returns>
        float CalculateTax(Document document);
    }
}
