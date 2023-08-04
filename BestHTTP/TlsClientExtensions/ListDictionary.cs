
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace BestHTTP.TlsClientExtensions
{
    public class ListDictionary : IDictionary<int, byte[]>
    {
        private IList<KeyValuePair<int, byte[]>> items= new List<KeyValuePair<int, byte[]>>();
        public byte[] this[int key] 
        {
            get 
            {
               var item= items.Where(x => x.Key == key).FirstOrDefault();
                if (item.Key != key)
                {
                    throw new KeyNotFoundException("not find key");
                }
                return item.Value;
            }
            set 
            {

                var item = items.Where(x => x.Key == key).FirstOrDefault();
                items.Remove(item);
                items.Add(new KeyValuePair<int, byte[]>(key,value));

            } 
        }

        public ICollection<int> Keys => items.Select(x => x.Key).ToList();

        public ICollection<byte[]> Values => items.Select(x => x.Value).ToList();

        public int Count => items.Count;

        public bool IsReadOnly => items.IsReadOnly;

        public void Add(int key, byte[] value)
        {
            var item=items.Where(x=>x.Key==key).FirstOrDefault();
            this.Remove(item);
            items.Add(new KeyValuePair<int, byte[]>(key,value));
        }

        public void Add(KeyValuePair<int, byte[]> item)
        {
            var oldItem = items.Where(x => x.Key == item.Key).FirstOrDefault();
            this.Remove(oldItem);
            items.Add(item);
 
        }

        public void Clear()
        {
             items.Clear();
        }

        public bool Contains(KeyValuePair<int, byte[]> item)
        {
            return items.Contains(item);
        }

        public bool ContainsKey(int key)
        {
            return items.Any(x => x.Key == key);
        }

        public void CopyTo(KeyValuePair<int, byte[]>[] array, int arrayIndex)
        {
            items.CopyTo(array,arrayIndex);
        }

        public IEnumerator<KeyValuePair<int, byte[]>> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public bool Remove(int key)
        {
            var item = items.Where(x => x.Key == key).FirstOrDefault();
            if (item.Key == key)
            {
                return items.Remove(item);
            }
            return true;
        }

        public bool Remove(KeyValuePair<int, byte[]> item)
        {
            return items.Remove(item);
        }

        public bool TryGetValue(int key, out byte[] value)
        {
           var item= items.Where(x => x.Key == key).FirstOrDefault();
            if (item.Key == key)
            {
                value=item.Value;
                return true;
            }
            value= null;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
        public void Shuffle()
        {
            for (int i = items.Count-1;i>0; i--)
            {
                var rand = new Random((Environment.TickCount ^ System.Guid.NewGuid().GetHashCode()));
                var index=rand.Next() % i;
                (items[i], items[index]) = (items[index], items[i]);
            }
        }
    }
}
