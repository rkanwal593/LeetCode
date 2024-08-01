using System;

public class Solution
{
    public bool IsMatch(string s, string p)
    {
        int sLength = s.Length;
        int pLength = p.Length;

        bool[,] dp = new bool[sLength + 1, pLength + 1];
        
        dp[0, 0] = true;

        for (int j = 1; j <= pLength; j++)
        {
            if (p[j - 1] == '*')
            {
                dp[0, j] = dp[0, j - 2]; 
            }
        }

        for (int i = 1; i <= sLength; i++)
        {
            for (int j = 1; j <= pLength; j++)
            {
                if (p[j - 1] == '.' || p[j - 1] == s[i - 1])
                {
                    
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else if (p[j - 1] == '*')
                {
                    dp[i, j] = dp[i, j - 2] || (dp[i - 1, j] && (s[i - 1] == p[j - 2] || p[j - 2] == '.'));
                }
            }
        }

        return dp[sLength, pLength];
    }
}
