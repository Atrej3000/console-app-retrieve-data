using Newtonsoft.Json;
using System.Text;
using static Format;

string url = "http://tester.consimple.pro";
var client = new HttpClient();
var response = await client.GetStringAsync(url);
Root? root = JsonConvert.DeserializeObject<Root>(response);
var result = root?.Products.Select(p => new { Product = p.Name, Category = root.Categories.Single(c => c.Id == p.CategoryId).Name });
if(result != null)
{
    StringBuilder sb = new StringBuilder($"|{"Product name", PADDING}|{"Category name", PADDING}|\n");
    sb.AppendLine(BORDER);
	foreach (var item in result)
	{
		sb.AppendLine($"|{item.Product, PADDING}|{item.Category, PADDING}|");
		sb.AppendLine(BORDER);
	}
	Console.WriteLine(sb.ToString());
}

