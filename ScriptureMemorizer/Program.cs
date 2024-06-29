using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string hardcodedScriptures = @"
John 3:16
For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.
Proverbs 3:5-6
Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.
";

        var scriptures = LoadScriptures(hardcodedScriptures);

        foreach (var scripture in scriptures)
        {
            scripture.Display();
            while (!scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nPress enter to hide words or type 'quit' to exit.");
                var input = Console.ReadLine();
                if (input == "quit")
                {
                    return;
                }
                scripture.HideRandomWords(3);
                Console.Clear();
                scripture.Display();
            }
        }
    }

    static List<Scripture> LoadScriptures(string scripturesText)
    {
        var scriptures = new List<Scripture>();
        var lines = scripturesText.Trim().Split('\n').Select(line => line.Trim()).ToArray();

        for (int i = 0; i < lines.Length; i += 2)
        {
            var reference = new Reference(lines[i]);
            var words = lines[i + 1].Split(' ').Select(word => new Word(word)).ToList();
            scriptures.Add(new Scripture(reference, words));
        }

        return scriptures;
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
    }

    public void HideRandomWords(int numberToHide)
    {
        var random = new Random();
        var wordsToHide = _words.Where(w => !w.IsHidden).OrderBy(x => random.Next()).Take(numberToHide);
        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.Display());
        Console.WriteLine(string.Join(" ", _words.Select(word => word.Display())));
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden);
    }
}

class Reference
{
    private string _reference;

    public Reference(string reference)
    {
        _reference = reference;
    }

    public string Display()
    {
        return _reference;
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string Display()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }

    public bool IsHidden
    {
        get { return _isHidden; }
    }
}
