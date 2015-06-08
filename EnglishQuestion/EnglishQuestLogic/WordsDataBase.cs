using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishQuestion.Logical 
{
    [System.Serializable]
    public class WordsDataBase : IComparable
    {
        private string _englishValue;
        private string _russianValue;
        private int _idValue;
        private bool _used;
        private bool _fakeUse;

        public WordsDataBase(string eng, string rus, int id)
        {
            _englishValue = eng;
            _russianValue = rus;
            _idValue = id;
        }

        public string EnglishWord {get { return _englishValue; } set { _englishValue = value; }}

        public string RussianWord{get { return _russianValue; } set { _russianValue = value; }}

        public int IdValue{get { return _idValue; } set { _idValue = value; }}

        public bool Used {get { return _used; } set { _used = value; }}
        public bool FakeUse { get { return _fakeUse; } set { _fakeUse = value; }}
        public int CompareTo(object obj)
        {
            WordsDataBase wdb = obj as WordsDataBase;
            if (wdb != null)
                return this._idValue.CompareTo(wdb._idValue);
            throw new NotImplementedException();
        }
    }
}
