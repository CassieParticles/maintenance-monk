using System;
using UnityEngine;

namespace GameObjects.Player
{
    public enum PlayerStates
    {
        Waiting,
        InGame,
        Talking,
        Shop
    }
    
    public class PlayerData : MonoBehaviour
    {
        
        private static PlayerData _instance;
        //Static getter, ensures player data can be fetched in any scene
        public static PlayerData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject("PlayerData").AddComponent<PlayerData>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                
                return _instance;
            }
        }
        
        
        //Data regarding the player and player state
        public int Coins { get; private set; }
        public float Reputation { get; private set; }
        public float DayProgress { get; private set; }
        public bool IsPaused { get; private set; }
        
        [NonSerialized] public PlayerStates State;

        public void EarnCoins(int coins)
        {
            Coins += coins;
        }

        public void EarnReputation(float reputation)
        {
            Reputation = reputation;
        }

        public void TogglePause() {
            IsPaused = !IsPaused;
        }
        private void Awake()
        {
            Reputation = 50;
        }
    }
}