using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icon = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "/resources/icons/bird.svg", "Bird" },
                    { 2, "/resources/icons/dog.svg", "Dog" },
                    { 3, "/resources/icons/cat.svg", "Cat" },
                    { 4, "/resources/icons/fish.svg", "Fish" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { 1, "Air-wind" },
                    { 2, "Blaziken" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, 1, "A small gregarious Australian parakeet that in the wild is green with a yellow head. It is popular as a pet bird and has been bred in a variety of colors.", "/img/pet/bird/budgerigar.jpg", "Budgerigar", 2762.68m, 14 },
                    { 2, 1, "A slender long-crested Australian parrot related to the cockatoos, with a mainly gray body, white shoulders, and a yellow and orange face.", "/img/pet/bird/cockatiel.jpg", "Cockatiel", 2278.8m, 18 },
                    { 3, 1, "A parrot with an erectile crest, found in Australia, eastern Indonesia, and neighboring islands.", "/img/pet/bird/cackatoo.jpg", "Cackatoo", 56970m, 21 },
                    { 4, 1, "A parrot native to central and eastern South America. With a length (from the top of its head to the tip of its long pointed tail) of about one meter it is longer than any other species of parrot.", "/img/pet/bird/hyacinth-macaw.jpg", "Hyacinth Macaw", 34182m, 5 },
                    { 5, 1, "A stocky seed- or fruit-eating bird with a small head, short legs, and a cooing voice. Doves are generally smaller and more delicate than pigeons, but many kinds have been given both names.", "/img/pet/bird/dove.jpg", "Dove", 3703.05m, 26 },
                    { 6, 1, "The most sexually dimorphic of all the parrot species. The contrast between the brilliant emerald green plumage of the male and the deep red/purple plumage of the female is so marked that the birds were, until the early 20th century, considered to be different species.", "/img/pet/bird/eclectus-parrot.jpg", "Eclectus Parrot", 7121.25m, 25 },
                    { 7, 1, "Known for the sweet singing of the males, canaries are friendly birds that are a type of finch native to the Canary Islands.", "/img/pet/bird/canary.jpg", "Canary", 1139.4m, 10 },
                    { 8, 3, "One of the first distinctly recognised breeds of Asian cat.", "/img/pet/cat/siamese.jpg", "Siamese", 15000m, 120 },
                    { 9, 3, "A long-haired breed of cat characterised by a round face and short muzzle.", "/img/pet/cat/persian.jpg", "Persian", 15000m, 119 },
                    { 10, 3, "The breed's distinctive appearance, seeming long, lean and finely colored compared to other cats, has been analogized to that of human fashion models.", "/img/pet/cat/abyssinian.jpg", "Abyssinian", 5697m, 34 },
                    { 11, 3, "A breed of cat known for its lack of fur.", "/img/pet/cat/sphynx.jpg", "Sphynx", 34182m, 20 },
                    { 12, 3, "A breed or sub-breed of long-haired cat similar in type to the Persian, with the exception of its blue eyes and its point colouration, which were derived from crossing the Persian with the Siamese.", "/img/pet/cat/himalayan.jpg", "Himalayan", 17091m, 19 },
                    { 13, 3, "A long-legged wild cat with black tufted ears and a uniform brown coat, native to Africa and western Asia.", "/img/pet/cat/caracal.jpg", "Caracal", 85455m, 5 },
                    { 14, 3, "A large American wild cat with a plain tawny to grayish coat, found from Canada to Patagonia.", "/img/pet/cat/cougar.jpg", "Cougar", 56970m, 3 },
                    { 15, 3, "A slender African wildcat with long legs, large ears, and a black-spotted orange-brown coat.", "/img/pet/cat/serval.jpeg", "Serval", 170910m, 1 },
                    { 16, 2, "It has erect ears that are in proportion to the equilateral triangle of the head. The breed standard indicates that the ears should be firm, medium in size, and tapered slightly to a rounded point.", "/img/pet/dog/pembroke-welsh-corgi.jpg", "Pembroke Welsh Corgi", 25000m, 212 },
                    { 17, 2, "A small sturdy hound of a breed with a coat of medium length, bred especially for hunting.", "/img/pet/dog/beagle.jpg", "Beagle", 28485m, 112 },
                    { 18, 2, "A small dog of a breed with long silky hair, a pointed muzzle, and pricked ears.", "/img/pet/dog/pomeranian.jpg", "Pomeranian", 30000m, 90 },
                    { 19, 2, "A dog of a white, short-haired breed with dark spots.", "/img/pet/dog/dalmatian.jpg", "Dalmatian", 34182m, 95 },
                    { 20, 2, "A British breed of toy dog of spaniel type. Four colours are recognised: Blenheim (chestnut and white), tricolour (black/white/tan), black and tan, and ruby; the coat is smooth and silky. The lifespan is usually between eight and twelve years.", "/img/pet/dog/cavalier-king-charles-spaniel.jpg", "Cavalier King Charles Spaniel", 56970m, 100 },
                    { 21, 2, "A medium-sized working sled dog breed. The breed belongs to the Spitz genetic family. It is recognizable by its thickly furred double coat, erect triangular ears, and distinctive markings, and is smaller than the similar-looking Alaskan Malamute.", "/img/pet/dog/siberian-husky.jpg", "Siberian Husky", 13500m, 73 },
                    { 22, 4, "A large genus of small, active, often colorful, freshwater ray-finned fishes, in the gourami family.", "/img/pet/fish/betta-fish.jpg", "Betta Fish", 1000m, 5000 },
                    { 23, 4, "A genus of freshwater catfish in the family Callichthyidae and subfamily Corydoradinae. The species usually have more restricted areas of endemism than other callichthyids, but the area of distribution of the entire genus almost equals the area of distribution of the family, except for Panama where Corydoras is not present.", "/img/pet/fish/corydoras-catfish.jpg", "Corydoras Catfish", 1993m, 6000 },
                    { 24, 4, "A goldfish that possesses an egg-shaped body, a high dorsal fin, a long quadruple caudal fin, and no shoulder hump.", "/img/pet/fish/fantail-goldfish.jpg", "Fantail Goldfish", 284m, 7000 },
                    { 25, 4, "A small, livebearing freshwater fish widely kept in aquariums. Native to tropical America, it has been introduced elsewhere to control mosquito larvae.", "/img/pet/fish/guppy.jpg", "Guppy", 100m, 1200 },
                    { 26, 4, "A small genus of freshwater fish from the family Cichlidae known to most aquarists as angelfish.", "/img/pet/fish/silver-angelfish.jpg", "Silver Angelfish", 1139m, 3450 },
                    { 27, 4, "A marine fish belonging to the family Pomacentridae, which includes clownfishes and damselfishes. Amphiprion ocellaris are found in different colors, depending on where they are located.", "/img/pet/fish/ocellaris-clownfish.jpg", "Ocellaris Clownfish (False Percula Clownfish)", 1139m, 10 },
                    { 28, 4, "The twospined angelfish has a basic dark purplish-blue body. This is marked with irregular orange vertical bars on its flanks.", "/img/pet/fish/coral-beauty-angelfish.jpg", "Coral Beauty Angelfish (Two-Spined Angelfish)", 3417.63m, 10 },
                    { 29, 4, "Typically olive to brown with dark bars and a large number of round or elongated white spots of different sizes. The blenny has many pale spots, dark streaks that run anteriorly, and several dark bands.", "/img/pet/fish/lawnmower-blenny.jpg", "Lawnmower Blenny (Jeweled Rockskipper)", 8539.803m, 10 },
                    { 30, 4, "It differs from all the other hawkfish species in its elongated snout, the length of the snout fitting roughly twice into the overall length of the head. The canine teeth in the jaws are of uniform size and are only slightly larger than the inner band of villiform teeth.", "/img/pet/fish/longnose-hawkfish.jpg", "Longnose Hawkfish", 56959.6m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
