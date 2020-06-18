using CsvToJson.Constants;
using CsvToJson.Interfaces;
using CsvToJson.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CsvToJson
{
    class Program
    {
        static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConverterService, ConverterService>()
                .BuildServiceProvider();

            var originalFileFormat = "";
            Console.WriteLine("What file type would you like to convert from?");

            while (!FileFormats.All.Contains(originalFileFormat) || originalFileFormat != FileFormats.Csv)
            {
                FileFormats.All.ForEach(fileFormat => Console.WriteLine(fileFormat));

                originalFileFormat = Console.ReadLine().ToUpper();

                if (originalFileFormat != FileFormats.Csv)
                    Console.WriteLine("{0} is not available to convert from. Please select another.", originalFileFormat);
            }

            Console.WriteLine("What file type would you like to convert to?");
            var chosenFileFormat = "";
            while (!FileFormats.All.Contains(chosenFileFormat) || chosenFileFormat != FileFormats.Json)
            {
                FileFormats.All.ForEach(fileFormat => Console.WriteLine(fileFormat));

                chosenFileFormat = Console.ReadLine().ToUpper();

                if (chosenFileFormat != FileFormats.Json)
                    Console.WriteLine("{0} is not available to convert to. Please select another.", chosenFileFormat);
            }

            Console.WriteLine("Please enter the {0}'s file path.", originalFileFormat);

            string filePath = Console.ReadLine();
            var converterService = serviceProvider.GetService<IConverterService>();
            string json;

            switch (chosenFileFormat)
            {
                case FileFormats.Json:
                    json = converterService.ConvertCsvToJson(filePath);
                    break;
                default:
                    json = converterService.ConvertCsvToJson(filePath);
                    break;
            }

            Console.WriteLine(json);

            Console.WriteLine("Please press any key to exit.");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}

