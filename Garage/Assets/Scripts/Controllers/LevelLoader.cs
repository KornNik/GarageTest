using UnityEngine;
using Data;
using Helpers;
using Behaviours;

namespace Controllers
{
    class LevelLoader
    {
        private GameObject _level;
        private LevelData _levelData;

        private void Awake()
        {

        }
        public void LoadLevelGame(int index)
        {
            LoadLevelVisuals(index);
        }
        public void ClearLevelFull()
        {
            if (!ReferenceEquals(_level, null))
            {
                GameObject.Destroy(_level.gameObject);
                _level = null;
                Services.Instance.LevelService.SetObject(null);
            }
        }

        private void LoadLevelVisuals(int index)
        {
            _levelData = Services.Instance.DatasBundle.ServicesObject.GetData<LevelsBundle>().GetRandomLevelData();
            _level = GameObject.Instantiate(_levelData.GetPrefab(), _levelData.GetLevelPosition(), Quaternion.identity);
            _level.transform.localPosition = Vector3.zero;
            _level.transform.localRotation = Quaternion.identity;
            Services.Instance.LevelService.SetObject(_level.GetComponent<Level>());
        }
    }
}
