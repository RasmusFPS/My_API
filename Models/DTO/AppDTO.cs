namespace MYAPI.Models.DTO
{
    public record GetPersonResponse(int Id, string Name, string Phone);
    public record AddLinkToPerson(string URL, int InterestId);

}
