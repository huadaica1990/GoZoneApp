using GoZoneApp.Data.Enums;

namespace GoZoneApp.Infrastructure.Interfaces
{
    public interface ISwitchable
    {
        Status Status { get; set; }
    }
}
