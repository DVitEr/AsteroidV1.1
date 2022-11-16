using System;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Fabrica
{
    public class FabricaPlayer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Transform _transform;

        public event Action<Player> OnCreatePlayer = delegate { };

        private void Start()
        {
            CreateObject();
        }

        public void CreateObject()
        {
            var player = Instantiate(_player, _transform.position, Quaternion.identity);
            OnCreatePlayer.Invoke(player);
        }
    }
}