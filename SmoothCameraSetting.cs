using System;
using System.Collections.Generic;
using System.Linq;
using ICities;

namespace SmoothCamera
{
    public static class SmoothCameraSetting
    {
        private static readonly string[] ShadowQualityLabels =
{
            "None",
            "Low",
            "Middle",
            "High"
        };

        private static readonly string[] LevelOfDetailLabels =
        {
            "Low",
            "Middle",
            "High",
            "Excellent"
        };

        private static readonly string[] IntegerLabels =
        {
            "Disable",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
        };

        private static readonly int[] IntegerValues =
        {
            0,
            5,
            10,
            15,
            20,
            25,
            30,
            35,
            40,
            45,
            50,
            55,
            60,
        };

        private static readonly string[] ToggleKeyCode =
        {
            "Disable",
            "G",
            "Ctrl + G",
            "Shift + G",
            "Alt + G",
            "Ctrl + Shift + G",
        };

        public static void OnSettingsUI(UIHelperBase helper, String versionString)
        {
            if (SmoothCamera.IsNeedToResetSetting)
            {
                SetDefaultValues();
            }

            // Load the configuration
            SmoothCameraConfiguration config = Configuration<SmoothCameraConfiguration>.Load();

            var group = helper.AddGroup("Smooth Camera " + versionString);

            // Default shadow quality 
            int defaultShadowQualitySelectedIndex = config.DefaultShadowQuality;
            group.AddDropdown("Default shadow quality", ShadowQualityLabels, defaultShadowQualitySelectedIndex, sel =>
            {
                // Change config value and save config
                config.DefaultShadowQuality = sel;
                Configuration<SmoothCameraConfiguration>.Save();
            });

            //  Light weight shadow quality
            int lightWeightShadowQualitySelectedIndex = config.LightWeightShadowQuality;
            group.AddDropdown("Light weight shadow quality", ShadowQualityLabels, lightWeightShadowQualitySelectedIndex, sel =>
            {
                // Change config value and save config
                config.LightWeightShadowQuality = sel;
                Configuration<SmoothCameraConfiguration>.Save();
            });

            //  Default level of detail
            int defaultLevelOfDetailSelectedIndex = config.DefaultLevelOfDetail;
            group.AddDropdown("Default level of detail", LevelOfDetailLabels, defaultLevelOfDetailSelectedIndex, sel =>
            {
                // Change config value and save config
                config.DefaultLevelOfDetail = sel;
                Configuration<SmoothCameraConfiguration>.Save();
            });

            //  Light weight level of detail
            int lightWeightLevelOfDetailSelectedIndex = config.LightWeightLevelOfDetail;
            group.AddDropdown("Light weight level of detail", LevelOfDetailLabels, lightWeightLevelOfDetailSelectedIndex, sel =>
            {
                // Change config value and save config
                config.LightWeightLevelOfDetail = sel;
                Configuration<SmoothCameraConfiguration>.Save();
            });
            /*
            //  Apply at position change
            group.AddCheckbox("Apply at position change.", config.ApplyAtPositionChange, sel =>
            {
                config.ApplyAtPositionChange = sel;
                Configuration<SmoothCameraConfiguration>.Save();
            });

            //  Apply at angle change
            group.AddCheckbox("Apply at angle change.", config.ApplyAtAngleChange, sel =>
            {
                config.ApplyAtAngleChange = sel;
                Configuration<SmoothCameraConfiguration>.Save();
            });

            //  Apply at zoom change
            group.AddCheckbox("Apply at zoom change.", config.ApplyAtZoomChange, sel =>
            {
                config.ApplyAtZoomChange = sel;
                Configuration<SmoothCameraConfiguration>.Save();
            });
            */
            //  Return delay frame
            int returnDelayFrameSelectedIndex = GetSelectedOptionIndex(config.ReturnDalayFrame, IntegerValues);
            group.AddDropdown("Return delay frame (Default:5)", IntegerLabels, returnDelayFrameSelectedIndex, sel =>
            {
                // Change config value and save config
                config.ReturnDalayFrame = IntegerValues[sel];
                Configuration<SmoothCameraConfiguration>.Save();
            });

            //  ApplyThresholdFPS
            int applyThreasholdFPSSelectedIndex = GetSelectedOptionIndex(config.ApplyThresholdFPS, IntegerValues);
            group.AddDropdown("Apply only when FPS is slower than this value.(Default:Disable) ", IntegerLabels, applyThreasholdFPSSelectedIndex, sel =>
            {
                // Change config value and save config
                config.ApplyThresholdFPS = IntegerValues[sel];
                Configuration<SmoothCameraConfiguration>.Save();
            });

            int toggleKeyCodeIndex = config.ToggleKeyCode;
            group.AddDropdown("ToggleKeyCode.(Default:Ctrl + G) ", ToggleKeyCode, toggleKeyCodeIndex, sel =>
            {
                // Change config value and save config
                config.ToggleKeyCode = sel;
                Configuration<SmoothCameraConfiguration>.Save();
            });

            //  Dont apply when FreeCamera
            group.AddCheckbox("Don't apply when a FreeCamera mode is enabled.", config.DontApplyWhenFreeCamera, sel =>
            {
                config.DontApplyWhenFreeCamera = sel;
                Configuration<SmoothCameraConfiguration>.Save();
            });

        }

