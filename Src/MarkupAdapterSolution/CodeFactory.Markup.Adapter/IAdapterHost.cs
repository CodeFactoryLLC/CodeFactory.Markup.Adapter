using System;
using System.Threading.Tasks;

namespace CodeFactory.Markup.Adapter
{
    /// <summary>
    /// Base implementation of the adapter host.
    /// </summary>
    public interface IAdapterHost
    {
        /// <summary>
        /// Registers a <see cref="ITagAdapter"/> implemented adapter with the host.
        /// </summary>
        void RegisterAdapter(Func<IAdapterHost, ITagAdapter> loadAdapter);

        
        /// <summary>
        /// Converts the target tag and content into the desired markup format.
        /// </summary>
        /// <param name="tag">The target tag to convert.</param>
        /// <param name="content">The content of the tag to be converted.</param>
        /// <returns>Returns the converted markup for the tag, or the original content if it cannot be converted.</returns>
        Task<string> ConvertTag(string tag, string content);

        /// <summary>
        /// Converts the target tag and content into the desired markup format.
        /// </summary>
        /// <param name="tag">The target tag to convert.</param>
        /// <param name="content">The content of the tag to be converted.</param>
        /// <returns>Returns the converted markup in a data class that provides the result of the conversion</returns>
        Task<ConversionResult> ConvertTagWithResult(string tag, string content);
    }
}
