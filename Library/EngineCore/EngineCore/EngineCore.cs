﻿using System;
            public enum DeviceTypes { Mouse, Keyboard };

            private DeviceTypes _deviceType;
                this._deviceType = DeviceTypes.Keyboard;
            {
                set
                {
                    this._deviceType = value;
                }
                get
                {
                    return this._deviceType;
                }
            }