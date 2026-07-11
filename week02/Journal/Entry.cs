using System;

// *****************************************************
// Class: Entry
//
// Responsibility:
// This class represents a single journal entry.
// It stores the date, the prompt presented to the user,
// the user's response, and an additional mood field
// (added as a creativity enhancement).
// *****************************************************

public class Entry
{
    // Stores the date the journal entry was created.
    public string _date;

    // Stores the prompt shown to the user.
    public string _promptText;

    // Stores the user's response to the prompt.
    public string _entryText;

    // Creativity enhancement:
    // Stores the user's mood for the day.
    public string _mood;

    // *************************************************
    // Method: Display
    //
    // Responsibility:
    // Displays all the information for a journal entry
    // in a clear and readable format.
    // *************************************************
    public void Display()
    {
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Date   : {_date}");
        Console.WriteLine($"Mood   : {_mood}");
        Console.WriteLine($"Prompt : {_promptText}");
        Console.WriteLine($"Entry  : {_entryText}");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine();
    }
}