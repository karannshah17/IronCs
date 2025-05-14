// See https://aka.ms/new-console-template for more information
using IronCs.Implentation;
using IronCs.Interface;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");
var services = new ServiceCollection();
services.AddSingleton<IPhonePadParser, PhonePadParser>();

var provider = services.BuildServiceProvider();
var parser = provider.GetRequiredService<IPhonePadParser>();

// Call parser
string output = await parser.OldPhonePad("222 2 22#");
Console.WriteLine(output);
string output2 = await parser.OldPhonePad("4433555 555666#");
Console.WriteLine(output2);
string output3 = await parser.OldPhonePad("8 88777444666*664#");
Console.WriteLine(output3);