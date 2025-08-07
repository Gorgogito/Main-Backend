namespace Main.Application.DTO.Request
{

    public class RequestDtoRolePerUser_Insert
    {

        public string? UserName { get; set; }
        public string? CodeRole { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

    }

    public class RequestDtoRolePerUser_Delete
    {
        public string? UserName { get; set; }
        public string? CodeRole { get; set; }
    }

    public class RequestDtoRolePerUser_GetById
    {
        public string? UserName { get; set; }
        public string? CodeRole { get; set; }
    }

    public class RequestDtoRolePerUser_GetByUser
    {
        public string? UserName { get; set; }
    }

    public class RequestDtoRolePerUser_GetByRole
    {
        public string? CodeRole { get; set; }
    }

    public class RequestDtoRolePerUser_ListWithPagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}
