namespace Main.Application.DTO.Request
{

    public class RequestDtoMenu_Insert
    {

        public string? Code { get; set; }
        public string? CodeGroupMenu { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Order { get; set; }
        public int? Level { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

    }

    public class RequestDtoMenu_Update
    {

        public string? Code { get; set; }
        public string? CodeGroupMenu { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Order { get; set; }
        public int? Level { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }

    }

    public class RequestDtoMenu_Delete
    {
        public string? Code { get; set; }
    }

    public class RequestDtoMenu_GetById
    {
        public string? Code { get; set; }
    }

    public class RequestDtoMenu_GetByGroupMenu
    {
        public string? CodeGroupMenu { get; set; }
    }

    public class RequestDtoMenu_ListWithPagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}

