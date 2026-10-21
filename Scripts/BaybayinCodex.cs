using System.Collections.Generic;

// Latin letter -> Baybayin glyph (Unicode Tagalog block).
// Use Noto Sans Tagalog
public static class BaybayinCodex
{
    public const string TileLetters = "ABDGHIKLMNPRSTUWY";

    static readonly Dictionary<char, string> Glyphs = new()
    {
        ['A'] = "\u1700", ['I'] = "\u1701", ['U'] = "\u1702",
        ['K'] = "\u1703", ['G'] = "\u1704", ['T'] = "\u1706",
        ['D'] = "\u1707", ['N'] = "\u1708", ['P'] = "\u1709",
        ['B'] = "\u170A", ['M'] = "\u170B", ['Y'] = "\u170C",
        ['L'] = "\u170E", ['W'] = "\u170F", ['S'] = "\u1710",
        ['H'] = "\u1711", ['R'] = "\u170D",
    };

    public static string GetGlyph(char letter) =>
        Glyphs.TryGetValue(char.ToUpper(letter), out var g) ? g : letter.ToString();
}
