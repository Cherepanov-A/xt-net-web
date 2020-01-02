using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class RegPatterns
    {
        internal static List<string> DateFinder(string text)
        {
            var dateFind = new Regex(@"([0-2]\d|3[01])-(0\d|1[0-2])-\d{4}");
            var results = dateFind.Matches(text);
            var result = new List<string>();
            if (results.Count > 0)
            {
                result.Add($"Text \"{text}\" contains date.");
            }
            else
            {
                result.Add($"Text \"{text}\" doesn't contains date.");
            }
            return result;
        }

        internal static List<string> HtmlReplaser(string text)
        {
            var htmlReplase = new Regex(@"(<.*?>)");
            var results = htmlReplase.Matches(text);
            var tmp = string.Empty;
            var result = new List<string>();
            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    tmp = htmlReplase.Replace(text, " ");
                }
                result.Add(tmp);
            }
            else
            {
                result.Add(text);
            }
            return result;
        }

        internal static List<string> EmailFinder(string text)
        {
            var emailFind = new Regex("(([a-z]|\\d)(\\w|\\d|\\.|-)*([a-z]|\\d)@([a-z]{2,6})\\.(([a-z]|\\d)([a-z]|\\d|-)*([a-z]|\\d)*\\.)?[a-z]{2,3})");
            var results = emailFind.Matches(text);
            var result = new List<string>();
            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    result.Add(results[i].Value);
                }
            }
            else
            {
                result.Add("No emails found");
            }
            return result;
        }

        internal static List<string> TimeCounter(string text)
        {
            var tCount = new Regex(@"((0?\d)|(2[0, 3])|(1\d)):([0, 5]\d)");
            var results = tCount.Matches(text);
            var result = new List<string>();
            result.Add($"Time was found {results.Count} time(s)");
            return result;
        }

        internal static List<string> NumberValidator(string text)
        {
            var scienceNum = new Regex(@"-?\d*(\.\d*)?e-?\d*");
            var regularNum = new Regex(@"-?\d*(\.\d*)?");
            var resultsS = scienceNum.Matches(text);
            var resultsR = regularNum.Matches(text);
            var result = new List<string>();
            if (resultsS.Count > 0)
            {
                result.Add($"{resultsS[0]} is a science format");
                return result;
            }
            else if (resultsR.Count > 0)
            {                
                result.Add($"{resultsR[0]} is a regular format");                
                return result;
            }
            else
            {
                result.Add($"{text} is not a number");
                return result;
            }
        }
    }
}
