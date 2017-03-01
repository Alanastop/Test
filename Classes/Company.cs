// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Company.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The company.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Classes
{
    using System;
    using System.ComponentModel;

    using DcProgrammingTutorial.Lib.Interfaces;

    /// <summary>
    /// A class wiht the audits of the company.
    /// </summary>
    public class Company : IEntity, IEntityAudit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        public Company()
        {
            this.Documents = new BindingList<Document>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        /// <param name="document">
        /// The given Company document.
        /// </param>
        public Company(Document document)
        {
            document.Company = this;
            this.Documents = new BindingList<Document> { document };
        }

        /// <summary>
        /// Gets or sets a value indicating whether the company is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the code of the company.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a list of documents of the current company.
        /// </summary>
        public BindingList<Document> Documents { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date and time which the company is created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the date and time which the company is updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets when the company is deleted.
        /// </summary>
        public DateTime Deleted { get; set; }

        /// <summary>
        /// Gets or sets the user the object is created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user the object is updated by.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user the object is deleted by.
        /// </summary>
        public string DeletedBy { get; set; }
    }
}