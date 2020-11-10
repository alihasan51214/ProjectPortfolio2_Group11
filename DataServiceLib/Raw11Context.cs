using DataServiceLib.DBObjects;
using Microsoft.EntityFrameworkCore;

namespace DataServiceLib
{
    public class Raw11Context : DbContext
    {
        private readonly string _connectionString;

        public Raw11Context(string connectionString)
        {

            _connectionString = connectionString;
        }

        public DbSet<ActorsKnownForTitles> ActorsKnownForTitles { get; set; }
        public DbSet<ActorsProfession> ActorsProfessions { get; set; }
        public DbSet<BookmarkPerson> BookmarkPerson { get; set; }
        public DbSet<Bookmarktitle> Bookmarktitle { get; set; }
        public DbSet<Directors> Directors { get; set; }
        public DbSet<TitleEpisode> EpisodeTitles { get; set; }
        public DbSet<TitleGenres> Genres { get; set; }
        public DbSet<NameBasics> NameBasics { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<TitleAkas> TitleAkas { get; set; }
        public DbSet<TitleBasics> TitleBasics { get; set; }
        public DbSet<TitlePrincipals> TitlePrincipals { get; set; }
        public DbSet<UserNameRate> UserNameRates { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserTitleRate> UserTitleRates { get; set; }
        public DbSet<WordSearch> WordSearch { get; set; }
        public DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorsKnownForTitles>().ToTable("actors_known_for_titles");
            modelBuilder.Entity<ActorsKnownForTitles>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ActorsKnownForTitles>().Property(x => x.KnownForTitles).HasColumnName("knownfortitles");

            modelBuilder.Entity<ActorsProfession>().ToTable("actors_profession");
            modelBuilder.Entity<ActorsProfession>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ActorsProfession>().Property(x => x.PrimaryProfession).HasColumnName("primaryprofession");
            
            modelBuilder.Entity<BookmarkPerson>().ToTable("bookmarkpersons");
            modelBuilder.Entity<BookmarkPerson>().Property(x => x.Userid).HasColumnName("userid");
            modelBuilder.Entity<BookmarkPerson>().Property(x => x.Nconst).HasColumnName("nconst");
            
            modelBuilder.Entity<Bookmarktitle>().ToTable("bookmarktitles");
            modelBuilder.Entity<Bookmarktitle>().Property(x => x.Userid).HasColumnName("userid");
            modelBuilder.Entity<Bookmarktitle>().Property(x => x.Tconst).HasColumnName("tconst");
            
            modelBuilder.Entity<Directors>().ToTable("directors");
            modelBuilder.Entity<Directors>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<Directors>().Property(x => x.Nconst).HasColumnName("nconst");

            modelBuilder.Entity<NameBasics>().ToTable("name_basicsnew");
            modelBuilder.Entity<NameBasics>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<NameBasics>().Property(x => x.PrimaryName).HasColumnName("primaryname");
            modelBuilder.Entity<NameBasics>().Property(x => x.BirthYear).HasColumnName("birthyear");
            modelBuilder.Entity<NameBasics>().Property(x => x.DeathYear).HasColumnName("deathyear");
            modelBuilder.Entity<NameBasics>().HasKey(x => x.Nconst);

            modelBuilder.Entity<SearchHistory>().ToTable("search_history");
            modelBuilder.Entity<SearchHistory>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<SearchHistory>().Property(x => x.SearchInput).HasColumnName("search_input");
            modelBuilder.Entity<SearchHistory>().Property(x => x.DateTime).HasColumnName("search_date");

            modelBuilder.Entity<TitleAkas>().ToTable("title_akas");
            modelBuilder.Entity<TitleAkas>().Property(x => x.TitleID).HasColumnName("titleid");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Title).HasColumnName("title");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Types).HasColumnName("types");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Attributes).HasColumnName("attributes");
            modelBuilder.Entity<TitleAkas>().Property(x => x.IsOriginalTitle).HasColumnName("isoriginaltitle");
            
