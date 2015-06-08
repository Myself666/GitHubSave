using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EnglishQuestion.Logical
{
    public class SaveLoadClass
    {
        BinaryFormatter binFormater = new BinaryFormatter();

        public void SaveWordsBase(WordsDataBase[] wdb)
        {
            using (Stream _stream = new FileStream("WordsBaseData.dat",FileMode.Create,FileAccess.Write))
            {
                binFormater.Serialize(_stream,wdb);
            }
        }

        public WordsDataBase[] LoadWordsBase(string path)
        {


            WordsDataBase[] _wdbBase;
            string[] readWords = File.ReadAllLines(path);
            Dictionary<String,string> dictWords = new Dictionary<string, string>();
            
            foreach ( var read in readWords)
            {
                string[] line = read.Split('|');
                dictWords.Add(line[0], line[1]);
            }
            ICollection<string> keys = dictWords.Keys;
            _wdbBase = new WordsDataBase[dictWords.Count];
            int i = 0;
            
            foreach (var word in dictWords.Keys)
            {
                _wdbBase[i] = new WordsDataBase(word,dictWords[word],i);
                _wdbBase[i].IdValue = i + 1;
                i++;
            }
            /*using (Stream _fStream = new FileStream("WordsBaseData.dat",FileMode.Open,FileAccess.Read))
            {
                var tempBase = binFormater.Deserialize(_fStream);
                _wdbBase = (WordsDataBase[]) tempBase;
            }*/
            return _wdbBase;
        }
    }
}
