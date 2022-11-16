using Assets.Game.Scripts.HealsSystem;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Fabrica
{
    public class Asteroid : MonoBehaviour, ITeleportable
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private int _hp;
        public Vector2 Position
        {
            get => _transform.position;
            set
            {
                if (_transform.position != null)
                {
                    _transform.position = value;
                }
            }
        }
        void Update()
        {
            if (_hp <= 0)
            {
                OnDestroy.Invoke(this);
                Destroy(gameObject);
            }
        }
        public void TakeDamage(int damage)
        {
            _hp -= damage;
        }
        public event Action<Asteroid> OnDestroy = delegate { };
    }
}
