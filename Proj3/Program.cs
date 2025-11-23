using System;
using System.Numerics;

public class Program
{

    // 1) Побудувати розклад бінома (ax + by)^n
    public static void Task1_BinomialExpansion(int a, int b, int n)
    {
        Console.Write($"({a}x + {b}y)^{n} = ");
        for (int k = 0; k <= n; k++)
        {
            int n_minus_k = n - k;

            // Коефіцієнт: C(n, k) * a^(n-k) * b^k
            BigInteger binom_coeff = MathHelper.BinomialCoefficient(n, k);
            BigInteger term_coeff = binom_coeff * BigInteger.Pow(a, n_minus_k) * BigInteger.Pow(b, k);

            // Формування терма
            string x_term = (n_minus_k > 0) ? $"x^{n_minus_k}" : "";
            string y_term = (k > 0) ? $"y^{k}" : "";

            if (n_minus_k == 1) x_term = "x";
            if (k == 1) y_term = "y";

            Console.Write($"{term_coeff}{x_term}{y_term}");
            if (k < n)
            {
                Console.Write(" + ");
            }
        }
        Console.WriteLine();
    }

    // 2) Знайти коефіцієнт біля x^j y^(n-j)
    public static void Task2_BinomialCoefficient(int a, int b, int n, int j)
    {
        if (j < 0 || j > n)
        {
            Console.WriteLine($"Коефіцієнт дорівнює 0, оскільки показник j={j} знаходиться поза діапазоном [0, n={n}].");
            return;
        }

        int k = n - j; // k = n - j

        // Формула: C(n, j) * a^j * b^(n-j)
        BigInteger binom_coeff = MathHelper.BinomialCoefficient(n, j);
        BigInteger a_power = BigInteger.Pow(a, j);
        BigInteger b_power = BigInteger.Pow(b, k);

        BigInteger result_coeff = binom_coeff * a_power * b_power;

        Console.WriteLine($"Шуканий терм: $\\binom{{{n}}}{{{j}}} a^{{{j}}} b^{{{k}}} x^{{{j}}} y^{{{k}}}$");
        Console.WriteLine($"Коефіцієнт: C({n}, {j}) * {a}^{j} * {b}^{k}");
        Console.WriteLine($" = {binom_coeff} * {a_power} * {b_power}");
        Console.WriteLine($" = {result_coeff}");
    }

    // 3) Побудувати розклад полінома (ax + by + cz)^n
    public static void Task3_MultinomialExpansion(int a, int b, int c, int n)
    {
        Console.WriteLine($"({a}x + {b}y + {c}z)^{n} = ");
        Console.WriteLine("Сума усіх термів $\\sum_{i+j+k=n} \\frac{n!}{i! j! k!} a^i b^j c^k x^i y^j z^k$:");

        bool first_term = true;
        // Перебір усіх невід'ємних цілих i, j, k таких, що i + j + k = n
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n - i; j++)
            {
                int k = n - i - j; // k автоматично визначається: k = n - i - j

                // Коефіцієнт: M(n; i, j, k) * a^i * b^j * c^k
                BigInteger multi_coeff = MathHelper.MultinomialCoefficient(n, i, j, k);
                BigInteger term_coeff = multi_coeff * BigInteger.Pow(a, i) * BigInteger.Pow(b, j) * BigInteger.Pow(c, k);

                // Формування терма
                string x_term = (i > 0) ? $"x^{i}" : "";
                string y_term = (j > 0) ? $"y^{j}" : "";
                string z_term = (k > 0) ? $"z^{k}" : "";

                if (i == 1) x_term = "x";
                if (j == 1) y_term = "y";
                if (k == 1) z_term = "z";

                if (!first_term)
                {
                    Console.Write(" + ");
                }
                Console.Write($"{term_coeff}{x_term}{y_term}{z_term}");
                first_term = false;
            }
        }
        Console.WriteLine();
    }

    // 4) Знайти коефіцієнт біля x^i y^j z^k
    public static void Task4_MultinomialCoefficient(int a, int b, int c, int n, int i, int j, int k)
    {
        // Перевірка умови (i + j + k = n)
        if (i + j + k != n)
        {
            Console.WriteLine($"Коефіцієнт дорівнює 0, оскільки сума показників ({i} + {j} + {k} = {i + j + k}) не дорівнює n={n}.");
            return;
        }

        // Формула: M(n; i, j, k) * a^i * b^j * c^k
        BigInteger multi_coeff = MathHelper.MultinomialCoefficient(n, i, j, k);
        BigInteger a_power = BigInteger.Pow(a, i);
        BigInteger b_power = BigInteger.Pow(b, j);
        BigInteger c_power = BigInteger.Pow(c, k);

        BigInteger result_coeff = multi_coeff * a_power * b_power * c_power;

        Console.WriteLine($"Шуканий терм: $\\frac{{{n}!}}{{{i}!{j}!{k}!}} a^{{{i}}} b^{{{j}}} c^{{{k}}} x^{{{i}}} y^{{{j}}} z^{{{k}}}$");
        Console.WriteLine($"Коефіцієнт: M({n}; {i}, {j}, {k}) * {a}^{i} * {b}^{j} * {c}^{k}");
        Console.WriteLine($" = {multi_coeff} * {a_power} * {b_power} * {c_power}");
        Console.WriteLine($" = {result_coeff}");
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //  Вхідні дані 
        int a = 2;
        int b = 3;
        int c = 4;
        int n = 3;
        int j_binom = 1; // для завдання 2
        int i_multi = 1; // для завдання 4
        int j_multi = 1; // для завдання 4
        int k_multi = 1; // для завдання 4

        // Перевірка умови для мультиноміального коефіцієнта
        if (i_multi + j_multi + k_multi != n)
        {
            Console.WriteLine($"\nУвага: Для завдання 4 показники (i={i_multi}, j={j_multi}, k={k_multi}) повинні сумуватись до n={n}.");
            Console.WriteLine("Будь ласка, змініть вхідні дані для завдання 4.");
            Console.WriteLine($"(i + j + k = {i_multi + j_multi + k_multi}, а має бути {n})");
        }

        // --- Завдання 1: Біноміальний розклад (ax + by)^n ---
        Console.WriteLine($"\n--- 1. Біноміальний Розклад ({a}x + {b}y)^{n} ---");
        Task1_BinomialExpansion(a, b, n);

        // --- Завдання 2: Коефіцієнт біля x^j y^(n-j) ---
        Console.WriteLine($"\n--- 2. Коефіцієнт біля x^{j_binom} y^{n - j_binom} в розкладі ({a}x + {b}y)^{n} ---");
        Task2_BinomialCoefficient(a, b, n, j_binom);

        // --- Завдання 3: Розклад полінома (ax + by + cz)^n ---
        Console.WriteLine($"\n--- 3. Мультиноміальний Розклад ({a}x + {b}y + {c}z)^{n} ---");
        Task3_MultinomialExpansion(a, b, c, n);

        // --- Завдання 4: Коефіцієнт біля x^i y^j z^k ---
        if (i_multi + j_multi + k_multi == n)
        {
            Console.WriteLine($"\n--- 4. Коефіцієнт біля x^{i_multi} y^{j_multi} z^{k_multi} в розкладі ({a}x + {b}y + {c}z)^{n} ---");
            Task4_MultinomialCoefficient(a, b, c, n, i_multi, j_multi, k_multi);
        }

    }

    
}