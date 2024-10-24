using Helpers;
using Controllers;
using Data;
using UnityEngine;

namespace Behaviours
{
    class AudioInitializer : IInitialization
    {
        public void Initialization()
        {
            var audioControllerPrefab = Services.Instance.DatasBundle.ServicesObject.
                GetData<ResourcesDataPrefabs>().GetScreenPrefab(ScreenTypes.Canvas);
            var audioController = GameObject.Instantiate(audioControllerPrefab).GetComponent<AudioController>();

            Services.Instance.AudioController.SetObject(audioController);
        }
    }
}
