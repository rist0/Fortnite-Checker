using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FortniteChecker.Models;
using FortniteChecker.Models.FortniteAPI;

namespace FortniteChecker.Classes
{
    static class SkinParser
    {
        public static string GetOutfit(Dictionary<string, ItemDetails> items)
        {
            var sb = new StringBuilder();

            foreach (var item in items.Values.Where(x => x.TemplateId.Contains("AthenaCharacter")))
            {
                var checkOutfit = GlobalVariables.Outfits.Cast<DictionaryEntry>()
                    .FirstOrDefault(x => item.TemplateId.Contains(x.Key.ToString()));

                if (checkOutfit.Key == null && checkOutfit.Value == null) continue;

                sb.AppendLine(GlobalVariables.Outfits[checkOutfit.Key].ToString());
            }

            return sb.ToString();
        }

        public static string GetBackBlings(Dictionary<string, ItemDetails> items)
        {
            var sb = new StringBuilder();

            foreach (var item in items.Values.Where(x => x.TemplateId.Contains("AthenaBackpack")))
            {
                var checkBackBling = GlobalVariables.Backblings.Cast<DictionaryEntry>()
                    .FirstOrDefault(x => item.TemplateId.Contains(x.Key.ToString()));

                if (checkBackBling.Key == null && checkBackBling.Value == null) continue;

                sb.AppendLine(GlobalVariables.Backblings[checkBackBling.Key].ToString());
            }

            return sb.ToString();
        }

        public static string GetGliders(Dictionary<string, ItemDetails> items)
        {
            var sb = new StringBuilder();

            foreach (var item in items.Values.Where(x => x.TemplateId.Contains("AthenaGlider")))
            {
                var checkGlider = GlobalVariables.Gliders.Cast<DictionaryEntry>()
                    .FirstOrDefault(x => item.TemplateId.Contains(x.Key.ToString()));

                if (checkGlider.Key == null && checkGlider.Value == null) continue;

                sb.AppendLine(GlobalVariables.Gliders[checkGlider.Key].ToString());
            }

            return sb.ToString();
        }

        public static string GetPickaxes(Dictionary<string, ItemDetails> items)
        {
            var sb = new StringBuilder();

            foreach (var item in items.Values.Where(x => x.TemplateId.Contains("AthenaPickaxe")))
            {
                var checkPickaxe = GlobalVariables.Pickaxes.Cast<DictionaryEntry>()
                    .FirstOrDefault(x => item.TemplateId.Contains(x.Key.ToString()));

                if (checkPickaxe.Key == null && checkPickaxe.Value == null) continue;

                sb.AppendLine(GlobalVariables.Pickaxes[checkPickaxe.Key].ToString());
            }

            return sb.ToString();
        }
    }
}
