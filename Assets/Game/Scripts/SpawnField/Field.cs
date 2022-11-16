using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.SpawnField
{
    public class Field : MonoBehaviour
    {
        [SerializeField] private Transform _transform;

        public Vector3 GetRandomWorldPosition()
        {
            var y = Random.Range(-0.5f, 0.5f);
            var x = Random.Range(-0.5f, 0.5f);
            var randomLocalPosition = new Vector2(x, y);
            return _transform.TransformPoint(randomLocalPosition);
        }

        public void FindComponents()
        {
            _transform = transform;
        }
    }
}