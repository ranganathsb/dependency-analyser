using System.Text;

namespace Drew.DependencyAnalyser
{
    /// <summary>
    /// Base class for dependency analysers.  Subclasses are intended to populate the <see cref="DependencyGraph"/> property instance.
    /// </summary>
    public abstract class DependencyAnalyserBase
    {
        protected StringBuilder Messages = new StringBuilder();

        public DependencyGraph<string> DependencyGraph { get; } = new DependencyGraph<string>();

        #region Message handling 

        /// <summary>
        /// Obtain any messages generated during the processing of dependencies.
        /// </summary>
        public string GetMessages()
        {
            return Messages.ToString();
        }

        internal void AddMessage(string message)
        {
            StartNewMessage();
            Messages.Append(message);
        }

        internal void AddMessage(string message, params object[] format)
        {
            StartNewMessage();
            Messages.AppendFormat(message, format);
        }

        private void StartNewMessage()
        {
            if (Messages.ToString().Length > 0)
                Messages.Append("\r\n");
        }

        #endregion
    }
}
