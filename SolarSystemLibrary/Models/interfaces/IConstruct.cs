
namespace SolarSystemLibrary.Models
{
    public interface IConstruct
    {
        string ConstructType { get; set; }

        ConstructStatus ConstructStatus { get; set; }

        ConstructSize ConstructSize { get; set; }

        string Information { get; set; }
    }
}
