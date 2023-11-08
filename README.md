## Description

Write a function which makes a list of strings representing all of the ways you can balance ```n``` pairs of parentheses.

### Examples
```C#
BalancedParens(0) returns List<string> with element:  ""
BalancedParens(1) returns List<string> with element:  "()"
BalancedParens(2) returns List<string> with elements: "()()", "(())"
BalancedParens(3) returns List<string> with elements: "()()()", "(())()", "()(())", "(()())", "((()))"
```

### My solution
```C#
using System.Collections.Generic;
using System.Linq;

public class Balanced
{
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
```
