using System.Globalization;

namespace _NetAsp.Entities
{
    internal class Products
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            
            Console.WriteLine($"Id:{Category.Id} || Categoria: {Category.Name}" +
                $" || Nivel: {Category.Tier} || Id do produto:{Id} || {Name} ||" +
                $" {Price.ToString("f2", CultureInfo.InvariantCulture)}");
            Console.WriteLine();
            return "";
        }
    }
}
