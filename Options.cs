using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Reflection;
using CommandLine;

namespace dupFinderEaser
{
    public class Options
    {
        [Option('d', "dupFinder", Required=true, HelpText = "Path to dupFinder app.")]
        public string DupFinderPath { get; set; }
        [Option('o', "outputDir", Required = true, HelpText = "Path to output dir.")]
        public string OutputDir { get; set; }
        [Option('e', "Exclude", Required = false, HelpText = "rules for exclude target files.")]
        public string Exclude { get; set; }
        [Option('f', "discard-fields", Required = false, HelpText = "see dupFinder help.")]
        public bool DiscardFields { get; set; }
        [Option('l', "discard-literals", Required = false, HelpText = "see dupFinder help.")]
        public bool DiscardLiterals { get; set; }
        [Option('v', "discard-local-vars", Required = false, HelpText = "see dupFinder help.")]
        public bool DiscardLocalVars { get; set; }
        [Option('t', "discard-types", Required = false, HelpText = "see dupFinder help.")]
        public bool DiscardTypes { get; set; }
        [Option('p', "properties", Separator = ';', Required = false, HelpText = "override msbuild properties.")]
        public IEnumerable<string> Properties { get; set; }
        [Value(1, MetaName = "Targets")]
        public IEnumerable<string> Targets { get; set; }
    }
}