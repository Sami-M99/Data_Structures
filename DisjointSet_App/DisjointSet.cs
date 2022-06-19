using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DisjointSet_App
{
    public class DisjointSet<T> : IEnumerable<T>
    {
        private Dictionary<T, DisjointSetNode<T>> set
            = new Dictionary<T, DisjointSetNode<T>>();

        public int Count { get; private set; }

        public DisjointSet()
        {

        }

        public DisjointSet(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                MakeSet(item);
            }
        }

        public void MakeSet(T value)
        {
            if (set.ContainsKey(value))
                throw new Exception("The Value nas aleardy been defined.");

            var newSet = new DisjointSetNode<T>(value, 0);  // Rank{X} = 0
            newSet.Parent = newSet;   // P{x} = x
            set.Add(value, newSet);
            Count++;
        }

        public T FindSet(T value)
        {
            // يشوف اذا القيمة مو موجوده يطلع خطا
            if (!set.ContainsKey(value))
                throw new Exception("The value is not in this set..");

            return findSet(set[value]).Value;
        }

        private DisjointSetNode<T> findSet(DisjointSetNode<T> node)
        {
            var parent = node.Parent;
            // هذا الشرط يشوف هل هو الجذر ام لا , لان الجذر يمثل نفسه وابو نفسه
            if (node != parent)
            {
                node.Parent = findSet(node.Parent);
                return node.Parent;
            }
            return parent;

        }

        public void Union(T valueA, T valueB)
        {
            if (valueA == null || valueB == null)
                throw new ArgumentNullException();

            var rootA = FindSet(valueA);
            var rootB = FindSet(valueB);

            // اذا كان الممثل لهن واحد يعني مترابطات نخرج من دون ما نسوي شي
            if (rootA.Equals(rootB))
                return;

            var nodeA = set[rootA];
            var nodeB = set[rootB];

            if (nodeA.Rank == nodeB.Rank)
            {
                nodeB.Parent = nodeA;
                nodeA.Rank++;
            }
            else
            {
                // الرقم الكبر يكون الأب
                if (nodeA.Rank < nodeB.Rank)
                    nodeA.Parent = nodeB;
                else
                    nodeB.Parent = nodeA;
            }


        }

        public IEnumerator<T> GetEnumerator()
        {
            // foreach 
            return set.Values.Select(x => x.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
