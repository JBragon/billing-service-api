namespace Models.HttpRequest
{
    public class ClientFilter
    {
        public string? CPF { get; set; }
        public int Page { get; set; }
        public int RowsPerPage { get; set; }
        public string Sort { get; set; }
        public string SortDir { get; set; }
    }
}
