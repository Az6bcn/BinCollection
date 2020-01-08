using System;
namespace NextBinCollection.Models
{
    public class BinCollectionModel
    {
        public string BinType { get; set; }
        public string CollectionDay { get; set; }
        public DateTime NextCollection { get; set; }
        public string Color { get; set; }
    }
}
