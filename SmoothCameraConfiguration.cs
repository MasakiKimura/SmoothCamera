using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmoothCamera
{
    [ConfigurationPath("SmoothCamera.xml")]
    public class SmoothCameraConfiguration
    {
        public int DefaultShadowQuality { get; set; } = 3;

        public int LightWeightShadowQuality { get; set; } = 0;

        public int DefaultLevelOfDetail { get; set; } = 3;

        public int LightWeightLevelOfDetail { get; set; } = 0;

        public bool ApplyAtPositionChange { get; set; } = true;

        public bool ApplyAtAngleChange { get; set; } = true;

        public bool ApplyAtZoomChange  { get; set; } = true;

        public int ReturnDalayFrame { get; set; } = 15;

        public int ApplyThresholdFPS { get; set; } = 30;
    }
}
