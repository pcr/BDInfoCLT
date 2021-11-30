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
            var options = new CLOptions();

            // Parse in 'strict mode', success or quit
            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Environment.Exit(-1);
            }

            int ret = options.validate();
            if (ret != 0)
            {
                Environment.Exit(ret);
            }

            if (options.showVersion)
            {
                options.printVersion();
                Environment.Exit(0);
            }

            runner run = new runner();
            run.InitBDROM(options);

            //If mpsl specified, select playlist in a different way
            if (options.playlistsToScan != null)
            {
                try
                {
                    if (options.verbose)
                    {
                        Console.WriteLine("-m or --mpls specified, running in non-interactive mode...");
                        Console.Write("Atempting to find ");
                        Console.Write(String.Join<String>(", ", options.playlistsToScan) + Environment.NewLine);
                    }

                    run.SelectPlayList(options.playlistsToScan);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("ERROR: " + ex.Message);
                    Environment.Exit(-1);
                }
            }
            else
            {
                run.SelectPlayList();
            }

            run.AddStreamFilesInPlaylists();
            run.ScanBDROM(options.fullScan);

            run.GenerateReport(options);
        }
    }
}


