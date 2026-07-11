using System;

/*
 * *****************************************************
 * Program: Journal Program
 *
 * Author: Michael Lopez
 *
 * Description:
 * This program allows users to keep a personal journal.
 * Users can:
 *   - Write a new journal entry.
 *   - Display all journal entries.
 *   - Save entries to a file.
 *   - Load entries from a file.
 *
 * Creativity Enhancement:
 *   1. Each journal entry stores the user's mood.
 *   2. The program displays the number of entries loaded
 *      after reading a journal file.
 * *****************************************************
 */

class Program
{
    static void Main(string[] args)
    {
        // Create the Journal object that stores all entries.
        Journal journal = new Journal();

        // Create the PromptGenerator object that provides
        // a random prompt whenever the user writes an entry.
        PromptGenerator promptGenerator = new PromptGenerator();

        // Variable that stores the user's menu choice.
        int choice = 0;

        // Continue displaying the menu until the user quits.
        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("           Journal Program");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Load Journal");
            Console.WriteLine("4. Save Journal");
            Console.WriteLine("5. Quit");
            Console.WriteLine();

            Console.Write("Select an option (1-5): ");

            // Validate the user's input.
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                // *****************************************
                // Option 1 - Write a new journal entry.
                // *****************************************
                case 1:

                    // Get a random prompt.
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine();
                    Console.WriteLine($"Prompt:");
                    Console.WriteLine($"{prompt}");
                    Console.WriteLine();

                    // Ask the user to answer the prompt.
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    // Creativity enhancement.
                    Console.Write("How are you feeling today? ");
                    string mood = Console.ReadLine();

                    // Create a new journal entry.
                    Entry newEntry = new Entry();

                    // Save today's date.
                    newEntry._date = DateTime.Now.ToShortDateString();

                    // Store the prompt.
                    newEntry._promptText = prompt;

                    // Store the user's response.
                    newEntry._entryText = response;

                    // Store the user's mood.
                    newEntry._mood = mood;

                    // Add the entry to the journal.
                    journal.AddEntry(newEntry);

                    Console.WriteLine();
                    Console.WriteLine("Journal entry added successfully!");

                    break;

                // *****************************************
                // Option 2 - Display all journal entries.
                // *****************************************
                case 2:

                    journal.DisplayAll();

                    break;

                // *****************************************
                // Option 3 - Load a journal file.
                // *****************************************
                case 3:

                    Console.Write("Enter the filename to load: ");

                    string loadFile = Console.ReadLine();

                    if (System.IO.File.Exists(loadFile))
                    {
                        journal.LoadFromFile(loadFile);
                    }
                    else
                    {
                        Console.WriteLine("The specified file does not exist.");
                    }

                    break;

                // *****************************************
                // Option 4 - Save the journal.
                // *****************************************
                case 4:

                    Console.Write("Enter the filename to save: ");

                    string saveFile = Console.ReadLine();

                    journal.SaveToFile(saveFile);

                    break;

                // *****************************************
                // Option 5 - Exit the program.
                // *****************************************
                case 5:

                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Journal Program.");
                    Console.WriteLine("Goodbye!");

                    break;

                // *****************************************
                // Invalid menu option.
                // *****************************************
                default:

                    Console.WriteLine("Please choose a number between 1 and 5.");

                    break;
            }
        }
    }
}