# dupFinderEaser

create report html from dupFinder result xml

# QuickStart

```bat
> dotnet publish -c Release -r win-x64
> cd bin\Release\netcoreapp3.0\win-x64\publish
> dupFinderEaser.exe --help
USAGE:
Create HTML from dupFinder report xml:
  dupFinderEaser --dupFinder c:\CLT\dupfinder.exe --outputDir c:\output c:\sources\\**\*.cs

  -d, --dupFinder             Required. Path to dupFinder app.

  -o, --outputDir             Required. Path to output dir.

  -e, --Exclude               rules for exclude target files.

  -f, --discard-fields        see dupFinder help.

  -l, --discard-literals      see dupFinder help.

  -v, --discard-local-vars    see dupFinder help.

  -t, --discard-types         see dupFinder help.

  -p, --properties            override msbuild properties.

  --help                      Display this help screen.

  --version                   Display version information.

  Source (pos. 0)             rule of finding sources.
> dupFinderEaser.exe -d c:\CLT\dupfinder.exe -o c:\tmp\Output c:\Sources\your\pj\\**\*.cs
```

you will see report.html in c:\tmp\Output\report.html

# See Also

* https://pleiades.io/help/resharper/dupFinder.html


