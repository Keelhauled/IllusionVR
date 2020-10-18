﻿using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using VRGIN.Controls.Speech;
using VRGIN.Core;
using VRGIN.Visuals;

namespace IllusionVR.Koikatu
{
    /// <summary>
    /// Context class that can be serialized as an XML. Normally, you would implement this yourself and simply override getters with sensible values.
    /// </summary>
    [XmlRoot("Context")]
    public class ConfigurableContext : IVRManagerContext
    {
        public ConfigurableContext()
        {
            // We'll keep those always the same
            _Materials = new DefaultMaterialPalette();
            Settings = KoikatuSettings.Load(Path.Combine(BepInEx.Paths.ConfigPath, "VRSettings.xml"));

            // Set defaults
            ConfineMouse = true;
            EnforceDefaultGUIMaterials = false;
            GUIAlternativeSortingMode = false;
            GuiLayer = "Default";
            GuiFarClipPlane = 1000f;
            GuiNearClipPlane = -1000f;
            IgnoreMask = 0;
            InvisibleLayer = "Ignore Raycast";
            PrimaryColor = Color.cyan;
            SimulateCursor = true;
            UILayer = "UI";
            UILayerMask = LayerMask.GetMask(UILayer);
            UnitToMeter = 1f;
            NearClipPlane = 0.001f;
            PreferredGUI = GUIType.uGUI;
            CameraClearFlags = CameraClearFlags.Skybox;
        }

        [XmlIgnore]
        public IMaterialPalette Materials => _Materials;
        private DefaultMaterialPalette _Materials;

        [XmlIgnore]
        public VRSettings Settings { get; }

        [XmlIgnore]
        public Type VoiceCommandType => typeof(VoiceCommand);

        public bool ConfineMouse { get; set; }

        public bool EnforceDefaultGUIMaterials { get; set; }

        public bool GUIAlternativeSortingMode { get; set; }

        public float GuiFarClipPlane { get; set; }

        public string GuiLayer { get; set; }

        public float GuiNearClipPlane { get; set; }

        public int IgnoreMask { get; set; }

        public string InvisibleLayer { get; set; }

        public Color PrimaryColor { get; set; }

        public bool SimulateCursor { get; set; }

        public string UILayer { get; set; }

        public int UILayerMask { get; set; }

        public float UnitToMeter { get; set; }

        public float NearClipPlane { get; set; }

        public GUIType PreferredGUI { get; set; }

        public CameraClearFlags CameraClearFlags { get; set; }
    }
}
