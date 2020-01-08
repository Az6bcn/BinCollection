using System;
using System.Collections.Generic;

namespace NextBinCollection.MobileAppService.Models
{
    public class ManchesterCouncil
    {
        public int Id { get; set; }

        public string CouncilName { get; set; }
    }

    public static class ManchesterCouncils
    {

        public static IEnumerable<ManchesterCouncil> GetManchesterCouncils()
        {
            return new List<ManchesterCouncil>
            {
                new ManchesterCouncil
                {
                    Id = 0,
                    CouncilName = "Tameside"
                },
                new ManchesterCouncil
                {
                    Id = 1,
                    CouncilName = "Bolton"
                },
                new ManchesterCouncil
                {
                    Id = 2,
                    CouncilName = "Bury"
                },
                new ManchesterCouncil
                {
                    Id = 3,
                    CouncilName = "Manchester"
                },
                new ManchesterCouncil
                {
                    Id = 4,
                    CouncilName = "Oldham"
                },
                new ManchesterCouncil
                {
                    Id = 5,
                    CouncilName = "Rochdale"
                },new ManchesterCouncil
                {
                    Id = 6,
                    CouncilName = "Salford"
                },
                new ManchesterCouncil
                {
                    Id = 7,
                    CouncilName = "Tameside"
                },
                new ManchesterCouncil
                {
                    Id = 8,
                    CouncilName = "Trafford"
                },
                new ManchesterCouncil
                {
                    Id = 9,
                    CouncilName = "Wigan"
                }
            };
        }
    }
}
