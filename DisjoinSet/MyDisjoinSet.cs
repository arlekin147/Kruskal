using System.Collections.Generic;

namespace DisjoinSet
{
    public class MyDisjoinSet
    {
        private Dictionary<int, int> _sets = new Dictionary<int, int>();

        public MyDisjoinSet() {}

        public MyDisjoinSet(IEnumerable<int> elements)
        {
            foreach(var el in elements)
            {
                _sets.Add(el, el);
            }
        }

        public void Add(int element)
        {
            _sets.Add(element, element);
        }

        public int Find(int element)
        {
            if( element == _sets[element]) return element;

            var newRepresenter = Find(_sets[element]);
            return _sets[element] = newRepresenter;
        }

        public void Union(int first, int second)
        {
            _sets[second] = first;
        }

        public MyDisjoinSet Copy()
        {
            var result = new MyDisjoinSet();
            
            foreach(var el in this)
            {
                result.Add(el.Key, el.Value);
            }

            return result;
        }

        public IEnumerator<KeyValuePair<int, int>> GetEnumerator()
        {
            return _sets.GetEnumerator();
        }

        public bool Contains(int element)
        {
            return _sets.ContainsKey(element);
        }

        private void Add(int key, int value)
        {
            _sets.Add(key, value);
        }
    }
}