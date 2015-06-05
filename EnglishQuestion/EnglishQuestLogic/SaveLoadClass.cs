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

        public WordsDataBase[] LoadWordsBase()
        {
            WordsDataBase[] _wdbBase;
            using (Stream _fStream = new FileStream("WordsBaseData.dat",FileMode.Open,FileAccess.Read))
            {
                var tempBase = binFormater.Deserialize(_fStream);
                _wdbBase = (WordsDataBase[]) tempBase;
            }
            return _wdbBase;
        }
    }
}
