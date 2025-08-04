namespace Main.Application.DTO.Request
{

    public class RequestDtoAccessControl_Insert
    {

        public string? Code { get; set; }
        public string? CodeResource { get; set; }
        public string? CodeProgram { get; set; }
        public bool? Read { get; set; }
        public bool? Write { get; set; }
        public bool? Create { get; set; }
        public bool? Eliminate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

    }

    public class RequestDtoAccessControl_Update
    {

        public string? Code { get; set; }
        public string? CodeResource { get; set; }
        public string? CodeProgram { get; set; }
        public bool? Read { get; set; }
        public bool? Write { get; set; }
        public bool? Create { get; set; }
        public bool? Eliminate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }

    }

    public class RequestDtoAccessControl_Delete
    {
        public string? Code { get; set; }
    }

    public class RequestDtoAccessControl_GetById
    {
        public string? Code { get; set; }
    }

    public class RequestDtoAccessControl_GetByResource
    {
        public string? CodeResource { get; set; }
    }

    public class RequestDtoAccessControl_GetByProgram
    {
        public string? CodeProgram { get; set; }
    }

    public class RequestDtoAccessControl_ListWithPagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}
