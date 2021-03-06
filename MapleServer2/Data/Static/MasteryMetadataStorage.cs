﻿using System.Collections.Generic;
using System.IO;
using Maple2Storage.Types.Metadata;
using MapleServer2.Constants;
using ProtoBuf;

namespace MapleServer2.Data.Static
{
    public static class MasteryMetadataStorage
    {
        private static readonly Dictionary<int, MasteryMetadata> masteries = new Dictionary<int, MasteryMetadata>();

        static MasteryMetadataStorage()
        {
            using FileStream stream = File.OpenRead($"{Paths.RESOURCES}/ms2-mastery-metadata");
            List<MasteryMetadata> masteryList = Serializer.Deserialize<List<MasteryMetadata>>(stream);
            foreach (MasteryMetadata mastery in masteryList)
            {
                masteries[mastery.Type] = mastery;
            }
        }

        public static List<int> GetMasteryTypes()
        {
            return new List<int>(masteries.Keys);
        }

        public static MasteryMetadata GetMastery(int type)
        {
            return masteries.GetValueOrDefault(type);
        }
    }
}
