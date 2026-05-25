using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciService.Utilities
{
	public class Fibonacci
	{
		public async Task<int> FibonnacciCalculator(int n)
		{
			if (n <= 1) return n;
			return await FibonnacciCalculator(n - 1) + await FibonnacciCalculator(n - 2);
		}
	}
}
