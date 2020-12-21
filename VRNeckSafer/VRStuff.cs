using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using Valve.VR;

namespace VRNeckSafer
{
    class VRStuff
    {
        private CVRSystem system;
        private TrackedDevicePose_t[] Poses;
        private HmdMatrix34_t HmdPose;
         
        private float Angle;

        public  VRStuff()
        {
            var initError = EVRInitError.None;

            system = OpenVR.Init(ref initError, EVRApplicationType.VRApplication_Utility);

            if (initError != EVRInitError.None)
                return;

            Poses = new TrackedDevicePose_t[OpenVR.k_unMaxTrackedDeviceCount];
        }

        public int getHmdYaw()
        {
            system.GetDeviceToAbsoluteTrackingPose(ETrackingUniverseOrigin.TrackingUniverseStanding, 0.0f, Poses);
            HmdPose = Poses[0].mDeviceToAbsoluteTracking;
            
            return (int) (Math.Round(Math.Atan2(HmdPose.m2, HmdPose.m10)* 180.0/Math.PI));
        }

        public void setOffsetAngle(float a)
        {
            Angle = a;

            float c = (float)Math.Cos(Angle);
            float s = (float)Math.Sin(Angle);

            HmdMatrix34_t rotatedCenter = new HmdMatrix34_t()
            {
                m0 = c,
                m1 = 0,
                m2 = s,
                m3 = 0,
                m4 = 0,
                m5 = 1,
                m6 = 0,
                m7 = 0,
                m8 = -s,
                m9 = 0,
                m10 = c,
                m11 = 0
            };
            OpenVR.ChaperoneSetup.SetWorkingStandingZeroPoseToRawTrackingPose(ref rotatedCenter);
            OpenVR.ChaperoneSetup.ShowWorkingSetPreview();

        }

    }
}
