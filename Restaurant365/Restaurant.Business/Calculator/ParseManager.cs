using Restaurant.Business.Enums;
using Restaurant.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Business.Calculator
{
    public interface IParseManager
    {
        /// <summary>
        /// Aggregates the request object
        /// </summary>
        /// <returns>CalcReqeustModel</returns>
        CalcRequestModel ParseRequest(string request);

        /// <summary>
        /// Parses the request into delimiters
        /// </summary>
        /// <returns>List of delimiters</returns>
        List<string> ParseDelimiters(string request);
    }

    public class ParseManager : IParseManager
    {
        private ParseConfigModel _config;

        public ParseManager(ParseConfigModel config)
        {
            _config = config;
        }

        public CalcRequestModel ParseRequest(string request)
        {
            var delimiters = ParseDelimiters(request);
            var numberString = GetNumberString(request); 
            return new CalcRequestModel()
            {
                Operation = _config.Operation,
                Numbers = SeparatedIntSet(numberString, delimiters)
            };
        }

        public string GetNumberString(string request)
        {
            if (!request.StartsWith("//")) return request;
            var beginning = request.IndexOf("\n") + 1;
            var numberString = request.Substring(beginning);
            return numberString;
        }

        public List<string> ParseDelimiters(string request)
        {
            var delimiters = new List<string> { "," };

            //NOTE: tricky wording on Stretch goal 3a: "Alternate" delimiter implies that it's XOR with "\n" but that would be counter to Requirement 8b
            // Requirements superceed stretch goals, so I left this in there.
            if (!string.IsNullOrEmpty(_config.AlternateDelimiter))
            {
                delimiters.Add(_config.AlternateDelimiter);
            }

            if (!request.StartsWith("//"))
            {
                delimiters.Add("\n");
                return delimiters;
            }

            var end = request.IndexOf("\n") - 2;
            var delimiterString = request.Substring(2,  end);
            if (!delimiterString.StartsWith("["))
            {
                delimiters.Add(delimiterString);
                return delimiters;
            }

            //Remove first and last "[" and "]"
            delimiterString = delimiterString.Substring(1);
            delimiterString = delimiterString.Substring(0, delimiterString.Length - 1);
            var extras = delimiterString.Split("][");

            delimiters.AddRange(extras);

            return delimiters;
        }

        private int ParseInt(string str, int defaultValue = 0)
        {
            int.TryParse(str, out defaultValue);
            return defaultValue;
        }

        private List<int> SeparatedIntSet(string str, IEnumerable<string> separators)
        {
            var separated = str.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var parsed = separated.Select(item => ParseInt(item));
            return parsed.ToList();
        }
    }
}
