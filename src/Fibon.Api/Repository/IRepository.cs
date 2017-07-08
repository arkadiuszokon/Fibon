using System;
using System.Collections.Generic;

namespace Fibon.Api.Repository
{
    public interface IRepository
    {
        void Insert(int number, int value);

        int? Get(int number);

    }

    public class RepositoryInMemory : IRepository
    {
        private readonly Dictionary<int, int> _storage = new Dictionary<int, int>();

        public int? Get(int number)
        {
            int value;
            if (_storage.TryGetValue(number, out value))
            {
                return value;
            }
            return null;
        }

        public void Insert(int number, int value)
        {
            _storage[number] = value;
        }
    }
}
