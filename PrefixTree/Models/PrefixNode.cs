using PrefixTree.Models.Abstract;

namespace PrefixTree.Models;

public class PrefixNode : IPrefixNode
{
    private readonly GoodEnoughDictionary<char, IPrefixNode> _branches = new();
    public bool IsWordEnd { get; private set; }
    public GoodEnoughDictionary<char, IPrefixNode> Branches => _branches;

    public void Insert(string word)
    {
         if (string.IsNullOrEmpty(word))
         {
             IsWordEnd = true;
             return;
         }

        foreach (var pair in _branches)
            if (pair.Key == word[0])
            {
                pair.Value.Insert(word[1..]);

                return;
            }


        var newNode = word.Length == 1 ? new PrefixNode { IsWordEnd = true } : new PrefixNode();
        _branches.Add(word[0], newNode);
        //Console.WriteLine(word + " " + IsWordEnd);

        if (word.Length > 1)
            newNode.Insert(word[1..]);
    }
}