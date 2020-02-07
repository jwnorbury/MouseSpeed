using System.Runtime.InteropServices;

namespace MouseSpeed
{
    public class MouseHandler
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SystemParametersInfo")]
        private static extern bool SetMouseSpeed(uint uiAction, uint uiParam, uint speed, uint fWinIni);

        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SystemParametersInfo")]
        private static extern bool GetMouseSpeed(uint uiAction, uint uiParam, ref uint speed, uint fWinIni);

        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SystemParametersInfo")]
        private static extern bool SetMouseAcceleration(uint uiAction, uint uiParam, uint[] mouseInfo, uint fWinIni);

        public static uint GetMouseSpeed()
        {
            uint speed = 0;
            GetMouseSpeed(112, 0, ref speed, 0);
            return speed;
        }

        public static void SetMouseSpeed(uint speed)
        {
            SetMouseSpeed(113, 0, speed, 0);
        }

        public static void SetMouseAcceleration(bool enabled)
        {
            var mouseInfo = enabled
                ? new uint[] { 0, 0, 1 }
                : new uint[] { 0, 0, 0 };
            SetMouseAcceleration(4, 0, mouseInfo, 0);
        }
    }
}
