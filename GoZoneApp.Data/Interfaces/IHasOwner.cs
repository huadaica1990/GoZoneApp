namespace GoZoneApp.Infrastructure.Interfaces
{
    public interface IHasOwner<T>
    {
        T OwnerId { get; set; }
    }
}
