namespace PrefixTree.Models.Abstract;

public interface IArrayPrefixNode
{
    public IArrayPrefixNode?[] Children { get; }
    public bool IsWordEnd { get; }
    public void Insert(string word);
} 