        public static void SetDefaultValues()
        {
            SmoothCameraConfiguration config = Configuration<SmoothCameraConfiguration>.Load();

            config.DefaultShadowQuality = SmoothCameraConfiguration.DefaultShadowQuality_DefaultValue;
            config.LightWeightShadowQuality = SmoothCameraConfiguration.LightWeightShadowQuality_DefaultValue;
            config.DefaultLevelOfDetail = SmoothCameraConfiguration.DefaultLevelOfDetail_DefaultValue;
            config.LightWeightLevelOfDetail = SmoothCameraConfiguration.LightWeightLevelOfDetail_DefaultValue;
            config.ApplyAtPositionChange = SmoothCameraConfiguration.ApplyAtPositionChange_DefaultValue;
            config.ApplyAtAngleChange = SmoothCameraConfiguration.ApplyAtAngleChange_DefaultValue;
            config.ApplyAtZoomChange = SmoothCameraConfiguration.ApplyAtZoomChange_DefaultValue;
            config.ReturnDalayFrame = SmoothCameraConfiguration.ReturnDalayFrame_DefaultValue;
            config.ApplyThresholdFPS = SmoothCameraConfiguration.ApplyThresholdFPS_DefaultValue;
            config.DontApplyWhenFreeCamera = SmoothCameraConfiguration.DontApplyWhenFreeCamera_DefaultValue;
            config.ToggleKeyCode = SmoothCameraConfiguration.ToggleKeyCode_DefaultValue;
            config.VersionInfo = SmoothCameraConfiguration.VersionInfo_DefaultValue;
            Configuration<SmoothCameraConfiguration>.Save();
        }

        public static bool HasChangedFromDefault()
        {
            SmoothCameraConfiguration config = Configuration<SmoothCameraConfiguration>.Load();

            bool sameAsDefault = config.DefaultShadowQuality == SmoothCameraConfiguration.DefaultShadowQuality_DefaultValue
                && config.LightWeightShadowQuality == SmoothCameraConfiguration.LightWeightShadowQuality_DefaultValue
                && config.DefaultLevelOfDetail == SmoothCameraConfiguration.DefaultLevelOfDetail_DefaultValue
                && config.LightWeightLevelOfDetail == SmoothCameraConfiguration.LightWeightLevelOfDetail_DefaultValue
                && config.ApplyAtPositionChange == SmoothCameraConfiguration.ApplyAtPositionChange_DefaultValue
                && config.ApplyAtAngleChange == SmoothCameraConfiguration.ApplyAtAngleChange_DefaultValue
                && config.ApplyAtZoomChange == SmoothCameraConfiguration.ApplyAtZoomChange_DefaultValue
                && config.ReturnDalayFrame == SmoothCameraConfiguration.ReturnDalayFrame_DefaultValue
                && config.ApplyThresholdFPS == SmoothCameraConfiguration.ApplyThresholdFPS_DefaultValue
                && config.DontApplyWhenFreeCamera == SmoothCameraConfiguration.DontApplyWhenFreeCamera_DefaultValue
                && config.ToggleKeyCode == SmoothCameraConfiguration.ToggleKeyCode_DefaultValue;

            return !sameAsDefault;
        }

        private static int GetSelectedOptionIndex(int value, int[] optionValues)
        {
            int index = Array.IndexOf(optionValues, value);
            if (index < 0) index = 0;

            return index;
        }
    }
}
