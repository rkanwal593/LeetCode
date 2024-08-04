public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1 || s.Length <= numRows)
            return s;

        var rows = new List<StringBuilder>();
        for (int i = 0; i < Math.Min(numRows, s.Length); i++)
            rows.Add(new StringBuilder());

        int currentRow = 0;
        bool goingDown = false;

        foreach (char c in s) {
            rows[currentRow].Append(c);
            if (currentRow == 0 || currentRow == numRows - 1)
                goingDown = !goingDown;
            currentRow += goingDown ? 1 : -1;
        }

        var result = new StringBuilder();
        foreach (var row in rows)
            result.Append(row);

        return result.ToString();
    }
}
