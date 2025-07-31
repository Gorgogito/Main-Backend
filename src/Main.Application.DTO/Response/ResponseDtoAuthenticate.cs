namespace Main.Application.DTO.Response
{
    public class ResponseDtoAuthenticate
    {

        public string? UserName { get; set; }
        public string? Password { get; set; }       
        public string? Names { get; set; }
        public string? Surnames { get; set; }
        public string? Phone { get; set; }
        public string? EMail { get; set; }      
        public string? Token { get; set; }    
        public int? MinutesExpires {  get; set; }

    }
}
