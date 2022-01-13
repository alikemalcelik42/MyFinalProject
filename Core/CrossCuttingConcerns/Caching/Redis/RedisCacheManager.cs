using ServiceStack;
using ServiceStack.Redis;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        public void Add(string key, object value, int duration)
        {
            using (RedisClient redisClient = new RedisClient())
            {
                redisClient.Set(key, value, DateTime.Now.AddMinutes(duration));
            }
        }

        public T Get<T>(string key)
        {
            using (RedisClient redisClient = new RedisClient())
            {
                return redisClient.Get<T>(key);
            }
        }

        public object Get(string key)
        {
            using (RedisClient redisClient = new RedisClient())
            {
                return redisClient.Get<object>(key);
            }
        }

        public bool IsAdd(string key)
        {
            using (RedisClient redisClient = new RedisClient())
            {
 
                return redisClient.Get<object>(key) != null;
            }
        }

        public void Remove(string key)
        {
            using (RedisClient redisClient = new RedisClient())
            {
                redisClient.Remove(key);
            }
        }

        public void RemoveByPattern(string pattern)
        {
            using (RedisClient redisClient = new RedisClient())
            {
                var keys = redisClient.GetAllKeys();

                var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var keysToRemove = keys.Where(d => regex.IsMatch(d)).Select(d => d).ToList();

                foreach (string key in keysToRemove)
                {
                    redisClient.Remove(key);
                }
            }
        }
    }
}
