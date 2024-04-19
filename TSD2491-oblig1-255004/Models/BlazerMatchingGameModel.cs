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
            shuffledEmoji = pickRandomEmoji();
            MatchesFound = 0;
        }

        string lastEmojiFound = string.Empty;
        string lastDescription = string.Empty;

        public void ButtonClick(string emoji, string emojiDescription)
        {
            if (MatchesFound == 0)
            {
                GameStatus = "Game Running";
            }
            if (lastEmojiFound == string.Empty)
            {
                lastEmojiFound = emoji;
                lastDescription = emojiDescription;
            }
            else if ((lastEmojiFound == emoji) && (emojiDescription != lastDescription))
            {
                lastEmojiFound = string.Empty;
                shuffledEmoji = shuffledEmoji
                    .Select(a => a.Replace(emoji, string.Empty))
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
                lastEmojiFound = string.Empty;
            }
        }
    }
}
