using System.Collections;
using System.Text;

internal class FormatTable
{
    private const int _padding = -20;
    private const string _border = "|----------" +
                                    "----------" +
                                    "----------" +
                                    "----------" +
                                    "-|";
    public static void MakeTable(Dictionary<string, string> products)
    {
        string topColumns = $"|{"Product name",_padding}" +
                        $"|{"Category name",_padding}|";
        StringBuilder sb = new();
        sb.AppendLine(topColumns);
        sb.AppendLine(_border);
        foreach (var product in products)
        {
            sb.AppendLine($"|{product.Key,_padding}|{product.Value,_padding}|");
            sb.AppendLine(_border);
        }
        Console.WriteLine(sb.ToString());
    }
}