            modelBuilder.Entity<TitleBasics>().ToTable("title_basicsnew");
            modelBuilder.Entity<TitleBasics>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<TitleBasics>().Property(x => x.TitleType).HasColumnName("titletype");
            modelBuilder.Entity<TitleBasics>().Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
            modelBuilder.Entity<TitleBasics>().Property(x => x.OriginalTitle).HasColumnName("oritinaltitle");
            modelBuilder.Entity<TitleBasics>().Property(x => x.IsAdult).HasColumnName("isadult");
            modelBuilder.Entity<TitleBasics>().Property(x => x.StartYear).HasColumnName("startyear");
            modelBuilder.Entity<TitleBasics>().Property(x => x.EndYear).HasColumnName("endyear");
            modelBuilder.Entity<TitleBasics>().Property(x => x.RunTimeMinutes).HasColumnName("runtimeminutes");
            modelBuilder.Entity<TitleBasics>().Property(x => x.Poster).HasColumnName("poster");
            modelBuilder.Entity<TitleBasics>().Property(x => x.Awards).HasColumnName("awards");
            modelBuilder.Entity<TitleBasics>().Property(x => x.Plot).HasColumnName("plot");
            modelBuilder.Entity<TitleBasics>().Property(x => x.AvarageRating).HasColumnName("averagerating");
            modelBuilder.Entity<TitleBasics>().Property(x => x.NumVotes).HasColumnName("numvotes");
             
            modelBuilder.Entity<TitleEpisode>().ToTable("title_episode");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.ParentTconst).HasColumnName("parenttconst");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.SeasonNumber).HasColumnName("seasonnumber");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.EpisodeNumber).HasColumnName("episodenumber");
            
            modelBuilder.Entity<TitleGenres>().ToTable("title_genre");
            modelBuilder.Entity<TitleGenres>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<TitleGenres>().Property(x => x.Genres).HasColumnName("genres");
            
            modelBuilder.Entity<TitlePrincipals>().ToTable("title_principals");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Category).HasColumnName("category");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Job).HasColumnName("job");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Characters).HasColumnName("characters");
            
            modelBuilder.Entity<UserNameRate>().ToTable("user_namerate");
            modelBuilder.Entity<UserNameRate>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<UserNameRate>().Property(x => x.NameIndividRating).HasColumnName("name_individrating");
            modelBuilder.Entity<UserNameRate>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<UserNameRate>().Property(x => x.DateTime).HasColumnName("username_date");
            
            modelBuilder.Entity<Users>().ToTable("users");
            modelBuilder.Entity<Users>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<Users>().Property(x => x.Name).HasColumnName("name");
            modelBuilder.Entity<Users>().Property(x => x.Age).HasColumnName("age");
            modelBuilder.Entity<Users>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<Users>().Property(x => x.Mail).HasColumnName("mail");

            modelBuilder.Entity<UserTitleRate>().ToTable("user_titlerate");
            modelBuilder.Entity<UserTitleRate>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<UserTitleRate>().Property(x => x.TitleIndividRating).HasColumnName("title_individrating");
            modelBuilder.Entity<UserTitleRate>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<UserTitleRate>().Property(x => x.UserTitleRateDate).HasColumnName("usertitlerate_date");

            modelBuilder.Entity<WordSearch>().ToTable("wi");
            modelBuilder.Entity<WordSearch>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<WordSearch>().Property(x => x.Word).HasColumnName("word");
            modelBuilder.Entity<WordSearch>().Property(x => x.Field).HasColumnName("field");
            modelBuilder.Entity<WordSearch>().Property(x => x.Lexeme).HasColumnName("lexeme");
            
            modelBuilder.Entity<Writer>().ToTable("writers");
            modelBuilder.Entity<Writer>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<Writer>().Property(x => x.Writers).HasColumnName("writers");
        }
    }
}