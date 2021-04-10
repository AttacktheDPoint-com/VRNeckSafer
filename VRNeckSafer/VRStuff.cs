using SharpDX;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Valve.VR;

namespace VRNeckSafer
{
    public class VRStuff
    {
        static public Config conf;

        private CVRSystem system;
        private TrackedDevicePose_t[] Poses;
        private HmdMatrix34_t HmdPose;
        public Vector3 deltaPos;
        public double deltaRot;
        double HMDYawOffset;

        public VRStuff()
        {
            var initError = EVRInitError.None;

            Poses = new TrackedDevicePose_t[OpenVR.k_unMaxTrackedDeviceCount];

            EVRApplicationType ea;
            switch (conf.AppMode)
            {
                case "Background":
                    ea = EVRApplicationType.VRApplication_Background;
                    break;
                default:
                    ea = EVRApplicationType.VRApplication_Overlay;
                    break;
            }

            var task = Task.Run(() => OpenVR.Init(ref initError, ea));//you can pass parameters to the method as well
            if (task.Wait(TimeSpan.FromSeconds(5)))
                system = task.Result; //the method returns elegantly
            else
                initError = EVRInitError.Unknown;

            if (initError != EVRInitError.None)
            {
                if (initError == EVRInitError.Unknown)
                {
                    MessageBox.Show("SteamVR timed out!\r\n try to restart SteamVR/Oculus/WMR", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Unable to connect to SteamVR/OpenVR", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                System.Environment.Exit(0);
            }
        }

        public bool isSeatedMode()
        {
            if (conf.GameMode == "Force seated") return true;
            if (conf.GameMode == "Force standing") return false;
            return OpenVR.Compositor.GetTrackingSpace() == ETrackingUniverseOrigin.TrackingUniverseSeated;
        }

        public void calcPositionOffset()
        {
            system.GetDeviceToAbsoluteTrackingPose(ETrackingUniverseOrigin.TrackingUniverseStanding, 0.0f, Poses);
            deltaPos = new Vector3(
                Poses[0].mDeviceToAbsoluteTracking.m3,
                Poses[0].mDeviceToAbsoluteTracking.m7,
                Poses[0].mDeviceToAbsoluteTracking.m11);
            deltaRot = Math.Atan2(Poses[0].mDeviceToAbsoluteTracking.m2, Poses[0].mDeviceToAbsoluteTracking.m10);
        }

        public void getHmdSeatedPositionOffset()
        {
            deltaPos = new Vector3(0, 0, 0);
            deltaRot = 0;

            if (conf.PosCompensation == "always") calcPositionOffset();
            if (conf.PosCompensation == "when seated" && isSeatedMode()) calcPositionOffset();
            if (conf.PosCompensation == "when standing" && !isSeatedMode()) calcPositionOffset();
        }

        public bool HmdIsActive()
        {
            if (system.GetTrackedDeviceActivityLevel(0) == EDeviceActivityLevel.k_EDeviceActivityLevel_UserInteraction)
                return true;
            else
                return false;
        }

        public void getHMDPose()
        {
            if (isSeatedMode())
                system.GetDeviceToAbsoluteTrackingPose(ETrackingUniverseOrigin.TrackingUniverseSeated, 0.0f, Poses);
            else
                system.GetDeviceToAbsoluteTrackingPose(ETrackingUniverseOrigin.TrackingUniverseStanding, 0.0f, Poses);
            HmdPose = Poses[0].mDeviceToAbsoluteTracking;
        }
        public void getHmdYawOffset()
        {
            getHMDPose();
            HMDYawOffset = (float)Math.Atan2(HmdPose.m2, HmdPose.m10);
        }

        public int getHmdYaw()
        {
            getHMDPose();
            double HMDYaw = Math.Atan2(HmdPose.m2, HmdPose.m10);
            return (int)Math.Round((HMDYaw - HMDYawOffset) * 180.0 / Math.PI);
        }
        public int getHmdPitch()
        {
            getHMDPose();
            double HMDPitch = Math.Atan2(Math.Sqrt(HmdPose.m2 * HmdPose.m2 + HmdPose.m10 * HmdPose.m10), HmdPose.m6);
            return (int)Math.Round((HMDPitch) * 180.0 / Math.PI);
        }


        public void setOffset(int a, Vector3 trans)
        {
            double Angle = a * Math.PI / 180.0;

            HmdMatrix34_t resetCenter = new HmdMatrix34_t()
            { m0 = 1, m1 = 0, m2 = 0, m3 = deltaPos.X, m4 = 0, m5 = 1, m6 = 0, m7 = deltaPos.Y, m8 = 0, m9 = 0, m10 = 1, m11 = deltaPos.Z };
            setChaperone(resetCenter);

            getHMDPose();

            // IL-2: deltaRot and deltaPos = 0
            // DCS: HMDYawOffset =0
            Vector3 newTrans = rotateCoord(trans, -HMDYawOffset);

            Vector3 oldHmdXyz = new Vector3(HmdPose.m3, HmdPose.m7, HmdPose.m11);
            oldHmdXyz = rotateCoord(oldHmdXyz, -deltaRot);
            oldHmdXyz = Vector3.Add(oldHmdXyz, deltaPos);

            Vector3 newHmdXyz = new Vector3(HmdPose.m3, HmdPose.m7, HmdPose.m11);

            newHmdXyz = Vector3.Subtract(newHmdXyz, newTrans);
            newHmdXyz = rotateCoord(newHmdXyz, -Angle - deltaRot);

            Vector3 Xyz = Vector3.Subtract(oldHmdXyz, newHmdXyz);

            float c = (float)Math.Cos(Angle + deltaRot);
            float s = (float)Math.Sin(Angle + deltaRot);

            HmdMatrix34_t rotatedCenter = new HmdMatrix34_t()
            { m0 = c, m1 = 0, m2 = s, m3 = Xyz.X, m4 = 0, m5 = 1, m6 = 0, m7 = Xyz.Y, m8 = -s, m9 = 0, m10 = c, m11 = Xyz.Z };

            setChaperone(rotatedCenter);
        }

        void setChaperone(HmdMatrix34_t newSetup)
        {

            if (isSeatedMode())
                OpenVR.ChaperoneSetup.SetWorkingSeatedZeroPoseToRawTrackingPose(ref newSetup);
            else
                OpenVR.ChaperoneSetup.SetWorkingStandingZeroPoseToRawTrackingPose(ref newSetup);

            OpenVR.ChaperoneSetup.ShowWorkingSetPreview();
        }

        public Vector3 rotateCoord(Vector3 v, double a)
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
