// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   Defines the Logger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Classes
{
    using System;
    using System.IO;

    /// <summary>
    ///  The Logger class.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// A method that creates a txt file with the errors,the warnings and the user who did it them.
        /// </summary>
        /// <param name="exceptions">
        /// The name of the current exception.
        /// </param>
        /// <param name="errorTypes">
        /// The given errortype.
        /// </param>
        /// <param name="time">
        /// The time which the error is comitted.
        /// </param>
        public static void AddLog(string exceptions, Enum errorTypes, DateTime time)
        {
            var streamWriter = File.AppendText(@"C:\!projects!\DcProgrammingTutorial\errorLog.txt");
            streamWriter.WriteLine(errorTypes + " : " + exceptions + " " + time + Environment.NewLine + "UserName : " + Environment.UserName);
            streamWriter.WriteLine();
            streamWriter.Close();
        }
    }
}
