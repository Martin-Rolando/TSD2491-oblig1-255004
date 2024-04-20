using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TSD2491_oblig1_255004.Models
{
    public class BlazerMatchingGameModel
    {
        // Variabler for spillmodellen
        public int MatchesFound = 0;
        public string GameStatus { get; private set; }
        public string PlayerName { get; set; }        
        public int GamesPlayed { get; set; }

        // Statisk dictionary for å holde oversikt over spillere og antall spill
        private static Dictionary<string, int> playerGameCounts = new Dictionary<string, int>();

        // Metode for å hente høy score-liste
        public static List<KeyValuePair<string, int>> GetHighScoreList()
        {
            return playerGameCounts.ToList();
        }
        // Metode for å øke antall spill spilt
        public void IncrementGamesPlayed()
        {
            GamesPlayed++;

            // Sjekker om dictionary er null og oppdaterer spillertellinger
            if (playerGameCounts == null)
                playerGameCounts = new Dictionary<string, int>();

            if (PlayerName != null) 
            {
                if (!playerGameCounts.ContainsKey(PlayerName))
                {
                    playerGameCounts[PlayerName] = 1;
                }
                else
                {
                    playerGameCounts[PlayerName]++;
                }
            }
        }
        // Metode for å hente antall spill spilt for en spesifikk spiller
        public static int GetGamesPlayed(string playerName)
        {
            if (playerName != null && playerGameCounts.ContainsKey(playerName))
            {
                return playerGameCounts[playerName];
            }
            return 0;
        }
        // Konstruktør som setter opp spillet
        public BlazerMatchingGameModel()
        {
            SetUpGame();
        }
        // Listene med emojis
        static public List<string> animalEmoji = new List<string>
        {
        "🐴","🐴",
        "🐯","🐯",
        "🐮","🐮",
        "🐷","🐷",
        "🦒","🦒",
        "🐭","🐭",
        "🐼","🐼",
        "🐔","🐔",
        };

        static List<string> faceEmoji = new List<string>
        {
        "😁","😁",
        "😂","😂",
        "😒","😒",
        "😍","😍",
        "😎","😎",
        "😑","😑",
        "🤔","🤔",
        "😜","😜",
        };

        static List<string> sportEmoji = new List<string>
        {
        "🏋️‍","🏋️‍",
        "🤺","🤺",
        "🤼","🤼",
        "🏊","🏊",
        "🏃","🏃",
        "🏀","🏀",
        "🏈","🏈",
        "🤸","🤸",
        };

        static Random random = new Random();
        public List<string> shuffledEmoji = pickRandomEmoji();// Liste som inneholder tilfeldig valgte emojis

        // Metode for å velge tilfeldige emojis i starten av spillet, mellom de tre forskjellige emoji listene
        static List<string> pickRandomEmoji()
        {
            int randomIndex = random.Next(0, 3);
            switch (randomIndex)
            {
                case 0:
                    return animalEmoji = animalEmoji.OrderBy(items => random.Next()).ToList();
                case 1:
                    return faceEmoji = faceEmoji.OrderBy(items => random.Next()).ToList();
                case 2:
                    return sportEmoji = sportEmoji.OrderBy(items => random.Next()).ToList();
                default:
                    throw new Exception("Invalid random index");
            }
        }
        private void SetUpGame()
        {
            shuffledEmoji = pickRandomEmoji();// Velger tilfeldige emojis
            MatchesFound = 0;// Nullstiller antall matcher funnet
        }

        string lastEmojiFound = string.Empty;
        string lastDescription = string.Empty;

        // Metode som håndterer klikk på emojiene
        public void ButtonClick(string emoji, string emojiDescription)
        {
            if (MatchesFound == 0)
            {
                GameStatus = "Game Running";// Setter spillets status til "Game Running" hvis ingen matcher er funnet ennå
            }
            if (lastEmojiFound == string.Empty)
            {
                lastEmojiFound = emoji;// Lagrer siste emoji som ble klikket på
                lastDescription = emojiDescription;// Lagrer beskrivelsen av siste emoji som ble klikket på
            }
            else if ((lastEmojiFound == emoji) && (emojiDescription != lastDescription))
            {
                lastEmojiFound = string.Empty;// Nullstiller siste emoji funnet
                shuffledEmoji = shuffledEmoji
                    .Select(a => a.Replace(emoji, string.Empty))
                    .ToList();// Fjerner matchede emojis fra listen
                MatchesFound++;// Øker antall matcher funnet
                if (MatchesFound == 8)
                {
                    GameStatus = "Game Complete";// Setter spillets status til "Game Complete" når alle 8 matcher er funnet
                    IncrementGamesPlayed();// Øker antall spill spilt
                    SetUpGame();// Setter opp spillet på nytt
                }
            }
            else
            {
                lastEmojiFound = string.Empty;// Nullstiller siste emoji funnet hvis matchen ikke er gyldig
            }
        }
    }
}
