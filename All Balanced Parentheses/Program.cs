using System.Collections.Generic;
using System.Linq;

public class Balanced
{
    public static void Main()
    {
        // Test
        var t = BalancedParens(3);
        // ...should return "((()))", "(()())", "(())()", "()(())", "()()()"
    }

    public static List<string> BalancedParens(int n)
    {
        if (n == 0)
            return new List<string>() { "" };

        List<string> combinations = new() { "(" };

        for (int i = 0; i < combinations.Count; i++)
        {
            if (combinations[i].Length == n * 2)
                continue;

            int numberOfOpeningParentheses = combinations[i].Count(c => c == '(');

            if (numberOfOpeningParentheses == n)
            {
                combinations.Add(combinations[i] + ')');
                continue;
            }

            if (combinations[i].Length - numberOfOpeningParentheses == numberOfOpeningParentheses)
            {
                combinations.Add(combinations[i] + '(');
                continue;
            }

            combinations.Add(combinations[i] + '(');
            combinations.Add(combinations[i] + ')');
        }

        return combinations.Where(s => s.Length == n * 2).ToList();
    }
}