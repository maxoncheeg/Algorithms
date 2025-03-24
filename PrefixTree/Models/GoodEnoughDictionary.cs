using System.Collections;
using PrefixTree.Models.Abstract;

namespace PrefixTree.Models;

public class GoodEnoughDictionary<TK, TV> : IEnumerable<KeyValuePair<TK, TV>>
{
    private readonly List<KeyValuePair<TK, TV>> _items = new();

    public int Count => _items.Count;

    public void Add(TK key, TV value)
    {
        _items.Add(new KeyValuePair<TK, TV>(key, value));
    }

    public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}