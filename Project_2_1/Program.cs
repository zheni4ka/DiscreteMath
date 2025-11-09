namespace Project_2_1
{
    internal class Program
    {
        static void Main()
        {
            HashSet<string> U = new HashSet<string> { "a", "b", "c", "d", "e", "f", "g" };
            HashSet<string> A = new HashSet<string> { "a", "b", "c", "d" };
            HashSet<string> B = new HashSet<string> { "b", "c" };
            HashSet<string> C = new HashSet<string> { "d", "e" };

            HashSet<string> BC = new HashSet<string>(B);
            BC.UnionWith(C);

            HashSet<string> complement = new HashSet<string>(U);
            complement.ExceptWith(BC);

            HashSet<string> result = new HashSet<string>(A);
            result.ExceptWith(complement);

            Console.WriteLine("A = {" + string.Join(", ", A) + "}");
            Console.WriteLine("B = {" + string.Join(", ", B) + "}");
            Console.WriteLine("C = {" + string.Join(", ", C) + "}");
            Console.WriteLine("(B ∪ C)' = {" + string.Join(", ", complement) + "}");
            Console.WriteLine("Результат A \\ (B ∪ C) = {" + string.Join(", ", result) + "}");
        }
    }
}
