using System.ComponentModel;

namespace SolarSystemLibrary
{
    public enum ConstructSize
    {
        [Description("Tiny")]
        Tiny = 0,

        [Description("Small")]
        Small = 1,

        [Description("Average")]
        Average = 2,

        [Description("Large")]
        Large = 3,

        [Description("Gargantuan")]
        Gargantuan = 4,

        [Description("Megastructure")]
        Mega = 5
    }
}
