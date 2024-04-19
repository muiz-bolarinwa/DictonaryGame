using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DictonaryGame
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> dictionary;
        private Random random;
        private Lifes life = new Lifes(3);
        static string currentDirectory = Directory.GetCurrentDirectory();
        string relativePath = Path.Combine(currentDirectory,"dictionary.json");

        public Form1()
        {
            InitializeComponent();
            InitializeDictionary();
            checkLives();
            StartNewGame();
            richTextBox1.Text = "Click the start button to start";
            button2.Text = "Exit";
        }

        private void InitializeDictionary()
        {
            // Read the JSON file containing the dictionary data
            string jsonFilePath = "./dictionary.json"; // Change this to the path of your JSON file
            string jsonContent = File.ReadAllText(relativePath);
            
            // Deserialize the JSON content into a Dictionary<string, string>
            dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckGuess();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void CheckGuess()
        {
            string guessedWord = richTextBox2.Text.ToLower();
            Logging.LogPlayerActivity(guessedWord);
            if (dictionary.ContainsKey(guessedWord))
            {
                MessageBox.Show("Correct guess! Well done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartGame();
            }
            else
            {
                MessageBox.Show("Incorrect guess. Try again!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                life.IncorrectAction();
                checkLives();
            }
        }

        private void checkLives()
        {
            label3.Text = life.GetCurrentLives().ToString();
            lifesDone();
        }

        private void lifesDone()
        {
            if (life.GetCurrentLives() <= 0)
            {
                MessageBox.Show("All lifes done, you loose", "Failure", MessageBoxButtons.OK);
                GameEndded();
            }
        }

        private void GameEndded()
        {
            richTextBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void StartNewGame()
        {
            richTextBox2.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            life.ResetLives();
        }


        private void StartGame()
        {
            if (dictionary.Count == 0)
            {
                MessageBox.Show("Dictionary is empty. Please add words before starting the game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            StartNewGame();
            label3.Text = life.GetCurrentLives().ToString();
            Random random = new Random();
            // Get a random word from the dictionary
            int randomIndex = random.Next(dictionary.Count);

            // Get the key-value pair at the random index
            KeyValuePair<string, string> randomEntry = dictionary.ElementAt(randomIndex);

           
          
                string definition = randomEntry.Value;

                // Display the definition and clear the previous guess
                richTextBox1.Text = definition;
                Console.WriteLine(definition);
                richTextBox2.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               CheckGuess();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.Tab)
            {
                StartGame();
            }
        }

        private void button2_TabStopChanged(object sender, EventArgs e)
        {

        }
    }
}
