﻿using System;

using ClickLib.Clicks;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Client.UI;
using YesAlready.BaseFeatures;

namespace YesAlready.Features
{
    /// <summary>
    /// AddonSelectString feature.
    /// </summary>
    internal class AddonSelectStringFeature : OnSetupSelectListFeature
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddonSelectStringFeature"/> class.
        /// </summary>
        public AddonSelectStringFeature()
            : base(Service.Address.AddonSelectStringOnSetupAddress)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "SelectString";

        /// <inheritdoc/>
        protected unsafe override void OnSetupImpl(IntPtr addon, uint a2, IntPtr data)
        {
            var addonPtr = (AddonSelectString*)addon;
            var popupMenu = &addonPtr->PopupMenu.PopupMenu;
            this.SetupOnItemSelectedHook(popupMenu);
            this.CompareNodesToEntryTexts(addon, popupMenu);
        }

        /// <inheritdoc/>
        protected override void SelectItemExecute(IntPtr addon, int index)
        {
            PluginLog.Debug($"AddonSelectString: Selecting {index}");
            ClickSelectString.Using(addon).SelectItem((ushort)index);
        }
    }
}