﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityAudit.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   Defines the audits of our current entities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Interfaces
{
    using System;

    /// <summary>
    /// The interface which contains our audit fields.
    /// </summary>
    public interface IEntityAudit
    {
        /// <summary>
        /// Gets or sets the date and time when the document is created.
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets when a document is updated.
        /// </summary>
        DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets when a document is deleted.
        /// </summary>
        DateTime Deleted { get; set; }

        /// <summary>
        /// Gets or sets from who a document is created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets from who a document is updated by.
        /// </summary>
        string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets from who a document is deleted by.
        /// </summary>
        string DeletedBy { get; set; }
    }
}
