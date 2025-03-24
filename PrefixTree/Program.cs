// See https://aka.ms/new-console-template for more information

using PrefixTree.Models;
using PrefixTree.Models.Abstract;

void FirstQuest()
{
    IArrayPrefixNode node = new ArrayPrefixNode();
    
    List<string> words = new List<string>()
    {
        "abc",
        "abd",
        "abdo",
        "abdc",
        "abdp",
        "ab"
    };
    
    foreach (var word in words)
    {
        node.Insert(word);
    }

    node.ConsolePrint();
    var stats = node.CalculateStats();
    stats.SymbolsAmount = words.Sum(word => word.Length);

    Console.WriteLine($"Количество символов: {stats.SymbolsAmount}");
    Console.WriteLine($"Количество слов: {stats.WordsAmount}");
    Console.WriteLine($"Количество ветвлений: {stats.BranchingAmount}");
    Console.WriteLine($"Количество внутренних узлов: {stats.InnerNodesAmount}");
    Console.WriteLine($"Среднее кол-во веток в ветвлениях: {stats.AverageBranchAmount}");
}

void SecondQuest()
{
    IPrefixNode node = new PrefixNode();

    List<string> words = new List<string>()
    {
        "abc",
        "abd",
        "abdo",
        "abdc",
        "abdp",
        "ab"
    };

    foreach (var word in words)
    {
        node.Insert(word);
    }

    node.ConsolePrint();
    var stats = node.CalculateStats();
    stats.SymbolsAmount = words.Sum(word => word.Length);

    Console.WriteLine($"Количество символов: {stats.SymbolsAmount}");
    Console.WriteLine($"Количество слов: {stats.WordsAmount}");
    Console.WriteLine($"Количество ветвлений: {stats.BranchingAmount}");
    Console.WriteLine($"Количество внутренних узлов: {stats.InnerNodesAmount}");
    Console.WriteLine($"Среднее кол-во веток в ветвлениях: {stats.AverageBranchAmount}");

}



FirstQuest();


