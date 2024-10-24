using UnityEngine;
using Data;
using Helpers;
using Behaviours.Units;

namespace Controllers
{
    sealed class PlayerLoader
    {
        private UnitController _player;
        private UnitsPrafabsData _prefabsData;

        public PlayerLoader()
        {
            _prefabsData = Services.Instance.DatasBundle.ServicesObject.GetData<UnitsPrafabsData>();
        }

        public void LoadPlayerClean()
        {
            ClearPlayer();
            LoadPlayerPrefab();
        }
        public void DeletePlayer()
        {
            ClearPlayer();
        }


        private bool LoadPlayerPrefab()
        {
            var playerPrefab = _prefabsData.GetPlayer();
            _player = GameObject.Instantiate(playerPrefab.GetComponent<UnitController>());
            if (!ReferenceEquals(_player, null))
            {
                _player.transform.position = Services.Instance.LevelService.ServicesObject.PlayerPlace.position;
                _player.transform.rotation = Services.Instance.LevelService.ServicesObject.PlayerPlace.rotation;
                Services.Instance.PlayerService.SetObject(_player);
                return true;
            }
            return false;
        }
        private bool ClearPlayer()
        {
            if (!ReferenceEquals(_player, null))
            {
                GameObject.Destroy(_player.gameObject);
                _player = null;
                Services.Instance.PlayerService.SetObject(null);
                return true;
            }
            return false;
        }
    }
}
