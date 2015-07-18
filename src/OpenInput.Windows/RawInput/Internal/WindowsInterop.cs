﻿namespace OpenInput
{
    using System;
    using System.Runtime.InteropServices;

    static partial class WindowsInterop
    {
        #region Helper Methods
        public static string GetDeviceDescription(string device)
        {
            string deviceDesc;
            try
            {
                var deviceKey = RawInput.RegistryAccess.GetDeviceKey(device);
                deviceDesc = deviceKey.GetValue("DeviceDesc").ToString();
                deviceDesc = deviceDesc.Substring(deviceDesc.IndexOf(';') + 1);
            }
            catch (Exception)
            {
                deviceDesc = "Device is malformed unable to look up in the registry";
            }
            
            return deviceDesc;
        }
        #endregion

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int GetRawInputData(IntPtr hRawInput, RawInput.DataCommand command, [Out] out RawInput.RawInputData buffer, [In, Out] ref int size, int cbSizeHeader);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int GetRawInputData(IntPtr hRawInput, RawInput.DataCommand command, [Out] IntPtr pData, [In, Out] ref int size, int sizeHeader);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern uint GetRawInputDeviceInfo(IntPtr hDevice, RawInput.RawInputDeviceInfo command, IntPtr pData, ref uint size);

        [DllImport("user32.dll")]
        public static extern uint GetRawInputDeviceInfo(IntPtr hDevice, uint command, ref RawInput.DeviceInfo data, ref uint dataSize);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern uint GetRawInputDeviceList(IntPtr pRawInputDeviceList, ref uint numberDevices, uint size);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool RegisterRawInputDevices(RawInput.RawInputDevice[] pRawInputDevice, uint numberDevices, uint size);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr notificationFilter, RawInput.DeviceNotification flags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterDeviceNotification(IntPtr handle);
    }
}
