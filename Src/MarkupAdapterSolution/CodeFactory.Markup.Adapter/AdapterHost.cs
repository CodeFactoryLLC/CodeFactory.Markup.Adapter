using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFactory.Markup.Adapter
{
    /// <summary>
    /// Host for all the tag adapters that will process tag conversion. 
    /// </summary>
    public class AdapterHost:IAdapterHost
    {
        /// <summary>
        /// The adapters used to process tags
        /// </summary>
        private ImmutableList<ITagAdapter> _adapters;


        /// <summary>
        /// Constructor that creates an instance of the <see cref="AdapterHost"/>
        /// </summary>
        public AdapterHost()
        {
            _adapters = ImmutableList<ITagAdapter>.Empty;
        }

        #region Implementation of IAdapterHost

        /// <summary>
        /// Registers a <see cref="ITagAdapter"/> implemented adapter with the host.
        /// </summary>
        public void RegisterAdapter(Func<IAdapterHost, ITagAdapter> loadAdapter)
        {
            var adapter = loadAdapter.Invoke(this);

            if (adapter == null) return;

            _adapters = _adapters.Add(adapter);
            
        }

        /// <summary>
        /// Converts the target tag and content into the desired markup format.
        /// </summary>
        /// <param name="tag">The target tag to convert.</param>
        /// <param name="content">The content of the tag to be converted.</param>
        /// <returns>Returns the converted markup for the tag, or the original content if it cannot be converted.</returns>
        public async Task<string> ConvertTag(string tag, string content)
        {
            string result = null;
            if (string.IsNullOrEmpty(tag)) return content;

            var adapter = _adapters.FirstOrDefault(a => a.SupportedTags.Contains(tag));

            if (adapter == null) return content;

            result = await adapter.ConvertTag(tag, content);

            return result;
        }

        /// <summary>
        /// Converts the target tag and content into the desired markup format.
        /// </summary>
        /// <param name="tag">The target tag to convert.</param>
        /// <param name="content">The content of the tag to be converted.</param>
        /// <returns>Returns the converted markup in a data class that provides the result of the conversion</returns>
        public async Task<ConversionResult> ConvertTagWithResult(string tag, string content)
        {
            ConversionResult result = null;

            if (string.IsNullOrEmpty(tag)) return ConversionResult.Init(false,content);

            var adapter = _adapters.FirstOrDefault(a => a.SupportedTags.Contains(tag));

            if (adapter == null) return ConversionResult.Init(false, content);

            result = await adapter.ConvertTagWithResult(tag, content);

            return result;
        }

        #endregion
    }
}
