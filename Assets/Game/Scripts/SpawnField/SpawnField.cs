using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.SpawnField
{
    public class SpawnField : MonoBehaviour
    {
        [SerializeField] private List<Field> _fields;
        public bool TryGetRandomWorldPosition(out Vector3 position)
        {
            position = default;
            if (_fields.Count == 0) return false;

            var fieldIndex = Random.Range(0, _fields.Count);
            position = _fields[fieldIndex].GetRandomWorldPosition();
            return true;
        }
    }
}