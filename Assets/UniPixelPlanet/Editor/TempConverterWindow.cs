using System.IO;
using System.Linq;
using UniPixelPlanet.Runtime.Data;
using UniPixelPlanet.Runtime.Planets;
using UnityEditor;
using UnityEngine;

namespace UniPixelPlanet.Editor
{
    public class TempConverterWindow : EditorWindow
    {
        private const string BasePath = "Assets/UniPixelPlanet/Assets/Presets/Planets";
        private Planet _targetPlanet;

        [MenuItem("Tools/TempConverterWindow")]
        private static void Init()
        {
            var window = GetWindow<TempConverterWindow>();
            window.ShowUtility();
        }

        private void OnGUI()
        {
            _targetPlanet = EditorGUILayout.ObjectField(_targetPlanet, typeof(Planet), true) as Planet;

            if (_targetPlanet is null)
                return;

            if (GUILayout.Button("Convert"))
            {
                // Float, Color, GradientColor, Vector
                // Assets/UniPixelPlanet/Assets/Presets/Planets

                var targetName = _targetPlanet.gameObject.name;

                CheckAndCreateFolder(targetName);
                ConvertFloat(targetName);
                ConvertColor(targetName);
                ConvertGradientColor(targetName);
                ConvertVector(targetName);
            }
        }

        private static void CheckAndCreateFolder(string targetName)
        {
            var path = $"{BasePath}/{targetName}";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void ConvertFloat(string targetName)
        {
            var count = 0;
            var planetFloatControllers = _targetPlanet.GetComponentsInChildren<PlanetFloatController>();
            if (planetFloatControllers is null || planetFloatControllers.Length == 0)
            {
                return;
            }

            foreach (var planetFloatController in planetFloatControllers)
            {
                var readOnlyList = planetFloatController.List;
                if (readOnlyList is null || readOnlyList.Count == 0)
                {
                    continue;
                }

                var planetFloatData = CreateInstance<PlanetFloatData>();

                var dataElements = readOnlyList.Select(elem => new DataElement<float>()
                {
                    propName = elem.propName,
                    value = elem.value
                });
                planetFloatData.OverwriteData(dataElements);

                AssetDatabase.CreateAsset(planetFloatData, $"{BasePath}/{targetName}/{targetName}{planetFloatController.gameObject.name}FloatData_{count}.asset");
                AssetDatabase.SaveAssetIfDirty(planetFloatData);
                count++;
            }
        }

        private void ConvertColor(string targetName)
        {
            var planetColorControllers = _targetPlanet.GetComponentsInChildren<PlanetColorController>();
            if (planetColorControllers is null || planetColorControllers.Length == 0)
            {
                return;
            }

            var count = 0;
            foreach (var planetColorController in planetColorControllers)
            {
                var readOnlyList = planetColorController.Colors;
                if (readOnlyList is null || readOnlyList.Count == 0)
                {
                    continue;
                }

                var planetColorData = CreateInstance<PlanetColorData>();

                var dataElements = readOnlyList.Select(c => new DataElement<Color>()
                {
                    propName = c.propName,
                    value = c.color
                });

                planetColorData.OverwriteData(dataElements);
                AssetDatabase.CreateAsset(planetColorData, $"{BasePath}/{targetName}/{targetName}{planetColorController.gameObject.name}ColorData_{count}.asset");
                AssetDatabase.SaveAssetIfDirty(planetColorData);
                count++;
            }
        }

        private void ConvertGradientColor(string targetName)
        {
            var planetGradientColorControllers = _targetPlanet.GetComponentsInChildren<PlanetGradiantColorController>();
            if (planetGradientColorControllers is null || planetGradientColorControllers.Length == 0)
            {
                return;
            }

            var count = 0;
            foreach (var planetGradientColorController in planetGradientColorControllers)
            {
                var planetGradiantColorData = CreateInstance<PlanetGradientColorData>();
                var dataElements = planetGradientColorController.Times.Select((t, i) => new DataElement<GradientColor>()
                {
                    propName = planetGradientColorController.PropName,
                    value = new GradientColor() {colorTime = t, color = planetGradientColorController.Colors[i]}
                }).ToList();

                planetGradiantColorData.OverwriteData(dataElements);
                AssetDatabase.CreateAsset(planetGradiantColorData,
                    $"{BasePath}/{targetName}/{targetName}{planetGradientColorController.gameObject.name}GradientColorData_{count}.asset");
                AssetDatabase.SaveAssetIfDirty(planetGradiantColorData);
                count++;
            }
        }


        private void ConvertVector(string targetName)
        {
            var planetVectorControllers = _targetPlanet.GetComponentsInChildren<PlanetVectorController>();
            if (planetVectorControllers is null || planetVectorControllers.Length == 0)
            {
                return;
            }

            var count = 0;
            foreach (var planetVectorController in planetVectorControllers)
            {
                var readOnlyList = planetVectorController.List;
                if (readOnlyList is null || readOnlyList.Count == 0)
                {
                    continue;
                }

                var planetVectorData = CreateInstance<PlanetVectorData>();

                var dataElements = readOnlyList.Select(elem => new DataElement<Vector4>()
                {
                    propName = elem.propName,
                    value = elem.value
                });
                planetVectorData.OverwriteData(dataElements);
                AssetDatabase.CreateAsset(planetVectorData, $"{BasePath}/{targetName}/{targetName}{planetVectorController.gameObject.name}VectorData_{count}.asset");
                AssetDatabase.SaveAssetIfDirty(planetVectorData);
                count++;
            }
        }
    }
}