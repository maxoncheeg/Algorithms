using PrefixTree.Models.Abstract;

namespace PrefixTree.Models;

public class ArrayPrefixNode : IArrayPrefixNode
{
    private const int N = 26;
    private const int Offset = 97;

    public IArrayPrefixNode?[] Children { get; } = new IArrayPrefixNode?[N];
    public bool IsWordEnd { get; private set; } = false;

    public void Insert(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            IsWordEnd = true;
            return;
        }

        int index = word[0] - Offset;
        Children[index] ??= word.Length == 1 ? new ArrayPrefixNode { IsWordEnd = true } : new ArrayPrefixNode();
        Children[index]!.Insert(word[1..]);
    }
}