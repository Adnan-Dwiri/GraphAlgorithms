using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        graph["a"] = new List<string> { "b" ,"c" };
        graph["b"] = new List<string> { "d" };
        graph["c"] = new List<string> { "e" };
        graph["d"] = new List<string> { "f" };
        graph["e"] = new List<string> { };
        graph["f"] = new List<string> { };
        graph["s"] = new List<string> { };

        DepthFirstSearch(graph, "a");
        BreadthFirstSearch(graph, "a");
        bool HP = HasPath(graph, "a", "s");
        Console.WriteLine(HP);

        Console.ReadKey();
    }

    public static void DepthFirstSearch(Dictionary<string, List<string>> graph ,string source)
    {
        Stack stack = new Stack();
        stack.Push(source);

        while(stack.Count > 0)
        {
            var current = stack.Pop();
            Console.WriteLine((string)current);
            foreach (var neighbor in graph[(string)current])
            {
                stack.Push(neighbor);
            }
        }
    }

    public static void BreadthFirstSearch(Dictionary<string, List<string>> graph, string source)
    {
        Queue queue = new Queue();
        queue.Enqueue(source);
        
        while(queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.WriteLine((string)current);

            foreach(var neighbor in graph[(string)current])
            {
                queue.Enqueue(neighbor);
            }
        }
    }

    public static bool HasPath(Dictionary<string, List<string>> graph,string source,string dst)
    {
        if(source == dst) return true;

        foreach(var neighbor in graph[(string)source])
        {
            if(HasPath(graph,neighbor,dst)) return true;
        }
        return false;
    }
}