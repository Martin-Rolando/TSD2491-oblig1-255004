using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TSD2491_oblig1_255004.Models
{
    public class BlazerMatchingGameModel
    {
        public int MatchesFound = 0;
        public string GameStatus { get; private set; }
        public BlazerMatchingGameModel()
        {
            SetUpGame();
        }

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
        public List<string> shuffledEmoji = pickRandomEmoji();

        private void SetUpGame()
        {
            shuffledEmoji = pickRandomEmoji();
            MatchesFound = 0;
        }

        string lastAnimalFound = string.Empty;
        string lastDescription = string.Empty;

        public void ButtonClick(string animal, string animalDescription)
        {
            if (MatchesFound == 0)
            {
                GameStatus = "Game Running";
            }
            if (lastAnimalFound == string.Empty)
            {
                lastAnimalFound = animal;
                lastDescription = animalDescription;
            }
            else if ((lastAnimalFound == animal) && (animalDescription != lastDescription))
            {
                lastAnimalFound = string.Empty;
                shuffledEmoji = shuffledEmoji
                    .Select(a => a.Replace(animal, string.Empty))
                    .ToList();
                MatchesFound++;
                if (MatchesFound == 8)
                {
                    GameStatus = "Game Complete";
                    IncrementGamesPlayed();
                    SetUpGame();
                }
            }
            else
            {
                lastAnimalFound = string.Empty;
            }
        }
    }
}
