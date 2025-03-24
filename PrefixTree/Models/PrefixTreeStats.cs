namespace PrefixTree.Models;

public class PrefixTreeStats
{
    public int SymbolsAmount { get; set; }
    public int WordsAmount { get; set; }
    public int InnerNodesAmount { get; set; }
    public int BranchingAmount { get; set; }
    public int BranchesCount { get; set; }
    
    public double AverageBranchAmount
    {
        get
        {
            if (BranchingAmount == 0) return 0;
            return (double)BranchesCount / BranchingAmount;
        }
    }
}