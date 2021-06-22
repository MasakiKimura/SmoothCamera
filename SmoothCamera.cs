using System;
using System.Reflection;
using ICities;
using Harmony;
using UnityEngine;
using ColossalFramework.UI;

namespace SmoothCamera
{
    public class SmoothCamera : IUserMod
    {
        public string Name => "Smooth Camera";
        public string Description => "Make your camera movement more smoothly.";

        private const string HarmonyId = "MSKGaming.SmoothCamera";
        private HarmonyInstance _harmony;

        public const float Version = 2.00f;
        public static string VersionString = String.Format("Ver. {0:F}", Version);
        public static bool IsNeedToResetSetting = false;

        public static SmoothCameraConfiguration Config;

        public void OnEnabled()
        {
            if (_harmony != null) return;

            _harmony = HarmonyInstance.Create(HarmonyId);
            _harmony.PatchAll(GetType().Assembly);

#if DEBUG
            HarmonyInstance.DEBUG = true;
#endif

            Config = Configuration<SmoothCameraConfiguration>.Load();

            if (SmoothCamera.Config.VersionInfo < 2.00f && SmoothCameraSetting.HasChangedFromDefault())
            {
                IsNeedToResetSetting = true;
            }
        }

        public void OnDisabled()
        {
            Config = null;

            _harmony.UnpatchAll(HarmonyId);
            _harmony = null;
        }

        public void OnSettingsUI(UIHelperBase helper) => SmoothCameraSetting.OnSettingsUI(helper, SmoothCamera.VersionString);


    }

    public class SmoothCameraLoading : LoadingExtensionBase
    {
        public override void OnCreated(ILoading loading)
        {

        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);

            if (SmoothCamera.IsNeedToResetSetting)
            {
                // create dialog panel
                ExceptionPanel panel = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");

                // display a message for the user in the panel
                panel.SetMessage("Smooth Camera :" + SmoothCamera.VersionString, "Smooth Camera is updated. Your setting has been back to default. Please adjust it again.", false);
            }

 
        }
    }

    public class KeyInputThreading : ThreadingExtensionBase
    {
        public static bool enabledByKeyToggle = true;

        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            if (toggleKeyCode())
            {
                enabledByKeyToggle = !enabledByKeyToggle;
#if DEBUG
                UnityEngine.Debug.Log("Key Toggle changed: " + enabledByKeyToggle);
#endif
            }
        }

        private bool toggleKeyCode()
        {
            switch(SmoothCamera.Config.ToggleKeyCode)
            {
                case 0:
                    return false;
                case 1:
                    return Input.GetKeyUp(KeyCode.G);
                case 2:
                    return ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyUp(KeyCode.G));
                case 3:
                    return ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyUp(KeyCode.G));
                case 4:
                    return ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKeyUp(KeyCode.G));
                case 5:
                    return ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyUp(KeyCode.G));
                default:
                    return false;
            }
        }

    }

    [HarmonyPatch(typeof(RenderManager.CameraInfo), "CheckRenderDistance")]
    public static class RenderManagerCameraInfoCheckRenderDistancePatch
    {
        public static void Prefix(ref float maxDistance)
        {

            if (CameraControllerUpdateCurrentPositionPatch.ObjectLOD == 0)
            {
                maxDistance = 200.0f;
            }
            else if (CameraControllerUpdateCurrentPositionPatch.ObjectLOD == 1)
            {
                maxDistance = 300.0f;
            }
            else if (CameraControllerUpdateCurrentPositionPatch.ObjectLOD == 2)
            {
                maxDistance = 400.0f;
            }
            else if (CameraControllerUpdateCurrentPositionPatch.ObjectLOD == 3)
            {
                // Do nothing
            }
        }

    }

    [HarmonyPatch(typeof(CameraController), "UpdateCurrentPosition")]
    public static class CameraControllerUpdateCurrentPositionPatch
    {
        private static Vector3 m_previousPosition = new Vector3();
        private static float m_previousSize = 1.0f;
        private static Vector2 m_previousAngle = new Vector2();
        private static bool isFirst = true;
        private static bool isMoving = false;
        private static uint count = 0;
        private static int m_shadowQualityDefaultValue;
        private static int m_shadowDistanceDefaultValue;


        public static int ObjectLOD = 3;

        public static void Postfix(ref ColossalFramework.SavedInt ___m_ShadowsQuality,
                                    ref ColossalFramework.SavedInt ___m_ShadowsDistance,
                                    Vector3 ___m_targetPosition,
                                    float ___m_targetSize,
                                    Vector2 ___m_targetAngle,
                                    bool ___m_freeCamera)
        {
            if (isFirst)
            {
                m_previousPosition = ___m_targetPosition;
                m_previousSize = ___m_targetSize;
                m_previousAngle = ___m_targetAngle;
                isFirst = false;
                m_shadowQualityDefaultValue = ___m_ShadowsQuality.value;
                m_shadowDistanceDefaultValue = ___m_ShadowsDistance.value;
            }
            else
            {
                bool isMovedPosition = Vector3.Distance(m_previousPosition, ___m_targetPosition) > 0.3f;
                bool isMovedSize = m_previousSize != ___m_targetSize;
                bool isMovedAngle = m_previousAngle != ___m_targetAngle;

                bool isMoved = isMovedPosition || isMovedSize || isMovedAngle;

                bool isStartMoving = isMoved && !isMoving;
                bool isStopMoving = !isMoved && isMoving;

                bool isFreeCameraLimitation = ___m_freeCamera && SmoothCamera.Config.DontApplyWhenFreeCamera;

                if (isStartMoving && !isFreeCameraLimitation && KeyInputThreading.enabledByKeyToggle)
                {
                    if (count == 0)
                    {
                        m_shadowQualityDefaultValue = ___m_ShadowsQuality.value;
                        m_shadowDistanceDefaultValue = ___m_ShadowsDistance.value;
                    }
                    ___m_ShadowsQuality.value = SmoothCamera.Config.LightWeightShadowQuality;
                    ___m_ShadowsDistance.value = SmoothCamera.Config.LightWeightShadowQuality;
                    ObjectLOD = SmoothCamera.Config.LightWeightLevelOfDetail;

                    count = 0;
#if DEBUG
                    UnityEngine.Debug.Log("Change quality: shadow:" + ___m_ShadowsQuality.value + " lod:" + ObjectLOD);
#endif
                }

                if ((isStopMoving || count != 0))
                {
                    if (count++ > SmoothCamera.Config.ReturnDalayFrame)
                    {
                        ___m_ShadowsQuality.value = m_shadowQualityDefaultValue;
                        ___m_ShadowsDistance.value = m_shadowDistanceDefaultValue;

                        ObjectLOD = SmoothCameraConfiguration.DefaultLevelOfDetail_DefaultValue;

                        count = 0;

#if DEBUG
                    UnityEngine.Debug.Log("Change quality: shadow:" + ___m_ShadowsQuality.value + " lod:" + ObjectLOD);
#endif
                    }
#if DEBUG
                    UnityEngine.Debug.Log("stop moving count: " + count);
#endif
                }

                m_previousPosition = ___m_targetPosition;
                m_previousSize = ___m_targetSize;
                m_previousAngle = ___m_targetAngle;
                isMoving = isMoved;

            }
        }
    }

}