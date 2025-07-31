namespace Main.Application.DTO.Response
{
    public class ResponseDtoAccessControl
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
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
