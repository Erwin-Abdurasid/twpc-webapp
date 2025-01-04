using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Products

            // Bird            
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Budgerigar",
                Description = "A small gregarious Australian parakeet that in the wild is green with a yellow head. It is popular as a pet bird and has been bred in a variety of colors.",
                ImageUrl = "/img/pet/bird/budgerigar.jpg",
                Price = (decimal)2762.68,
                Qty = 14,
                CategoryId = 1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Cockatiel",
                Description = "A slender long-crested Australian parrot related to the cockatoos, with a mainly gray body, white shoulders, and a yellow and orange face.",
                ImageUrl = "/img/pet/bird/cockatiel.jpg",
                Price = (decimal)2278.80,
                Qty = 18,
                CategoryId = 1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Cackatoo",
                Description = "A parrot with an erectile crest, found in Australia, eastern Indonesia, and neighboring islands.",
                ImageUrl = "/img/pet/bird/cackatoo.jpg",
                Price = 56970,
                Qty = 21,
                CategoryId = 1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Hyacinth Macaw",
                Description = "A parrot native to central and eastern South America. With a length (from the top of its head to the tip of its long pointed tail) of about one meter it is longer than any other species of parrot.",
                ImageUrl = "/img/pet/bird/hyacinth-macaw.jpg",
                Price = 34182,
                Qty = 5,
                CategoryId = 1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Dove",
                Description = "A stocky seed- or fruit-eating bird with a small head, short legs, and a cooing voice. Doves are generally smaller and more delicate than pigeons, but many kinds have been given both names.",
                ImageUrl = "/img/pet/bird/dove.jpg",
                Price = (decimal)3703.05,
                Qty = 26,
                CategoryId = 1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Eclectus Parrot",
                Description = "The most sexually dimorphic of all the parrot species. The contrast between the brilliant emerald green plumage of the male and the deep red/purple plumage of the female is so marked that the birds were, until the early 20th century, considered to be different species.",
                ImageUrl = "/img/pet/bird/eclectus-parrot.jpg",
                Price = (decimal)7121.25,
                Qty = 25,
                CategoryId = 1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Canary",
                Description = "Known for the sweet singing of the males, canaries are friendly birds that are a type of finch native to the Canary Islands.",
                ImageUrl = "/img/pet/bird/canary.jpg",
                Price = (decimal)1139.40,
                Qty = 10,
                CategoryId = 1
            });

            // Cat
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Siamese",
                Description = "One of the first distinctly recognised breeds of Asian cat.",
                ImageUrl = "/img/pet/cat/siamese.jpg",
                Price = 15000,
                Qty = 120,
                CategoryId = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Name = "Persian",
                Description = "A long-haired breed of cat characterised by a round face and short muzzle.",
                ImageUrl = "/img/pet/cat/persian.jpg",
                Price = 15000,
                Qty = 119,
                CategoryId = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Name = "Abyssinian",
                Description = "The breed's distinctive appearance, seeming long, lean and finely colored compared to other cats, has been analogized to that of human fashion models.",
                ImageUrl = "/img/pet/cat/abyssinian.jpg",
                Price = 5697,
                Qty = 34,
                CategoryId = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 11,
                Name = "Sphynx",
                Description = "A breed of cat known for its lack of fur.",
                ImageUrl = "/img/pet/cat/sphynx.jpg",
                Price = 34182,
                Qty = 20,
                CategoryId = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                Name = "Himalayan",
                Description = "A breed or sub-breed of long-haired cat similar in type to the Persian, with the exception of its blue eyes and its point colouration, which were derived from crossing the Persian with the Siamese.",
                ImageUrl = "/img/pet/cat/himalayan.jpg",
                Price = 17091,
                Qty = 19,
                CategoryId = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 13,
                Name = "Caracal",
                Description = "A long-legged wild cat with black tufted ears and a uniform brown coat, native to Africa and western Asia.",
                ImageUrl = "/img/pet/cat/caracal.jpg",
                Price = 85455,
                Qty = 5,
                CategoryId = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 14,
                Name = "Cougar",
                Description = "A large American wild cat with a plain tawny to grayish coat, found from Canada to Patagonia.",
                ImageUrl = "/img/pet/cat/cougar.jpg",
                Price = 56970,
                Qty = 3,
                CategoryId = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 15,
                Name = "Serval",
                Description = "A slender African wildcat with long legs, large ears, and a black-spotted orange-brown coat.",
                ImageUrl = "/img/pet/cat/serval.jpeg",
                Price = 170910,
                Qty = 1,
                CategoryId = 3
            });

            // Dog
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 16,
                Name = "Pembroke Welsh Corgi",
                Description = "It has erect ears that are in proportion to the equilateral triangle of the head. The breed standard indicates that the ears should be firm, medium in size, and tapered slightly to a rounded point.",
                ImageUrl = "/img/pet/dog/pembroke-welsh-corgi.jpg",
                Price = 25000,
                Qty = 212,
                CategoryId = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 17,
                Name = "Beagle",
                Description = "A small sturdy hound of a breed with a coat of medium length, bred especially for hunting.",
                ImageUrl = "/img/pet/dog/beagle.jpg",
                Price = 28485,
                Qty = 112,
                CategoryId = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 18,
                Name = "Pomeranian",
                Description = "A small dog of a breed with long silky hair, a pointed muzzle, and pricked ears.",
                ImageUrl = "/img/pet/dog/pomeranian.jpg",
                Price = 30000,
                Qty = 90,
                CategoryId = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 19,
                Name = "Dalmatian",
                Description = "A dog of a white, short-haired breed with dark spots.",
                ImageUrl = "/img/pet/dog/dalmatian.jpg",
                Price = 34182,
                Qty = 95,
                CategoryId = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 20,
                Name = "Cavalier King Charles Spaniel",
                Description = "A British breed of toy dog of spaniel type. Four colours are recognised: Blenheim (chestnut and white), tricolour (black/white/tan), black and tan, and ruby; the coat is smooth and silky. The lifespan is usually between eight and twelve years.",
                ImageUrl = "/img/pet/dog/cavalier-king-charles-spaniel.jpg",
                Price = 56970,
                Qty = 100,
                CategoryId = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 21,
                Name = "Siberian Husky",
                Description = "A medium-sized working sled dog breed. The breed belongs to the Spitz genetic family. It is recognizable by its thickly furred double coat, erect triangular ears, and distinctive markings, and is smaller than the similar-looking Alaskan Malamute.",
                ImageUrl = "/img/pet/dog/siberian-husky.jpg",
                Price = 13500,
                Qty = 73,
                CategoryId = 2
            });

            // Fish
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 22,
                Name = "Betta Fish",
                Description = "A large genus of small, active, often colorful, freshwater ray-finned fishes, in the gourami family.",
                ImageUrl = "/img/pet/fish/betta-fish.jpg",
                Price = 1000,
                Qty = 5000,
                CategoryId = 4
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 23,
                Name = "Corydoras Catfish",
                Description = "A genus of freshwater catfish in the family Callichthyidae and subfamily Corydoradinae. The species usually have more restricted areas of endemism than other callichthyids, but the area of distribution of the entire genus almost equals the area of distribution of the family, except for Panama where Corydoras is not present.",
                ImageUrl = "/img/pet/fish/corydoras-catfish.jpg",
                Price = 1993,
                Qty = 6000,
                CategoryId = 4
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 24,
                Name = "Fantail Goldfish",
                Description = "A goldfish that possesses an egg-shaped body, a high dorsal fin, a long quadruple caudal fin, and no shoulder hump.",
                ImageUrl = "/img/pet/fish/fantail-goldfish.jpg",
                Price = 284,
                Qty = 7000,
                CategoryId = 4
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 25,
                Name = "Guppy",
                Description = "A small, livebearing freshwater fish widely kept in aquariums. Native to tropical America, it has been introduced elsewhere to control mosquito larvae.",
                ImageUrl = "/img/pet/fish/guppy.jpg",
                Price = 100,
                Qty = 1200,
                CategoryId = 4
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 26,
                Name = "Silver Angelfish",
                Description = "A small genus of freshwater fish from the family Cichlidae known to most aquarists as angelfish.",
                ImageUrl = "/img/pet/fish/silver-angelfish.jpg",
                Price = 1139,
                Qty = 3450,
                CategoryId = 4
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 27,
                Name = "Ocellaris Clownfish (False Percula Clownfish)",
                Description = "A marine fish belonging to the family Pomacentridae, which includes clownfishes and damselfishes. Amphiprion ocellaris are found in different colors, depending on where they are located.",
                ImageUrl = "/img/pet/fish/ocellaris-clownfish.jpg",
                Price = 1139,
                Qty = 10,
                CategoryId = 4
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 28,
                Name = "Coral Beauty Angelfish (Two-Spined Angelfish)",
                Description = "The twospined angelfish has a basic dark purplish-blue body. This is marked with irregular orange vertical bars on its flanks.",
                ImageUrl = "/img/pet/fish/coral-beauty-angelfish.jpg",
                Price = (decimal)3417.63,
                Qty = 10,
                CategoryId = 4
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 29,
                Name = "Lawnmower Blenny (Jeweled Rockskipper)",
                Description = "Typically olive to brown with dark bars and a large number of round or elongated white spots of different sizes. The blenny has many pale spots, dark streaks that run anteriorly, and several dark bands.",
                ImageUrl = "/img/pet/fish/lawnmower-blenny.jpg",
                Price = (decimal)8539.803,
                Qty = 10,
                CategoryId = 4
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 30,
                Name = "Longnose Hawkfish",
                Description = "It differs from all the other hawkfish species in its elongated snout, the length of the snout fitting roughly twice into the overall length of the head. The canine teeth in the jaws are of uniform size and are only slightly larger than the inner band of villiform teeth.",
                ImageUrl = "/img/pet/fish/longnose-hawkfish.jpg",
                Price = (decimal)56959.60,
                Qty = 1,
                CategoryId = 4
            });

            //Add users
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "Air-wind"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                UserName = "Blaziken"
            });

            //Create Shopping Cart for Users
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 1,
                UserId = 1
            });

            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 2,
                UserId = 2
            });

            //Add Product Categories
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 1,
                Name = "Bird",
                Icon = "/resources/icons/bird.svg"
            });

            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 2,
                Name = "Dog",
                Icon = "/resources/icons/dog.svg"
            });

            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 3,
                Name = "Cat",
                Icon = "/resources/icons/cat.svg"
            });

            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 4,
                Name = "Fish",
                Icon = "/resources/icons/fish.svg"
            });
        }

        public DbSet<Cart>? Carts { get; set; }
        public DbSet<CartItem>? CartItems { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductCategory>? ProductCategories { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}
