// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Document.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Classes
{
    using System;

    using DcProgrammingTutorial.Lib.Interfaces;

    /// <summary>
    /// It holds an event each time document updated.
    /// </summary>
    public delegate void DocumentUpdated();

    /// <summary>
    /// A class with the document's audits.
    /// </summary>
    public class Document : IEntity
    {
        /// <summary>
        /// An event which is invoked each time a document is updated.
        /// </summary>
        public event DocumentUpdated DocumentUpdated;

        /// <summary>
        /// The creation of a dummy document.
        /// </summary>
        public static Document CreateDummyDocument
            => new Document
                   {
                       Id = 0, Code = "A", Name = "Delegates", Created = DateTime.Now, Balance = 19
                   };

        /// <summary>
        /// Gets or sets the balance of the document.
        /// </summary>
        public float Balance { get; set; }

        /// <summary>
        /// Gets or sets the document code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the document company.
        /// </summary>
        public Company Company { get; set; }

        /// <summary>
        /// The company name.
        /// </summary>
        public string CompanyName => this.Company.Name;

        /// <summary>
        /// Gets or sets the document id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the document name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date and time which the document is created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the date and time which the document is updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the date and time which the document is deleted.
        /// </summary>
        public DateTime Deleted { get; set; }

        /// <summary>
        /// Gets or sets the date and time which the document is created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user the document is updated by.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user the document is deleted by.
        /// </summary>
        public string DeletedBy { get; set; }

        /// <summary>
        /// Invokes an event every time the method is updated.
        /// </summary>
        public virtual void OnDocumentUpdated()
        {
            this.DocumentUpdated?.Invoke();
        }
    }
}