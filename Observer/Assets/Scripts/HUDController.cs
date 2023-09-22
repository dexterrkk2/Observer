using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter.Observer
{
    public class HUDController : Observer
    {
        private bool _isTurboOn;
        private float _currentHealth;
        private BikeController bikeController;

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(50, 50, 100, 200));
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Health: " + _currentHealth);
            GUILayout.EndHorizontal();
            if (_isTurboOn)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Turbo Activated");
                GUILayout.EndHorizontal();
            }
            if(_currentHealth <= 50)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Warning Low Health: ");
                GUILayout.EndHorizontal();
            }
            GUILayout.EndArea();
        }
        public override void Notify(Subject subject)
        {
            if (!bikeController)
            {
                bikeController = subject.GetComponent<BikeController>();
            }

            if (bikeController)
            {
                _isTurboOn = bikeController.IsTurbon;
                _currentHealth = bikeController.CurrentHealth;
            }
        }
    }
}