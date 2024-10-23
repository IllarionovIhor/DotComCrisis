
namespace lab2.Extensions
{
    static class StringExtensions
    {
        public static string invert(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int charAppearances(this string str, char ch)
        {
            int count = 0;
            foreach (var elem in str)
            {
                if (elem == ch) count++;
            }
            return count;
        }
    }
}
