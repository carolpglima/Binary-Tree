using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        public class Node
        {
            public int value;
            public Node right;
            public Node left;
            public Node (Node l, Node r, int v)
            { 
                value = v;
                right = r;
                left = l;
            }

         
        }

        public static void PrintTree(Node n)
        {
            if (n.left != null)
                PrintTree(n.left);
            Console.WriteLine(n.value);
            if (n.right != null)
                PrintTree(n.right);
        }

        public static int CalcAltura(Node n)
        {
            if (n == null)
                return 0;
            int l = CalcAltura(n.left);
            int r = CalcAltura(n.right);
            return (Math.Max(l, r) + 1);
        }

        public static bool Search(Node n, int v)
        {
            if (n == null)
                return false;
            if (n.value == v)
                return true;
            if (n.value > v)
                return Search(n.left, v);
            else
                return Search(n.right, v);        
        }

        static void Main(string[] args)
        {
            /*                   7
             *     4                       9
             *   2     5               8         10
             * 1   3      6                         11
             */
            Console.WriteLine("Hello World!x");
            Node n1 = new Node(null, null, 1);
            Node n3 = new Node(null, null, 3);
            Node n2 = new Node(n1, n3, 2);
            Node n6 = new Node(null, null, 6);
            Node n5 = new Node(null, n6, 5);
            Node n4 = new Node(n2, n5, 4);
            Node n11 = new Node(null, null, 11);
            Node n10 = new Node(null, n11, 10);
            Node n8 = new Node(null, null, 8);
            Node n9 = new Node(n8, n10, 9);
            Node n7 = new Node(n4, n9, 7);

            PrintTree(n7);
            int alt = CalcAltura(n7);
            Console.WriteLine("Altura de n7 = " + alt);

            alt = CalcAltura(n1);
            Console.WriteLine("Altura de n1 = " + alt);

            bool achou = Search(n7,2);
            if (achou == true)
                Console.WriteLine("Achou " );
            else
                Console.WriteLine("Nao achou ");

            string input = "1100x2000@60";
            Regex rgx = new Regex(@"(\d+)x(\d+)(?=@)");
            int a=0;
            foreach (Match m in rgx.Matches(input))
            {
                string v1 = m.Groups[1].Value;
                string v2 = m.Groups[2].Value;
                Console.WriteLine("v1:" + v1 + " v2:" + v2);
                //a = int.Parse(v1.ToString());
                if (!Int32.TryParse(v1,out a))
                {
                    a = -1;
                }
            }
            if (a == 1100)
            {
                Console.WriteLine("a!!");
            }
        }
    }
}
