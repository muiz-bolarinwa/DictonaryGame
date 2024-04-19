using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryGame
{
  

        public static class Logging
        {
            private const string logFilePath = "player_activity.log";

            public static void LogPlayerActivity(string playerName)
            {
                try
                {
                    using (StreamWriter writer = File.AppendText(logFilePath))
                    {
                        writer.WriteLine($"{playerName} just was the word we just played");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while logging player activity: {ex.Message}");
                }
            }
        }
    }


