namespace StoreMovie_ApiRest.Models
{
    public class MoviesStore
    {

        public int Id { get; set; }
        public string NameMovie { get; set; }
        public int GenderId { get; set; }
        public MovieGender MovieGender { get; set; }
    }
}
