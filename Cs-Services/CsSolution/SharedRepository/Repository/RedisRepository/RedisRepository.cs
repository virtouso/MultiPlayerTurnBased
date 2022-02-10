using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedRepository.Repository.RedisRepository
{
    internal class RedisRepository:IRedisRepository
    {

        public RedisRepository()
        {
            IConnectionMultiplexer redis = ConnectionMultiplexer.Connect("10.0.75.1");
            services.AddScoped(s => redis.GetDatabase());
        }


    }
}
