using System;
using UnityEngine;
using Behaviours;
using Controllers;
using Data;
using Behaviours.Units;
using Helpers.Extensions;

namespace Helpers
{
    sealed class Services
    {
        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        public static Services Instance => _instance.Value;
        public Service<Camera> CameraService { get; private set; }
        public Service<AudioController> AudioController { get; private set; }
        public Service<SettingsController> SettingsController { get; private set; }
        public Service<TimeController> TimeController { get; private set; }
        public Service<DatasBundle> DatasBundle { get; private set; }
        public Service<LevelLoader> LevelLoader { get; private set; }
        public Service<PlayerLoader> PlayerLoader { get; private set; }
        public Service<GameStateBehaviour> GameStateBehavior { get; private set; }
        public Service<UnitController> PlayerService { get; private set; }
        public Service<InputActions> Inputs { get; private set; }
        public Service<Level> LevelService { get; private set; }

        public Services()
        {
            Initialize();
        }

        private void Initialize()
        {
            CameraService = new Service<Camera>();
            AudioController = new Service<AudioController>();
            SettingsController = new Service<SettingsController>();
            TimeController = new Service<TimeController>();
            DatasBundle = new Service<DatasBundle>();
            LevelLoader = new Service<LevelLoader>();
            GameStateBehavior = new Service<GameStateBehaviour>();
            PlayerLoader = new Service<PlayerLoader>();
            PlayerService = new Service<UnitController>();
            Inputs = new Service<InputActions>();
            LevelService = new Service<Level>();
        }

    }
}
