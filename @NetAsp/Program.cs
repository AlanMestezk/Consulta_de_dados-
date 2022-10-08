

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

            var r1 =
                from p in products
                where p.Category.Tier == 1 && p.Price < 300.00
                select p;
            Print("Qualidade 3 e com menos de 300 reais", r1);


            var r2 =
                from p in products
                where p.Category.Name == "Eletrônicos"
                select p.Name;
            Print("Eletrônicos: ", r2);


            var r3 =
                from p in products
                where p.Name[0] == 'C'
                select new
                {
                    p.Name,
                    p.Price,
                    CategoryName = p.Category.Name

                };
            Print("Objetos começando com c", r3);

            var r4 =
                from p in products
                where p.Category.Tier == 1
                orderby p.Name
                orderby p.Price
                select p;
            Print("Valor em ordem crescente", r4);

            var r5 =
                (from p in r4
                select p).
                Skip(1).Take(3);
            Print("Pular do 1 para o 3", r5);

            
        }
    }
}
