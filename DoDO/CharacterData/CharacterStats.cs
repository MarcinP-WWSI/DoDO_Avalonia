using System;
using System.Collections.Generic;
using System.Text;

namespace DoDO.CharacterData
{
    public class CharacterStats
    {
        public int MaxHP { get; set; }
        public int MaxMP { get; set; }
        public int Defense { get; set; }
        public int Dodge { get; set; }
        public int MinAttack { get; set; }
        public int MaxAttack { get; set; }
        public int SpecialCost { get; init; }
        public int SpecialMinMultiplier { get; init; }
        public int SpecialMaxMultiplier { get; init; }


    }
}
