using System;

namespace FortniteChecker.Models
{
    class FortniteAccountFullData
    {
        public FortniteAccount AccountData { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        
        public DateTimeOffset LastUpdate { get; set; }

        public string AccountId { get; set; }

        public bool HasBattlePassPurchased { get; set; }

        public long CurrentBattlePassLevel { get; set; }

        public long LifetimeTotalWins { get; set; }

        public long CurrentSeasonalLevel { get; set; }

        public long AccountLevel { get; set; }

        // NOTE: The reason this (and other type of skins) is a string is because Csv Helper doesn't support List<T>, unless manually written fields
        public string Outfits { get; set; }

        public string Backblings { get; set; }

        public string Gliders { get; set; }
        
        public string Pickaxes { get; set; }
    }

    class OldSeason
    {
        public long SeasonNumber { get; set; }

        public long SeasonWins { get; set; }

        public long SeasonLevel { get; set; }

        public bool PurchasedBattlePass { get; set; }

        public long BattlePassLevel { get; set; }
    }
}
