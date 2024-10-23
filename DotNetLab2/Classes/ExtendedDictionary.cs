namespace lab2.Classes
{
    public class DictionaryEntry<T, U, V>
    {
        public T Key { get; set; }
        public U Value1 { get; set; }
        public V Value2 { get; set; }

        public DictionaryEntry(T key, U value1, V value2)
        {
            Key = key;
            Value1 = value1;    
            Value2 = value2;
        }
    }
    public class ExtendedDictionary<T, U, V>
    {
        public List<DictionaryEntry<T, U, V>> Entries { get; set; }
        public int Length { get; set; }

        public ExtendedDictionary()
        {
            Entries = new List<DictionaryEntry<T, U, V>>();
            Length = 0;
        }

        public DictionaryEntry<T, U, V> this [T key]
        {
            get => this.GetEntry(key);
            set
            {
                DictionaryEntry<T, U, V> entry = this.GetEntry(key);
                entry.Key = value.Key;
                entry.Value1 = value.Value1;
                entry.Value2 = value.Value2;
            }
        }

        public void AddEntry(T key, U value1, V value2)
        {
            Entries.Add(new DictionaryEntry<T, U, V>(key, value1, value2));
            Length = Entries.Count;
        }
        public bool DeleteByKey(T key)
        {
            DictionaryEntry<T,U,V> entry = Entries.Find(x => x.Key.Equals(key));
            if (entry != null)
            {
                Entries.Remove(entry);
                Length = Entries.Count;
                return true;
            }
            return false;
        }
        public bool ContainsEntry(T key)
        {
            DictionaryEntry<T, U, V> entry = Entries.Find(x => x.Key.Equals(key));
            return entry != null;
        }
        public bool ContainsEntry(U value1, V value2)
        {
            DictionaryEntry<T, U, V> entry = Entries.Find(x => x.Value1.Equals(value1) && x.Value2.Equals(value2));
            return entry != null;
        }
        public DictionaryEntry<T,U,V> GetEntry(T key)
        {
            DictionaryEntry<T, U, V> entry = Entries.Find(x => x.Key.Equals(key));
            return entry;
        }
        public IEnumerator<DictionaryEntry<T,U,V>> GetEnumerator() { return Entries.GetEnumerator(); }
    }
}

