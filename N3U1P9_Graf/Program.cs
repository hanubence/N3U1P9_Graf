using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3U1P9_Graf
{
    internal class Program
    {
        static void EdgeLogger(object source, Graph<Person>.GraphEventArgs<Person> args)
        {
            Console.WriteLine($"[Graf] New edge added: '{args.A}' <-> '{args.B}'");
        }

        static void Main(string[] args)
        {
            Graph<Person> graf = new Graph<Person>();
            graf.EdgeAdded += EdgeLogger;

            Person Stew = new Person() { Name = "Stew" };
            Person Joseph = new Person() { Name = "Joseph" };
            Person Marge = new Person() { Name = "Marge" };
            Person Gerald = new Person() { Name = "Gerald" };
            Person Zack = new Person() { Name = "Zack" };
            Person Peter = new Person() { Name = "Peter" };
            Person Janet = new Person() { Name = "Janet" };

            graf.AddNode(Stew);
            graf.AddNode(Joseph);
            graf.AddNode(Marge);
            graf.AddNode(Gerald);
            graf.AddNode(Zack);
            graf.AddNode(Peter);
            graf.AddNode(Janet);

            graf.AddEdge(Stew, Marge);
            graf.AddEdge(Stew, Joseph);
            graf.AddEdge(Marge, Joseph);
            graf.AddEdge(Joseph, Gerald);
            graf.AddEdge(Joseph, Zack);
            graf.AddEdge(Gerald, Zack);
            graf.AddEdge(Zack, Peter);
            graf.AddEdge(Peter, Janet);

            //Legrovidebb ut Janet es Stew kozott
            Console.WriteLine($"The length of the shortest path between Janet and Stew: {graf.ShortestPathBFS(Janet, Stew)}");

            Console.ReadKey();
        }
    }
}
