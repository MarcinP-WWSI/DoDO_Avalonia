using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoDO.CharacterData.CharacterClasses
{
    internal class Orc : Character
    {
        private static readonly CharacterStats OrcStats = new()
        {
            MaxHP = 100,
            MaxMP = 30,
            Defense = 7,
            Dodge = 5,
            MinAttack = 10,
            MaxAttack = 20,
            SpecialCost = 5,
            SpecialMaxMultiplier = 3,
            SpecialMinMultiplier = 2
        };

        public Orc(string name)
            : base(name, OrcStats)
        {
        }

        public override int Attack()
        {
            return Random.Shared.Next(
                Stats.MinAttack,
                Stats.MaxAttack + 1
            );
        }

        public override int SpecialAttack()
        {
            if (MP < Stats.SpecialCost)
                throw new InvalidOperationException("Za mało MP!");
            ConsumeMana(Stats.SpecialCost);
            return Random.Shared.Next(
                Stats.SpecialMinMultiplier * Stats.MinAttack,
                Stats.SpecialMaxMultiplier * Stats.MaxAttack + 1
            );
        }
    }
}
