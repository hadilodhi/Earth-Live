using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet)), CanEditMultipleObjects]
public class PlanetEditor : Editor
{
    Planet planet;
    Editor shapeEditor;

    public override void OnInspectorGUI()
    {
        using(var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (check.changed)
            {
                planet.OnShapeSettingsUpdate();
            }
        }
        DrawSettingsEditor(planet.ShapeSettings, planet.OnShapeSettingsUpdate, ref planet.shapeSettingsFoldout, ref shapeEditor);
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldout, ref Editor editor)
    {
        if (settings != null)
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);
            using(var check = new EditorGUI.ChangeCheckScope())
            {
                if(foldout)
                {
                    CreateCachedEditor(settings, null, ref editor);
                    editor.OnInspectorGUI();
                }
                
                if (check.changed)
                {
                    if (onSettingsUpdated != null)
                    {
                        onSettingsUpdated();
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }
}
