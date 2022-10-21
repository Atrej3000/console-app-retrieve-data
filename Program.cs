using Newtonsoft.Json;
using static FormatTable;

string url = "http://tester.consimple.pro";
using var client = new HttpClient();
var response = await client.GetStringAsync(url);
Root? root = JsonConvert.DeserializeObject<Root>(response);
var products = root?.Products
    .Select(p => new { Product = p.Name, Category = root.Categories
    .Single(c => c.Id == p.CategoryId).Name })
    .ToDictionary(e => e.Product, e => e.Category);
if (products != null)
{
    MakeTable(products);
}
