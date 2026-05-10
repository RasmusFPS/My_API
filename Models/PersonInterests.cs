namespace MYAPI.Models
{
    public class PersonInterests
    {
        public int Id { get; set; }
        public int InterestId { get; set; }
        public int PersonId { get; set; }

        //Nav
        public Person person { get; set; } = null!;
        public Interest interest { get; set; } = null!;
    }
}
