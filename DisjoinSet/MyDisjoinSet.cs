using System.Collections.Generic;

namespace DisjoinSet
{
    public class MyDisjoinSet
    {
        private Dictionary<int, int> _sets = new Dictionary<int, int>();

        public MyDisjoinSet(IEnumerable<int> elements)
        {
            foreach(var el in elements)
            {
                _sets.Add(el, el);
            }
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

        public IEnumerator<KeyValuePair<int, int>> GetEnumerator()
        {
            return _sets.GetEnumerator();
        }
    }
}