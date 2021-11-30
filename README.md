BDInfo Command Line Toolkit
======

The main program is from BDInfo Project.
I Modified it to run in Windows's Command Line or Linux Shell with Mono.

Now, support BDMV folder & BDDisk ISO. 

I plan to improve the command param and help for more function, <p>
but the work is very busy, so the update will not be very regular.

------

  
<p><B>BDInfoCLT 0.7.5.8</B></p>

```
Licensed under LGPL V2.1<p>
Usage: BDInfoCLT [--version] [--help]
       BDInfoCLT <BD Folder/ISO File> [options]
	   
Options:

  --version                   Just show version of the program

  -f, --full-scan             Do a full scan

  -s, --simple                Output with simple mode

  --summary                   Generate summary in report

  -o <dir>, --output=<dir>    Output report to a folder

  -v                          (verbose) Print additional details.

  -m, --mpls                  Specify the playlists to scan, non-interactive

  -h, --help                  Display this help screen.
```


BDInfo
======

(source origin: http://www.cinemasquid.com/blu-ray/tools/bdinfo)
(I am not the original Author of BDInfo)

The BDInfo tool was designed to collect video and audio technical specifications from Blu-ray movie discs, including:

<ul>
<li>Disc Size</li>
<li>Playlist File Contents</li>
<li>Stream Codec and Bitrate Details</li>
</ul>

Requirements
======
<ul>
<li>Windows 7 or higher Operating System</li>
<li>Blu-ray BD-ROM Drive</li>
<li>.NET Framework 4.7.2 or Higher</li>
<li>Source Code</li>
</ul>

The BDInfo source code is licensed under the LGPL 2.1.<br>
The free tool <a href="http://www.microsoft.com/visualstudio/en-us/products/2010-editions/visual-csharp-express">Microsoft Visual C# 2010 Express</a> can be used to build the source code.


Known Issues
======

Occasionally inaccurate bit-depth measurement on Dolby TrueHD and DTS-HD Master audio streams.<br>
BDInfo will *NOT* function correctly with copy-protected discs. You will have to decrypt commercial Blu-ray movie discs before you will be able to gather any info.
