namespace WebAPI4.Dto
{
    public class PageList<T> : List<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        public static PageList<T> Create(IQueryable<T> soure, int pageNumber, int pageSize)
        {
            var count = soure.Count();
            var items = soure.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }

    }
}
