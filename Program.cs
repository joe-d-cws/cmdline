using System;
using System.Collections.Generic;
using System.Text;

namespace CmdLine
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineParser parser;
            char option;

            foreach (string arg in args)
            {
                Console.WriteLine("Arg: --{0}--", arg);
            }

            parser = new CommandLineParser("abcdef:g::h:i::j:k:", args);

            while (parser.OptionIndex < args.Length)
            {
                while ((option = parser.NextOption()) != '\0')
                {
                    if (option == '?')
                    {
                        Console.WriteLine("Option {0} invalid, or missing parameter", parser.OptionCharacter);
                    }
                    else
                    {
                        Console.WriteLine("Option: {0}", option);
                        Console.WriteLine("Parameter: {0}", (parser.OptionArgument != null ? parser.OptionArgument : ""));
                    }
                }
                if (parser.OptionIndex < args.Length)
                {
                    Console.WriteLine("Non-option: {0}", args[parser.OptionIndex]);
                    parser.OptionIndex++;
                }
            }

            Console.WriteLine("Help:\r\n{0}\r\n", parser.GetHelpMessage());
        }
    }
}
