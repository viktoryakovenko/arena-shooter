using UnityEngine;

namespace Code.UI
{
    public class DeviceChecker : MonoBehaviour
    {
        private void Start()
        {
            if (SystemInfo.deviceType != DeviceType.Desktop)
                Instantiate(Resources.Load("Hud/DesktopUI"), transform);
            else
                Instantiate(Resources.Load("Hud/MobileUI"), transform);

            Destroy(this);
        }
    }
}