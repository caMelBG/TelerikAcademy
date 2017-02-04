using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evacuation
{
    public class EvacuationSolution
    {
        static List<Edge>[] edges;
        static Node[] rooms;

        static void Main(string[] args)
        {
            var roomCount = int.Parse(Console.ReadLine());
            edges = new List<Edge>[roomCount];
            rooms = new Node[roomCount];
            for (int i = 0; i < roomCount; i++)
            {
                edges[i] = new List<Edge>();
            }

            for (int i = 0; i < roomCount; i++)
            {
                rooms[i] = new Node(i);
            }

            var exits = Console.ReadLine()
                .Split(' ')
                .Select(e => rooms[int.Parse(e)])
                .ToArray();

            foreach (var exit in exits)
            {
                exit.DistanceFromStart = TimeSpan.Zero;
            }

            var connectionCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < connectionCount; i++)
            {
                var data = Console.ReadLine().Split(' ');
                var roomA = int.Parse(data[0]);
                var roomB = int.Parse(data[1]);
                var distance = TimeSpan.ParseExact(data[2], "mm\\:ss", CultureInfo.InvariantCulture);

                edges[roomA].Add(new Edge { Other = roomB, Weight = distance });
                edges[roomB].Add(new Edge { Other = roomA, Weight = distance });
            }

            var maxTime = TimeSpan.ParseExact(Console.ReadLine(), "mm\\:ss", CultureInfo.InvariantCulture);

            foreach (var exit in exits)
            {
                Dijstra(exit);
            }

            var unsafeRooms = rooms
                .Where(r => r.DistanceFromStart > maxTime)
                .OrderBy(r => r.Id);

            if (unsafeRooms.Count() > 0)
            {
                Console.WriteLine("Unsafe");
                Console.WriteLine(string.Join(", ", unsafeRooms));
            }
            else
            {
                var longestEvacuationRoom = GetLongestEvacuationTimeRoom();
                Console.WriteLine("Safe");
                Console.WriteLine(longestEvacuationRoom);
            }
        }

        private static Node GetLongestEvacuationTimeRoom()
        {
            int maxTimeRoom = int.MaxValue;
            TimeSpan time = TimeSpan.Zero;
            foreach (var room in rooms)
            {
                if (room.DistanceFromStart > time ||
                    (room.DistanceFromStart == time && room.Id < maxTimeRoom))
                {
                    maxTimeRoom = room.Id;
                    time = room.DistanceFromStart;
                }
            }

            return rooms[maxTimeRoom];
        }

        static void Dijstra(Node start)
        {
            var queue = new PriorityQueue<Node>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var current = queue.ExtractTop();
                var children = edges[current.Id];
                foreach (var edge in children)
                {
                    var child = rooms[edge.Other];
                    var newDistance = current.DistanceFromStart + edge.Weight;
                    if (newDistance < child.DistanceFromStart)
                    {
                        child.DistanceFromStart = newDistance;
                        if (queue.Contains(child))
                        {
                            queue.DecreaseKey(child);
                        }
                        else
                        {
                            queue.Enqueue(child);
                        }
                    }
                }
            }
        }
    }

    class Edge
    {
        public int Other { get; set; }

        public TimeSpan Weight { get; set; }
    }

    public class Node : IComparable<Node>
    {
        public Node(int id)
        {
            this.Id = id;
            this.DistanceFromStart = TimeSpan.MaxValue;
        }

        public int Id { get; set; }

        public TimeSpan DistanceFromStart { get; set; }

        public int CompareTo(Node other)
        {
            return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
        }

        public override string ToString()
        {
            var distance = this.DistanceFromStart == TimeSpan.MaxValue ?
                "unreachable" : this.DistanceFromStart.ToString("hh\\:mm\\:ss");

            return string.Format("{0} ({1})", this.Id, distance);
        }
    }

    public enum Comparator
    {
        Min,
        Max
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private Dictionary<T, int> searchCollection;
        private List<T> heap;
        private Comparer<T> comparer;

        public PriorityQueue(Comparator comparator)
        {
            this.SetComparator(comparator);
            this.heap = new List<T>();
            this.searchCollection = new Dictionary<T, int>();
        }

        public PriorityQueue()
            : this(Comparator.Min)
        {
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public T ExtractTop()
        {
            var min = this.heap[0];
            var last = this.heap[this.heap.Count - 1];
            this.searchCollection[last] = 0;
            this.heap[0] = last;
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.HeapifyDown(0);
            }

            this.searchCollection.Remove(min);

            return min;
        }

        public T PeekMin()
        {
            return this.heap[0];
        }

        public bool Contains(T element)
        {
            return this.searchCollection.ContainsKey(element);
        }

        public void Enqueue(T element)
        {
            this.searchCollection.Add(element, this.heap.Count);
            this.heap.Add(element);
            this.HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyDown(int i)
        {
            var left = (2 * i) + 1;
            var right = (2 * i) + 2;
            var smallest = i;

            if (left < this.heap.Count && this.comparer.Compare(this.heap[left], this.heap[smallest]) < 0)
            {
                smallest = left;
            }

            if (right < this.heap.Count && this.comparer.Compare(this.heap[right], this.heap[smallest]) < 0)
            {
                smallest = right;
            }

            if (smallest != i)
            {
                T old = this.heap[i];
                this.searchCollection[old] = smallest;
                this.searchCollection[this.heap[smallest]] = i;
                this.heap[i] = this.heap[smallest];
                this.heap[smallest] = old;
                this.HeapifyDown(smallest);
            }
        }

        private void HeapifyUp(int i)
        {
            var parent = (i - 1) / 2;
            while (i > 0 && this.comparer.Compare(this.heap[i], this.heap[parent]) < 0)
            {
                T old = this.heap[i];
                this.searchCollection[old] = parent;
                this.searchCollection[this.heap[parent]] = i;
                this.heap[i] = this.heap[parent];
                this.heap[parent] = old;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        private void SetComparator(Comparator comparator)
        {
            if (comparator == Comparator.Min)
            {
                this.comparer = Comparer<T>.Default;
            }
            else
            {
                this.comparer = Comparer<T>.Create((a, b) => b.CompareTo(a));
            }
        }

        public void DecreaseKey(T element)
        {
            int index = this.searchCollection[element];
            this.HeapifyUp(index);
        }
    }
}
