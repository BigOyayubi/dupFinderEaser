using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Xsl;
using CommandLine;
using CommandLine.Text;

namespace dupFinderEaser
{
    public class OptParse
    {
        public static void Parse(string[] args)
        {
            var result = (ParserResult<Options>) Parser.Default.ParseArguments<Options>(args);
            if (result.Tag != ParserResultType.Parsed)
            {
                return;
            }

            new OptParse((result as Parsed<Options>).Value).Exec();
        }

        private Options _options;

        OptParse(Options opts)
        {
            _options = opts;
        }

        private string DupFinderPath => _options.DupFinderPath;
        private string OutputDir => _options.OutputDir;
        private string Exclude => _options.Exclude;
        private bool DiscardFields => _options.DiscardFields;
        private bool DiscardLiterals => _options.DiscardLiterals;
        private bool DiscardTypes => _options.DiscardTypes;
        private bool DiscardLocalVars => _options.DiscardLocalVars;
        private IEnumerable<string> Properties => _options.Properties;
        private IEnumerable<string> Targets => _options.Source;

        void Exec()
        {
            Console.WriteLine($"{nameof(Options.DupFinderPath)}    : {DupFinderPath}");
            Console.WriteLine($"{nameof(Options.OutputDir)}        : {OutputDir}");
            Console.WriteLine($"{nameof(Options.Exclude)}          : {Exclude}");
            Console.WriteLine($"{nameof(Options.DiscardFields)}    : {DiscardFields.ToString()}");
            Console.WriteLine($"{nameof(Options.DiscardLiterals)}  : {DiscardLiterals.ToString()}");
            Console.WriteLine($"{nameof(Options.DiscardTypes)}     : {DiscardTypes.ToString()}");
            Console.WriteLine($"{nameof(Options.DiscardLocalVars)} : {DiscardLocalVars.ToString()}");
            Console.WriteLine($"{nameof(Options.Properties)}       : {string.Join(';', Properties.ToArray())}");
            Console.WriteLine($"{nameof(Options.Source)}           : {string.Join(';', Targets.ToArray())}");

            if (!Targets.Any())
            {
                Console.WriteLine("Please set Targets");
                return;
            }

            ExecDupFinder(_options);
            MakeReportHtml(_options);
        }

        void MakeReportHtml(Options opts)
        {
            using (System.IO.StringReader reader = new System.IO.StringReader(dupFinderEaser.Properties.Resources.ReportXsl))
            {
                var xsl = System.Xml.XmlReader.Create(reader);
                var trans = new XslCompiledTransform();
                trans.Load(xsl);
                trans.Transform(opts.GetReportXmlPath(), opts.GetReportHtmlPath());
            }
        }

        void ExecDupFinder(Options opts)
        {
            var xmlPath = opts.GetReportXmlPath();
            try
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = opts.DupFinderPath;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    var args = new List<string>()
                    {
                        "--show-text",
                        $"--output=\"{xmlPath}\""
                    };
                    if (!string.IsNullOrEmpty(opts.Exclude)) args.Add($"--exclude=\"{opts.Exclude}\"");
                    if (opts.DiscardFields) args.Add("--discard-fields=true");
                    if (opts.DiscardLiterals) args.Add("--discard-literals=true");
                    if (opts.DiscardTypes) args.Add("--discard-types=true");
                    if (opts.DiscardLocalVars) args.Add("--discard-local-vars=true");
                    if (opts.Properties.Any()) args.Add($"--properties:{string.Join(';', opts.Properties)}");
                    args.Add(string.Join(' ', opts.Source));
                    process.StartInfo.Arguments = string.Join(" ", args);
                    Console.WriteLine($"args : {process.StartInfo.Arguments}");
                    Console.WriteLine("Wait for dupFinder app");
                    process.Start();
                    process.WaitForExit();
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("failed to exec dupFinder");
                Console.WriteLine(e.ToString());
            }
        }
    }
}