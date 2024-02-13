using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherCompleteApp
{
    internal class CaesarCipher
    {
        private char[] CapitalMainText = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private char[] SmallMainText = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private char[] CapitalCeaserCipherText = { 'X', 'Y', 'Z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W' };
        private char[] SmallCeaserCipherText = { 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w' };
        
        

        public string Encrypt(string Text)
        {
            string encryptedText = string.Empty;
            int index;
            char[] txt=Text.ToCharArray();
            foreach(char c in txt)
            {
                if (Char.IsUpper(c))
                {
                    index=Array.IndexOf(CapitalMainText,c);
                    encryptedText += CapitalCeaserCipherText.GetValue(index).ToString();
                }
                else if(Char.IsLower(c))
                {
                    index = Array.IndexOf(SmallMainText, c);
                    encryptedText += SmallCeaserCipherText.GetValue(index).ToString();
                }
                else
                {
                    encryptedText += c;
                }
            }
            return encryptedText;
        }

        public string Decrypt(string Text)
        {
            string decryptedText = string.Empty;
            int index;
            char[] txt = Text.ToCharArray();
            foreach (char c in txt)
            {
                if (Char.IsUpper(c))
                {
                    index=Array.IndexOf(CapitalCeaserCipherText,c);
                    decryptedText += CapitalMainText.GetValue(index).ToString();
                }
                else if (Char.IsLower(c))
                {
                    index = Array.IndexOf(SmallCeaserCipherText, c);
                    decryptedText += SmallMainText.GetValue(index).ToString();
                }
                else { decryptedText += c; }
            }
            return decryptedText;
        }

        public string Encrypt(string Text,int Shift)
        {
           Start:
            try
            {
                string encryptedText = string.Empty;
                int index;
                char[] txt = Text.ToCharArray();
                foreach (char c in txt)
                {
                    if (Char.IsUpper(c))
                    {
                        index = Array.IndexOf(CapitalMainText, c) - Shift + 3;
                        if (index < 0)
                        {
                            index = 26 - Shift + 3;
                        }
                        else if (index > 25)
                        {
                            index = -1 - Shift + 3;
                        }
                        encryptedText += CapitalCeaserCipherText.GetValue(index).ToString();
                    }
                    else if (Char.IsLower(c))
                    {
                        index = Array.IndexOf(SmallMainText, c) - Shift + 3;
                        if (index < 0)
                        {
                            index = 26 - Shift;
                        }
                        else if (index > 25)
                        {
                            index = -1 - Shift;
                        }
                        encryptedText += SmallCeaserCipherText.GetValue(index).ToString();
                    }
                    else
                    {
                        encryptedText += c;
                    }
                }
                return encryptedText;
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message+" The default shift will be considered 3");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===================================================================");
                Shift = 3;
                goto Start;
            }
        }
        

        public string Decrypt(string Text,int Shift)
        {
            Start:
            try
            {
                string decryptedText = string.Empty;
                int index;
                char[] txt = Text.ToCharArray();
                foreach (char c in txt)
                {
                    if (Char.IsUpper(c))
                    {
                        index = Array.IndexOf(CapitalCeaserCipherText, c) + Shift - 3;
                        if (index < 0)
                        {
                            index = 26 + Shift - 3;
                        }
                        else if (index > 25)
                        {
                            index = -1 + Shift - 3;
                        }
                        decryptedText += CapitalMainText.GetValue(index).ToString();
                    }
                    else if (Char.IsLower(c))
                    {
                        index = Array.IndexOf(SmallCeaserCipherText, c) + Shift - 3;
                        if (index < 0)
                        {
                            index = 26 + Shift - 3;
                        }
                        else if (index > 25)
                        {
                            index = -1 + Shift - 3;
                        }
                        decryptedText += SmallMainText.GetValue(index).ToString();
                    }
                    else { decryptedText += c; }
                }
                return decryptedText;
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message + " The default shift will be considered 3");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===================================================================");
                Shift = 3;
                goto Start;
            }
        }
    }
}
