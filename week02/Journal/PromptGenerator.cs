using System;
using System.Collections.Generic;

// *****************************************************
// Class: PromptGenerator
//
// Responsibility:
// This class stores a list of journal prompts and
// returns one random prompt whenever it is requested.
// *****************************************************

public class PromptGenerator
{
    // Stores all the prompts that can be displayed
    // to the user.
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What challenge did I overcome today?"
    };

    // Random object used to select a random prompt.
    private Random _random = new Random();

    // *************************************************
    // Method: GetRandomPrompt
    //
    // Responsibility:
    // Returns one random prompt from the list.
    // *************************************************
    public string GetRandomPrompt()
    {
        // Generate a random index between 0 and the
        // total number of prompts minus one.
        int index = _random.Next(_prompts.Count);

        // Return the prompt located at the random index.
        return _prompts[index];
    }
}