using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DoDO.CharacterData.CharacterClasses
{
    internal class Mage : Character
    {
        private static readonly CharacterStats MageStats = new()
        {
            MaxHP = 70,
            MaxMP = 80,
            Defense = 2,
            Dodge = 10,
            MinAttack = 20,
            MaxAttack = 35,
            SpecialCost = 10,
            SpecialMaxMultiplier = 5,
            SpecialMinMultiplier = 3
        };

        public Mage(string name)
            : base(name, MageStats)
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
