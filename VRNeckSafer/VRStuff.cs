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
        private Vector3 DiffXyz;

        private float lastAngle;

        public VRStuff()
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

        public void setOffsetAngle(int a, Vector3 trans)
        {
            float Angle = (float)(a * Math.PI / 180.0);

            system.GetDeviceToAbsoluteTrackingPose(ETrackingUniverseOrigin.TrackingUniverseStanding, 0.0f, Poses);
            HmdPose = Poses[0].mDeviceToAbsoluteTracking;

            Vector3 oldHmdXyz = new Vector3(HmdPose.m3, 0.0F, HmdPose.m11);
            Vector3 newHmdXyz = new Vector3(HmdPose.m3, 0.0F, HmdPose.m11);

          
            newHmdXyz = rotateCoord(newHmdXyz, -Angle);

            DiffXyz = Vector3.Subtract(oldHmdXyz, newHmdXyz );

            float c = (float)Math.Cos(Angle);
            float s = (float)Math.Sin(Angle);

            HmdMatrix34_t rotatedCenter = new HmdMatrix34_t()
            {
                m0 = c,
                m1 = 0,
                m2 = s,
                m3 = DiffXyz.X + trans.X,
                m4 = 0,
                m5 = 1,
                m6 = 0,
                m7 = DiffXyz.Y,
                m8 = -s,
                m9 = 0,
                m10 = c,
                m11 = DiffXyz.Z + trans.Z,
            };
            OpenVR.ChaperoneSetup.SetWorkingStandingZeroPoseToRawTrackingPose(ref rotatedCenter);
            OpenVR.ChaperoneSetup.ShowWorkingSetPreview();

            lastAngle = Angle;

        }
        public Vector3 rotateCoord(Vector3 v, float a)
        {
            double s = Math.Sin(a);
            double c = Math.Cos(a);
            double X = v.X * c - v.Z * s;
            double Z = v.X * s + v.Z * c;
            v.X = (float)X;
            v.Z = (float)Z;
            return v;
        }

    }
}
