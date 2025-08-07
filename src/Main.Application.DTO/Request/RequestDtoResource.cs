namespace Main.Application.DTO.Request
{

    public class RequestDtoResource_Insert
    {

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

    }

    public class RequestDtoResource_Update
    {

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }

    }

    public class RequestDtoResource_Delete
    {
        public string? Code { get; set; }
    }

    public class RequestDtoResource_GetById
    {
        public string? Code { get; set; }
    }

    public class RequestDtoResource_ListWithPagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}
