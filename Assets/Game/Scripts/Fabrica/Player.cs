using Assets.Game.Scripts.HealsSystem;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Game.Scripts.Fabrica
{
    public class Player : MonoBehaviour, ITeleportable
    {
        [SerializeField] private Transform _transform;

        [SerializeField] private int HP=3;
        [SerializeField] private GameObject _boomShip;


        public Vector2 Position
        {
            get => _transform.position;
            set
            {
                if (_transform.position != null)
                {
                    _transform.position = value;
                }
                else
                {
                    Debug.Log("Пропал игрок");
                }
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Asteroid")
            {
                
                if (HP != 0)
                {
                    var punch = 1;
                    OnHealth.Invoke(punch);
                    Debug.Log("Event to punch");
                    HP--;
                }
                else
                {
                    OnDestroy(this);
                    var boomShip = Instantiate(_boomShip, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    Destroy(boomShip, 2);
                    Debug.Log("Dead!");
                }
                
            }
        }
        public event Action<Player> OnDestroy = delegate { };
        public event Action<int> OnHealth = delegate { };
    }
}