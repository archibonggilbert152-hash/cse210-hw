using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveJournal(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetSaveFormat());
            }
        }
    }

    public void csv(string fileName) 
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            Entry entry = new Entry();
            entry._date = parts[0];
            entry._prompt = parts[1];
            entry._response = parts[2];
            _entries.Add(entry);
        }
    }
    // Helper to correctly split CSV lines
private string[] SplitCsvLine(string csvLine)
{
    List<string> fields = new List<string>();
    bool inQuotes = false;
    string field = "";

    foreach (char c in csvLine)
    {
        if (c == '"')
        {
            inQuotes = !inQuotes;
            continue;
        }

        if (c == ',' && !inQuotes)
        {
            fields.Add(field);
            field = "";
        }
        else
        {
            field += c;
        }
    }

    fields.Add(field);
    return fields.ToArray();
}
}
