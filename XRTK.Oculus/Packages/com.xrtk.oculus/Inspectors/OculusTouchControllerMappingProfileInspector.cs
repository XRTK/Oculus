﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.﻿

using UnityEditor;
using XRTK.Inspectors.Profiles;
using XRTK.Oculus.Profiles;

namespace XRTK.Oculus.Inspectors
{
    [CustomEditor(typeof(OculusTouchControllerMappingProfile))]
    public class OculusTouchControllerMappingProfileInspector : BaseMixedRealityControllerMappingProfileInspector { }
}