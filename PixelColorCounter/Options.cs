using System;
using CommandLine;

namespace PixelColorCounter
{
	public class Options
	{
        [Option(
            Required = true,
            HelpText = "The image file to process")]
        public string InputFile { get; set; }

        [Option(
            Default = "ff0000",
            Required = false,
            HelpText = "A hex color code to look for in the file")]
        public string Color { get; set; }
    }
}

