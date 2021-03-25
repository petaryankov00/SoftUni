using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class Validator
    {
        public static void IsStatInRange(int min, int max, int value, string exceptionMessage)
        {
            if (value < min || value > max)
            {
                throw new InvalidOperationException(exceptionMessage);
            }
        }
    }
}
