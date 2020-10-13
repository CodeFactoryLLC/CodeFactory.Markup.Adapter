using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace CodeFactory.Markup.Adapter
{
    /// <summary>
    /// Base class implementation that supports the <see cref="ITagAdapter"/> implementation
    /// </summary>
    public abstract class BaseTagAdapter:ITagAdapter
    {
        #region backing fields to support the adapter
        private ImmutableList<string> _supportedTags;
        private readonly IAdapterHost _adapterHost;
        #endregion

        /// <summary>
        /// Initializes the base class
        /// </summary>
        protected BaseTagAdapter(IAdapterHost adapterHost)
        {
            _supportedTags = ImmutableList<string>.Empty;
            _adapterHost = adapterHost;
        }

        /// <summary>
        /// Registers a target tag that supports conversion on this adapter.
        /// </summary>
        /// <param name="tag">Tag that is supported by this adapter.</param>
        protected void RegisterSupportTag(string tag)
        {
            if (!_supportedTags.Contains(tag)) _supportedTags = _supportedTags.Add(tag);
        }

        #region Implementation of ITagAdapter

        /// <summary>
        /// The markup tags that are supported by this adapter.
        /// </summary>
        public IReadOnlyList<string> SupportedTags => _supportedTags;

        /// <summary>
        /// The adapter host that manages this tag adapter.
        /// </summary>
        public IAdapterHost AdapterHost => _adapterHost;


        /// <summary>
        /// Converts the target tag and content into the desired markup format.
        /// </summary>
        /// <param name="tag">The target tag to convert.</param>
        /// <param name="content">The content of the tag to be converted.</param>
        /// <returns>Returns the converted markup for the tag, or the original content if it cannot be converted.</returns>
        public abstract Task<string> ConvertTag(string tag, string content);


        /// <summary>
        /// Converts the target tag and content into the desired markup format.
        /// </summary>
        /// <param name="tag">The target tag to convert.</param>
        /// <param name="content">The content of the tag to be converted.</param>
        /// <returns>Returns the converted markup in a data class that provides the result of the conversion</returns>
        public abstract Task<ConversionResult> ConvertTagWithResult(string tag, string content);


        #endregion
    }
}
