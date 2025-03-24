using PrefixTree.Models.Abstract;

namespace PrefixTree.Models;

public static class PrefixNodeExtensions
{
    public static void ConsolePrint(this IPrefixNode node, int tab = 0)
    {
        foreach (var branch in node.Branches)
        {
            Console.WriteLine(new string(' ', tab) + branch.Key);
            ConsolePrint(branch.Value, tab + 1);
        }
    }

    public static void ConsolePrint(this IArrayPrefixNode node, int tab = 0)
    {
        for (int i = 0; i < node.Children.Length; i++)
        {
            if (node.Children[i] != null)
            {
                Console.WriteLine(new string(' ', tab) + (char)(i + 'a'));
                ConsolePrint(node.Children[i] ?? throw new ApplicationException(), tab + 1);
            }
        }
    }

    public static PrefixTreeStats CalculateStats(this IArrayPrefixNode node, PrefixTreeStats? stats = null)
    {
        stats ??= new PrefixTreeStats();

        if (node.IsWordEnd)
            stats.WordsAmount++;

        int branchesCount = 0;

        foreach (var child in node.Children)
        {
            if (child != null)
                branchesCount++;
        }

        if (branchesCount > 0)
        {
            stats.InnerNodesAmount++;
        }

        if (branchesCount > 1)
        {
            stats.BranchingAmount++;
            stats.BranchesCount += branchesCount;
        }


        foreach (var child in node.Children)
        {
            if (child != null)
                CalculateStats(child, stats);
        }

        return stats;
    }

    public static PrefixTreeStats CalculateStats(this IPrefixNode node, PrefixTreeStats? stats = null)
    {
        stats ??= new PrefixTreeStats();

        if (node.IsWordEnd)
            stats.WordsAmount++;

        if (node.Branches.Count > 0)
        {
            stats.InnerNodesAmount++;
        }

        if (node.Branches.Count > 1 && stats.SymbolsAmount != 0)
        {
            stats.BranchingAmount++;
            stats.BranchesCount += node.Branches.Count;
        }


        foreach (var branch in node.Branches)
        {
            CalculateStats(branch.Value, stats);
        }

        return stats;
    }
}