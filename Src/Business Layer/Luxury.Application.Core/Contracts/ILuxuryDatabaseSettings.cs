namespace Luxury.Application.Core.Contracts
{
    public interface ILuxuryDatabaseSettings
    {
        string CategoryCollectionName { get; set; }
        string RoomsCollectionName { get; set; }
        string CustomerCollectionName { get; set; }
        string ReservationCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
