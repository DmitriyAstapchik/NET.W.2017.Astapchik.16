namespace Homework
{
    /// <summary>
    /// logs invalid URLs
    /// </summary>
    public interface IUrlLogger
    {
        /// <summary>
        /// logs invalid URL
        /// </summary>
        /// <param name="badUrl">invalid URL to log</param>
        void Log(string badUrl);
    }
}