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

namespace BDInfo
{
    public class BDInfoSettings
    {
        public static bool MainFormHRSizeFormat
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.MainWindowHRSizeFormat; }
                catch { return true; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.MainWindowHRSizeFormat = value; }
                catch { }
            }
        }
        public static bool GenerateStreamDiagnostics
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.GenerateStreamDiagnostics; }
                catch { return true; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.GenerateStreamDiagnostics = value; }
                catch { }
            }
        }
        public static bool ExtendedStreamDiagnostics
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.ExtendedStreamDetails; }
                catch { return true; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.ExtendedStreamDetails = value; }
                catch { }
            }
        }

        public static bool EnableSSIF
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.EnableSSIF; }
                catch { return true; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.EnableSSIF = value; }
                catch { }
            }
        }

        public static bool AutosaveReport
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.AutosaveReport; }
                catch { return false; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.AutosaveReport = value; }
                catch { }
            }
        }

        public static bool GenerateFrameDataFile
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.GenerateFrameDataFile; }
                catch { return false; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.GenerateFrameDataFile = value; }
                catch { }
            }
        }

        public static bool FilterLoopingPlaylists
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.FilterLoopingPlaylists; }
                catch { return false; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.FilterLoopingPlaylists = value; }
                catch { }
            }
        }

        public static bool FilterShortPlaylists
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.FilterShortPlaylists; }
                catch { return false; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.FilterShortPlaylists = value; }
                catch { }
            }
        }

        public static int FilterShortPlaylistsValue
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.FilterShortPlaylistsValue; }
                catch { return 0; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.FilterShortPlaylistsValue = value; }
                catch { }
            }
        }

        public static bool UseImagePrefix
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.UseImagePrefix; }
                catch { return false; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.UseImagePrefix = value; }
                catch { }
            }
        }

        public static string UseImagePrefixValue
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.UseImagePrefixValue; }
                catch { return null; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.UseImagePrefixValue = value; }
                catch { }
            }
        }

        public static bool KeepStreamOrder
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.KeepStreamOrder; }
                catch { return false; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.KeepStreamOrder = value; }
                catch { }
            }
        }

        public static bool GenerateTextSummary
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.GenerateTextSummary; }
                catch { return false; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.GenerateTextSummary = value; }
                catch { }
            }
        }

        public static string LastPath
        {
            get
            {
                try { return BDInfoCLT.Properties.Settings.Default.LastPath; }
                catch { return ""; }
            }

            set
            {
                try { BDInfoCLT.Properties.Settings.Default.LastPath = value; }
                catch { }
            }
        }

        public static void SaveSettings()
        {
            try
            {
                BDInfoCLT.Properties.Settings.Default.Save();
            }
            catch { }
        }
    }
}