namespace Main.Application.DTO.Request
{

    public class RequestDtoProgram_Insert
    {

        public string? Code { get; set; }
        public string? CodeGroupMenu { get; set; }
        public string? CodeMenu { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Order { get; set; }
        public string? PathProgram { get; set; }
        public string? PathImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

    }

    public class RequestDtoProgram_Update
    {

        public string? Code { get; set; }
        public string? CodeGroupMenu { get; set; }
        public string? CodeMenu { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Order { get; set; }
        public string? PathProgram { get; set; }
        public string? PathImage { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }

    }

    public class RequestDtoProgram_Delete
    {
        public string? Code { get; set; }
    }

    public class RequestDtoProgram_GetById
    {
        public string? Code { get; set; }
    }

    public class RequestDtoProgram_GetByGroupMenu
    {
        public string? CodeGroupMenu { get; set; }
    }

    public class RequestDtoProgram_GetByMenu
    {
        public string? CodeMenu { get; set; }
    }

    public class RequestDtoProgram_ListWithPagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}
