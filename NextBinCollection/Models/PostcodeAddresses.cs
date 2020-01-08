using System;
using System.Collections.Generic;

namespace NextBinCollection.Models
{
    public class PostcodeAddresses
    {
        public List<string> addresses { get; set; }

        public PostcodeAddresses()
        {
            addresses = new List<string>();
        }
    }
}
