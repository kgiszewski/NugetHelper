using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NugetHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            //args
            //0 = "dist\\lib\\net471\\Some.dll"
            //1 = "Package.nuspec"

            Console.WriteLine($"Looking for assembly: {args[0]}");

            var fileVersion = FileVersionInfo.GetVersionInfo(args[0]).FileVersion;

            Console.WriteLine($"Found version: {fileVersion}");
            
            //update the nuspec
            var nuspecDoc = new XmlDocument();

            Console.WriteLine($"Looking for nuspec: {args[1]}");

            nuspecDoc.Load(args[1]);

            var versionNode = nuspecDoc.SelectSingleNode("//version");

            if (versionNode != null)
            {
                versionNode.InnerText = fileVersion;

                Console.WriteLine("Saving...");

                nuspecDoc.Save(args[1]);
            }
            else
            {
                Console.WriteLine("Could not find the version node.");
            }
        }
    }
}
