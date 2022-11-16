using Assets.Game.Scripts.Fabrica;
using Assets.Game.Scripts.SeamplessArea;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Game.Scripts.Fire
{
    public class Gun : MonoBehaviour
    {
        [Header("Общие настройки")]
        [Range(0f, 5f)]
        [SerializeField] private float _timeDestroy;
        [Range(0f, 5f)]
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Asteroid _asteroid;
        [Header("Урон")]
        [SerializeField] private GameObject _boom;
        [SerializeField] private float _distanse;
        [SerializeField] private int _damage = 1;
        public LayerMask whatIsSolid;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        void FixedUpdate()
        {
            _rigidbody.velocity = transform.up * speed;
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, _distanse, whatIsSolid);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Asteroid"))
                {
                    hitInfo.collider.GetComponent<Asteroid>().TakeDamage(_damage);
                    var boom = Instantiate(_boom, transform.position, Quaternion.identity);
                    Destroy(boom, 2);
                }
                Destroy(gameObject);
            }
        }    
    }
}