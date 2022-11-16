using Assets.Game.Scripts.Fabrica;
using Assets.Game.Scripts.HealsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Game.Scripts.SeamplessArea
{
    public class SeamlessArea : MonoBehaviour
    {
            [SerializeField] private List<ITeleportable> _teleportablesList;
            [SerializeField] private Camera _camera;
            [SerializeField] private FabricaAsteroid _fabricaAsteroid;
            [SerializeField] private FabricaPlayer _fabricaPlayer;

            [SerializeField] private UnityEvent OnRestart;
            [SerializeField] private UnityEvent OnSoundDesable;

        void OnCreateAsteroid(Asteroid asteroid)
            {
                _teleportablesList.Add(asteroid);
                asteroid.OnDestroy += OnDestroyAsteroid;
                Debug.Log("Create asteroid");
            }
            void OnDestroyAsteroid(Asteroid asteroid)
            {
                _teleportablesList.Remove(asteroid);
                Debug.Log("Destroy asteroid");
                OnSoundDesable.Invoke();
            }
            void OnCreatePlayer(Player player)
            {
                _teleportablesList.Add(player);
                player.OnDestroy += OnDestroyPlayer;
                Debug.Log("Create player");
            }
            void OnDestroyPlayer(Player player)
            {
                _teleportablesList.Remove(player);
                Debug.Log("Destroy player");
                Destroy(player);
                OnRestart.Invoke();
            }

            private void Awake()
            {
                _teleportablesList = new();
                _fabricaAsteroid.OnCreateAsteroid += OnCreateAsteroid;
                _fabricaPlayer.OnCreatePlayer += OnCreatePlayer;
            }
        private void OnDestroy()
        {
            _fabricaAsteroid.OnCreateAsteroid -= OnCreateAsteroid;
        }
        private void FixedUpdate()
            {
                foreach (var obj in _teleportablesList)
                {
                    HandleObject(obj);
                    var restart =_teleportablesList.Count;
                Debug.Log(restart);
                if (restart ==1)
                    {
                        OnRestart.Invoke();
                    }
                }
            }
            public void HandleObject(ITeleportable obj)
            {
                if (obj.Position == null)
                {
                    _teleportablesList.Remove(obj);
                }
                var newPosition = obj.Position;

                float sceneWidth = _camera.orthographicSize * 2 * _camera.aspect;
                float sceneHeight = _camera.orthographicSize * 2;

                float sceneRightEdge = sceneWidth / 2;
                float sceneLeftEdge = sceneRightEdge * -1;
                float sceneTopEdge = sceneHeight / 2;
                float sceneBottomEdge = sceneTopEdge * -1;

                if (newPosition.x > sceneRightEdge)
                {
                    obj.Position = new Vector2(sceneLeftEdge, newPosition.y);
                }
                if (newPosition.x < sceneLeftEdge)
                {
                    obj.Position = new Vector2(sceneRightEdge, newPosition.y);
                }
                if (newPosition.y > sceneTopEdge)
                {
                    obj.Position = new Vector2(newPosition.x, sceneBottomEdge);
                }
                if (newPosition.y < sceneBottomEdge)
                {
                    obj.Position = new Vector2(newPosition.x, sceneTopEdge);
                }
            }
        }
}