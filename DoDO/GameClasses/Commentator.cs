
using System;
using System.Collections.Generic;
using System.Text;
using DoDO.CharacterData;

namespace DoDO.GameClasses
{
    public class Commentator
    {
        public void Subscribe(Game game)
        {
            game.OnGameLog += Log;
            game.OnAttack += OnAttack;
            game.OnClassPicked += OnClassPicked;
            game.OnEnemySpawned += OnEnemySpawned;


            
        }

        private void OnEnemySpawned(Character enemy)
        {
            SubscribeCharacter(enemy);
        }

        private void SubscribeCharacter(Character character)
        {
            character.OnDamaged += OnDamaged;
            //character.OnDeath += OnDeath;
            character.OnManaChanged += OnManaChanged;
            character.OnHealthChanged += OnLifeChanged;
            character.OnPotionUsed += OnPotionUsed;
            character.OnPotionGained += OnPotionGained;
            character.OnStatsGained += OnStatsGained;
            character.OnDodged += OnDodged;
        }

        private void OnClassPicked(Character player)
        {
            SubscribeCharacter(player);
            Console.WriteLine($"Player wybiera swoją klasę {player.Name}.");
        }

        private void OnDodged(Character character)
        {
            Console.WriteLine($"{character.Name} unika ataku.");
        }

        private void OnStatsGained(Character character, StatGain gain)
        {
            Console.WriteLine($"{character.Name} zdobywa statystyki. Max Życie: +{gain.MaxHP} , Defence: +{gain.Defense} , Dodge: +{gain.Dodge} , Min dmg: +{gain.MinAttack}, Max dmg +{gain.MaxAttack}");
        }

        private void OnPotionUsed(Character character, int heal)
        {
            Console.WriteLine($"{character.Name} leczy się za pomocą potiona za {heal} , pozostało: {character.Potions}");
        }
        private void OnPotionGained(Character character)
        {
            Console.WriteLine($"{character.Name} zdobywa potiona, pozostało: {character.Potions}");
        }

        private void OnAttack(Character attacker, Character target, int dmg)
        {
            Console.WriteLine($"{attacker.Name} atakuje {target.Name} za {dmg}");
        }

        private void OnDamaged(Character c, int dmg)
        {
            Console.WriteLine($"{c.Name} otrzymuje {dmg} obrażeń (HP: {c.HP})");
        }

        private void OnDeath(Character c)
        {
            Console.WriteLine($"{c.Name} ginie");
        }

        private void OnManaChanged(Character c, int mp)
        {
            Console.WriteLine($"{c.Name} ma teraz {mp} MP");
        }

        private void OnLifeChanged(Character c, int hp)
        {
            Console.WriteLine($"{c.Name} ma teraz {hp} HP");
        }

        private void Log(string msg)
        {
            Console.WriteLine($"[GAME] {msg}");
        }
    }
}
