using System;

namespace ProvaPub.Services
{
	public class RandomService
	{
        Random seed;
		public RandomService()
		{
            seed = new Random(Guid.NewGuid().GetHashCode());
        }
		public int GetRandom()
		{
			var result = seed.Next(100);
			return result;
		}

	}
}
