namespace SystemMidterm_19070006058.Model.Dto
{
    public class QueryWithPagingDto
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
    public class CustomerDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
    }
    public class APIResultDto
    {
        public APIResultDto()
        {
            Status = "SUCCESS";
        }
        public string Status { get; set; }
        public string Message { get; set; }

    }
    public class CustomerResultDto : APIResultDto
    {
        public int Id { get; set; }

    }
}
