using System;

namespace TechHealth.Model
{
    public class RandomGenerator
    {
        public RandomGenerator()
        {
        }

        public string GenerateRandHash()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}