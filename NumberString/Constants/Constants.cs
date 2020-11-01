namespace NumberString
{
    /// <summary>
    /// Constants for defining resource string or any other application specific constants
    /// </summary>
    internal static class Constants
    {
        #region Error Messages
        internal const string APP_ERROR = "Sorry something went wrong."; 
        internal const string ERR_INVALID_INPUT = "number invalid";
        #endregion
        #region Regular Expression
        internal const string REG_EX_ALFANUMERIC = "^[ a-zA-Z0-9@./#&+-]+$";
        internal const string REG_EX_NUMBER = "^[0-9]+$";
        #endregion
    }
}
