// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentControllerV2.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The document controller v2 which manipulates the documents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Controllers
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using Classes;

    /// <summary>
    /// The document controller v 2 class.
    /// </summary>
    public class DocumentControllerV2 : DocumentController
    {
        /// <summary>
        /// The message which is displayed every time the user tries to calculate the tax and there is no document in our list.
        /// </summary>
        private const string TaxCalculateErrorMessage = "Document cannot be null";

        /// <summary>
        /// he message which is displayed every time the user tries to calculate the average balance of our documents and our list is empty.
        /// </summary>
        private const string AverageCalculateErrorMessage = "List cannot be empty";

        /// <summary>
        /// A method which calculates average balance.
        /// </summary>
        /// <param name="list">
        /// The name of our document list.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// Returns the value of the average balance of our documents.
        /// </returns>
        public override float CalculateAverageBalance(BindingList<Document> list)
        {
            float sum = 0;
            if (list == null)
            {
                throw new ArgumentNullException(AverageCalculateErrorMessage);
            }
            else
            {
                list.ToList().ForEach(document => sum += document.Balance);
                return sum / list.Count;
            }
        }

        /// <summary>
        /// A method which calculates the tax of our selected document.
        /// </summary>
        /// <param name="document">
        /// The document name.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// Returns the value of the selected document tax.
        /// </returns>
        public override float CalculateTax(Document document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(TaxCalculateErrorMessage);
            }

            var date2 = new DateTime(2016, 1, 1, 0, 0, 0);
            var result =
                DateTime.Compare(
                    Convert.ToDateTime(Convert.ToDateTime(document.Created).ToShortDateString()),
                    Convert.ToDateTime(date2.ToShortDateString()));
            if (result >= 0)
            {
                return document.Balance * 0.4f;
            }

            return document.Balance * 0.2f;        
        }
    }
}
