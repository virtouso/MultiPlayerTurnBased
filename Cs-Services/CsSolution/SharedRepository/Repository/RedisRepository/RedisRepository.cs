using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedRepository.Repository.RedisRepository
{
    internal class RedisRepository : IRedisRepository
    {


        private IConnectionMultiplexer _redis;
        private IDatabase _database;
        public RedisRepository(string ip, int port)
        {
            _redis = ConnectionMultiplexer.Connect($"{ip}:{port}");
            _database = _redis.GetDatabase();
        }




        public bool GetValueFromSortedList(string listName, string key, out double value)
        {
            double? result = _database.SortedSetScore(listName, key);
            value = result == null ? 0 : result.Value;
            return true;
        }

        public bool SendValueToSortedList(string listName, string key, double value)
        {
            _database.SortedSetIncrement(listName, key, value);
            return true;
        }

        public bool SetKeyValue(string key, string value)
        {
            _database.StringSet(key, value);
            return true;
        }

        public bool GetValue(string key, out string value)
        {
            value = _database.StringGet(key);
            return true;
        }


        public bool GetSortedList(string listName, int topCount, out List<Tuple<string, double>> selectedList, bool ascending)
        {
            SortedSetEntry[] result = null;
            if (ascending)
            {
                result = _database.SortedSetRangeByRankWithScores(listName, 0, topCount, Order.Ascending);
            }
            else
            {
                result = _database.SortedSetRangeByRankWithScores(listName, 0, topCount, Order.Descending);
            }
            selectedList = new List<Tuple<string, double>>(result.Length);
            for (int i = 0; i < result.Length; i++)
            {
                selectedList.Add(new Tuple<string, double>(result[i].Element.ToString(), result[i].Score));
            }
            return true;
        }

    }
}
