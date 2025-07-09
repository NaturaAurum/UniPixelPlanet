using UniPixelPlanet.Runtime;
using UnityEditor;
using UnityEngine;

namespace UniPixelPlanet.Editor
{
    [CustomEditor(typeof(CelestialBody), true)]
    public class CelestialBodyEditor: UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var cBody = (CelestialBody)target;
            if (GUILayout.Button("Update"))
            {
                cBody.Perform();
            }
        }
    }
}