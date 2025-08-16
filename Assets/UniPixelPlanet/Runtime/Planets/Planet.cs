using System;
using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class Planet : MonoBehaviour
    {
        private PlanetMaterialController[] _controllers;

        private void Awake()
        {
            _controllers = GetComponentsInChildren<PlanetMaterialController>();
        }

        public void Perform()
        {
            foreach (var controller in _controllers)
            {
                controller.Perform();
            }
        }
    }
}