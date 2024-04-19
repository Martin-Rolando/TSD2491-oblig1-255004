using Microsoft.AspNetCore.Mvc;

namespace TSD2491_oblig1_255004.Models
{
    public class BlazerMatchingGameModel
    {
        public int MatchesFound = 0;
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

        static Random random = new Random();
        public List<string> shuffledEmoji = pickRandomEmoji();

        private void SetUpGame()
        {
            shuffledEmoji = pickRandomEmoji();
            MatchesFound = 0;
        }
    }
}
