using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class Locker
    {
        //private object _data;
        private readonly string _keyword;
        private readonly int _id;
        private readonly string  _passwordOfCleanData; // решил реализовать, что клиент может сказать секретную фразу, и она стирает data и его ячейки

        public override int GetHashCode()
        {
            return _id.GetHashCode() ^ _keyword.GetHashCode();
        }

       public override bool Equals(object obj)
        {
            return obj == _passwordOfCleanData;                
        }

        public Locker(int id, string keyword)
        {
            _id = id;
            _keyword = keyword;
        }
        public Locker(int id, string keyword, string passwordOfCleanData)
        {
            _id = id;
            _keyword = keyword;
            _passwordOfCleanData = passwordOfCleanData;
        }

        public int Id => _id;
        public string GetPassword => _passwordOfCleanData;

        public bool Matches(int id, string keyword)
        {
            return (id.GetHashCode()^keyword.GetHashCode()) == GetHashCode();
        }
    }
}
