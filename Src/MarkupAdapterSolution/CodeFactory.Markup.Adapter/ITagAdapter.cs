using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFactory.Markup.Adapter
{
    /// <summary>
    /// Definition of all functionality that must be implemented in a markup tag adapter
    /// </summary>
    public interface ITagAdapter
    {
        /// <summary>
        /// The markup tags that are supported by this adapter.
        /// </summary>
        IReadOnlyList<string> SupportedTags { get; }

        /// <summary>
        /// The adapter host that manages this tag adapter.
        /// </summary>
        IAdapterHost AdapterHost { get; }

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
