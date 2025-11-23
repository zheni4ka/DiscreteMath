using System.Numerics;

public static class MathHelper
{
    // Обчислення факторіала (використовуємо BigInteger для великих n)
    public static BigInteger Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentException("Факторіал визначений лише для невід'ємних чисел.");
        if (n == 0)
            return 1;

        BigInteger result = 1;
        for (int i = 1; i <= n; i++) {result *= i;}
        return result;
    }

    // Обчислення Біноміального Коефіцієнта (n по k)
    // C(n, k) = n! / (k! * (n-k)!)
    public static BigInteger BinomialCoefficient(int n, int k)
    {
        if (k < 0 || k > n)
            return 0;
        if (k == 0 || k == n)
            return 1;
        if (k > n / 2)
            k = n - k; //C(n, k) = C(n, n-k)

        // Оптимізований розрахунок для зменшення розміру проміжних чисел
        BigInteger res = 1;
        for (int i = 1; i <= k; i++)
        {
            res = res * (n - i + 1) / i;
        }
        return res;
    }

    // Обчислення Мультиноміального Коефіцієнта (n / (i! * j! * k!))
    public static BigInteger MultinomialCoefficient(int n, int i, int j, int k)
    {
        if (i + j + k != n)
            throw new ArgumentException("Сума показників (i + j + k) повинна дорівнювати n.");

        // Використовуємо факторіали для простоти, але можна оптимізувати
        return Factorial(n) / (Factorial(i) * Factorial(j) * Factorial(k));
    }
}