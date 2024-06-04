using System.Text.RegularExpressions;

namespace Maturita_2024_ulohy_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("input.txt"))
            {
                Console.WriteLine(Validate(sr.ReadToEnd()));
            }
            Console.WriteLine(Validate(Console.ReadLine()));


        }

        public static bool Validate(string input) 
        {
            string regex = "\\{(START|END):[^\\}]+\\}";
            Regex tag = new Regex(regex);
            int matchPos = 0;
            Stack<string> stack = new Stack<string>();
            while(tag.IsMatch(input, matchPos)) 
            {
                Match m = tag.Match(input, matchPos);
                matchPos = m.Index+1;
                string content = ExtractContent(m.Value);
                if(m.Value[1] == 'S')
                {
                    stack.Push(content);
                }
                else
                {
                    if(content != stack.Pop())
                    {
                        return false;
                    }
                }
            }
            if(stack.Count == 0)
            {
                return true;
            }
            return false;
        }

        public static string ExtractContent(string tag) 
        {
            if (tag[1] == 'S')
            {
                return tag.Substring(7, tag.Length - 8);
            }
            else
            {
                return tag.Substring(5, tag.Length - 6);
            }
        }
    }
}
