namespace StoreMovie_ApiRest.Models
{
    public class UserStore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int CellPhone { get; set; }

        public int MoviesId { get; set; }
        public MoviesStore MoviesStore { get; set; }
    }
}
