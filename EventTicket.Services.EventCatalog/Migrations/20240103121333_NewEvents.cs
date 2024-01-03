using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventTicket.Services.EventCatalog.Migrations
{
    /// <inheritdoc />
    public partial class NewEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[]
                {
                    "EventId", "Name", "Price", "Artist", "Date", "Description", "ImageUrl", "CategoryId", "City"
                },
                values: new object[,]
                {
                    {Guid.NewGuid(), "Summer Music Festival", 80, "Various Artists", new DateTime(2023, 7, 15, 19, 0, 0), "Join us for a thrilling night of live performances by renowned musicians. Experience the magic of music under the starry sky.", "https://example.com/summer-music-festival.jpg", new Guid("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"), "Los Angeles"},
                    {Guid.NewGuid(), "Photography Exhibition: Through the Lens", 50, "Photography Enthusiasts", new DateTime(2023, 8, 5, 10, 0, 0), "Immerse yourself in the captivating world of photography. Explore breathtaking visuals and discover the stories behind each frame.", "https://example.com/photography-exhibition.jpg", new Guid("6313179F-7837-473A-A4D5-A5571B43E6C3"), "London"},
                    {Guid.NewGuid(), "Food and Wine Tasting", 75, "Master Chefs", new DateTime(2023, 9, 1, 18, 30, 0), "Indulge in a gastronomic adventure with an exquisite selection of gourmet dishes paired with fine wines. A culinary experience like no other.", "https://example.com/food-and-wine-tasting.jpg", new Guid("6313179F-7837-473A-A4D5-A5571B43E6C0"), "Paris"},
                    {Guid.NewGuid(), "Charity Run: Miles of Hope", 25, "Running Enthusiasts", new DateTime(2023, 9, 10, 8, 0, 0), "Lace up your running shoes and join us for a charity run to support a noble cause. Every step counts in making a positive impact.", "https://example.com/charity-run.jpg", new Guid("6313179F-7837-473A-A4D5-A5571B43E6C2"), "New York"},
                    {Guid.NewGuid(), "Stand-up Comedy Night", 40, "Hilarious Comedians", new DateTime(2023, 9, 20, 20, 0, 0), "Get ready for a night filled with laughter and entertainment. Sit back, relax, and enjoy the comedic brilliance of talented stand-up comedians.", "https://example.com/stand-up-comedy-night.jpg", new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AA"), "Chicago"},
                    {Guid.NewGuid(), "Film Screening: Classic Cinema", 30, "Movie Buffs", new DateTime(2023, 10, 15, 17, 30, 0), "Relive the golden age of cinema with a special screening of classic movies. Immerse yourself in timeless stories that continue to captivate audiences.", "https://example.com/film-screening.jpg", new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AA"), "Los Angeles"},
                    {Guid.NewGuid(), "Fashion Show: Trends Unveiled", 90, "Fashion Designers", new DateTime(2023, 11, 5, 19, 0, 0), "Witness the latest fashion trends come to life on the runway. Experience the glamour and creativity of the fashion industry up close.", "https://example.com/fashion-show.jpg", new Guid("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"), "Milan"},
                    {Guid.NewGuid(), "Tech Conference: Innovate Tomorrow", 120, "Tech Experts", new DateTime(2023, 11, 15, 9, 0, 0), "Explore groundbreaking technologies and gain insights from industry leaders. Join us to shape the future of innovation.", "https://example.com/tech-conference.jpg", new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AA"), "San Francisco"},
                    {Guid.NewGuid(), "Theater Play: Dramatic Tales", 50, "Theater Artists", new DateTime(2023, 12, 10, 15, 0, 0), "Immerse yourself in the world of theater with a mesmerizing play. Witness powerful storytelling unfold on stage.", "https://example.com/theater-play.jpg", new Guid("6313179F-7837-473A-A4D5-A5571B43E6C1"), "London"},
                    {Guid.NewGuid(), "Science Exhibition: Discover the Wonders", 30, "Science Enthusiasts", new DateTime(2024, 1, 15, 10, 0, 0), "Unleash your curiosity at our science exhibition. Engage with interactive displays and unravel the mysteries of the universe.", "https://example.com/science-exhibition.jpg", new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AA"), "Tokyo"},
                    {Guid.NewGuid(), "Fashion Workshop: Style Essentials", 60, "Fashion Stylists", new DateTime(2024, 2, 1, 13, 0, 0), "Discover your personal style and learn valuable fashion tips from industry experts. Elevate your fashion game with confidence.", "https://example.com/fashion-workshop.jpg", new Guid("6313179F-7837-473A-A4D5-A5571B43E6C0"), "Paris"},
                    {Guid.NewGuid(), "Workshop: Mindful Living", 30, "Mindfulness Experts", new DateTime(2024, 3, 5, 15, 0, 0), "Learn the art of living in the present moment and cultivate mindfulness in your daily life. Discover inner peace and clarity.", "https://example.com/mindful-living-workshop.jpg", new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AA"), "San Francisco"},
                    {Guid.NewGuid(), "Food Festival: Flavors of the World", 60, "International Chefs", new DateTime(2024, 3, 20, 12, 0, 0), "Embark on a culinary journey and savor delectable dishes from around the world. Experience a fusion of flavors and cultures.", "https://example.com/food-festival.jpg", new Guid("6313179F-7837-473A-A4D5-A5571B43E6C3"), "New York"},
                    {Guid.NewGuid(), "Tech Workshop: Coding Essentials", 50, "Tech Instructors", new DateTime(2024, 4, 15, 10, 0, 0), "Unlock the world of coding and gain essential programming skills. Dive into the realm of technology and innovation.", "https://example.com/tech-workshop.jpg", new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AA"), "Berlin"},
                    {Guid.NewGuid(), "Dance Workshop: Expressive Moves", 40, "Dance Instructors", new DateTime(2024, 5, 1, 16, 0, 0), "Discover the art of dance and express yourself through graceful movements. Unleash your inner dancer.", "https://example.com/dance-workshop.jpg", new Guid("6313179F-7837-473A-A4D5-A5571B43E6C1"), "London"},
                    {Guid.NewGuid(), "Film Festival: Cinematic Extravaganza", 70, "Film Enthusiasts", new DateTime(2024, 5, 10, 12, 0, 0), "Celebrate the magic of cinema with a diverse selection of films from around the globe. Experience cinematic excellence.", "https://example.com/film-festival.jpg", new Guid("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"), "Los Angeles"},
                    {Guid.NewGuid(), "Music Concert: Melodies in Motion", 90, "Renowned Musicians", new DateTime(2024, 6, 1, 19, 30, 0), "Immerse yourself in an unforgettable musical journey with mesmerizing performances by world-renowned musicians.", "https://example.com/music-concert.jpg", new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AA"), "New York"},
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Events",
            keyColumn: "EventId",
            keyValues: new object[]
            {
                new Guid("B0788D2F-8003-43C1-92A4-EDC76A7C5DDF"),
                new Guid("6313179F-7837-473A-A4D5-A5571B43E6C2"),
                new Guid("D178C2E7-3EE3-43A9-97A7-ED3141FD019D"),
                new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AB"),
                new Guid("6313179F-7837-473A-A4D5-A5571B43E6C4"),
                new Guid("D178C2E7-3EE3-43A9-97A7-ED3141FD019E"),
                new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AC"),
                new Guid("6313179F-7837-473A-A4D5-A5571B43E6C5"),
                new Guid("D178C2E7-3EE3-43A9-97A7-ED3141FD019F"),
                new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AD"),
                new Guid("6313179F-7837-473A-A4D5-A5571B43E6C6"),
                new Guid("D178C2E7-3EE3-43A9-97A7-ED3141FD0190"),
                new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AE"),
                new Guid("6313179F-7837-473A-A4D5-A5571B43E6C7"),
                new Guid("D178C2E7-3EE3-43A9-97A7-ED3141FD0191"),
                new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AF"),
                new Guid("6313179F-7837-473A-A4D5-A5571B43E6C8"),
                new Guid("D178C2E7-3EE3-43A9-97A7-ED3141FD0192"),
                new Guid("BF3F3002-7E53-441E-8B76-F6280BE284A0"),
                new Guid("6313179F-7837-473A-A4D5-A5571B43E6C9")
            });
        }
    }
}
