namespace Webjet.Movies.Domain.Entities
{
    public class Movie
    {
        public string Id { get; set; }

        public string Database { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Rated { get; set; }

        public string Released { get; set; }

        public string Runtime { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public string Writer { get; set; }

        public string Actors { get; set; }

        public string Plot { get; set; }

        public string Language { get; set; }

        public string Country { get; set; }

        public string Poster { get; set; }

        public string Metascore { get; set; }

        public float Rating { get; set; }

        public float Votes { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public void SetDatabase(string database)
        {
            Database = database;
        }
    }
}
