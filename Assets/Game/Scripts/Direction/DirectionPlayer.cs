using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.LowLevel;

namespace Assets.Game.Scripts.Direction
{
    public class DirectionPlayer : MonoBehaviour
    {
        [Header("Контроль объекта")]
        [Range(0f, 10f)]
        [SerializeField] private int _speed;

        [Header("Физика")]
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private Vector3 direction;
        private int move;
        [SerializeField] private Transform _transform;

        [Header("Стрельба")]
        public Transform _positionBulletHolders;
        [SerializeField] GameObject _bulletPrefab;

        [Range(0f, 5f)]
        [SerializeField] private float _cooldawn;
        private float _timeForShot;

        [SerializeField] private UnityEvent OnFire;

        private int ofset = -90;

        void Aweke()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            _rigidbody2D.AddForce(direction.normalized * move * _speed);
        }

        void Update()
        {
            Vector3 mousePosMain = Input.mousePosition;
            mousePosMain.z = Mathf.Abs(Camera.main.transform.position.z);
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
            direction = lookPos - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg ;
            transform.rotation = Quaternion.AngleAxis(angle + ofset, Vector3.forward);

            if (Input.GetMouseButton(0))
            {
                if (_timeForShot <= 0)
                {
                    var bullet = Instantiate(_bulletPrefab, _positionBulletHolders.position, transform.rotation);
                    OnFire.Invoke();
                    _timeForShot = _cooldawn;
                    Destroy(bullet, 3);
                }
            }
            _timeForShot -= Time.deltaTime;
            if (Input.GetMouseButton(1))
            {
                move = 1;
            }
            else
            {
                move = 0;
            }
        }
    }
}