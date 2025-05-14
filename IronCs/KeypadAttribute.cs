using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronCs
{
	[AttributeUsage(AttributeTargets.Field)]
	internal class KeypadAttribute : Attribute
	{
		public string Letters { get; }

		public KeypadAttribute(string letters)
		{
			Letters = letters;
		}
	}
}
