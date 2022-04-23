using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3U1P9_Graf
{
    internal class Graph<T>
    {
        public delegate void ExternalProcessor(T item);
        public delegate void GraphEventHandler<T>(object source, GraphEventArgs<T> geargs);

        public class GraphEventArgs<T>: EventArgs
        {
            public T A { get; set; }
            public T B { get; set; }
            public GraphEventArgs(T a, T b)
            {
                A = a;
                B = b;
            }
        }

        public event GraphEventHandler<T> EdgeAdded;

        List<T> data;
        List<List<T>> neighbors;

        public Graph()
        {
            data = new List<T>();
            neighbors = new List<List<T>>();
        }

        public void AddNode(T node)
        {
            data.Add(node);
            neighbors.Add(new List<T>());
        }

        public void AddEdge(T from, T to)
        {
            int idx = data.IndexOf(from);
            neighbors[idx].Add(to);

            idx = data.IndexOf(to);
            neighbors[idx].Add(from);

            EdgeAdded?.Invoke(this, new GraphEventArgs<T>(from, to));
        }

        public bool HasEdge(T from, T to)
        {
            int idx = data.IndexOf(from);
            return neighbors[idx].Contains(to);
        }

        public List<T> Neighbors(T node)
        {
            int idx = data.IndexOf(node);
            return neighbors[idx];
        }

        public void BFS(T from, ExternalProcessor _method)
        {
            ExternalProcessor method = _method;
            Queue<T> S = new Queue<T>();
            List<T> F = new List<T>();

            S.Enqueue(from);
            F.Add(from);

            while (S.Count != 0)
            {
                T k = S.Dequeue();
                method?.Invoke(k);

                foreach (T edge in Neighbors(k))
                {
                    if (!F.Contains(edge))
                    {
                        S.Enqueue(edge);
                        F.Add(edge);
                    }
                }
            }
        }

        public void DFS(T from, ExternalProcessor _method)
        {
            ExternalProcessor method = _method;
            List<T> F = new List<T>();

            DFSR(from, ref F, method);
        }

        void DFSR(T from, ref List<T> F, ExternalProcessor method)
        {
            F.Add(from);
            method?.Invoke(from);

            foreach (T x in Neighbors(from))
            {
                if (!F.Contains(x))
                {
                    DFSR(x, ref F, method);
                }
            }
        }
    }
}
