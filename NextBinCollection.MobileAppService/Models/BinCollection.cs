using System;
namespace NextBinCollection.MobileAppService.Models
{
    public class BinCollection
    {
        public string BinType { get; set; }
        public string CollectionDay { get; set; }
        public DateTime NextCollection { get; set; }
        public string Color { get; set; }
    }
}
