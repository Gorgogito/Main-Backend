namespace Main.Application.DTO.Response
{
    public class ResponseDtoMenu
    {
        public string? Code { get; set; }
        public string? CodeGroupMenu { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Order { get; set; }
        public int? Level { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }

    }
}
