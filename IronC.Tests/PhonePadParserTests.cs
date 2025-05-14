using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronCs;
using IronCs.Implentation;
using IronCs.Interface;

namespace IronC.Tests
{
	public class PhonePadParserTests
	{
		private  IPhonePadParser _parser;

		[SetUp]
		public void Setup()
		{
			_parser = new PhonePadParser();
		}

		[Test]
		public async Task OldPhonePad_ShouldReturnE_ForValidInput()
		{
			var result = await _parser.OldPhonePad("33#");
			Assert.AreEqual("E", result);
		}

		[Test]
		public async Task OldPhonePad_ReturnsTuring_Backspace()
		{
			var result = await _parser.OldPhonePad("8 88777444666*664#"); // * has backspace on keypad
			Assert.AreEqual("TURING", result);
		}

		[Test]
		public async Task OldPhonePad_IgnoresInvalidDigits()
		{
			string input = "11 4433555#"; // 1 is not valid so it should be ignored 
			string result = await _parser.OldPhonePad(input);
			Assert.AreEqual("HEL", result); // so only keys apart from 1 should be considered 
		}
	}
}
