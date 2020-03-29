﻿// Copyright (c) XRTK. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEditor;
using UnityEngine;
using XRTK.Definitions.Utilities;
using XRTK.Inspectors.Profiles.InputSystem;
using XRTK.Inspectors.Utilities;
using XRTK.Oculus.Profiles;

namespace XRTK.Oculus.Inspectors
{
    /// <summary>
    /// Default inspector for <see cref="OculusHandControllerDataProviderProfile"/>.
    /// </summary>
    [CustomEditor(typeof(OculusHandControllerDataProviderProfile))]
    public class OculusHandControllerDataProviderProfileInspector : BaseMixedRealityHandDataProviderProfileInspector
    {
        private SerializedProperty minConfidenceRequired;

        protected override void OnEnable()
        {
            base.OnEnable();

            minConfidenceRequired = serializedObject.FindProperty(nameof(minConfidenceRequired));
        }

        public override void OnInspectorGUI()
        {
            MixedRealityInspectorUtility.RenderMixedRealityToolkitLogo();

            if (ThisProfile.ParentProfile != null &&
                GUILayout.Button("Back To Configuration Profile"))
            {
                Selection.activeObject = ThisProfile.ParentProfile;
            }

            ThisProfile.CheckProfileLock();

            base.OnInspectorGUI();

            serializedObject.Update();

            EditorGUILayout.BeginVertical();

            EditorGUILayout.Space();
            SupportedPlatforms supportedPlatforms = SupportedPlatforms.Android | SupportedPlatforms.Editor;
            if (MixedRealityInspectorUtility.CheckProfilePlatform(supportedPlatforms,
                $"You can't edit platform specific hand configuration with the current build target. Please switch to {supportedPlatforms}."))
            {
                EditorGUILayout.PropertyField(minConfidenceRequired);
            }

            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}