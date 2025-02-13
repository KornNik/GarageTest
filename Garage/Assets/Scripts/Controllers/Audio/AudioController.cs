using UnityEngine;
using Behaviours;
using Helpers;
using Data;

namespace Controllers
{
    sealed class AudioController : MonoBehaviour
    {

        private AudioMixerVolumeMuter _audioMixerMuter;

        private AudioClip _audioClip;
        private AudioSourcePool _audioSourcePool;
        private AudioEventsHandler _audioEventsHandler;

        public void Awake()
        {
            _audioSourcePool = new AudioSourcePool();
            _audioEventsHandler = new AudioEventsHandler();
            _audioMixerMuter = Services.Instance.DatasBundle.ServicesObject.GetData<AudioMixerVolumeMuter>();

        }
        private void OnEnable()
        {
            _audioEventsHandler.Subscribe();   
        }
        private void OnDisable()
        {
            _audioEventsHandler.Unsubscribe();
        }

        public void PlaySound(SoundEventInfo soudnInfo)
        {
            if (soudnInfo.IsOneShot)
            {
                _audioSourcePool.PlayAtPointOneShot(soudnInfo.AudioClip, soudnInfo.PlayPosition, soudnInfo.SoundVolume);
            }
            else
            {
                _audioSourcePool.PlayAtPoint(soudnInfo.AudioClip, soudnInfo.PlayPosition, soudnInfo.SoundVolume);
            }
        }

        public void SwitchMutedState()
        {
            _audioMixerMuter.Muted = !_audioMixerMuter.Muted;
        }
        public void SetSoundStatus(bool status)
        {
            _audioMixerMuter.Muted = status;
        }
        public bool IsSoundMuted()
        {
            return _audioMixerMuter.Muted;
        }
    }
}