using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

[CustomPropertyDrawer(typeof(SceneAssetAttribute))]
public class SceneDrawer : PropertyDrawer {
	
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
		
		if (property.propertyType == SerializedPropertyType.String) {
			SceneAsset sceneObject = GetSceneObject(property.stringValue);
			Object scene = EditorGUI.ObjectField(position, label, sceneObject, typeof(SceneAsset), true);
			if (scene == null) {
				property.stringValue = "";
			} else if (scene.name != property.stringValue) {
				SceneAsset sceneObj = GetSceneObject(scene.name);
				if (sceneObj == null) {
					Debug.LogWarning("The scene " + scene.name + " cannot be used. To use this scene add it to the build settings for the project");
				} else {
					property.stringValue = scene.name;
				}
			}
		}
		else
			EditorGUI.LabelField (position, label.text, "Use [Scene] with strings.");
	}
	private SceneAsset GetSceneObject(string sceneObjectName) {
		if (string.IsNullOrEmpty(sceneObjectName)) {
			return null;
		}

		EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;

		for (int i = 0; i < scenes.Length; i++) {
			if (scenes[i].path.IndexOf(sceneObjectName, StringComparison.Ordinal) != -1) {
				return AssetDatabase.LoadAssetAtPath(scenes[i].path, typeof(SceneAsset)) as SceneAsset;
			}
		}

		Debug.LogWarning($"Scene [{sceneObjectName}] cannot be used. Add this scene to the 'Scenes in the Build' in build settings.");
		return null;
	}
}