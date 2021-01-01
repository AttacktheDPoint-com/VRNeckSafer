using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using Valve.VR;
using System.Windows.Forms;
using System.Threading;

namespace VRNeckSafer
{
    class VRStuff
    {
        private CVRSystem system;
        private TrackedDevicePose_t[] Poses;
        private HmdMatrix34_t HmdPose;
        private Vector3 DiffXyz;

        private float lastAngle;
        private HmdMatrix34_t seated,lll;
        public String debugMsg;
        public Vector3 deltaPos;

        public VRStuff()
        {
            var initError = EVRInitError.None;

            Poses = new TrackedDevicePose_t[OpenVR.k_unMaxTrackedDeviceCount];

            system = OpenVR.Init(ref initError, EVRApplicationType.VRApplication_Overlay);
            

            if (initError != EVRInitError.None)
            {
                MessageBox.Show("Unable to connect to SteamVR/OpenVR","Problem",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }

            getHmdSeatedPositionOffset();
        }

        public void getHmdSeatedPositionOffset()
        {
            system.GetDeviceToAbsoluteTrackingPose(ETrackingUniverseOrigin.TrackingUniverseSeated, 0.0f, Poses);
            Vector3 V1 = new Vector3(
                Poses[0].mDeviceToAbsoluteTracking.m3,
                Poses[0].mDeviceToAbsoluteTracking.m7,
                Poses[0].mDeviceToAbsoluteTracking.m11);

            system.GetDeviceToAbsoluteTrackingPose(ETrackingUniverseOrigin.TrackingUniverseStanding, 0.0f, Poses);
            Vector3 V2 = new Vector3(
                Poses[0].mDeviceToAbsoluteTracking.m3,
                Poses[0].mDeviceToAbsoluteTracking.m7,
                Poses[0].mDeviceToAbsoluteTracking.m11);
            deltaPos = Vector3.Subtract(V2, V1);
        }

        public bool HmdIsActive()
        {
            if (system.GetTrackedDeviceActivityLevel(0) == EDeviceActivityLevel.k_EDeviceActivityLevel_UserInteraction)
                return true;
            else
                return false;
        }

        public int getHmdYaw()
        {
            system.GetDeviceToAbsoluteTrackingPose(ETrackingUniverseOrigin.TrackingUniverseSeated, 0.0f, Poses);
            HmdPose = Poses[0].mDeviceToAbsoluteTracking;

            OpenVR.ChaperoneSetup.GetWorkingSeatedZeroPoseToRawTrackingPose(ref lll);
            debugMsg = lll.m0 +" "+ lll.m1 + " " + lll.m2 + " " + lll.m3 + " " + lll.m4 ;

            return (int) (Math.Round(Math.Atan2(HmdPose.m2, HmdPose.m10)* 180.0/Math.PI));
        }

        public void setOffsetAngle(int a, Vector3 trans)
        {
            float Angle = (float)(a * Math.PI / 180.0);

            ETrackingUniverseOrigin origin = OpenVR.Compositor.GetTrackingSpace();

            system.GetDeviceToAbsoluteTrackingPose(origin, 0.0f, Poses);
            HmdPose = Poses[0].mDeviceToAbsoluteTracking;
            Vector3 oldHmdXyz = new Vector3(HmdPose.m3, HmdPose.m7, HmdPose.m11);
            Vector3 newHmdXyz = new Vector3(HmdPose.m3, HmdPose.m7, HmdPose.m11);


            newHmdXyz = rotateCoord(newHmdXyz, -Angle);
            Vector3 Xyz = Vector3.Add(Vector3.Add(Vector3.Subtract(oldHmdXyz, newHmdXyz), deltaPos), trans);

            float c = (float)Math.Cos(Angle);
            float s = (float)Math.Sin(Angle);

            HmdMatrix34_t rotatedCenter = new HmdMatrix34_t()
            {
                m0 = c,
                m1 = 0,
                m2 = s,
                m3 = Xyz.X,
                m4 = 0,
                m5 = 1,
                m6 = 0,
                m7 = Xyz.Y,
                m8 = -s,
                m9 = 0,
                m10 = c,
                m11 = Xyz.Z,
            };

            if (origin == ETrackingUniverseOrigin.TrackingUniverseSeated)
                OpenVR.ChaperoneSetup.SetWorkingSeatedZeroPoseToRawTrackingPose(ref rotatedCenter);
            else
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
