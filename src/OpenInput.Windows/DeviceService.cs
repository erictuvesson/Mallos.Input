﻿namespace OpenInput
{
    using SharpDX.DirectInput;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    class DeviceService
    {
        public static Lazy<DeviceService> Service = new Lazy<DeviceService>();

        public DirectInput directInput;

        public Rectangle ScreenBounds;

        public DeviceService()
        {
            this.directInput = new DirectInput();

            // Does this create issues for multiple screens?
            this.ScreenBounds = Screen.GetBounds(new System.Drawing.Point(0, 0));
        }
    }
}
