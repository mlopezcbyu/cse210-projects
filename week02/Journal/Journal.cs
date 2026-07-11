using System;
using System.Collections.Generic;
using System.IO;

// *****************************************************
// Class: Journal
//
// Responsibility:
// This class manages the journal entries.
// It stores all entries in a list and provides methods
// to add, display, save, and load journal entries.
// *****************************************************

public class Journal
{
    // Stores all journal entries.
    public List<Entry> _entries = new List<Entry>();

    // *************************************************
    // Method: AddEntry
    //
    // Responsibility:
    // Adds a new journal entry to the list.
    // *************************************************
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // *************************************************
    // Method: DisplayAll
    //
    // Responsibility:
    // Displays every journal entry stored in the list.
    // *************************************************
    public void DisplayAll()
    {
        // Check whether the journal contains any entries.
        if (_entries.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("The journal is empty.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Journal Entries");
        Console.WriteLine("=========================");

        // Display each entry.
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // *************************************************
    // Method: SaveToFile
    //
    // Responsibility:
    // Saves every journal entry to a text file.
    // *************************************************
    public void SaveToFile(string fileName)
    {
        // Create or overwrite the file.
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            // Write each journal entry on its own line.
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(
                    $"{entry._date}|{entry._mood}|{entry._promptText}|{entry._entryText}"
                );
            }
        }

        Console.WriteLine();
        Console.WriteLine("Journal saved successfully!");
    }

    // *************************************************
    // Method: LoadFromFile
    //
    // Responsibility:
    // Loads journal entries from a text file.
    // Any entries currently in memory are replaced.
    // *************************************************
    public void LoadFromFile(string fileName)
    {
        // Remove any entries already stored.
        _entries.Clear();

        // Read every line from the file.
        string[] lines = File.ReadAllLines(fileName);

        // Process each line.
        foreach (string line in lines)
        {
            // Split the line into separate values.
            string[] parts = line.Split("|");

            // Create a new Entry object.
            Entry entry = new Entry();

            // Assign each value to the appropriate field.
            entry._date = parts[0];
            entry._mood = parts[1];
            entry._promptText = parts[2];
            entry._entryText = parts[3];

            // Add the entry to the journal.
            _entries.Add(entry);
        }

        Console.WriteLine();
        Console.WriteLine($"{_entries.Count} journal entries loaded successfully!");
    }
}