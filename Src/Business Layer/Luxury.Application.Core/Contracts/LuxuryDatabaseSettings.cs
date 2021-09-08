namespace Luxury.Application.Core.Contracts
{
    public class LuxuryDatabaseSettings : ILuxuryDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string RoomsCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string ReservationCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
