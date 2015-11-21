namespace Nancy.Json
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Nancy.Json.Converters;

    /// <summary>
    /// Configuration for JSON serialization.
    /// </summary>
    public class JsonConfiguration
    {
        /// <summary>
        /// A default instance of the <see cref="JsonConfiguration"/> class.
        /// </summary>
        public static readonly JsonConfiguration Default = new JsonConfiguration
        {
            Converters = new List<JavaScriptConverter> { new TimeSpanConverter(), new TupleConverter() },
            DefaultEncoding = Encoding.UTF8,
            ISO8601DateFormat = true,
            MaxJsonLength = 102400,
            MaxRecursions = 100,
            PrimitiveConverters = new List<JavaScriptPrimitiveConverter>(),
            RetainCasing = false
        };

        private JsonConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonConfiguration"/> class.
        /// </summary>
        public JsonConfiguration(bool? iso8601DateFormat, int? maxJsonLength, int? maxRecursions, Encoding defaultEncoding, IList<JavaScriptConverter> converters, IList<JavaScriptPrimitiveConverter> primitiveConverters, bool? retainCasing)
        {
            this.ISO8601DateFormat = iso8601DateFormat ?? Default.ISO8601DateFormat;
            this.MaxJsonLength = maxJsonLength ?? Default.MaxJsonLength;
            this.MaxRecursions = maxRecursions ?? Default.MaxRecursions;
            this.DefaultEncoding = defaultEncoding ?? Default.DefaultEncoding;
            this.Converters = converters ?? Default.Converters;
            this.PrimitiveConverters = primitiveConverters ?? Default.PrimitiveConverters;
            this.RetainCasing = retainCasing ?? Default.RetainCasing;
        }

        /// <summary>
        /// Max length of JSON output.
        /// </summary>
        /// <remarks>The default is 102400.</remarks>
        public int MaxJsonLength { get; private set; }

        /// <summary>
        /// Maximum number of recursions.
        /// </summary>
        /// <remarks>The default is 100.</remarks>
        public int MaxRecursions { get; private set; }

        /// <summary>
        /// Gets the default <see cref="Encoding"/> for JSON responses.
        /// </summary>
        /// <remarks>The default is <see langword="Encoding.UTF8" />.</remarks>
        public Encoding DefaultEncoding { get; private set; }

        /// <summary>
        /// Gets or sets the type converters that should be used.
        /// </summary>
        /// <remarks>The default is <see cref="TimeSpanConverter"/> and <see cref="TupleConverter"/>.</remarks>
        public IList<JavaScriptConverter> Converters { get; private set; }

        /// <summary>
        /// Gets or sets the converters used for primitive types.
        /// </summary>
        /// <remarks>The default are no converters.</remarks>
        public IList<JavaScriptPrimitiveConverter> PrimitiveConverters { get; private set; }

        /// <summary>
        /// Gets or sets if C# casing should be retained or if camel-casing should be enforeced.
        /// </summary>
        /// <remarks>The default is <see langword="false"/>.</remarks>
        public bool RetainCasing { get; private set; }

        /// <summary>
        /// Gets or sets if ISO-860 date formats should be used or not.
        /// </summary>
        /// <remarks>The default is <see langword="false"/>.</remarks>
        public bool ISO8601DateFormat { get; private set; }
    }
}
