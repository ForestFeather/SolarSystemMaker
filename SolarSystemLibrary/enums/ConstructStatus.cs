using System.ComponentModel;

namespace SolarSystemLibrary
{
    public enum ConstructStatus
    {
        [Description("Active")]
        Active = 0,

        [Description("Under Construction")]
        UnderConstruction = 1,

        [Description("Abandoned")]
        Vacuum = 2,
    }
}
