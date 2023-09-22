using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter.Observer
{
    public class BikeController : Subject
    {
        public bool IsTurbon
        {
            get; private set;
        }
        public float CurrentHealth
        {
            get { return health; }
        }
        private bool _isEngineOn;
        private HUDController _hudController;
        private CameraController _cameraController;
        private float health = 100f;

        private void Awake()
        {
            _hudController = gameObject.AddComponent<HUDController>();

            _cameraController = (CameraController)FindObjectOfType(typeof(CameraController)); 
        }

        private void Start()
        {
            StartEngine();
        }

        private void OnEnable()
        {
            if (_hudController)
            {
                Attach(_hudController);
            }
            if (_cameraController)
            {
                Attach(_cameraController);
            }
        }
        private void OnDisable()
        {
            if (_hudController)
            {
                Detach(_hudController);
            }
            if (_cameraController)
            {
                Detach(_cameraController);
            }
        }
        private void StartEngine()
        {
            _isEngineOn = true;
            NotifyObservers();
        }
        public void ToggleTurbo()
        {
            if (_isEngineOn)
            {
                IsTurbon = !IsTurbon;
            }
            NotifyObservers();
        }
        public void TakeDamage(float amount)
        {
            health -= amount;
            IsTurbon = false;
            NotifyObservers();
            if (health<0)
            {
                Destroy(gameObject);
            }
        }
    }
}
