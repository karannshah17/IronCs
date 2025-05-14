using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronCs.Enums
{
	/// <summary>
	///		ennumeration which simulates mobile keypad as per its keys 
	/// </summary>
		public enum Key
		{
			[Keypad("")]
			Key1 = '1',

			[Keypad("ABC")]
			Key2 = '2',

			[Keypad("DEF")]
			Key3 = '3',

			[Keypad("GHI")]
			Key4 = '4',

			[Keypad("JKL")]
			Key5 = '5',

			[Keypad("MNO")]
			Key6 = '6',

			[Keypad("PQRS")]
			Key7 = '7',

			[Keypad("TUV")]
			Key8 = '8',

			[Keypad("WXYZ")]
			Key9 = '9',

			[Keypad(" ")]
			Key0 = '0',
		}
	}

