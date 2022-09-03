using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfMerge
{
    public class StringRandomizer
    {

        /// <summary>
        /// mischt den InputString in den OutputString
        /// </summary>
        public static string ShuffleStringInString(string Shuffle, string StringIn, Boolean OutputAsUpper =true)
        {

            List<char> ListInput = new List<char>();
            List<int> insertPos = new List<int>();
            //erstellt eine Liste mit allen möglichen Einfügepositionen
            for (int i = 0; i < Shuffle.Length; i++)
            {
                insertPos.Add(i);

            }
            //erstellt eine Liste der Buchstaben des InputString
            for (int i = 0; i < StringIn.Length; i++)
            {
                ListInput.Add(StringIn[i]);
            }

            char item;
            char[] shuffleArr = Shuffle.ToCharArray();
            Random rnd = new Random();
            while (ListInput.Count > 0)
            {
                item = StringRandomizer.TakeElementFromList(ref ListInput, rnd.Next(0, ListInput.Count));
                int InsertIndex = StringRandomizer.TakeElementFromList(ref insertPos, rnd.Next(0, ListInput.Count));
                shuffleArr[InsertIndex] = item;
            }
            string NewShuffle = new string(shuffleArr);
            if (OutputAsUpper)
            {
                return NewShuffle.ToUpper();
            }
            else { return NewShuffle; }

        }
        public static string RandomString(int length)
        {
            var chars="ABCDEFGHIJKLMNOPQRSTUVWXYZÄÜßÖ";
            var stringChars = new char[length];
            Random rnd = new Random();

            for (int i=0;i<length;i++)
            {
                stringChars[i] = chars[rnd.Next(chars.Length)];
            }
            return new string(stringChars);
        }
        /// <summary>
        /// nimmt ein Element von einer Liste, das danach gelöscht wird
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        public static T TakeElementFromList<T>(ref List<T> list, int Index)
        {
            T item;
            item = list.ElementAt(Index);
            list.Remove(item);
            return item;
        }
    }
    public static class Extension
    {
        

    }
}
