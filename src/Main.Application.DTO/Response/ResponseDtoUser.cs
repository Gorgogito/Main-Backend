namespace Main.Application.DTO.Response
{
    public class ResponseDtoUser
    {

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Description { get; set; }
        public string? Names { get; set; }
        public string? Surnames { get; set; }
        public string? Phone { get; set; }
        public string? EMail { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }

    }
}
