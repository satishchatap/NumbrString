using System;
using System.IO;

namespace NumberString
{
    /// <summary>
    /// File Helper for all file related methods.
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Extract string from file.
        /// </summary>
        /// <param name="filePath">path with file name</param>
        /// <returns></returns>
        public static string GetStringFromFile(string filePath)
        {
            try
            {
                var resultText = string.Empty;
                using (StreamReader streamReader = File.OpenText(filePath))
                {
                    resultText = streamReader.ReadToEnd();
                }
                return resultText;
            }
            catch(FileNotFoundException fx)
            {
                throw new ApplicationException("File not found.",fx);
            }
            catch(Exception ex)
            {
                throw new ApplicationException("File is not accessible or problem occured while reading.", ex);
            }
        }
    }
}
