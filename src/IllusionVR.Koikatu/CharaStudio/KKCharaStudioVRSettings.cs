﻿using System.Xml.Serialization;
using VRGIN.Core;

namespace IllusionVR.Koikatu.CharaStudio
{
    [XmlRoot("Settings")]
    public class KKCharaStudioVRSettings : VRSettings
    {
        private bool _LockRotXZ = true;

        public static KKCharaStudioVRSettings Load(string path)
        {
            return Load<KKCharaStudioVRSettings>(path);
        }

        [XmlComment("Lock XZ Axis (pitch / roll) rotation.")]
        public bool LockRotXZ
        {
            get => _LockRotXZ;
            set
            {
                _LockRotXZ = value;
                TriggerPropertyChanged("LockRotXZ");
            }
        }
    }
}
