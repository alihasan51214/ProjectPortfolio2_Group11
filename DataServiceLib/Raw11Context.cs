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
        public DbSet<BookmarkTitle> BookmarkTitle { get; set; }
        public DbSet<Directors> Directors { get; set; }
        public DbSet<TitleEpisode> EpisodeTitles { get; set; }
        public DbSet<TitleGenres> Genres { get; set; }
        public DbSet<NameBasics> NameBasics { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<TitleAkas> TitleAkas { get; set; }
        public virtual DbSet<TitleBasics> TitleBasics { get; set; }

        public virtual DbSet<TitleBasicsDto> TitleBasicsDTO { get; set; }

        //  public virtual DbSet<SearchResults> SearchResults { get; set; }

        public DbSet<TitlePrincipals> TitlePrincipals { get; set; }
        public DbSet<TitleNameRate> TitleNameRates { get; set; }
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
            modelBuilder.Entity<ActorsKnownForTitles>().Property(x => x.NConst).HasColumnName("nconst");
            modelBuilder.Entity<ActorsKnownForTitles>().Property(x => x.KnownForTitles).HasColumnName("knownfortitles");
            modelBuilder.Entity<ActorsKnownForTitles>().HasKey(c => new { Nconst = c.NConst, c.KnownForTitles });

            modelBuilder.Entity<ActorsProfession>().ToTable("actors_profession");
            modelBuilder.Entity<ActorsProfession>().Property(x => x.NConst).HasColumnName("nconst");
            modelBuilder.Entity<ActorsProfession>().Property(x => x.PrimaryProfession).HasColumnName("primaryprofession");
            modelBuilder.Entity<ActorsProfession>().HasKey(c => new { Nconst = c.NConst, c.PrimaryProfession });

            modelBuilder.Entity<BookmarkPerson>().ToTable("bookmarkpersons");
            modelBuilder.Entity<BookmarkPerson>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<BookmarkPerson>().Property(x => x.NConst).HasColumnName("nconst");
            modelBuilder.Entity<BookmarkPerson>().HasKey(c => new { Userid = c.UserId, Nconst = c.NConst });

            modelBuilder.Entity<BookmarkTitle>().ToTable("bookmarktitles");
            modelBuilder.Entity<BookmarkTitle>().Property(x => x.Userid).HasColumnName("bookmarkid");
            modelBuilder.Entity<BookmarkTitle>().Property(x => x.Userid).HasColumnName("userid");
            modelBuilder.Entity<BookmarkTitle>().Property(x => x.TConst).HasColumnName("tconst");
            modelBuilder.Entity<BookmarkTitle>().HasKey(c => new { c.Userid, Tconst = c.TConst });

            modelBuilder.Entity<Directors>().ToTable("directors");
            modelBuilder.Entity<Directors>().Property(x => x.TConst).HasColumnName("tconst");
            modelBuilder.Entity<Directors>().Property(x => x.NConst).HasColumnName("nconst");
            modelBuilder.Entity<Directors>().HasKey(c => new { Nconst = c.NConst, Tconst = c.TConst });

            modelBuilder.Entity<NameBasics>().ToTable("name_basicsnew");
            modelBuilder.Entity<NameBasics>().Property(x => x.NConst).HasColumnName("nconst");
            modelBuilder.Entity<NameBasics>().Property(x => x.PrimaryName).HasColumnName("primaryname");
            modelBuilder.Entity<NameBasics>().Property(x => x.BirthYear).HasColumnName("birthyear");
            modelBuilder.Entity<NameBasics>().Property(x => x.DeathYear).HasColumnName("deathyear");
            modelBuilder.Entity<NameBasics>().HasKey(x => x.NConst);

            modelBuilder.Entity<SearchHistory>().ToTable("search_history");
            modelBuilder.Entity<SearchHistory>().HasNoKey();
            modelBuilder.Entity<SearchHistory>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<SearchHistory>().Property(x => x.SearchInput).HasColumnName("search_input");
            modelBuilder.Entity<SearchHistory>().Property(x => x.DateTime).HasColumnName("search_date");
            
            modelBuilder.Entity<TitleAkas>().ToTable("title_akas");
            modelBuilder.Entity<TitleAkas>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Title).HasColumnName("title");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Types).HasColumnName("types");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Attributes).HasColumnName("attributes");
            modelBuilder.Entity<TitleAkas>().Property(x => x.IsOriginalTitle).HasColumnName("isoriginaltitle");
            modelBuilder.Entity<TitleAkas>().HasKey(c => new { TitleID = c.TitleId, c.Ordering });
            
            modelBuilder.Entity<TitleBasics>().ToTable("title_basicsnew");
            modelBuilder.Entity<TitleBasics>().Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
            modelBuilder.Entity<TitleBasics>().Property(x => x.TConst).HasColumnName("tconst");
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
            modelBuilder.Entity<TitleBasics>().HasKey(c => new {Tconst = c.TConst});
            
            //TitleBasicsDto
            modelBuilder.Entity<TitleBasicsDto>().Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
            modelBuilder.Entity<TitleBasicsDto>().HasNoKey();
          
            modelBuilder.Entity<TitleEpisode>().ToTable("title_episode");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.TConst).HasColumnName("tconst");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.ParentTConst).HasColumnName("parenttconst");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.SeasonNumber).HasColumnName("seasonnumber");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.EpisodeNumber).HasColumnName("episodenumber");
            modelBuilder.Entity<TitleEpisode>().HasKey(c => new {Tconst = c.TConst});

            modelBuilder.Entity<TitleGenres>().ToTable("title_genre");
            modelBuilder.Entity<TitleGenres>().Property(x => x.TConst).HasColumnName("tconst");
            modelBuilder.Entity<TitleGenres>().Property(x => x.Genres).HasColumnName("genres");
            modelBuilder.Entity<TitleGenres>().HasKey(c => new { Tconst = c.TConst,c.Genres });

            modelBuilder.Entity<TitlePrincipals>().ToTable("title_principals");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.TConst).HasColumnName("tconst");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.NConst).HasColumnName("nconst");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Category).HasColumnName("category");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Job).HasColumnName("job");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Characters).HasColumnName("characters");
            modelBuilder.Entity<TitlePrincipals>().HasKey(c => new { Tconst = c.TConst, c.Ordering });

            modelBuilder.Entity<TitleNameRate>().ToTable("user_namerate");
            modelBuilder.Entity<TitleNameRate>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<TitleNameRate>().Property(x => x.NameIndividRating).HasColumnName("name_individrating");
            modelBuilder.Entity<TitleNameRate>().Property(x => x.NConst).HasColumnName("nconst");
            modelBuilder.Entity<TitleNameRate>().Property(x => x.DateTime).HasColumnName("username_date");
            modelBuilder.Entity<TitleNameRate>().HasNoKey();

            modelBuilder.Entity<Users>().ToTable("users");
            modelBuilder.Entity<Users>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<Users>().Property(x => x.Name).HasColumnName("name");
            modelBuilder.Entity<Users>().Property(x => x.Age).HasColumnName("age");
            modelBuilder.Entity<Users>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<Users>().Property(x => x.Mail).HasColumnName("mail");
            modelBuilder.Entity<Users>().HasKey(c => new { c.UserId });

            modelBuilder.Entity<UserTitleRate>().ToTable("user_titlerate");
            modelBuilder.Entity<UserTitleRate>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<UserTitleRate>().Property(x => x.TitleIndividRating).HasColumnName("individrating_title");
            modelBuilder.Entity<UserTitleRate>().Property(x => x.TConst).HasColumnName("tconst");
            modelBuilder.Entity<UserTitleRate>().Property(x => x.UserTitleRateDate).HasColumnName("usertitlerate_date");
            modelBuilder.Entity<UserTitleRate>().HasNoKey();

            modelBuilder.Entity<WordSearch>().ToTable("wi");
            modelBuilder.Entity<WordSearch>().Property(x => x.TConst).HasColumnName("tconst");
            modelBuilder.Entity<WordSearch>().Property(x => x.Word).HasColumnName("word");
            modelBuilder.Entity<WordSearch>().Property(x => x.Field).HasColumnName("field");
            modelBuilder.Entity<WordSearch>().Property(x => x.Lexeme).HasColumnName("lexeme");
            modelBuilder.Entity<WordSearch>().HasKey(c => new { Tconst = c.TConst,c.Word,c.Field });

            modelBuilder.Entity<Writer>().ToTable("writers");
            modelBuilder.Entity<Writer>().Property(x => x.TConst).HasColumnName("tconst");
            modelBuilder.Entity<Writer>().Property(x => x.Writers).HasColumnName("writers");
            modelBuilder.Entity<Writer>().HasKey(c => new { c.Writers, Tconst = c.TConst, });
        }
    }
}