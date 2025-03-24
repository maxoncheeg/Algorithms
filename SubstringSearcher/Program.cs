// See https://aka.ms/new-console-template for more information


using SubstringSearcher.Extensions;

string initialText1 =
        "eytvygrpkshuoguutvjoxzreiknzvmkwtjjdymxvuspywalaglibklcbennuhevthdjpbjhxlpodeevcmjfvxgmmfvdwhhxildjm", //100
    initialSearch1 = "pbdfkrsbhx"
    ;


int multiplier = 100000;
Random random = new();

//Console.WriteLine($"TEXT: {text}");
//Console.WriteLine($"SEARCH STRING: {search}");

var watch = new System.Diagnostics.Stopwatch();
IList<int> result = new List<int>();
IList<int> result1 = new List<int>();


var text = initialText1;
var search = initialSearch1;
// text = text.Multiply(multiplier);
// search = search.Multiply(multiplier);

text = search = "";
int x = random.Next(1, multiplier);
int y = random.Next(1, x);
for (int i = 0; i < x; i++)
{
    text += (char)random.Next(48, 123);
    if (i < y)
    {
        search += (char)random.Next(48, 123);
    }
}


// watch.Start();
// result = text.Find(search);
// watch.Stop();

var findTime = watch.ElapsedMilliseconds;

watch.Start();
result1 = text.FindSlow(search);
watch.Stop();

// if (result.Count != result1.Count)
// {
//     Console.WriteLine("FALSE FALSE FALSE");
//     return;
// }

Console.WriteLine($"mult: {multiplier} | find: {findTime} | findSlow: {watch.ElapsedMilliseconds}");

// for (int i = 0; i < result.Count; i++)
// {
//     if (result[i] != result1[i])
//     {
//         Console.WriteLine("ERROR: FALSE FALSE FALSE");
//         break;
//     }
// }


//Console.WriteLine("\nTIME: " + watch.ElapsedMilliseconds);