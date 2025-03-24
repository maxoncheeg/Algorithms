namespace SubstringSearcher.Extensions;

public static class StringExtensions
{
    private const char SpecialSeparatorCharacter = '\0';

    // Поиск с помощью префикс-функции
    public static IList<int> Find(this string @this, string search)
    {
        var fullString = $"{search}{SpecialSeparatorCharacter}{@this}";
        var prefixFunction = fullString.GetPrefixFunction();
        IList<int> result = [];
        
        for (int i = search.Length + 1; i < fullString.Length; i++)
            if(prefixFunction[i] == search.Length)
                result.Add(i - search.Length * 2);
        
        return result;
    }
    
    // Наивный алгоритм поиска
    public static IList<int> FindSlow(this string @this, string search)
    {
        List<int> result = [];
        
        //иииии
        for (int i = 0; i < @this.Length - search.Length + 1; i++)
        {
            //a
            for (int j = 0; j < search.Length; j++)
            {
                if (i + j >= @this.Length) break;
                if (@this[i + j] != search[j])
                    break;
                
                if(j + 1 == search.Length)
                    result.Add(i);
            }
        }
        
        return result;
    }

    // Получение префикс функции
    public static IList<int> GetPrefixFunction(this string @this)
    {
        int k = 0;
        IList<int> function = [0];

        for (int i = 1; i < @this.Length; i++)
        {
            while (@this[i] != @this[k] && k != 0)
                k = function[k - 1];

            if (@this[i] == @this[k])
                ++k;

            function.Add(k);
        }

        return function;
    }

    public static string Multiply(this string @this, int multiplier)
    {
        var result = string.Empty;
        for (var i = 0; i < multiplier; i++)
            result += @this;
        return result;
    }
}