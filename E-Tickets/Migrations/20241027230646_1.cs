using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Tickets.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictrue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    News = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CinemaLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogInVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RememberMe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogInVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieStatus = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorMovies_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumOfTickets = table.Column<int>(type: "int", nullable: false),
                    SelectedSeats = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => new { x.MovieId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_Booking_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    CinemaId = table.Column<int>(type: "int", nullable: true),
                    BookingApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BookingMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Booking_BookingMovieId_BookingApplicationUserId",
                        columns: x => new { x.BookingMovieId, x.BookingApplicationUserId },
                        principalTable: "Booking",
                        principalColumns: new[] { "MovieId", "ApplicationUserId" });
                    table.ForeignKey(
                        name: "FK_Seats_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seats_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Bio", "FirstName", "LastName", "News", "ProfilePictrue" },
                values: new object[,]
                {
                    { 1, "Ryan Reynolds is a Canadian actor and producer best known for his roles in films such as Deadpool, The Proposal, and Free Guy. He has established himself as one of the most charismatic and humorous actors in Hollywood.", "Ryan", "Reynolds", "Reynolds is currently filming the highly anticipated Deadpool 3, where he will reprise his iconic role alongside Hugh Jackman as Wolverine.", "Ryan Reynolds.jpg" },
                    { 2, "Hugh Jackman is an Australian actor, singer, and producer. He is best known for his role as Wolverine in the X-Men series and his performances in Les Misérables and The Greatest Showman.", "Hugh", "Jackman", "Jackman is set to return as Wolverine in Deadpool 3, marking his return to the role after his supposed final appearance in 2017's Logan.", "Hugh Jackman.jpg" },
                    { 3, "Joaquin Phoenix is an American actor known for his intense and unconventional performances. He won an Academy Award for his role as Arthur Fleck in Joker and has appeared in films like Gladiator and Her.", "Joaquin", "Phoenix", "Phoenix is set to return as Arthur Fleck in Joker: Folie à Deux, the much-anticipated sequel to his award-winning performance.", "Joaquin Phoenix.jpg" },
                    { 4, "Zendaya is an American actress and singer who rose to fame with her role in the Disney Channel series Shake It Up and has since become known for her performances in Euphoria and Dune.", "Zendaya", "", "Zendaya will reprise her role as Chani in Dune: Part Two, continuing the sci-fi epic alongside Timothée Chalamet.", "Zendaya.jpg" },
                    { 5, "Margot Robbie is an Australian actress and producer known for her roles in films such as The Wolf of Wall Street, Suicide Squad, and Barbie. She has earned widespread acclaim for her versatility and charm.", "Margot", "Robbie", "Robbie is rumored to appear in a future installment of the DC Universe, continuing her portrayal of Harley Quinn.", "Margot Robbie.jpg" },
                    { 6, "Timothée Chalamet is an American actor who gained recognition for his performances in films such as Call Me by Your Name, Lady Bird, and Dune. He is known for his intense and emotional acting style.", "Timothée", "Chalamet", "Chalamet will reprise his role as Paul Atreides in Dune: Part Two, continuing the epic saga of Frank Herbert's novel.", "Timothée Chalamet.jpg" },
                    { 7, "Florence Pugh is a British actress known for her powerful performances in films such as Midsommar, Little Women, and Don't Worry Darling. She has quickly become one of Hollywood's most respected young talents.", "Florence", "Pugh", "Pugh is set to star in Dune: Part Two as Princess Irulan, marking her entry into the science fiction genre.", "Florence Pugh.jpg" },
                    { 8, "Tom Hardy is an English actor and producer known for his versatile roles in both film and television. He has received critical acclaim for his performances in movies like Mad Max: Fury Road, The Revenant, and Venom. Hardy is also known for his roles in popular films such as Inception and Dunkirk.", "Tom", "Hardy", "Hardy is set to reprise his role as Eddie Brock in the upcoming Venom sequel, Venom: The Last Dance.", "Tom Hardy.jpg" },
                    { 9, "Daniel Kaluuya is a British actor and writer known for his roles in Get Out, Black Panther, and Judas and the Black Messiah. He won an Academy Award for Best Supporting Actor for his portrayal of Fred Hampton.", "Daniel", "Kaluuya", "Kaluuya will star in the upcoming Marvel film, set to expand his presence in the superhero genre.", "Daniel Kaluuya.jpg" },
                    { 10, "Emily Blunt is a British-American actress known for her roles in films such as A Quiet Place, Mary Poppins Returns, and Edge of Tomorrow. She has received acclaim for her versatility and strong screen presence.", "Emily", "Blunt", "Blunt is set to star in the upcoming film Oppenheimer, directed by Christopher Nolan, which chronicles the life of J. Robert Oppenheimer.", "Emily Blunt.jpg" },
                    { 11, "Christian Bale is a British-American actor known for his versatility and commitment to his roles. He has received numerous accolades, including two Academy Awards. Some of his notable films include American Psycho, The Dark Knight Trilogy, and Ford v Ferrari.", "Christian", "Bale", "Bale is set to star in the upcoming film Oppenheimer, directed by Christopher Nolan, where he will portray J. Robert Oppenheimer.", "Christian Bale.jpg" },
                    { 12, "Rachel Zegler is an American actress and singer who gained fame for her role as Maria in the 2021 film adaptation of West Side Story, directed by Steven Spielberg. She is known for her powerful voice and compelling performances.", "Rachel", "Zegler", "Zegler will star as Snow White in the upcoming live-action adaptation of Disney's classic animated film.", "Rachel Zegler.jpg" },
                    { 13, "Leonardo DiCaprio is an American actor and producer known for his diverse roles in both independent films and major blockbusters. He has received numerous accolades, including an Academy Award for Best Actor for his performance in The Revenant. His notable films include Titanic, Inception, The Wolf of Wall Street, and Once Upon a Time in Hollywood.", "Leonardo", "DiCaprio", "DiCaprio is set to star in Martin Scorsese's upcoming film Killers of the Flower Moon, which tells the story of the Osage murders in the 1920s.", "Leonardo DiCaprio.jpg" },
                    { 14, "Denzel Washington is an American actor, producer, and director known for his powerful performances in both drama and action films. He has received numerous awards, including two Academy Awards for Best Actor for his roles in Training Day and Glory. Some of his notable films include Malcolm X, The Equalizer series, and Fences.", "Denzel", "Washington", "Washington is set to star in the upcoming film The Equalizer 3, continuing his role as Robert McCall.", "Denzel Washington.jpg" },
                    { 15, "Zoe Saldana is an American actress and dancer known for her roles in blockbuster franchises including Avatar, Guardians of the Galaxy, and Star Trek. She is recognized for her strong performances and has become one of the highest-grossing actresses in Hollywood.", "Zoe", "Saldana", "Saldana will reprise her role as Neytiri in the upcoming Avatar sequels, continuing her journey in James Cameron's epic sci-fi universe.", "Zoe Saldana.jpg" },
                    { 16, "Matthew McConaughey is an American actor and producer known for his charismatic performances and distinct voice. He gained fame with films such as Dazed and Confused, The Lincoln Lawyer, and Magic Mike, but he earned critical acclaim and an Academy Award for Best Actor for his role in Dallas Buyers Club.", "Matthew", "McConaughey", "McConaughey is set to star in the upcoming film The Gentleman, directed by Guy Ritchie, which follows a British drug lord and his attempts to sell off his empire.", "Matthew McConaughey.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Sci-Fi" },
                    { 5, "Cartoon" },
                    { 6, "Horror" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "CinemaLogo", "Description", "Name" },
                values: new object[,]
                {
                    { 1, " Mall of Egypt Cinema", "Vox.jpg", "Step into a world where stories come to life at VOX Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", "VOX" },
                    { 2, "Nasr City", "City Stars.jpg", "Step into a world where stories come to life at City Stars Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", "City Stars " },
                    { 3, "The 5Th Settlement", "Point 90.jpg", "Step into a world where stories come to life at Point 90 Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", "Point 90 " },
                    { 4, "Sheikh Zayed City", "Americana IMAX.jpg", "Step into a world where stories come to life at Americana IMAX Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", "Americana IMAX " },
                    { 5, "DownTown", "Zawya.jpg", "Step into a world where stories come to life at Zawya Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", "Zawya " },
                    { 6, "ElMaadi ", "Galaxy.jpg", "Step into a world where stories come to life at Galaxy Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", "Galaxy  " },
                    { 7, " Behind Masaken Sheraton", "SunCity.PNg", "Step into a world where stories come to life at Sun City Cinema, a state-of-the-art movie theater designed to provide the ultimate cinematic experience. this modern theater features plush, reclining seats and crystal-clear surround sound that immerses you in every moment. Whether you're here for the latest blockbuster, an indie gem, or a family-friendly flick, our giant screens deliver stunning visuals, transporting you to new worlds. Enjoy a wide selection of snacks, from classic buttered popcorn to gourmet treats, and make the most of our comfortable, spacious seating. With a range of movie times and special screenings, [Theater Name] offers something for every movie lover. Whether it's a solo escape, a night out with friends, or a family outing, your perfect movie experience starts here.", "Sun City " }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "CinemaId", "Description", "EndDate", "ImgUrl", "MovieStatus", "Name", "Price", "StartDate", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, 1, 1, "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1965), "The Dark Knight.jpg", 2, "The Dark Knight", "12.99", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1983), "EXeTwQWrcwY" },
                    { 2, 1, 3, "Robert McCall finds himself at home in Southern Italy, but he discovers his friends are under the control of local crime bosses. As events turn deadly, McCall knows what he has to do: become his friends' protector by taking on the mafia.", new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Equalizer 3.jpg", 1, "The Equalizer 3", "15.99", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "19ikl8vy4zs" },
                    { 3, 1, 3, "Eddie Brock struggles to adapt to his new life as the host of Venom, while facing off against new threats that challenge his dual existence. As he delves deeper into the world of anti-heroes, he must confront his own inner demons.", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venom The Last Dance.jpg", 0, "Venom: The Last Dance", "12.99", new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HyIyd9joTTc" },
                    { 4, 3, 4, "Based on true events, this film follows the investigation into a series of murders targeting wealthy Osage people in 1920s Oklahoma, sparking the birth of the FBI.", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Killers of the Flower Moon.jpg", 1, "Killers of the Flower Moon", "14.99", new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "EP34Yoxs3FQ" },
                    { 5, 4, 5, "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1979), "Interstellar.jpg", 2, "Interstellar", "13.99", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1996), "zSWdZVtXT7E" },
                    { 6, 3, 6, "Sequel to the 2019 film Joker, following Arthur Fleck as he continues to descend into madness, with new characters joining his dark world.", new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joker Folie à Deux.jpg", 0, "Joker: Folie à Deux", "16.99", new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "_OKAwz2MsJs" },
                    { 7, 2, 7, "The merc with a mouth, Deadpool, teams up with Wolverine in a chaotic adventure that crosses timelines and dimensions. Expect a mix of humor, action, and the unexpected in this highly anticipated sequel.", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deadpool & Wolverine.jpg", 0, "Deadpool & Wolverine", "17.99", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "73_1biulkYk" },
                    { 8, 4, 1, "In late 19th century London, two rival magicians, Robert Angier and Alfred Borden, compete to create the ultimate stage illusion while sacrificing everything they have to outwit each other. Their obsession leads to tragic consequences as they delve into the world of magic and deception.", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Prestige.jpg", 2, "The Prestige", "9.99", new DateTime(2006, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ELq7V8vkekI" },
                    { 9, 1, 2, "In a future where Earth is invaded by aliens, a public relations officer finds himself caught in a time loop, reliving the same day over and over again. With the help of a skilled warrior, he learns how to fight back and save humanity.", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edge of Tomorrow.jpg", 2, "Edge of Tomorrow", "9.99", new DateTime(2014, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "yUmSVcttXnI" },
                    { 10, 3, 2, "A faded television actor and his stunt double strive to achieve fame and success in the film industry during the final years of Hollywood's Golden Age in 1969 Los Angeles.", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Once Upon a Time... in Hollywood.jpg", 2, "Once Upon a Time... in Hollywood", "12.99", new DateTime(2019, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "ELeMaP8EPAA" },
                    { 11, 5, 4, "Miles Morales returns for the next chapter of the Oscar-winning animated saga. He meets Gwen Stacy and teams up with a new group of Spider-People to face a powerful villain while navigating the multiverse.", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Across the Spider-Verse.jpg", 1, "Spider-Man: Across the Spider-Verse", "14.99", new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "cqGjhVJWtEg" },
                    { 12, 1, 5, "This prequel to The Hunger Games follows a young Coriolanus Snow as he mentors the District 12 tribute in the 10th Hunger Games, setting the stage for his rise to power.", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hunger Games The Ballad of Songbirds & Snakes.jpg", 0, "The Ballad of Songbirds and Snakes", "15.99", new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "NxW_X4kzeus" },
                    { 13, 1, 6, "Paul Atreides unites with Chani and the Fremen while seeking revenge against those who destroyed his family. He must face a choice between the love of his life and the fate of the universe.", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dune Part Two.jpg", 0, "Dune: Part Two", "16.99", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "poWiludgQCw" },
                    { 14, 4, 7, "The third installment of James Cameron’s epic Avatar franchise continues the journey of the Na'vi people on Pandora, with new adventures and challenges in the breathtaking world of the planet's oceans and beyond.", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 3.Png", 0, "Avatar 3", "19.99", new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "d9MyW72ELq0" }
                });

            migrationBuilder.InsertData(
                table: "ActorMovies",
                columns: new[] { "Id", "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 5, 10 },
                    { 2, 6, 13 },
                    { 3, 4, 13 },
                    { 4, 9, 11 },
                    { 5, 13, 10 },
                    { 6, 10, 9 },
                    { 7, 14, 2 },
                    { 8, 15, 14 },
                    { 9, 3, 6 },
                    { 10, 13, 4 },
                    { 11, 1, 7 },
                    { 12, 2, 7 },
                    { 13, 8, 3 },
                    { 14, 16, 5 },
                    { 15, 2, 8 },
                    { 16, 11, 8 },
                    { 17, 11, 1 },
                    { 18, 12, 12 },
                    { 19, 7, 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovies_ActorId",
                table: "ActorMovies",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovies_MovieId",
                table: "ActorMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ApplicationUserId",
                table: "Booking",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CinemaId",
                table: "Movies",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_BookingMovieId_BookingApplicationUserId",
                table: "Seats",
                columns: new[] { "BookingMovieId", "BookingApplicationUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_CinemaId",
                table: "Seats",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_MovieId",
                table: "Seats",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovies");

            migrationBuilder.DropTable(
                name: "ApplicationUserVM");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LogInVM");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cinemas");
        }
    }
}
