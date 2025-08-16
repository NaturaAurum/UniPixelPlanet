using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UniPixelPlanet.Runtime;
using UniPixelPlanet.Runtime.Attributes;

namespace UniPixelPlanet.Editor
{
    [CustomPropertyDrawer(typeof(ShaderPropAttribute))]
    public class ShaderPropDrawer : PropertyDrawer
    {
        private static string[] s_displayNames;
        private static string[] s_values;
        private static bool s_initialized;

        private static void EnsureCache()
        {
            if (s_initialized && s_displayNames != null && s_values != null && s_displayNames.Length == s_values.Length && s_values.Length > 0)
                return;

            try
            {
                var fields = typeof(UniPixelPlanetShaderProps)
                    .GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string))
                    .ToArray();

                var names = new List<string>(fields.Length);
                var vals = new List<string>(fields.Length);
                foreach (var f in fields)
                {
                    var val = (string)f.GetRawConstantValue();
                    vals.Add(val);
                    // Show both field name and value for clarity
                    names.Add($"{f.Name}  ({val})");
                }

                // Sort by display name for stability
                var pairs = names.Zip(vals, (n, v) => new { n, v }).OrderBy(p => p.n).ToArray();
                s_displayNames = pairs.Select(p => p.n).ToArray();
                s_values = pairs.Select(p => p.v).ToArray();
                s_initialized = true;
            }
            catch (Exception)
            {
                s_displayNames = Array.Empty<string>();
                s_values = Array.Empty<string>();
                s_initialized = true;
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            EnsureCache();

            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.HelpBox(position, "[ShaderProp] can only be applied to string fields.", MessageType.Warning);
                EditorGUI.EndProperty();
                return;
            }

            // Build options including current if missing
            var current = property.stringValue ?? string.Empty;
            var display = s_displayNames;
            var values = s_values;
            var index = -1;
            if (values.Length > 0)
            {
                index = Array.IndexOf(values, current);
            }

            var hasCurrentButMissing = index < 0 && !string.IsNullOrEmpty(current);
            if (hasCurrentButMissing)
            {
                display = new[] { $"(Current) {current}" }.Concat(display).ToArray();
                values = new[] { current }.Concat(values).ToArray();
                index = 0;
            }

            using (new EditorGUI.DisabledScope(values.Length == 0))
            {
                if (values.Length == 0)
                {
                    // Fallback to text field when no constants found
                    property.stringValue = EditorGUI.TextField(position, label, current);
                }
                else
                {
                    var newIndex = EditorGUI.Popup(position, label.text, Mathf.Max(index, 0), display);
                    if (newIndex >= 0 && newIndex < values.Length)
                    {
                        var newValue = values[newIndex];
                        if (newValue != current)
                        {
                            property.stringValue = newValue;
                        }
                    }
                }
            }

            EditorGUI.EndProperty();
        }
    }
}
