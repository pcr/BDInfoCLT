//============================================================================
// BDInfo - Blu-ray Video and Audio Analysis Tool
// Copyright © 2010 Cinema Squid
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//=============================================================================

using BDInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using CommandLine;
using CommandLine.Text;
using System.Reflection;
using System.IO;

namespace BDInfoCLT
{
    static class Program
    {
        static void Main(string[] args)
        {
            var options = new MyOptions();
            // Parse in 'strict mode', success or quit
            if(CommandLine.Parser.Default.ParseArguments(args, options))
            {
                //validatePath(options.input);
                //validatePath(options.output);

                runner run = new runner();
                run.InitBDROM(options.input);

                //If mpsl specified, select playlist in a different way
                if (options.playlistsToScan != null)
                {
                    try
                    {
                        System.Console.WriteLine("-m or --mpls specified, running in non-interactive mode...");
                        System.Console.Write("Atempting to find ");
                        System.Console.Write(String.Join<String>(", ", options.playlistsToScan) + Environment.NewLine);
                        
                        run.SelectPlayList(options.playlistsToScan);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("ERROR: " + ex.Message);
                        Environment.Exit(-1);
                    }
                }
                else
                {
                    run.SelectPlayList();
                }
                
                run.AddStreamFilesInPlaylists();
                run.ScanBDROM();
                run.GenerateReport(options.output);
            }
        }

        //Returns 
        public static void validatePath(String pathName)
        {
            if (pathName == null)
            {
                System.Console.WriteLine("Usage: BDInfoCLT <BD Folder> <Save Path>");
                Environment.Exit(-1);
            }
            if(!Directory.Exists(pathName))
            {
                System.Console.WriteLine("folder '{0}' not found!", pathName);
                Environment.Exit(-1);
            }
        }
    }

    class MyOptions
    {
        [ValueOption(0)]
        public string input { get; set; }

        [ValueOption(1)]
        public string output { get; set; }

        [OptionList('m', "mpls", Required = false, HelpText = "Specify the playlists to scan, non-interactive")]
        public List<String> playlistsToScan { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText {
                Heading = new HeadingInfo("BDInfoCLT", (Assembly.GetExecutingAssembly().GetName().Version).ToString()),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine("Licensed under LGPL V2.1");
            help.AddPreOptionsLine("Usage: BDInfoCLT <BD Folder> <Save Path>");
            help.AddOptions(this);
            return help;
        }
    }
}


