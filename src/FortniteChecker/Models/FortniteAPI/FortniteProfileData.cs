using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FortniteChecker.Models.FortniteAPI
{
    class FortniteProfileData
    {
        [JsonProperty("profileRevision")] public long ProfileRevision { get; set; }

        [JsonProperty("profileId")] public string ProfileId { get; set; }

        [JsonProperty("profileChangesBaseRevision")]
        public long ProfileChangesBaseRevision { get; set; }

        [JsonProperty("profileChanges")] public List<ProfileChange> ProfileChanges { get; set; }

        [JsonProperty("profileCommandRevision")]
        public long ProfileCommandRevision { get; set; }

        [JsonProperty("serverTime")] public DateTimeOffset ServerTime { get; set; }

        [JsonProperty("responseVersion")] public long ResponseVersion { get; set; }
    }

    public class ProfileChange
    {
        [JsonProperty("changeType")] public string ChangeType { get; set; }

        [JsonProperty("profile")] public Profile Profile { get; set; }
    }

    public class Profile
    {

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }

        [JsonProperty("rvn")]
        public long Rvn { get; set; }

        [JsonProperty("wipeNumber")]
        public long WipeNumber { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("profileId")]
        public string ProfileId { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("items")]
        public Dictionary<string, ItemDetails> Item { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("commandRevision")]
        public long CommandRevision { get; set; }
    }

    public class ItemDetails
    {
        [JsonProperty("templateId")]
        public string TemplateId { get; set; }

        //[JsonProperty("attributes")]
        //public ItemAttributes Attributes { get; set; }

        //[JsonProperty("quantity")]
        //public long Quantity { get; set; }
    }

    //public  class ItemAttributes
    //{
    //    [JsonProperty("level")]
    //    public long Level { get; set; }

    //    [JsonProperty("item_seen")]
    //    public bool ItemSeen { get; set; }

    //    [JsonProperty("completion_battlepass_interact_athena_hidden_star_03", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? CompletionBattlepassInteractAthenaHiddenStar03 { get; set; }

    //    [JsonProperty("sent_new_notification")]
    //    public bool SentNewNotification { get; set; }

    //    [JsonProperty("challenge_bundle_id")]
    //    public string ChallengeBundleId { get; set; }

    //    [JsonProperty("challenge_linked_quest_given")]
    //    public string ChallengeLinkedQuestGiven { get; set; }

    //    [JsonProperty("quest_state")]
    //    public QuestState QuestState { get; set; }

    //    [JsonProperty("last_state_change_time")]
    //    public DateTimeOffset LastStateChangeTime { get; set; }

    //    [JsonProperty("challenge_linked_quest_parent")]
    //    public string ChallengeLinkedQuestParent { get; set; }

    //    [JsonProperty("max_level_bonus")]
    //    public long MaxLevelBonus { get; set; }

    //    [JsonProperty("xp")]
    //    public long Xp { get; set; }

    //    [JsonProperty("favorite")]
    //    public bool Favorite { get; set; }
    //}

    public class Stats
    {
        [JsonProperty("attributes")]
        public StatsAttributes Attributes { get; set; }
    }

    public class StatsAttributes
    {
        [JsonProperty("past_seasons")]
        public List<PastSeason> PastSeasons { get; set; }

        [JsonProperty("season_match_boost")]
        public long SeasonMatchBoost { get; set; }

        [JsonProperty("favorite_victorypose")]
        public string FavoriteVictorypose { get; set; }

        [JsonProperty("quest_manager")]
        public QuestManager QuestManager { get; set; }

        [JsonProperty("book_level")]
        public long BookLevel { get; set; }

        [JsonProperty("season_num")]
        public long SeasonNum { get; set; }

        [JsonProperty("favorite_consumableemote")]
        public string FavoriteConsumableemote { get; set; }

        [JsonProperty("banner_color")]
        public string BannerColor { get; set; }

        [JsonProperty("favorite_callingcard")]
        public string FavoriteCallingcard { get; set; }

        [JsonProperty("favorite_character")]
        public string FavoriteCharacter { get; set; }

        [JsonProperty("favorite_spray")]
        public List<object> FavoriteSpray { get; set; }

        [JsonProperty("book_xp")]
        public long BookXp { get; set; }

        [JsonProperty("favorite_loadingscreen")]
        public string FavoriteLoadingscreen { get; set; }

        [JsonProperty("season")]
        public Season Season { get; set; }

        [JsonProperty("book_purchased")]
        public bool BookPurchased { get; set; }

        [JsonProperty("lifetime_wins")]
        public long LifetimeWins { get; set; }

        [JsonProperty("favorite_hat")]
        public string FavoriteHat { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("favorite_battlebus")]
        public string FavoriteBattlebus { get; set; }

        [JsonProperty("favorite_mapmarker")]
        public string FavoriteMapmarker { get; set; }

        [JsonProperty("favorite_vehicledeco")]
        public string FavoriteVehicledeco { get; set; }

        [JsonProperty("accountLevel")]
        public long AccountLevel { get; set; }

        [JsonProperty("favorite_backpack")]
        public string FavoriteBackpack { get; set; }

        [JsonProperty("favorite_dance")]
        public List<string> FavoriteDance { get; set; }

        [JsonProperty("inventory_limit_bonus")]
        public long InventoryLimitBonus { get; set; }

        [JsonProperty("favorite_skydivecontrail")]
        public string FavoriteSkydivecontrail { get; set; }

        [JsonProperty("favorite_pickaxe")]
        public string FavoritePickaxe { get; set; }

        [JsonProperty("favorite_glider")]
        public string FavoriteGlider { get; set; }

        [JsonProperty("daily_rewards")]
        public DailyRewards DailyRewards { get; set; }

        [JsonProperty("xp")]
        public long Xp { get; set; }

        [JsonProperty("season_friend_match_boost")]
        public long SeasonFriendMatchBoost { get; set; }

        [JsonProperty("banner_icon")]
        public string BannerIcon { get; set; }
    }

    public class DailyRewards
    {
    }

    public class QuestManager
    {
        [JsonProperty("dailyLoginInterval")]
        public DateTimeOffset DailyLoginInterval { get; set; }

        [JsonProperty("dailyQuestRerolls")]
        public long DailyQuestRerolls { get; set; }
    }

    public class PastSeason
    {
        [JsonProperty("seasonNumber")]
        public long SeasonNumber { get; set; }

        [JsonProperty("numWins")]
        public long NumWins { get; set; }

        [JsonProperty("numHighBracket")]
        public long NumHighBracket { get; set; }

        [JsonProperty("numLowBracket")]
        public long NumLowBracket { get; set; }

        [JsonProperty("seasonXp")]
        public long SeasonXp { get; set; }

        [JsonProperty("seasonLevel")]
        public long SeasonLevel { get; set; }

        [JsonProperty("bookXp")]
        public long BookXp { get; set; }

        [JsonProperty("bookLevel")]
        public long BookLevel { get; set; }

        [JsonProperty("purchasedVIP")]
        public bool PurchasedVip { get; set; }
    }

    public class Season
    {
        [JsonProperty("numWins")]
        public long NumWins { get; set; }

        [JsonProperty("numHighBracket")]
        public long NumHighBracket { get; set; }

        [JsonProperty("numLowBracket")]
        public long NumLowBracket { get; set; }
    }

    public enum QuestState { Active };

}
