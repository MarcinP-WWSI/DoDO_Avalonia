using System;
using DoDO.Interfaces;

namespace DoDO.CharacterData
{
    public abstract class Character : IAttackable
    {

        public string Name { get; }
        public CharacterStats Stats { get; set; }

        public int HP { get; protected set; }
        public int MP { get; protected set; }

        public int Potions { get; protected set; }

        public event Action<Character, int> OnDamaged;
        public event Action<Character> OnDeath;
        public event Action<Character> OnDodged;

        public event Action<Character, int> OnHealthChanged;
        public event Action<Character,int> OnManaChanged;
        public event Action<Character, int> OnPotionUsed;
        public event Action<Character> OnPotionGained;
        public event Action<Character,StatGain> OnStatsGained;

        public delegate void AttackEventHandler(Character attacker, Character target, int damage);

        public Character()
        {
        }

        public Character(string name, CharacterStats stats)
        {
            Name = name;
            Stats = stats;
            HP = stats.MaxHP;
            MP = stats.MaxMP;
            Potions = 3;
        }

        public void ReceiveDamage(int damage)
        {
            if (Random.Shared.Next(0, 100) < Stats.Dodge)
            {
                OnDodged?.Invoke(this);
            }
            else
            {
                damage = damage - Stats.Defense;
                if (damage < 0)
                    damage = 0;
                HP -= damage;
                OnDamaged?.Invoke(this, damage);

                if (HP <= 0)
                    Death();
            }


                
        }

        protected void ConsumeMana(int amount)
        {
            MP -= amount;
            OnManaChanged?.Invoke(this, MP);
        }

        protected void Death()
        {
            OnDeath?.Invoke(this);
        }

        public void UsePotion()
        {
            if (Potions > 0)
            {
                Potions--;
                int healAmount = Stats.MaxHP / 4;
                HP += healAmount;
                OnPotionUsed?.Invoke(this,healAmount);
                OnHealthChanged?.Invoke(this, HP);
            }
        }

        public void GainPotion()
        {
            Potions += 1;
            OnPotionGained?.Invoke(this);
        }

        public void ApplyStatGain(StatGain gain)
        {
            Stats.MaxHP += gain.MaxHP;
            HP += gain.MaxHP;
            Stats.Defense += gain.Defense;
            Stats.MinAttack += gain.MinAttack;
            Stats.MaxAttack += gain.MaxAttack;

            //HP += gain.MaxHP/4; // heal po levelu
            OnStatsGained?.Invoke(this, gain);
            //if (HP < Stats.MaxHP)
            //{
            //    HP = Stats.MaxHP;
            //}
        }

        public abstract int Attack();
        public abstract int SpecialAttack();

        public static Character operator -(Character c, int dmg)
        {
            c.HP -= dmg;
            return c;
        }

        public static Character operator +(Character c, int heal)
        {
            c.HP += heal;
            return c;
        }

    }
}
