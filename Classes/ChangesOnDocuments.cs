// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangesOnDocuments.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The changes on documents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Classes
{
    using System.ComponentModel;

    /// <summary>
    /// The changes on documents.
    /// </summary>
    public class ChangesOnDocuments 
    {
        /// <summary>
        /// Gets or sets a value indicating whether is true or not.
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        public Document Document { get; set; }

        /// <summary>
        /// Gets or sets a list of documents.
        /// </summary>
        public BindingList<Document> DocumentList { get; set; }
    }
}
