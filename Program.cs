using System.IO;
namespace CaesarCipherCompleteApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exception:
            try
            {
            Start:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hello, Welcome to File Encryptor and Decryptor:");
                Console.WriteLine("Choose your operation by pressing E, D, or F");
                Console.WriteLine("(E) to Encrypt a message.");
                Console.WriteLine("(D) to Decrypt a file.");
                Console.WriteLine("(F) to exit.");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar == 'e' || key.KeyChar == 'E')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nWelcome to encryption!");
                    Console.WriteLine("Enter your message to encrypt:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string message = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter the shift:");
                    Console.ForegroundColor = ConsoleColor.White;
                    int shift = int.Parse(Console.ReadLine());
                    CaesarCipher cc = new CaesarCipher();
                    string EncryptedMessage = cc.Encrypt(message, shift);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your encrypted message is: " + EncryptedMessage);
                    Console.WriteLine("==================================================");
                    goto Start;
                }
                else if (key.KeyChar == 'D' || key.KeyChar == 'd')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nWelcome to decryption!");
                    Console.WriteLine("Enter the directory that your encrypted file is in it:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string dir = @Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter your encrypted file' name:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string fileName = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter the shift of decryption:");
                    Console.ForegroundColor = ConsoleColor.White;
                    int shift = int.Parse(Console.ReadLine());
                    CaesarCipher cc = new CaesarCipher();
                    StreamReader sr = new StreamReader(dir + fileName);
                    string DecryptedMessage = cc.Decrypt(sr.ReadToEnd(), shift);
                    sr.Close();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your decrypted message is: " + DecryptedMessage);
                    Console.WriteLine("==================================================");
                    goto Start;
                }
                else if (key.KeyChar == 'F' || key.KeyChar == 'f')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nGood Bye! Hope to see you later!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe input was invalid! Try again.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("==================================================");
                    goto Start;
                }
            }//try
            catch(FormatException e)
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==================================================");
                goto Exception;
            }
            catch (FileNotFoundException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==================================================");
                goto Exception;
            }
            Console.ReadKey();
        }
    }
}