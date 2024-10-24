using UnityEngine;
using Helpers;
using Behaviours;

namespace Data
{
    [CreateAssetMenu(fileName = "ResourcesData", menuName = "Data/ResourcesData")]
    sealed class ResourcesDataPrefabs : ScriptableObject
    {
        [SerializeField] private GameObject _cameraPrefab;
        [SerializeField] private GameStateBehaviour _gameStatePrefab;

        [SerializeField] private ResorcePrefabStruct<ScreenTypes>[] _screensPrefabs;
        [SerializeField] private ResorcePrefabStruct<AudioTypes>[] _audioPrefabs;

        public GameObject GetScreenPrefab(ScreenTypes screenType)
        {
            GameObject screenPrefab = default;
            for (int i = 0; i < _screensPrefabs.Length; i++)
            {
                if (_screensPrefabs[i].Type == screenType) screenPrefab = _screensPrefabs[i].Gameobject;
            }
            return screenPrefab;
        }
        public GameObject GetAudioPrefab(AudioTypes audioType)
        {
            GameObject audioPrefab = default;
            for (int i = 0; i < _audioPrefabs.Length; i++)
            {
                if (_audioPrefabs[i].Type == audioType) audioPrefab = _audioPrefabs[i].Gameobject;
            }
            return audioPrefab;
        }
        public GameObject GetCamerPrefab()
        {
            return _cameraPrefab;
        }
        public GameStateBehaviour GetGameStatePrefab()
        {
            return _gameStatePrefab;
        }

    }
}
