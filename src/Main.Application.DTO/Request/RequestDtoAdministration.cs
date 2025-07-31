namespace Main.Application.DTO.Request
{

    public class RequestDtoAdministration_Insert
    {
        public string? CodeRole { get; set; }
        public string? CodeResource { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }

    public class RequestDtoAdministration_Update
    {
        public string? CodeRole { get; set; }
        public string? CodeResource { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }

    public class RequestDtoAdministration_Delete
    {
        public string? CodeRole { get; set; }
        public string? CodeResource { get; set; }
    }

    public class RequestDtoAdministration_GetById
    {
        public string? CodeRole { get; set; }
        public string? CodeResource { get; set; }
    }

    public class RequestDtoAdministration_GetByResource
    {
        public string? CodeResource { get; set; }
    }

    public class RequestDtoAdministration_GetByRole
    {
        public string? CodeRole { get; set; }
    }

    public class RequestDtoAdministration_ListWithPagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}
