using System.Linq;
using WebUi.Models;

namespace VyKundeservice.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(VyDbContext context)
        {
            // Allerede data i databasen
            if (context.Categories.Any())
            {
                return;
            }

            var categories = new[]
            {
                new Category
                {
                    Name = "Admin"
                },
                new Category
                {
                    Name = "Avganger"
                },
                new Category
                {
                    Name = "Billett"
                },
                new Category
                {
                    Name = "Kvittering"
                },
                new Category
                {
                    Name = "Stasjoner"
                }
            };
            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            //int categoryId = context.Categories.Single(c => c.Name == "Admin").CategoryId;
            var questions = new[]
            {
                new Question
                {
                    Message = "Hvem er Admin?",
                    Answer = "Personer som arbeider hos Vy kundeservice",
                    CategoryId = context.Categories.Single( c => c.Name == "Admin").CategoryId
                },
                new Question
                {
                    Message = "Hvordan kan jeg bli admin?",
                    Answer = "Begynn hos Vy kundeservice",
                    CategoryId = context.Categories.Single( c => c.Name == "Admin").CategoryId
                },
                new Question
                {
                    Message = "Kan admin kjøpe billett for meg?",
                    Answer = "Nei! Strengt forbudt.",
                    CategoryId = context.Categories.Single( c => c.Name == "Admin").CategoryId
                },
                new Question
                {
                    Message = "Hvor mange avganger går det i timen?",
                    Answer = "Se avgangstabellen på våre nettsider",
                    CategoryId = context.Categories.Single( c => c.Name == "Avganger").CategoryId
                },
                //new Question
                //{
                //    Message = "Kan det komme flere avganger hos meg?",
                //    Answer = "",
                //    CategoryId = context.Categories.Single( c => c.Name == "Avganger").CategoryId
                //},
                //new Question
                //{
                //    Message = "Hva slags type billetter fins det?",
                //    Answer = "",
                //    CategoryId = context.Categories.Single( c => c.Name == "Billett").CategoryId
                //},
                //new Question
                //{
                //    Message = "Hva er aldersgrensen på ungdomsbillett?",
                //    Answer = "",
                //    CategoryId = context.Categories.Single( c => c.Name == "Billett").CategoryId
                //},
                //new Question
                //{
                //    Message = "Hvem bestemmer prisen for billettens?",
                //    Answer = "",
                //    CategoryId = context.Categories.Single( c => c.Name == "Billett").CategoryId
                //},
                //new Question
                //{
                //    Message = "Er kvitteringen et gyldig bevis for kjøpt billett?",
                //    Answer = "",
                //    CategoryId = context.Categories.Single( c => c.Name == "Kvittering").CategoryId
                //},
                //new Question
                //{
                //    Message = "Hvorfor er stasjonen stengt?",
                //    Answer = "",
                //    CategoryId = context.Categories.Single( c => c.Name == "Stasjoner").CategoryId
                //},
                //new Question
                //{
                //    Message = "Hvem har ansvar for måking av stasjonen?",
                //    Answer = "",
                //    CategoryId = context.Categories.Single( c => c.Name == "Stasjoner").CategoryId
                //},
                //new Question
                //{
                //    Message = "Hvordan kan jeg kontakte dere om dårlige stasjoner?",
                //    Answer = "",
                //    CategoryId = context.Categories.Single( c => c.Name == "Stasjoner").CategoryId
                //}
            };
            context.Questions.AddRange(questions);
            context.SaveChanges();
        }
    }
}
