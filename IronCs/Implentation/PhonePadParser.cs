using IronCs.Enums;
using IronCs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IronCs.Implentation
{
	/// <summary>
	/// Parses input from an older  phone keypad into corresponding text
	/// </summary>
	public class PhonePadParser:IPhonePadParser

	{
		/// <summary>
		/// Asynchronously parses a string representing key presses on a phone keypad.
		/// Interprets numbers (2–9, 0), space as pause, '*' as backspace, and '#' as send.
		/// </summary>
		/// <param name="input">A string of key presses ending with '#'.</param>
		/// <returns>A task representing the asynchronous operation. Returns the parsed string output.</returns>
		public async Task<string> OldPhonePad(string input)
		{
			return await Task.Run(() =>
			{
				var result = new StringBuilder();
				var buffer = new List<char>();

				foreach (char c in input)
				{
					switch (c)
					{
						case ' ':
							// Pause = process current sequence
							if (buffer.Count > 0)
							{
								char letter = ProcessKeyPad(buffer);
								if (letter != '\0')
									result.Append(letter);
								buffer.Clear();
							}
							break;

						case '*':
							// Backspace
							if (buffer.Count > 0)
							{
								buffer.Clear(); // Cancel current buffer
							}
							else if (result.Length > 0)
							{
								result.Remove(result.Length - 1, 1);
							}
							break;

						case '#':
							// End of input = process last buffer
							if (buffer.Count > 0)
							{
								char letter = ProcessKeyPad(buffer);
								if (letter != '\0')
									result.Append(letter);
							}
							return result.ToString();

						default:
							// If digit changes, flush the current buffer
							if (buffer.Count > 0 && buffer[0] != c)
							{
								char letter = ProcessKeyPad(buffer);
								if (letter != '\0')
									result.Append(letter);
								buffer.Clear();
							}
							buffer.Add(c);
							break;
					}
				}

				// Fallback in case # was missing
				if (buffer.Count > 0)
				{
					char letter = ProcessKeyPad(buffer);
					if (letter != '\0')
						result.Append(letter);
				}

				return result.ToString();
			});
		}

		/// <summary>
		///		Processes a sequence of repeated digit characters into a single letter as per old mobile keypad
		/// </summary>
		/// <param name="sequence"></param>
		/// <returns></returns>
		private char ProcessKeyPad(List<char> sequence)
		{
			if (sequence.Count == 0)
				return '\0';

			char number = sequence[0];
			int count = sequence.Count;

			if (!Enum.TryParse($"Key{number}", out Key keyEnum))
				return '\0';

			string letters = GetStringFromEnum(keyEnum);

			return letters.Length > 0
				? letters[(count - 1) % letters.Length]
				: '\0';
		}
		/// <summary>
		///		retrieve the keypad letters associated with a given key enum.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		private string GetStringFromEnum(Key key)
		{
			FieldInfo field = typeof(Key).GetField(key.ToString());
			var attribute = field?.GetCustomAttribute<KeypadAttribute>();
			return attribute?.Letters ?? "";
		}
	}
}
