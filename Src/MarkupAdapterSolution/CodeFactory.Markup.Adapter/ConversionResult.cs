namespace CodeFactory.Markup.Adapter
{
    /// <summary>
    /// Thread safe data class that provide the status and contents of a tag conversion.
    /// </summary>
    public class ConversionResult
    {
        #region Backing fields

        private readonly bool _convertedTag;
        private readonly string _content;

        #endregion

        /// <summary>
        /// Constructor that creates the instance of the class
        /// </summary>
        /// <param name="convertedTag">Flag that determines if the tag conversion was completed or the original value was returned.</param>
        /// <param name="content">The contents that was returned from the conversion process.</param>
        internal ConversionResult(bool convertedTag, string content)
        {
            _convertedTag = convertedTag;
            _content = content;
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="ConversionResult"/> data class.
        /// </summary>
        /// <param name="convertedTag">Flag that determines if the tag conversion was completed or the original value was returned.</param>
        /// <param name="content">The contents that was returned from the conversion process.</param>
        /// <returns>New readonly instance of the data class.</returns>
        public static ConversionResult Init(bool convertedTag, string content) =>
            new ConversionResult(convertedTag, content);

        /// <summary>
        /// Flag that determines if the tag conversion was completed or the original value was returned.
        /// </summary>
        public bool ConvertedTag => _convertedTag;

        /// <summary>
        /// The contents that was returned from the conversion process.
        /// </summary>
        public string Content => _content;
    }
}
