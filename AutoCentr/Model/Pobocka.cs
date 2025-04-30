using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCentr.Model;

public enum Pobocka
{
    [JsonProperty("Praha")]
    Praha,
    [JsonProperty("Pardubice")]
    Pardubice,
    [JsonProperty("Olomouc")]
    Olomouc,
    [JsonProperty("Ostrava")]
    Ostrava,
    [JsonProperty("Plzen")]
    Plzen,
    [JsonProperty("Kolin")]
    Kolin,
    [JsonProperty("Brno")]
    Brno,
    [JsonProperty("Jihlava")]
    Jihlava,
    [JsonProperty("Liberec")]
    Liberec,
    [JsonProperty("Zlin")]
    Zlin
}
public static class EnumHelper
{
    public static T[] GetEnumValues<T>() where T : Enum
    {
        return (T[])Enum.GetValues(typeof(T));
    }
}
