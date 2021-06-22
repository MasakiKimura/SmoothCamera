using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmoothCamera
{
    [ConfigurationPath("SmoothCamera.xml")]
    public class SmoothCameraConfiguration
    {
        public const int LightWeightShadowQuality_DefaultValue = 3;
        public const int DefaultLevelOfDetail_DefaultValue = 3;
        public const int LightWeightLevelOfDetail_DefaultValue = 1;
        public const int ReturnDalayFrame_DefaultValue = 0;
        public const bool DontApplyWhenFreeCamera_DefaultValue = true;
        public const int ToggleKeyCode_DefaultValue = 2;
        public const float VersionInfo_DefaultValue = SmoothCamera.Version;

        public int LightWeightShadowQuality { get; set; } = LightWeightShadowQuality_DefaultValue;

        public int LightWeightLevelOfDetail { get; set; } = LightWeightLevelOfDetail_DefaultValue;

        public int ReturnDalayFrame { get; set; } = ReturnDalayFrame_DefaultValue;

        public bool DontApplyWhenFreeCamera { get; set; } = DontApplyWhenFreeCamera_DefaultValue;

        public int ToggleKeyCode { get; set; } = ToggleKeyCode_DefaultValue;

        public float VersionInfo { get; set; } = 1.00f;
    }
}
