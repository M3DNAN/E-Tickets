using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using E_Tickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using E_Tickets.ViewModel;
namespace E_Tickets.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Booking> Booking { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var Builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            var connection = Builder.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActorMovie>()
            .HasOne(am => am.Actor)
            .WithMany(a => a.ActorMovies)
            .HasForeignKey(am => am.ActorId);

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.ActorMovies)
                .HasForeignKey(am => am.MovieId);
            modelBuilder.Entity<Actor>().HasData(
new Actor
{
    Id = 1,
    FirstName = "Ryan",
    LastName = "Reynolds",
    Bio = "Ryan Reynolds is a Canadian actor and producer best known for his roles in films such as Deadpool, The Proposal, and Free Guy. He has established himself as one of the most charismatic and humorous actors in Hollywood.",
    ProfilePictrue = "Ryan Reynolds.jpg",
    News = "Reynolds is currently filming the highly anticipated Deadpool 3, where he will reprise his iconic role alongside Hugh Jackman as Wolverine."
},

new Actor
{
    Id = 2,
    FirstName = "Hugh",
    LastName = "Jackman",
    Bio = "Hugh Jackman is an Australian actor, singer, and producer. He is best known for his role as Wolverine in the X-Men series and his performances in Les Misérables and The Greatest Showman.",
    ProfilePictrue = "Hugh Jackman.jpg",
    News = "Jackman is set to return as Wolverine in Deadpool 3, marking his return to the role after his supposed final appearance in 2017's Logan."
},

new Actor
{
    Id = 3,
    FirstName = "Joaquin",
    LastName = "Phoenix",
    Bio = "Joaquin Phoenix is an American actor known for his intense and unconventional performances. He won an Academy Award for his role as Arthur Fleck in Joker and has appeared in films like Gladiator and Her.",
    ProfilePictrue = "Joaquin Phoenix.jpg",
    News = "Phoenix is set to return as Arthur Fleck in Joker: Folie à Deux, the much-anticipated sequel to his award-winning performance."
},

new Actor
{
    Id = 4,
    FirstName = "Zendaya",
    LastName = "",
    Bio = "Zendaya is an American actress and singer who rose to fame with her role in the Disney Channel series Shake It Up and has since become known for her performances in Euphoria and Dune.",
    ProfilePictrue = "Zendaya.jpg",
    News = "Zendaya will reprise her role as Chani in Dune: Part Two, continuing the sci-fi epic alongside Timothée Chalamet."
},

new Actor
{
    Id = 5,
    FirstName = "Margot",
    LastName = "Robbie",
    Bio = "Margot Robbie is an Australian actress and producer known for her roles in films such as The Wolf of Wall Street, Suicide Squad, and Barbie. She has earned widespread acclaim for her versatility and charm.",
    ProfilePictrue = "Margot Robbie.jpg",
    News = "Robbie is rumored to appear in a future installment of the DC Universe, continuing her portrayal of Harley Quinn."
}, new Actor
{
    Id = 6,
    FirstName = "Timothée",
    LastName = "Chalamet",
    Bio = "Timothée Chalamet is an American actor who gained recognition for his performances in films such as Call Me by Your Name, Lady Bird, and Dune. He is known for his intense and emotional acting style.",
    ProfilePictrue = "Timothée Chalamet.jpg",
    News = "Chalamet will reprise his role as Paul Atreides in Dune: Part Two, continuing the epic saga of Frank Herbert's novel."
},

new Actor
{
    Id = 7,
    FirstName = "Florence",
    LastName = "Pugh",
    Bio = "Florence Pugh is a British actress known for her powerful performances in films such as Midsommar, Little Women, and Don't Worry Darling. She has quickly become one of Hollywood's most respected young talents.",
    ProfilePictrue = "Florence Pugh.jpg",
    News = "Pugh is set to star in Dune: Part Two as Princess Irulan, marking her entry into the science fiction genre."
},

new Actor
{
    Id = 8,
    FirstName = "Tom",
    LastName = "Hardy",
    Bio = "Tom Hardy is an English actor and producer known for his versatile roles in both film and television. He has received critical acclaim for his performances in movies like Mad Max: Fury Road, The Revenant, and Venom. Hardy is also known for his roles in popular films such as Inception and Dunkirk.",
    ProfilePictrue = "Tom Hardy.jpg",
    News = "Hardy is set to reprise his role as Eddie Brock in the upcoming Venom sequel, Venom: The Last Dance."
}
,

new Actor
{
    Id = 9,
    FirstName = "Daniel",
    LastName = "Kaluuya",
    Bio = "Daniel Kaluuya is a British actor and writer known for his roles in Get Out, Black Panther, and Judas and the Black Messiah. He won an Academy Award for Best Supporting Actor for his portrayal of Fred Hampton.",
    ProfilePictrue = "Daniel Kaluuya.jpg",
    News = "Kaluuya will star in the upcoming Marvel film, set to expand his presence in the superhero genre."
},

new Actor
{
    Id = 10,
    FirstName = "Emily",
    LastName = "Blunt",
    Bio = "Emily Blunt is a British-American actress known for her roles in films such as A Quiet Place, Mary Poppins Returns, and Edge of Tomorrow. She has received acclaim for her versatility and strong screen presence.",
    ProfilePictrue = "Emily Blunt.jpg",
    News = "Blunt is set to star in the upcoming film Oppenheimer, directed by Christopher Nolan, which chronicles the life of J. Robert Oppenheimer."
}, new Actor
{
    Id = 11,
    FirstName = "Christian",
    LastName = "Bale",
    Bio = "Christian Bale is a British-American actor known for his versatility and commitment to his roles. He has received numerous accolades, including two Academy Awards. Some of his notable films include American Psycho, The Dark Knight Trilogy, and Ford v Ferrari.",
    ProfilePictrue = "Christian Bale.jpg",
    News = "Bale is set to star in the upcoming film Oppenheimer, directed by Christopher Nolan, where he will portray J. Robert Oppenheimer."
}, new Actor
{
    Id = 12,
    FirstName = "Rachel",
    LastName = "Zegler",
    Bio = "Rachel Zegler is an American actress and singer who gained fame for her role as Maria in the 2021 film adaptation of West Side Story, directed by Steven Spielberg. She is known for her powerful voice and compelling performances.",
    ProfilePictrue = "Rachel Zegler.jpg",
    News = "Zegler will star as Snow White in the upcoming live-action adaptation of Disney's classic animated film."
}, new Actor
{
    Id = 13,
    FirstName = "Leonardo",
    LastName = "DiCaprio",
    Bio = "Leonardo DiCaprio is an American actor and producer known for his diverse roles in both independent films and major blockbusters. He has received numerous accolades, including an Academy Award for Best Actor for his performance in The Revenant. His notable films include Titanic, Inception, The Wolf of Wall Street, and Once Upon a Time in Hollywood.",
    ProfilePictrue = "Leonardo DiCaprio.jpg",
    News = "DiCaprio is set to star in Martin Scorsese's upcoming film Killers of the Flower Moon, which tells the story of the Osage murders in the 1920s."
}, new Actor
{
    Id = 14,
    FirstName = "Denzel",
    LastName = "Washington",
    Bio = "Denzel Washington is an American actor, producer, and director known for his powerful performances in both drama and action films. He has received numerous awards, including two Academy Awards for Best Actor for his roles in Training Day and Glory. Some of his notable films include Malcolm X, The Equalizer series, and Fences.",
    ProfilePictrue = "Denzel Washington.jpg",
    News = "Washington is set to star in the upcoming film The Equalizer 3, continuing his role as Robert McCall."
}, new Actor
{
    Id = 15,
    FirstName = "Zoe",
    LastName = "Saldana",
    Bio = "Zoe Saldana is an American actress and dancer known for her roles in blockbuster franchises including Avatar, Guardians of the Galaxy, and Star Trek. She is recognized for her strong performances and has become one of the highest-grossing actresses in Hollywood.",
    ProfilePictrue = "Zoe Saldana.jpg",
    News = "Saldana will reprise her role as Neytiri in the upcoming Avatar sequels, continuing her journey in James Cameron's epic sci-fi universe."
}, new Actor
{
    Id = 16,
    FirstName = "Matthew",
    LastName = "McConaughey",
    Bio = "Matthew McConaughey is an American actor and producer known for his charismatic performances and distinct voice. He gained fame with films such as Dazed and Confused, The Lincoln Lawyer, and Magic Mike, but he earned critical acclaim and an Academy Award for Best Actor for his role in Dallas Buyers Club.",
    ProfilePictrue = "Matthew McConaughey.jpg",
    News = "McConaughey is set to star in the upcoming film The Gentleman, directed by Guy Ritchie, which follows a British drug lord and his attempts to sell off his empire."
}







               );
            modelBuilder.Entity<Category>().HasData(
                   new Category { Id = 1, Name= "Action" },
                   new Category { Id = 2, Name= "Comedy" },
                   new Category { Id = 3, Name= "Drama" },
                   new Category { Id = 4, Name= "Sci-Fi" },
                   new Category { Id = 5, Name= "Cartoon" },
                   new Category { Id = 6, Name= "Horror" }

               );
            modelBuilder.Entity<Cinema>().HasData(
                   new Cinema { Id = 1,
                       Name = "VOX" ,
                       Description= "Step into a world where stories come to life at VOX Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", 
                       CinemaLogo="Vox.jpg" , 
                       Address= " Mall of Egypt Cinema" },
                   new Cinema { Id = 2, 
                       Name = "City Stars ", 
                       Description= "Step into a world where stories come to life at City Stars Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", 
                       CinemaLogo= "City Stars.jpg", 
                       Address= "Nasr City" },
                   new Cinema { Id = 3,
                       Name = "Point 90 ", 
                       Description= "Step into a world where stories come to life at Point 90 Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", 
                       CinemaLogo= "Point 90.jpg", 
                       Address= "The 5Th Settlement" },
                   new Cinema { Id = 4, 
                       Name = "Americana IMAX ", 
                       Description= "Step into a world where stories come to life at Americana IMAX Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", 
                       CinemaLogo= "Americana IMAX.jpg", 
                       Address= "Sheikh Zayed City" },
                   new Cinema { Id = 5, 
                       Name = "Zawya ", 
                       Description= "Step into a world where stories come to life at Zawya Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", 
                       CinemaLogo="Zawya.jpg", 
                       Address= "DownTown" },
                   new Cinema { Id = 6, 
                       Name = "Galaxy  ", 
                       Description= "Step into a world where stories come to life at Galaxy Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", 
                       CinemaLogo= "Galaxy.jpg",
                       Address= "ElMaadi " },
                   new Cinema { Id = 7, 
                       Name = "Sun City ", 
                       Description= "Step into a world where stories come to life at Sun City Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", 
                       CinemaLogo= "SunCity.PNg", 
                       Address= " Behind Masaken Sheraton" }
        
               );
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "The Dark Knight",
                    Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Price = 12.99,
                    ImgUrl = "The Dark Knight.jpg",
                    TrailerUrl = "EXeTwQWrcwY",
                    StartDate = new DateTime(2008 - 07 - 18) ,
                    EndDate = new DateTime( 2008-12-31),
                    MovieStatus = MovieStatus.Expired,
                    CategoryId = 1,
                    CinemaId = 1,
                },

