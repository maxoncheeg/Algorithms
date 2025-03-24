namespace PrefixTree.Models.Abstract;

public interface IPrefixNode
{
    public bool IsWordEnd { get; }
    public GoodEnoughDictionary<char, IPrefixNode> Branches { get; }
    public void Insert(string word);
}