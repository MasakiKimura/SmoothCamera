﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmoothCamera
{
    [ConfigurationPath("SmoothCamera.xml")]
    public class SmoothCameraConfiguration
    {
        public const int DefaultShadowQuality_DefaultValue = 3;
        public const int LightWeightShadowQuality_DefaultValue = 3;
        public const int DefaultLevelOfDetail_DefaultValue = 3;
        public const int LightWeightLevelOfDetail_DefaultValue = 1;
        public const bool ApplyAtPositionChange_DefaultValue = true;
        public const bool ApplyAtAngleChange_DefaultValue = true;
        public const bool ApplyAtZoomChange_DefaultValue = true;
        public const int ReturnDalayFrame_DefaultValue = 5;
        public const int ApplyThresholdFPS_DefaultValue = 0;
        public const bool DontApplyWhenFreeCamera_DefaultValue = true;
        public const float VersionInfo_DefaultValue = SmoothCamera.Version;

        public int DefaultShadowQuality { get; set; } = DefaultShadowQuality_DefaultValue;

        public int LightWeightShadowQuality { get; set; } = LightWeightShadowQuality_DefaultValue;

        public int DefaultLevelOfDetail { get; set; } = DefaultLevelOfDetail_DefaultValue;

        public int LightWeightLevelOfDetail { get; set; } = LightWeightLevelOfDetail_DefaultValue;

        public bool ApplyAtPositionChange { get; set; } = ApplyAtPositionChange_DefaultValue;

        public bool ApplyAtAngleChange { get; set; } = ApplyAtAngleChange_DefaultValue;

        public bool ApplyAtZoomChange  { get; set; } = ApplyAtZoomChange_DefaultValue;

        public int ReturnDalayFrame { get; set; } = ReturnDalayFrame_DefaultValue;

        public int ApplyThresholdFPS { get; set; } = ApplyThresholdFPS_DefaultValue;

        public bool DontApplyWhenFreeCamera { get; set; } = DontApplyWhenFreeCamera_DefaultValue;

        public float VersionInfo { get; set; } = 1.00f;
    }
}