new Movie
{
    Id = 10,
    Name = "Once Upon a Time... in Hollywood",
    Description = "A faded television actor and his stunt double strive to achieve fame and success in the film industry during the final years of Hollywood's Golden Age in 1969 Los Angeles.",
    Price = 12.99,
    ImgUrl = "Once Upon a Time... in Hollywood.jpg",
    TrailerUrl = "ELeMaP8EPAA",
    StartDate = new DateTime(2019, 7, 26),
    EndDate = new DateTime(2024, 12, 31),
    MovieStatus = MovieStatus.Expired,
    CategoryId = 3,
    CinemaId = 2,
},


new Movie
{
    Id = 3,
    Name = "Venom: The Last Dance",
    Description = "Eddie Brock struggles to adapt to his new life as the host of Venom, while facing off against new threats that challenge his dual existence. As he delves deeper into the world of anti-heroes, he must confront his own inner demons.",
    Price = 12.99,
    ImgUrl = "Venom The Last Dance.jpg",
    TrailerUrl = "HyIyd9joTTc",
    StartDate = new DateTime(2024, 5, 30),
    EndDate = new DateTime(2024, 12, 31),
    MovieStatus = MovieStatus.Upcoming,
    CategoryId = 1,
    CinemaId = 3,
}
,

new Movie
{
    Id = 4,
    Name = "Killers of the Flower Moon",
    Description = "Based on true events, this film follows the investigation into a series of murders targeting wealthy Osage people in 1920s Oklahoma, sparking the birth of the FBI.",
    Price = 14.99,
    ImgUrl = "Killers of the Flower Moon.jpg",
    TrailerUrl = "EP34Yoxs3FQ",
    StartDate = new DateTime(2023, 10, 20),
    EndDate = new DateTime(2024, 3, 31),
    MovieStatus = MovieStatus.Available,
    CategoryId = 3,
    CinemaId = 4,
}, new Movie
{
    Id = 5,
    Name = "Interstellar",
    Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
    Price = 13.99,
    ImgUrl = "Interstellar.jpg",
    TrailerUrl = "zSWdZVtXT7E",
    StartDate = new DateTime(2014 -11-07),
    EndDate = new DateTime(2015 -05-31),
    MovieStatus = MovieStatus.Expired,
    CategoryId = 4,
    CinemaId = 5,
},
new Movie
{
    Id = 6,
    Name = "Joker: Folie à Deux",
    Description = "Sequel to the 2019 film Joker, following Arthur Fleck as he continues to descend into madness, with new characters joining his dark world.",
    Price = 16.99,
    ImgUrl = "Joker Folie à Deux.jpg",
    TrailerUrl = "_OKAwz2MsJs",
    StartDate = new DateTime(2024, 10, 4),
    EndDate = new DateTime(2025, 2, 28),
    MovieStatus = MovieStatus.Upcoming,
    CategoryId = 3,
    CinemaId = 6,
}, new Movie
{
    Id = 7,
    Name = "Deadpool & Wolverine",
    Description = "The merc with a mouth, Deadpool, teams up with Wolverine in a chaotic adventure that crosses timelines and dimensions. Expect a mix of humor, action, and the unexpected in this highly anticipated sequel.",
    Price = 17.99,
    ImgUrl = "Deadpool & Wolverine.jpg",
    TrailerUrl = "73_1biulkYk",
    StartDate = new DateTime(2024, 7, 26),
    EndDate = new DateTime(2024, 12, 31),
    MovieStatus = MovieStatus.Upcoming,
    CategoryId = 2,
    CinemaId = 7,
}, new Movie
{
    Id = 8,
    Name = "The Prestige",
    Description = "In late 19th century London, two rival magicians, Robert Angier and Alfred Borden, compete to create the ultimate stage illusion while sacrificing everything they have to outwit each other. Their obsession leads to tragic consequences as they delve into the world of magic and deception.",
    Price = 9.99,
    ImgUrl = "The Prestige.jpg",
    TrailerUrl = "ELq7V8vkekI",
    StartDate = new DateTime(2006, 10, 20),
    EndDate = new DateTime(2024, 12, 31),
    MovieStatus = MovieStatus.Expired,
    CategoryId = 4,
    CinemaId = 1,
}
,

