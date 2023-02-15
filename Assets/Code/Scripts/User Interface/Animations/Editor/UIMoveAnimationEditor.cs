using System;
using UnityEditor;

namespace UnityEngine.UI.Animation
{
    [CustomEditor(typeof(UIMoveAnimation))]
    public class UIMoveAnimationEditor : Editor
    {
        private UIMoveAnimation _ui;
        private bool _enabled, _editing;

        public override void OnInspectorGUI()
        {
            //Default Inspector
            base.OnInspectorGUI();

            //Buttons
            if (!_ui) _ui = target as UIMoveAnimation;
            ButtonsConditions(ref _enabled, "Show", "Hide", SceneView.RepaintAll, SceneView.RepaintAll);
            ButtonsConditions(ref _editing, "Edit Initial Position", "Final Position", _ui.StartEditInitPosition, _ui.StopEditInitPosition);

            if (_editing && GUILayout.Button("Save")) { _ui.SaveInitPosition(); SceneView.RepaintAll(); }
        }
        private void OnSceneGUI()
        {
            //show trails
            if (!_ui || !_enabled) return;
            if (!_editing) _ui.SaveEndPosition();

            Handles.color = Color.red;
            Handles.DrawLine(_ui.Init, _ui.Final, 1f);
        }
        private void ButtonsConditions(ref bool value, string first, string second, Action action1, Action action2)
        {
            if (!value && GUILayout.Button(first)) { value = !value; action1?.Invoke(); }
            else if (value && GUILayout.Button(second)) { value = !value; action2?.Invoke(); }
        }
    }
}