using cmdParameter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cmdParameter
{
    public class ParameterAnalyzer
    {
        private string[] _parameters;

        private IEnumerable<ParameterOption> _options;

        public ParameterAnalyzer(string[] parameters, IEnumerable<ParameterOption> options)
        {
            _parameters = parameters;
            _options = options;
        }

        public IEnumerable<ParameterOptionValue> GetOptionValues()
        {
            var result = new List<ParameterOptionValue>();
            var optionRequireValues = _options.ToDictionary(x => x.OptionName, x => x.RequireValue);
            for (var i = 0; i < _parameters.Length; i++)
            {
                var optionValue = new ParameterOptionValue();
                if (optionRequireValues.ContainsKey(_parameters[i]))
                {
                    optionValue.OptionName = _parameters[i];
                    optionValue.RequireValue = optionRequireValues[_parameters[i]];
                    if (optionRequireValues[_parameters[i]] && i + 1 < _parameters.Length && !optionRequireValues.ContainsKey(_parameters[i + 1]))
                    {
                        optionValue.Value = _parameters[i + 1];
                        i += 1;
                    }
                }
                else
                {
                    optionValue.Value = _parameters[i];
                }
                result.Add(optionValue);
            }
            return result;
        }
    }
}
