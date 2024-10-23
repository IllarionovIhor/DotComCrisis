using static lab2.Extensions.StringExtensions;
using static lab2.Extensions.ArrayExtensions;
using lab2.Classes;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("************ Завдання №1 ************");
Console.Write($"Введіть рядок: ");
string text = Console.ReadLine();
Console.WriteLine($" >> Рядок: {text}");
Console.WriteLine($" >> Інвертування рядку: {text.invert()}"); 
Console.WriteLine($" >> \'а\' зустрічається " +
    $"{text.charAppearances('а')} рази\n");

int[] array = new int[] {1,4,5,1,7,3,73,2,70, 1, 2, 3, 4, 5, 1, 6};
Console.WriteLine($" >> Масив типу int: {array.Print()}");
Console.WriteLine($" >> Число 1 зустрічається" +
    $" {array.ElementAppearances(1)} раз(и)");
Console.WriteLine($" >> Масив лише з унікальними значеннями:" +
    $" {array.NoRepeat().Print()}");

Console.WriteLine("\n\n************Завдання №2 ************");

ExtendedDictionary<string,double,bool> dict = new ExtendedDictionary<string,double,bool>();
dict.AddEntry("Index1", 3.14, true);
dict.AddEntry("Index2", 1, false);
dict.AddEntry("Index3", 4.2, true);

Console.WriteLine(" >> Створений словник (T - string, U - double, V - bool):");
foreach(var item in dict)
{
    Console.WriteLine($"   {{Key: {item.Key}, Value1: {item.Value1}, Value2: {item.Value2}}}");
}
Console.WriteLine($" >> Довжина словнику: {dict.Length}");
Console.WriteLine($"\n >> Наявність запису з ключем \"Index1\": {dict.ContainsEntry("Index1")}");
Console.WriteLine($" >> Наявність запису з ключем \"Key34\": {dict.ContainsEntry("Key34")}");
Console.WriteLine($" >> Наявність запису з значеннями 1 і false: {dict.ContainsEntry(1,false)}");
Console.WriteLine($" >> Значення запису за допомогою індексації \"Index3\": {dict["Index3"].Value1}");

if(dict.DeleteByKey("Index1"))
{
    Console.WriteLine("\n >> Оновлений зміст словнику \"Index1\":");
    foreach (var item in dict)
    {
        Console.WriteLine($"   {{Key: {item.Key}, Value1: {item.Value1}, Value2: {item.Value2}}}");
    }
}