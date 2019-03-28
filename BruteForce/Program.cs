using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForce
{
    class Program
    {
        const string characters = "0123456789abcdefghijklmnopqrstuvwxyz";
        private static long computedKeys = 0;
        static char[] initialKey = { 'z', 'z', 'z', 'z', 'z', 'z', 'z' };
        static int length = initialKey.Length;
        static int indexOfLastChar = length - 1;
        static Stopwatch stopwatch = Stopwatch.StartNew();

        static void Main(string[] args)
        {
            createNewKey(0, initialKey, length, true);
        }

        private static void createNewKey(int currentCharPosition, char[] keyChars, int keyLength, bool useInitialValue)
        {
            int loopInitialValue = useInitialValue ? characters.IndexOf(keyChars[currentCharPosition]) : characters.Length - 1;

            // We are looping trough the full length of our charactersToTest array
            for (int i = loopInitialValue; i >= 0; i--)
            {
                /* The character at the currentCharPosition will be replaced by a
                 * new character from the charactersToTest array => a new key combination will be created */
                keyChars[currentCharPosition] = characters[i];

                // The method calls itself recursively until all positions of the key char array have been replaced
                if (currentCharPosition < (length - 1))
                {
                    createNewKey(currentCharPosition + 1, keyChars, keyLength, computedKeys == 0);
                }
                else
                {
                    // A new key has been created, remove this counter to improve performance
                    computedKeys++;
                    string key = new String(keyChars);
                    Console.WriteLine(key);
                    stopwatch.Stop();
                    //Console.WriteLine(stopwatch.ElapsedTicks);
                    stopwatch = Stopwatch.StartNew();
                }
            }
        }
    }
}
