using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDO.CharacterData.CharacterClasses
{
    internal class Rouge : Character
    {
        private static readonly CharacterStats RougeStats = new()
        {
            MaxHP = 80,
            MaxMP = 30,
            Defense = 5,
            Dodge = 15,
            MinAttack = 15,
            MaxAttack = 30,
            SpecialCost = 5,
            SpecialMaxMultiplier = 4,
            SpecialMinMultiplier = 3
        };

        public Rouge(string name)
            : base(name, RougeStats)
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
