using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace dupFinderEaser
{
    public static class Helper
    {
        public static string GetReportXmlPath(this Options opts)
        {
            return System.IO.Path.Join(opts.OutputDir, "report.xml");
        }

        public static string GetReportHtmlPath(this Options opts)
        {
            return System.IO.Path.Join(opts.OutputDir, "report.html");
        }

   }
}