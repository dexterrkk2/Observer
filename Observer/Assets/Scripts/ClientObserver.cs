using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter.Observer
{
    public class ClientObserver : MonoBehaviour
    {
        private BikeController bikeController;
        // Start is called before the first frame update
        void Start()
        {
            bikeController = (BikeController) FindObjectOfType(typeof(BikeController));
        }
        private void OnGUI()
        {
            if (GUILayout.Button("Damage Bike"))
            {
                if (bikeController)
                {
                    bikeController.TakeDamage(15f);
                }
            }
            if(GUILayout.Button("Toggle Turbo"))
            {
                if (bikeController)
                {
                    bikeController.ToggleTurbo();
                }
            }
        }
    }
}
