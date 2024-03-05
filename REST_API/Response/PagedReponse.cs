namespace REST_API.Response
{
    public class PagedResponse<T>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public IEnumerable<T> Data { get; set; } = new List<T>();

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public int TotalCount { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
