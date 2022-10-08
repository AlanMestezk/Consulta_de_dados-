

using _NetAsp.Entities;

namespace _NetAsp
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach(T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

       static void Main(string[] args)
        {

            Category c1 = new()
            { Id = 1, Name = "Ferramenta", Tier = 3 };
            Category c2 = new()
            { Id = 2, Name = "Eletrônicos", Tier = 1};
            

            List<Products> products = new List<Products>()
            {
                new(){Id = 1, Name = "Chave Phillips", Price = 200.00, Category = c1 },
                new(){Id = 11, Name = "Pc Gamer", Price = 5000.00, Category = c2},
                new(){Id = 2, Name = "Martelo", Price = 300.00, Category = c1},
                new(){Id = 12, Name = "SmartPhone", Price = 2000.00, Category = c2},
                new(){Id = 13, Name = "Carregador SmartPhone", Price = 200.00, Category = c2},
                new(){Id = 3, Name = "Mala de ferramenta", Price = 5000.00, Category = c1}
            };

            var re = products.Where(p => p.Price >= 300.00);
            Print("Preços maior ou igual a 300: ", re);

            var r1 = products.Where(p => p.Category.Tier == 3 && p.Price <= 300.00);
            Print("Qualidade 3 e com menos de 300 reais", r1);

            var r2 = products.Where(p => p.Category.Name == "Eletrônicos")
                .Select(p => p.Name);
            Print("Eletrônicos", r2);

            //colocando apelido no nome da categoria
            var r3 = products.Where(p => p.Name[0] == 'C')
                .Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("Objetos começando com c", r3);

            var r4 = products.Where(p => p.Category.Tier == 1)
                .OrderBy(p=> p.Price);
            Print("Valor em ordem crescente", r4);

            var r5 = r4.Skip(1).Take(3);
            Print("Pular do 1 para o 3", r5);

            var r10 = products.Max(p => p.Price);
            Console.WriteLine("Maior preço " + r10);

            var r11 = products.Min(p => p.Price);
            Console.WriteLine("Menor preço " + r11);


            var r12 = products.Where(p => p.Category.Id == 1)
                .Sum(p => p.Price);
            Console.WriteLine("Soma dos preços da categoria 1: "+ r12);

            var r13 = products.Where(p => p.Category.Id == 2)
                .Average(p => p.Price);
            Console.WriteLine("Media dos preços da categoria 2: " + r13);

            var r14 = products.Where(p => p.Category.Id == 3)
                .Select(p => p.Price)
                .DefaultIfEmpty(0.0)
                .Average();
            Console.WriteLine("Media dos preços da categoria 3 se não existir, retorne 0: " + r13);
       
        }
    }
}
