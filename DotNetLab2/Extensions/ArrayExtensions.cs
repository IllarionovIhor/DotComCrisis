namespace lab2.Extensions
{
    static class ArrayExtensions
    {
        public static int ElementAppearances<T>(this T[] arr, T elem) where T : struct
        {
            int count = 0;
            foreach (var item in arr)
            {
                if (item.Equals(elem)) count++;
            }
            return count;
        }

        public static T[] NoRepeat<T>(this T[] arr) where T : struct
        {
            List<T> res = new List<T>();
            foreach (var item in arr)
            {
                if (!res.Contains(item)) res.Add(item);
            }
            return res.ToArray();
        }

        public static string Print<T>(this T[] arr) where T : struct
        {
            string text = "[";
            for(int i = 0; i < arr.Length; i++)
            {
                text+=arr[i].ToString();
                if (i < arr.Length - 1) text += ",";
            }
            return text+"]";
        }

        public static bool Contains<T>(this T[] arr, T elem) where T : struct
        {
            foreach(var item in arr)
            {
                if (item.Equals(elem)) return true;
            }
            return false;
        }
    }
}
