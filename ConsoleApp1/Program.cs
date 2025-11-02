using System;

public class Program
{

    // Функція для перетворення boolean в 0 або 1 для виводу
    static int ToBit(bool value) => value ? 1 : 0;
    static bool Implication(bool p, bool q) => !p || q;

    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string header = " a | b | c | a→b | b→c | c→a | (b→c)→(c→a) | (a → b) → ((b → c) → (c → a))";
        Console.WriteLine(header);
        Console.WriteLine(new string('-', header.Length));

        bool allResultsTrue = true;
        bool atLeastOneTrue = false;


        for (int value_a = 0; value_a <= 1; value_a++)
            for (int value_b = 0; value_b <= 1; value_b++)
                for (int value_c = 0; value_c <= 1; value_c++)
                {

                    bool a = value_a == 1;
                    bool b = value_b == 1;
                    bool c = value_c == 1;

                    bool res_a_b = Implication(a, b);         
                    bool res_b_c = Implication(b, c);          
                    bool res_c_a = Implication(c, a);          
                    bool res_mid = Implication(res_b_c, res_c_a); 

                    bool finalResult = Implication(res_a_b, res_mid);

                    Console.WriteLine($" {ToBit(a)} | {ToBit(b)} | {ToBit(c)} |  {ToBit(res_a_b)}  |  {ToBit(res_b_c)}  |  {ToBit(res_c_a)}  |      {ToBit(res_mid)}      |     {ToBit(finalResult)}");

                    if (finalResult) atLeastOneTrue = true;
                    else allResultsTrue = false;
                }

        Console.WriteLine("------------------");
        Console.WriteLine("\nОцінка формули:");

        if (allResultsTrue)
        {
            Console.WriteLine("Формула є тавтологією та виконуваною.");
        }
        else if (atLeastOneTrue)
        {
            Console.WriteLine("Формула є виконуваною (нейтральною).");
        }
        else
        {
            Console.WriteLine("Формула є суперечністю та НЕвиконуваною.");
        }
    }
}