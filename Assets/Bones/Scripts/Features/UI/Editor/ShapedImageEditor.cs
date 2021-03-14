using UnityEditor;
using UnityEditor.UI;

namespace UITools
{
    [CustomEditor(typeof(ShapedImage), true)]
    [CanEditMultipleObjects]
    public class ShapedImageEditor : ImageEditor
    {
        private SerializedProperty cornerDivisions;
        private SerializedProperty amount;
        private SerializedProperty desiredCornerRadius;

        protected override void OnEnable()
        {
            base.OnEnable();
            cornerDivisions = serializedObject.FindProperty("cornerDivisions");
            amount = serializedObject.FindProperty("amount");
            desiredCornerRadius = serializedObject.FindProperty("desiredCornerRadius");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();

            EditorGUILayout.Separator();
            
            var modified = false;
            modified |= EditorGUILayout.PropertyField(cornerDivisions);
            modified |= EditorGUILayout.PropertyField(amount);
            modified |= EditorGUILayout.PropertyField(desiredCornerRadius);

            serializedObject.ApplyModifiedProperties();
        }
    }
}