// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using PrefixTree.Models;

void GenerateWords(int symbolsAmount)
{
    int minLength = 10, maxLength = 35;
    var random = new Random();
    using var writer = new StreamWriter($"output{symbolsAmount}.txt", false);

    while (symbolsAmount > 0)
    {
        int length = (symbolsAmount <= maxLength) ? symbolsAmount : random.Next(minLength, maxLength);

        for (int i = 0; i < length; i++)
            writer.Write((char)random.Next(97, 123));

        writer.WriteLine();
        symbolsAmount -= length;
    }
}

void Test(int symbolsAmount)
{
    var node = new PrefixNode();
    //var node = new ArrayPrefixNode();

    using var reader = new StreamReader($"output{symbolsAmount}.txt");
    long totalTime = 0;
    Stopwatch stopwatch = new Stopwatch();
    var stats = new PrefixTreeStats();

    while (!reader.EndOfStream)
    {
        string? line = reader.ReadLine();

        if (!string.IsNullOrEmpty(line))
        {
            stats.SymbolsAmount += line.Length;
        
            stopwatch.Start();
            node.Insert(line);
            stopwatch.Stop();
        
            //totalTime += stopwatch.ElapsedMilliseconds;
            //stopwatch.Reset();
        }
    }
    Console.WriteLine($"\n ВРЕМЯ: {stopwatch.ElapsedMilliseconds} | СИМВОЛЫ: {stats.SymbolsAmount}\n");
//node.ConsolePrint();
    stats = node.CalculateStats(stats);
    Process proc = Process.GetCurrentProcess();
    Console.WriteLine($" Память: {(double)proc.PrivateMemorySize64 / 8 / 1024 / 1024 } MB");
    Console.WriteLine($" Количество слов: {stats.WordsAmount}");
    Console.WriteLine($" Количество ветвлений: {stats.BranchingAmount}");
    Console.WriteLine($" Количество внутренних узлов: {stats.InnerNodesAmount}");
    Console.WriteLine($" Среднее кол-во веток в ветвлениях: {stats.AverageBranchAmount}");
}


//GenerateWords(100000);
Test(100000);