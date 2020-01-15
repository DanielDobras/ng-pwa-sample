using System;
using System.Collections.Generic;
using System.IO;
using Ng_Pwa_Sample_Backend.Web.Models;

namespace Ng_Pwa_Sample_Backend.Web.Factory
{
    public class QuestionFactory
    {
        private readonly string DEFAULT_PATH = AppDomain.CurrentDomain.BaseDirectory + "Images/Difficulty";
        // Load images
        
        // create Questions depending on difficulty

        // randomizes order of questions

        public List<Question> GetQuestions(string difficulty)
        {
            if (difficulty.ToLower() == "easy")
            {
                return LoadEasyQuestions();
            }

            return LoadHardQuestions();
        }

        private List<Question> LoadEasyQuestions()
        {
            var cockatiel = new Question
            {
                Name = "Cockatiel",
                IsBird = true,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Easy/Cockatiel.jpg"))),
                Description =
                    "The cockatiel (Nymphicus hollandicus), also known as miniature cockatoo, weero, or quarrion, is a bird that is a member of its own branch of the cockatoo family endemic to Australia. They are prized as household pets and companion parrots throughout the world and are relatively easy to breed. As a caged bird, cockatiels are second in popularity only to the budgerigar."
            };

            var aeroplane = new Question()
            {
                Name = "Aeroplane",
                IsBird = false,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Easy/Flugzeug.jpg"))),
                Description = "An aeroplane is not a bird..."
            };

            var shark = new Question()
            {
                Name = "Sharknado",
                IsBird = false,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Easy/Hai.jpg"))),
                Description = "While Sharknado does seem to be flying, he is not a bird."
            };

            var scarlet = new Question
            {
                Name = "Scarlet Tanager",
                IsBird = true,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Easy/Scarlet_tanager.jpg"))),
                Description =
                    "The scarlet tanager (Piranga olivacea) is a medium-sized American songbird. Until recently, it was placed in the tanager family (Thraupidae),but other members of its genus and it are now classified as belonging to the cardinal family (Cardinalidae). The species' plumage and vocalizations are similar to other members of the cardinal family, although the Piranga species lacks the thick conical bill (well suited to seed and insect eating) that many cardinals possess."
            };

            var superMan = new Question
            {
                Name = "Superman",
                IsBird = false,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Easy/Superman.jpg"))),
                Description = "Is it a bird? Is it a plane? https://www.youtube.com/watch?v=ySvAs5ppkRw"
            };

            var questions = new List<Question> {cockatiel, aeroplane, shark, scarlet, superMan};

            return ShuffleList(questions);
        }


        private List<Question> LoadHardQuestions()
        {
            var chicken = new Question
            {
                Name = "Chicken",
                IsBird = true,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Hard/Chicken.jpg"))),
                Description =
        "A chicken is a bird. One of the features that differentiate it from most other birds is that it has a comb and two wattles. The comb is the red appendage on the top of the head, and the wattles are the two appendages under the chin. These are secondary sexual characteristics and are more prominent in the male."
            };

            var bat = new Question()
            {
                Name = "Bat",
                IsBird = false,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Hard/Fledermaus.jpg"))),
                Description = "According to scientific principles of classification, though, we now know there's no such thing as a bird without feathers. Instead, bats are mammals. In fact, bats are the only mammals that can truly fly. A few other mammals, such as the flying squirrel, appear to fly, but they actually glide through the air instead."
            };

            var penguin = new Question()
            {
                Name = "Penguin",
                IsBird = true,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Hard/Penguin.jpg"))),
                Description = "Penguins (order Sphenisciformes, family Spheniscidae) are a group of aquatic flightless birds. They live almost exclusively in the Southern Hemisphere, with only one species, the Galapagos penguin, found north of the equator. Highly adapted for life in the water, penguins have countershaded dark and white plumage, and their wings have evolved into flippers."
            };

            var peafowl  = new Question
            {
                Name = "Peafowl",
                IsBird = true,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Hard/Pfau.jpg"))),
                Description =
                    "Peafowl is a common name for three species of birds in the genera Pavo and Afropavo of the Phasianidae family, the pheasants and their allies. Male peafowl are referred to as peacocks, and female peafowl as peahens, though peafowl of either sex are often referred to colloquially as \"peacocks.\""
            };

            var dinosaur = new Question
            {
                Name = "Pteranodon",
                IsBird = false,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Hard/Pteranodon.jpg"))),
                Description = "Flying dinosaurs are reptiles."
            };

            var auerhuhn = new Question
            {
                Name = "Capercaillie // Auerhuhn",
                IsBird = true,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Hard/Auerhuhn.jfif"))),
                Description = ""
            };
            var kiwi = new Question
            {
                Name = "Kiwi",
                IsBird = true,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Hard/Kiwi.jfif"))),
                Description = ""
            };

            var schuhschnabel = new Question
            {
                Name = "Shoe Beak // Schuhschnabel",
                IsBird = true,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Hard/Schuhschnabel.jfif"))),
                Description = ""
            };

            var strauss = new Question
            {
                Name = "Ostrich // Strauss",
                IsBird = true,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Hard/Strauss.jpg"))),
                Description = ""
            };


            var taubenschwänzchen = new Question
            {
                Name = "Humming // Taubenschwänzchen",
                IsBird = false,
                Image = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(DEFAULT_PATH, "Hard/Taubenschwaenzchen.jpg"))),
                Description = ""
            };

            var questions = new List<Question> { chicken, bat, dinosaur, peafowl, penguin, auerhuhn, kiwi, schuhschnabel, strauss, taubenschwänzchen };

            return ShuffleList(questions);
        }


        private List<T> ShuffleList<T>(List<T> inputList)
        {
            List<T> randomList = new List<T>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }
    }
}
