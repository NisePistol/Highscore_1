using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace Highscore
{
    class SpelarePoäng
    {
        public string namn { get; set; }
        public int poeng { get; set; }
        public DateTime datum { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            SkapaOchSkrivUt();
            
            //Läs in spelare från json fil
            string jsonIn = File.ReadAllText("highscore.json");

            //Lägg spelare i lista
            List<SpelarePoäng> spelareLista = JsonSerializer.Deserialize<List<SpelarePoäng>>(jsonIn);

            //Skriv ut varje spelare och dess egenskaper
            foreach (var spelare in spelareLista)
            {
                Console.WriteLine($"Namn: {spelare.namn}, Poäng: {spelare.poeng}, Datum: {spelare.datum} ");
            }
        }
        
        static void SkapaOchSkrivUt()
        {
            // Skapa lista av spelare
            List<SpelarePoäng> spelareLista = new List<SpelarePoäng>();

            //Skapa första spelare
            SpelarePoäng spelare1 = new SpelarePoäng();
            spelare1.namn = "lars";
            spelare1.poeng = 100;
            spelare1.datum = DateTime.Now;
            
            //Lägg till spelare i listan
            spelareLista.Add(spelare1);

            //Skapa andra spelare
            SpelarePoäng spelare2 = new SpelarePoäng();
            spelare2.namn = "fred";
            spelare2.poeng = 69;
            spelare2.datum = DateTime.Now;

            //Lägg till spelare i listan
            spelareLista.Add(spelare2);

            //Serialize options
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            //Gör om till json format
            string json = JsonSerializer.Serialize(spelareLista, options);

            //Skriv ut till json fil
            File.WriteAllText("highscore.json", json);
        }
    }   
}