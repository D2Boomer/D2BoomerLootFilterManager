using System;
using Newtonsoft.Json;

namespace Lib_D2Data.Types
{
    public class DamageType : ICloneable
    {
        public DamageTypeEnum Type { get; set; }

        [JsonIgnore]
        public int MinDamage { get; set; }

        [JsonIgnore]
        public int MaxDamage { get; set; }
        public string DamageString { get; set; }

        public object Clone()
        {
            return new DamageType
            {
                DamageString = this.DamageString,
                Type = this.Type,
                MaxDamage = this.MaxDamage,
                MinDamage = this.MinDamage
            };
        }

        public override string ToString()
        {
            return Type.ToString();
        }
    }

    public enum DamageTypeEnum
    {
        OneHanded,
        TwoHanded,
        Thrown,
        Normal
    }
}