new Movie
{
    Id = 9,
    Name = "Edge of Tomorrow",
    Description = "In a future where Earth is invaded by aliens, a public relations officer finds himself caught in a time loop, reliving the same day over and over again. With the help of a skilled warrior, he learns how to fight back and save humanity.",
    Price = 9.99,
    ImgUrl = "Edge of Tomorrow.jpg",
    TrailerUrl = "yUmSVcttXnI",
    StartDate = new DateTime(2014, 5, 28),
    EndDate = new DateTime(2024, 12, 31),
    MovieStatus = MovieStatus.Expired,
    CategoryId = 1,
    CinemaId = 2,
}
,

new Movie
{
    Id = 2,
    Name = "The Equalizer 3",
    Description = "Robert McCall finds himself at home in Southern Italy, but he discovers his friends are under the control of local crime bosses. As events turn deadly, McCall knows what he has to do: become his friends' protector by taking on the mafia.",
    Price = 15.99,
    ImgUrl = "The Equalizer 3.jpg",
    TrailerUrl = "19ikl8vy4zs",
    StartDate = new DateTime(2023, 9, 1),
    EndDate = new DateTime(2024, 1, 31),
    MovieStatus = MovieStatus.Available,
    CategoryId = 1,
    CinemaId = 3,
},

new Movie
{
    Id = 11,
    Name = "Spider-Man: Across the Spider-Verse",
    Description = "Miles Morales returns for the next chapter of the Oscar-winning animated saga. He meets Gwen Stacy and teams up with a new group of Spider-People to face a powerful villain while navigating the multiverse.",
    Price = 14.99,
    ImgUrl = "Across the Spider-Verse.jpg",
    TrailerUrl = "cqGjhVJWtEg",
    StartDate = new DateTime(2023, 6, 2),
    EndDate = new DateTime(2024, 12, 31),
    MovieStatus = MovieStatus.Available,
     CategoryId = 5,
    CinemaId = 4
}
,

