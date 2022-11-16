using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Direction
{
        public class DirectionAsteroid : MonoBehaviour
        {
            [SerializeField] private Rigidbody2D _rigidbody2D;
            [SerializeField] private ForceMode _forceMode;
            [SerializeField] private int _speed;
            private Vector2 _direction;

            void Start()
            {
                _rigidbody2D = GetComponent<Rigidbody2D>();
                RandomDirection();
            }
            void RandomDirection()
            {
                var xVector = Random.Range(-2f, 3f);
                _direction.x = xVector;
                var yVector = Random.Range(-2f, 3f);
                _direction.y = yVector;
                _rigidbody2D.AddForce(_direction * _speed * Time.deltaTime);
            }  
        }
}