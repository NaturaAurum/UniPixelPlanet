using UniPixelPlanet.Runtime;
using UniPixelPlanet.Runtime.__Bodies__;
using UniPixelPlanet.Runtime.Planets;
using UnityEditor;
using UnityEngine;

namespace UniPixelPlanet.Editor
{
    [CustomEditor(typeof(Planet), true)]
    public class PlanetEditor: UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var cBody = (Planet)target;
            if (GUILayout.Button("Update"))
            {
                cBody.Perform();
            }
        }
    }
}