using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryGame
{
    internal class Lifes
    {
        private int totalLives;
        private int currentLives;

        public Lifes(int initialLives)
        {
            totalLives = initialLives;
            currentLives = initialLives;
        }

        public void IncorrectAction()
        {
            // Decrease the current lives by 1 for an incorrect action
            currentLives--;

           
        }

        public int GetCurrentLives()
        {
            return currentLives;
        }

        public void ResetLives()
        {
            // Reset the current lives to the total number of lives
            currentLives = totalLives;
            
        }
    }
}
