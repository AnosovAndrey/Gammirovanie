using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gammirovanie
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "";

            Console.WriteLine("Введите длинну ключа: ");
            int key_length = Convert.ToInt32(Console.ReadLine());

            key = Vizhener.Generate_Pseudorandom_KeyWord(key_length);
            Console.WriteLine(key + "  ключ шифрования");

            Vizhener.Key_to_KeyList(key);

            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();

            Console.WriteLine("Для использования сгенерированного ключа введите 1, для своего 2");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 2){
                Console.WriteLine("Введите ключ: ");
                key = Console.ReadLine();
            }

            string crypt = Vizhener.Encode(text, key); //шифрование. вернет "ыкык"
            string decrypt = Vizhener.Decode(crypt, key); // дешифрование. вернет "мама"
            Console.WriteLine("Зашифрованный текст: " + crypt); 
            Console.WriteLine("Расшифрованный текст: " + decrypt);

            Console.ReadLine();
        }
    }
}
