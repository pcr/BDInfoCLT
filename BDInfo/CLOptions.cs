using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace BDInfoCLT
{
    public class CLOptions
    {
        [ValueOption(0)]
        public string input { get; set; }

        //[ValueOption(1)]
        //public string output { get; set; }

        [Option("version", Required = false, HelpText = "Just show version of the program")]
        public bool showVersion { get; set; }

        [Option('f', "full-scan", Required = false, HelpText = "Do a full scan")]
        public bool fullScan { get; set; }

        [Option('s', "simple", Required = false, HelpText = "Output with simple mode")]
        public bool simpleMode { get; set; }

        [Option("summary", Required = false, HelpText = "Generate summary in report")]
        public bool genSummary { get; set; }

        [Option('o', "output", MetaValue ="<dir>", Required = false, HelpText = "Output report to a folder")]
        public string output { get; set; }

        [Option('v', Required = false, HelpText = "(verbose) Print additional details.")]
        public bool verbose { get; set; }

        [HelpOption('h', "help")]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("BDInfoCLT", (Assembly.GetExecutingAssembly().GetName().Version).ToString()),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine("Licensed under LGPL V2.1");
            help.AddPreOptionsLine("Usage: BDInfoCLT [--version] [--help]");
            help.AddPreOptionsLine("       BDInfoCLT <BD Folder/ISO File> [options]");
            help.AddPreOptionsLine(Environment.NewLine);
            help.AddPreOptionsLine("Options:");
            help.AddOptions(this);
            return help;
        }

        [OptionList('m', "mpls", Required = false, HelpText = "Specify the playlists to scan, non-interactive")]
        public List<String> playlistsToScan { get; set; }

        public void printVersion()
        {
            Console.WriteLine("BDInfoCLT {0}", (Assembly.GetExecutingAssembly().GetName().Version).ToString());
        }

        public int validate()
        {
            if (showVersion)
            {
                return 1;
            }

            var helpPair = CommandLine.Infrastructure.ReflectionHelper.RetrieveMethod<HelpOptionAttribute>(this);

            // Input
            if (input == null)
            {
                string helpText;
                HelpOptionAttribute.InvokeMethod(this, helpPair, out helpText);
                Console.Error.Write(helpText);
                return -1;
            }
            if (!Directory.Exists(input) && !File.Exists(input))
            {
                Console.Error.WriteLine("'{0}' is not exist or no permission to access!", input);
                return -1;
            }

            // Output
            if (output != null && !Directory.Exists(output))
            {
                Console.Error.WriteLine(" Output folder '{0}' is not exist.", output);
                return -1;
            }

            return 0;
        }
    }
}
