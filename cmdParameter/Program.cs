
using System;
using System.Collections.Generic;
using cmdParameter.Models;

namespace cmdParameter
{
    class Program
    {
        private static List<ParameterOption> _options = new List<ParameterOption>
        {
            new ParameterOption { OptionName ="--a", RequireValue = true},
            new ParameterOption { OptionName ="--b", RequireValue = true},
            new ParameterOption { OptionName ="--c", RequireValue = false},
        };

        static void Main(string[] args)
        {
            var analyzer = new ParameterAnalyzer(args, _options);
            var optionValues = analyzer.GetOptionValues();
        }


    }
}
