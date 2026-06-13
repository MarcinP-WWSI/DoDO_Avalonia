using System;
using System.Numerics;
using DoDO;
using DoDO.CharacterData;
using DoDO.CharacterData.CharacterClasses;
using Microsoft.Win32.SafeHandles;



namespace DoDO.GameClasses
{
    public class Game
    {

        public enum GameState
        {
            GameNotStarted,
            GameRunning,
            GameFinished
            

        };

        public enum PlayerAction
        {
            Attack = 1,
            SpecialAttack = 2,
            Potion = 3,

            EndGame = 9
        }

        public enum ClassPick
        {
            Warrior = 1,
            Mage = 2,
            Rouge = 3,

            
        }

        public GameState state;

        public event Character.AttackEventHandler OnAttack;
        public event Action<string> OnGameLog;
        public event Action<Character> OnEnemySpawned;
        public event Action<Character, StatGain> OnStatsGained;
        public event Action<Character> OnClassPicked;

        private Character player;
        private Character enemy;

        public Game()
        {
            //this.player = player;
            state = GameState.GameNotStarted;

        }

        public void Start()
        {
            if (state != GameState.GameNotStarted)
                return;
            
            int actionChoice = 0;

            state = GameState.GameRunning;
            OnGameLog?.Invoke("Gra się rozpoczyna!");

            OnGameLog?.Invoke("Wybierz swoją klasę!");

            ClassPick classes = InputHandler.PickPlayerClass();
            try
            {
                switch (classes)
                {
                    case ClassPick.Warrior:
                        player = new Warrior("Wojownik");
                        break;
                    case ClassPick.Mage:
                        player = new Mage("Mag");
                        break;
                    case ClassPick.Rouge:
                        player = new Rouge("Złodziej");
                        break;
                }
                OnClassPicked?.Invoke(player);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            SpawnNewEnemy();

            while (state == GameState.GameRunning)
            {
                try
                {
                    PlayerAction action = InputHandler.GetPlayerAction();

                    switch (action)
                    {
                        case PlayerAction.Attack:
                            PerformAttack(player, enemy);
                            break;

                        case PlayerAction.SpecialAttack:
                            PerformSpecialAttack(player, enemy);
                            break;

                        case PlayerAction.Potion:
                            player.UsePotion();
                            break;
                        case PlayerAction.EndGame:
                            state = GameState.GameFinished;
                            break;
                    }

                    OnGameLog?.Invoke("Tura Wroga!");
                    actionChoice = Random.Shared.Next(0, 2);
                    switch (actionChoice)
                    {
                        case 0:
                            PerformAttack(enemy, player);
                            break;
                        case 1:
                            PerformSpecialAttack(enemy, player);
                            break;
                    }

                    if (player.HP <= 0)
                    {
                        state = GameState.GameFinished;
                        OnGameLog?.Invoke("Gracz zginął!");
                    }

                    if (enemy.HP <= 0)
                    {

                        OnEnemyDeath(enemy);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }
                
            }

            OnGameLog?.Invoke("Gra zakończona!");
        
        }

        

        private void OnEnemyDeath(Character deadEnemy)
        {
            
           OnGameLog?.Invoke($"{deadEnemy.Name} został pokonany!");

            switch (Random.Shared.Next(0, 0))
            {
                case 0:
                    OnGameLog?.Invoke("Gracz otrzymuje eliksir zdrowia!");
                    player.GainPotion();;
                    break;
                case 1:
                    StatGain gain = GenerateRandomStatGain();
                    OnStatsGained?.Invoke(player, gain);
                    player.ApplyStatGain(gain);
                    break;
                default:
                    break;
            }
            SpawnNewEnemy();

        }

        private StatGain GenerateRandomStatGain()
        {
            return new StatGain
            {
                MaxHP = Random.Shared.Next(5, 11),
                Dodge = Random.Shared.Next(1,2),
                Defense = Random.Shared.Next(1, 4),
                MinAttack = Random.Shared.Next(1, 3),
                MaxAttack = Random.Shared.Next(2, 4)
            };
        }

        private void SpawnNewEnemy()
        {
            enemy = new Warrior("Doom Orc");
            enemy.OnDeath += OnEnemyDeath;
            OnEnemySpawned?.Invoke(enemy);
            OnGameLog?.Invoke($"Nowy wróg pojawił się: {enemy.Name}!");
        }

        private void PerformAttack(Character attacker, Character target)
        {
            int dmg = attacker.Attack();

            OnAttack?.Invoke(attacker, target, dmg);
            target.ReceiveDamage(dmg);
        }
        private void PerformSpecialAttack(Character attacker, Character target)
        {
            int dmg = attacker.SpecialAttack();

            OnAttack?.Invoke(attacker, target, dmg);
            target.ReceiveDamage(dmg);
        }

    }
}