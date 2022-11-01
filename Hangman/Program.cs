// Hangman example in C# (.NET 6 console application)
using System.Text.RegularExpressions;

// List of words that can be used for the game.
var words = new[]
{
    "coffee",
    "banana",
    "airport",
    "cryptography",
    "computer",
};

// Pick a random word from the array.
var chosenWord = words[new Random().Next(0, words.Length - 1)];

// Regex with valid characters (single character between a and z).
var validCharacters = new Regex("^[a-z]$");

// Number of lives the player has before loosing.
var lives = 5;

// Empty array that will contain all the letters submitted by the player.
var letters = new List<string>();

// As long as there are lives left, the loop continues
while (lives != 0)
{
    // Counter of characters left to guess.
    var charactersLeft = 0;
    
    // Loop through all the characters of the word
    foreach (var character in chosenWord)
    {
        // Make the letter a string (easier for conditions).
        var letter = character.ToString();
        
        // If the letter in the loop is in our array of used letters, we write
        // the letter, otherwise we show an underscore (as a letter left to
        // guess).
        if (letters.Contains(letter))
        {
            Console.Write(letter);
        }
        else
        {
            Console.Write("_");
            
            // We also increase the count of letters left, used to track whether
            // the game is finished or not.
            charactersLeft++;
        }
    }
    Console.WriteLine(string.Empty);

    // If there are no characters left, the game is over and we can break out
    // of the loop.
    if (charactersLeft == 0)
    {
        break;
    }

    Console.Write("Type in a letter: ");
    
    // Read the input character and transform it to lowercase to make it easier
    // to compare to already used letters (we could fall into the scenario of a
    // player inputting a capitalized letter that has already been submitted). 
    var key = Console.ReadKey().Key.ToString().ToLower();
    Console.WriteLine(string.Empty);

    // Using the declared Regex above, we check if the the submitted character
    // is valid or not.
    if (!validCharacters.IsMatch(key))
    {
        // If the character is invalid, we loop back to the beginning using the
        // "continue" statement and let the user know of the error.
        Console.WriteLine($"The letter {key} is invalid. Try again.");
        continue;
    }

    // Is the letter already in our array of used letters? 
    if (letters.Contains(key))
    {
        // Only show a message to the user that the letter has already been
        // used. We don't want to do anything else (for example storing it)
        // with that.
        Console.WriteLine("You already entered this letter!");
        continue;
    }

    // If the letter has not already been used, we add it to our array of
    // letters.
    letters.Add(key);

    // If the chosen word doesn't contain the given letter, we reduce the
    // number of lives left by one.
    if (!chosenWord.Contains(key))
    {
        lives--;

        // If all the lives ran out, there's no point saying how many lives
        // are left as the loose message will be shown.
        if (lives > 0)
        {
            // Here, a ternary is used in the string to either how a pluralized
            // version of "try" or the singular one, depending on how many
            // lives are left.
            Console.WriteLine($"The letter {key} is not in the word. You have {lives} {(lives == 1 ? "try" : "tries")} left.");
        }
    }
}

// If the user has lives left, we display the win message, otherwise we don't
if (lives > 0)
{
    // This uses a ternary to pluralize the word lives unless there only one
    // life left.
    Console.WriteLine($"You won with {lives} {(lives == 1 ? "life" : "lives")} left!");
}
else
{
    Console.WriteLine($"You lost! The word was {chosenWord}.");   
}