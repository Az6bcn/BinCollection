using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NextBinCollection.MobileAppService.Models;
using NextBinCollection.MobileAppService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NextBinCollection.MobileAppService.Controllers
{
    [Route("api/postcode")]
    [ApiController]
    public class PostCodeAndAddressesController : ControllerBase
    {
        private readonly GetAddressesServices _getAddressesServices;
        public PostCodeAndAddressesController(GetAddressesServices getAddressesServices)
        {
            _getAddressesServices = getAddressesServices;
        }

        // GET: api/values
        [HttpGet("addresses/{postcode}")]
        public async Task<IActionResult> Get(string postcode)
        {
            return Ok(new
            {
                addresses = new List<string>
                {
                    "1 Blackdown Grove- - - - - Oldham- Lancashire",
                    "10 Blackdown Grove- - - - - Oldham- Lancashire",
                    "12 Blackdown Grove- - - - - Oldham- Lancashire",
                    "14 Blackdown Grove- - - - - Oldham- Lancashire",
                    "16 Blackdown Grove- - - - - Oldham- Lancashire",
                    "2 Blackdown Grove- - - - - Oldham- Lancashire",
                    "3 Blackdown Grove- - - - - Oldham- Lancashire",
                    "4 Blackdown Grove- - - - - Oldham- Lancashire",
                    "5 Blackdown Grove- - - - - Oldham- Lancashire",
                    "6 Blackdown Grove- - - - - Oldham- Lancashire",
                    "8 Blackdown Grove- - - - - Oldham- Lancashire"
                }
            });
            //var response = await _getAddressesServices.GetAddressForPostCode(postcode);

            //return Ok(response);
        }


        [HttpGet("manchestercouncils")]
        public IActionResult GetCouncilsInManchester()
        {
            return Ok(ManchesterCouncils.GetManchesterCouncils());
        }



        [HttpGet("address/bincollection")]
        public IActionResult GetBinColletionDetailsForPostCode(string postcode)
        {
            return Ok(
                new List<BinCollection>
                {
                    new BinCollection{ BinType = "Brown Bin", CollectionDay = "Thursday", NextCollection = new DateTime(2020,01,02), Color = "Brown" },
                    new BinCollection{ BinType = "Green Bin", CollectionDay = "Thursday", NextCollection = new DateTime(2020,01,02), Color = "Green"  },
                    new BinCollection{ BinType = "Grey Bin", CollectionDay = "Thursday", NextCollection = new DateTime(2020,01,09), Color = "Gray"  },
                    new BinCollection{ BinType = "Green Bin", CollectionDay = "Thursday", NextCollection = new DateTime(2020,01,09), Color = "Green"  },
                    new BinCollection{ BinType = "Blue Bin", CollectionDay = "Thursday", NextCollection = new DateTime(2020,01,16), Color = "#0080ff"  },
                    new BinCollection{ BinType = "Grey Bin", CollectionDay = "Thursday", NextCollection = new DateTime(2020,01,16), Color = "Brown"  }
                });
        }

    }
}
