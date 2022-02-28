using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedRepository.Repository.RedisRepository
{
    public interface IRedisRepository
    {
        bool SetKeyValue(string key, string value);
        bool GetValue(string key, out string value);
        bool SendValueToSortedList(string listName,string key, double value);
        bool GetValueFromSortedList(string listName, string key, out double value);
        bool GetSortedList(string listName,int topCount,  out List<Tuple<string, double>> selectedList, bool ascending  );


    }
}