new Movie
{
    Id = 12,
    Name = "The Ballad of Songbirds and Snakes",
    Description = "This prequel to The Hunger Games follows a young Coriolanus Snow as he mentors the District 12 tribute in the 10th Hunger Games, setting the stage for his rise to power.",
    Price = 15.99,
    ImgUrl = "The Hunger Games The Ballad of Songbirds & Snakes.jpg",
    TrailerUrl = "NxW_X4kzeus",
    StartDate = new DateTime(2023, 11, 17),
    EndDate = new DateTime(2024, 3, 31),
    MovieStatus = MovieStatus.Upcoming,
    CategoryId = 1,
    CinemaId = 5
}, new Movie
{
    Id = 13,
    Name = "Dune: Part Two",
    Description = "Paul Atreides unites with Chani and the Fremen while seeking revenge against those who destroyed his family. He must face a choice between the love of his life and the fate of the universe.",
    Price = 16.99,
    ImgUrl = "Dune Part Two.jpg",
    TrailerUrl = "poWiludgQCw",
    StartDate = new DateTime(2024, 3, 15),
    EndDate = new DateTime(2024, 8, 1),
    MovieStatus = MovieStatus.Upcoming,
    CategoryId = 1,
    CinemaId = 6
},

new Movie
{
    Id = 14,
    Name = "Avatar 3",
    Description = "The third installment of James Cameron’s epic Avatar franchise continues the journey of the Na'vi people on Pandora, with new adventures and challenges in the breathtaking world of the planet's oceans and beyond.",
    Price = 19.99,
    ImgUrl = "Avatar 3.Png",
    TrailerUrl = "d9MyW72ELq0",
    StartDate = new DateTime(2024, 12, 20),
    EndDate = new DateTime(2025, 6, 1),
    MovieStatus = MovieStatus.Upcoming,
    CategoryId = 4,
    CinemaId = 7
}
);

            modelBuilder.Entity<ActorMovie>().HasData(
                new ActorMovie { Id = 1 ,ActorId=5 , MovieId =10 },
                new ActorMovie { Id = 2, ActorId =6 , MovieId =13 },
                new ActorMovie { Id = 3, ActorId =4 , MovieId =13 },
                new ActorMovie { Id = 4, ActorId =9 , MovieId =11 },
                new ActorMovie { Id = 5, ActorId =13 , MovieId =10 },
                new ActorMovie { Id = 6, ActorId =10 ,MovieId =9 },
                new ActorMovie { Id = 7, ActorId =14 , MovieId =2 },
                new ActorMovie { Id = 8, ActorId =15 ,MovieId =14 },
                new ActorMovie { Id = 9, ActorId =3 , MovieId =6 },
                new ActorMovie { Id = 10, ActorId = 13, MovieId = 4 },
                new ActorMovie { Id = 11 ,ActorId =1 , MovieId =7 },
                new ActorMovie { Id = 12, ActorId =2 , MovieId =7 },
                new ActorMovie { Id = 13, ActorId =8 , MovieId =3 },
                new ActorMovie { Id = 14, ActorId =16 , MovieId =5 },
                new ActorMovie { Id = 15, ActorId =2 , MovieId =8 },
                new ActorMovie { Id = 16, ActorId =11 , MovieId =8 },
                new ActorMovie { Id = 17, ActorId =11 , MovieId =1 },
                new ActorMovie { Id = 18, ActorId =12 , MovieId =12 },
                new ActorMovie { Id = 19, ActorId =7 , MovieId =13 }

             ); 

        }
        public DbSet<E_Tickets.ViewModel.ApplicationUserVM> ApplicationUserVM { get; set; } = default!;
        public DbSet<E_Tickets.ViewModel.LogInVM> LogInVM { get; set; } = default!;
    }
}
