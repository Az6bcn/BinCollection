using System;
using System.Collections.Generic;

namespace NextBinCollection.Models
{
    public class CouncilPostCodeRequest
    {
        public string Council { get; set; } = String.Empty;
        public ManchesterCouncil SelectedCouncil { get; set; }
        public string PostCode { get; set; } = String.Empty;
        public string SelectedAddress { get; set; }

    }
}
