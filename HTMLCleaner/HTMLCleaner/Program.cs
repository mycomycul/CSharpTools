using System;
using System.Text.RegularExpressions;
using System.Web;

namespace HTMLCleaner
{
    class Program
    {

        //Simple program that removes all html brackets from html code 
        //Execute from console or using debug build arguements
        
        //Arg 0 = the file to clean  Arg1 = where to save the file
        static void Main(string[] args)
        {
            string HTMLtoClean = System.IO.File.ReadAllText(args[0]);
            string cleanedText = CleanFromHTML(HTMLtoClean);

            System.IO.File.WriteAllText(args[1], cleanedText);
        }

        static string CleanFromHTML(string stringToClean)
        {
            Regex HTMLCommentRegEx = new Regex("<[^>]*>", RegexOptions.IgnoreCase);
            stringToClean = HTMLCommentRegEx.Replace(HttpUtility.HtmlDecode(stringToClean).Replace("\n", String.Empty), "");
            return stringToClean;
        }
    }
}
