using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.DeviceSimulation;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    [UsedImplicitly]
    internal sealed class DeviceSimulatorMuteAudioPlugin : DeviceSimulatorPlugin
    {
        public override string title => "Mute Audio";

        private Button m_button;

        public override VisualElement OnCreateUI()
        {
            m_button = new();
            m_button.clicked += () =>
            {
                EditorUtility.audioMasterMute = !EditorUtility.audioMasterMute;
                UpdateButtonText();
            };

            UpdateButtonText();

            var root = new VisualElement();
            root.Add( m_button );

            return root;
        }

        private void UpdateButtonText()
        {
            m_button.text = EditorUtility.audioMasterMute ? "ON" : "OFF";
        }
    }
}