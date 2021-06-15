using System;
using ICities;
using Harmony;
using UnityEngine;

namespace SmoothCamera
{
    public class SmoothCamera : IUserMod
    {
        public string Name => "Smooth Camera";
        public string Description => "Make your camera movement more smoothly.";

        private const string HarmonyId = "MSKGaming.SmoothCamera";
        private HarmonyInstance _harmony;

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
        }

        public void OnDisabled()
        {
            Config = null;

            _harmony.UnpatchAll(HarmonyId);
            _harmony = null;
        }

        public void OnSettingsUI(UIHelperBase helper) => SmoothCameraSetting.OnSettingsUI(helper);


    }

    public class SmoothCameraLoading : LoadingExtensionBase
    {
        public override void OnCreated(ILoading loading)
        {

        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);

        }
    }

    public class KeyInputThreading : ThreadingExtensionBase
    {
        public static bool isSlowerThanThreshold = false;

        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            if (SmoothCamera.Config.ApplyThresholdFPS > 0)
            {
                float realFPS = 1.0f / realTimeDelta;

                isSlowerThanThreshold = realFPS < (float)SmoothCamera.Config.ApplyThresholdFPS ? true : false;

                //UnityEngine.Debug.Log("realFPS:" + realFPS + "    threshold: " + SmoothCamera.Config.ApplyThresholdFPS);
            }
            else
            {
                isSlowerThanThreshold = true;
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

        public static void Postfix(ref ColossalFramework.SavedInt ___m_ShadowsQuality,
                                    ref ColossalFramework.SavedInt ___m_ShadowsDistance,
                                    Vector3 ___m_targetPosition,
                                    float ___m_targetSize,
                                    Vector2 ___m_targetAngle)
        {
            if (isFirst)
            {
                m_previousPosition = ___m_targetPosition;
                m_previousSize = ___m_targetSize;
                m_previousAngle = ___m_targetAngle;
                isFirst = false;
            }
            else
            {
                bool isMovedPosition = Vector3.Distance(m_previousPosition, ___m_targetPosition) > 0.3f;
                bool isMovedSize = m_previousSize != ___m_targetSize;
                bool isMovedAngle = m_previousAngle != ___m_targetAngle;

                bool isMoved = (isMovedPosition && SmoothCamera.Config.ApplyAtPositionChange) 
                            || (isMovedSize && SmoothCamera.Config.ApplyAtZoomChange)
                            || (isMovedAngle && SmoothCamera.Config.ApplyAtAngleChange);

                //UnityEngine.Debug.Log("___m_targetPosition: " + ___m_targetPosition + "Distance: " + Vector3.Distance(m_previousPosition, ___m_targetPosition));

                bool isStartMoving = isMoved && !isMoving;
                bool isStopMoving = !isMoved && isMoving;

                if (isStartMoving && KeyInputThreading.isSlowerThanThreshold)
                {
                    ___m_ShadowsQuality.value = SmoothCamera.Config.LightWeightShadowQuality;
                    ___m_ShadowsDistance.value = SmoothCamera.Config.LightWeightShadowQuality;
                    RenderManager.LevelOfDetail = SmoothCamera.Config.LightWeightLevelOfDetail;

                    count = 0;
#if DEBUG
                    UnityEngine.Debug.Log("Change quality: shadow:" + ___m_ShadowsQuality.value + " lod:" + RenderManager.LevelOfDetail);
#endif
                }

                if (isStopMoving || count != 0)
                {
                    if (count++ > SmoothCamera.Config.ReturnDalayFrame)
                    {
                        if (___m_ShadowsQuality.value != SmoothCamera.Config.DefaultShadowQuality)
                        {
                            ___m_ShadowsQuality.value = SmoothCamera.Config.DefaultShadowQuality;
                            ___m_ShadowsDistance.value = SmoothCamera.Config.DefaultShadowQuality;
                        }

                        if (RenderManager.LevelOfDetail != SmoothCamera.Config.DefaultLevelOfDetail)
                        {
                            RenderManager.LevelOfDetail = SmoothCamera.Config.DefaultLevelOfDetail;
                        }

                        count = 0;

#if DEBUG
                    UnityEngine.Debug.Log("Change quality: shadow:" + ___m_ShadowsQuality.value + " lod:" + RenderManager.LevelOfDetail);
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