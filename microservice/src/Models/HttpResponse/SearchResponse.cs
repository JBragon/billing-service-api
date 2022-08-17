namespace Models.HttpResponse
{
    public class SearchResponse<TEntity>
    {
        public SearchResponse()
        {

        }

        public SearchResponse(IEnumerable<TEntity> items, int rowsCount, int pageIndex)
        {
            Items = items;
            RowsCount = rowsCount;
            PageIndex = pageIndex;
        }

        public IEnumerable<TEntity> Items { get; set; }
        public int RowsCount { get; set; }
        public int PageIndex { get; set; }
    }
}
