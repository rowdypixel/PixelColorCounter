using System;
using System.Drawing;
using System.IO;
using CommandLine;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PixelColorCounter
{
    class Program
    {
        static void Main(string[] args)
        {

            CommandLine.Parser.Default.ParseArguments<Options>(args)
            .WithParsed(RunOptions)
            .WithNotParsed(HandleParseError);
            Console.ReadKey();
        }

        static void RunOptions(Options opts)
        {
            Console.WriteLine($"Scanning {opts.InputFile}");


            var colorToTrack = Rgba32.ParseHex("ff0000");
            long coloredPixels = 0;

            using (var image = Image.Load<Rgba32>(opts.InputFile))
            {
                var total = image.Width * (long)image.Height;
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        if (image[x, y] == colorToTrack)
                            coloredPixels++;

                    }
                }

                var percentage = (decimal)coloredPixels / total;

                Console.WriteLine($"Color Pixels: {coloredPixels:N0}");
                Console.WriteLine($"Total Pixels: {total:N0}");
                Console.WriteLine($"Color Percentage: {percentage:P}");
            }
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine("Could not parse command line options");
        }
    }
}