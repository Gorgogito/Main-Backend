namespace Main.Application.DTO.Response
{
    public class ResponseDtoRolePerUser
    {

        public string? UserName { get; set; }
        public string? CodeRole { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }

    }
}
