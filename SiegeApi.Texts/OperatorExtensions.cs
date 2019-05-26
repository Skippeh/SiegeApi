using SiegeApi.Models;
using SiegeApi.Texts.Data;

namespace SiegeApi.Texts
{
    public static class OperatorExtensions
    {
        public static string GetGadgetDescription(this Operator source, string gadgetName, string language)
        {
            if (!GadgetDescriptions.Data.TryGetValue(language, out var languageData))
                return gadgetName;

            return !languageData.TryGetValue(gadgetName, out var result) ? gadgetName : result;
        }
    }
}