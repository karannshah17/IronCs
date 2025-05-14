using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronCs.Interface
{
	public interface IPhonePadParser
	{
		/// <summary>
		/// Asynchronously parses an input string simulating  phone keypad presses.
		/// </summary>
		/// <param name="input">Keypad sequence ending with '#'</param>
		/// <returns>Task that resolves to decoded text</returns>
		Task<string> OldPhonePad(string input);
	}
}
