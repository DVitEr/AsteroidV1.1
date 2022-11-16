using Assets.Game.Scripts.Fabrica;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace Assets.Game.Scripts.HealsSystem
{
    public class HealthPlayer : MonoBehaviour
    {

        [SerializeField] private int _numberOfLives;

        [SerializeField] private Image[] _lives;

        [SerializeField] private Sprite _fullLive;
        [SerializeField] private Sprite _emptyLive;

        [SerializeField] private FabricaPlayer _fabricaPlayer;

        Player firstPlayer;

        [SerializeField] public int HP = 3;


        void OnCreatePlayer(Player player)
        {
            Debug.Log("I sea you");
            player.OnHealth += OnHealth;
            firstPlayer = player;
        }
        void OnHealth(int punch)
        {
            if (HP != 0)
            {
                HP -= punch;
                Debug.Log("Punch");
            }
            else 
            {
                Debug.Log("Helth!");
                DesablePlayer(firstPlayer); 
            }
        }
        void DesablePlayer(Player player)
        {
            player.OnHealth -= OnHealth;
        }
        void Awake()
        {
            _fabricaPlayer.OnCreatePlayer += OnCreatePlayer;
        }
        void Update()
        {
            for (int i = 0; i < _lives.Length; i++)
            {
                if (i< HP)
                {
                    _lives[i].sprite = _fullLive;
                }
                else
                {
                    _lives[i].sprite = _emptyLive;
                }
                if (i < _numberOfLives)
                {
                    _lives[i].enabled = true;
                }
                else
                {
                    _lives[i].enabled = false;
                }
            }

        }

    }
}