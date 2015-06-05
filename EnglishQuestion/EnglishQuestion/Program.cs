using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using EnglishQuestion.Logical;

namespace EnglishQuestion
{
    class Program
    {
        static WordsDataBase[] wdbBase = new WordsDataBase[12];
        private static IPlayer _newPlayer;
        private static ConsoleHud _consoleLogic;
        private static SaveLoadClass _sNloadClass = new SaveLoadClass();


        static void Main(string[] args)
        {
            CreateWdb();
            _sNloadClass.SaveWordsBase(wdbBase);
            _newPlayer = new TwoPlayers();

            WordsDataBase[] workWdb = _sNloadClass.LoadWordsBase();
            _consoleLogic = new ConsoleHud(workWdb,_newPlayer, 12, true, true);
            int count = 0;
            _consoleLogic.GetStartGame();

            Console.ReadLine();
        }

        static void CreateWdb()
        {
            wdbBase[0] = new WordsDataBase("Apple", "Яблоко", 0);
            wdbBase[1] = new WordsDataBase("Cherry", "Вишня", 1);
            wdbBase[2] = new WordsDataBase("Room", "Комната", 3);
            wdbBase[3] = new WordsDataBase("Table", "Стол", 4);
            wdbBase[4] = new WordsDataBase("Orange", "Апельсин", 5);
            wdbBase[5] = new WordsDataBase("Pen", "Ручка", 6);
            wdbBase[6] = new WordsDataBase("Father","Отец", 7);
            wdbBase[7] = new WordsDataBase("Mather", "Мать",8);
            wdbBase[8] = new WordsDataBase("Book","Книга", 9);
            wdbBase[9] = new WordsDataBase("Daybook","Дневник",10);
            wdbBase[10] = new WordsDataBase("Board","Доска",11);
            wdbBase[11] = new WordsDataBase("Teacher","Учитель",12);
        }
    }
}
