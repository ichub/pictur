﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pictur {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class HotKeySettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static HotKeySettings defaultInstance = ((HotKeySettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new HotKeySettings())));
        
        public static HotKeySettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("49")]
        public uint FullKey {
            get {
                return ((uint)(this["FullKey"]));
            }
            set {
                this["FullKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public uint FullModifiers {
            get {
                return ((uint)(this["FullModifiers"]));
            }
            set {
                this["FullModifiers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50")]
        public uint WindowKey {
            get {
                return ((uint)(this["WindowKey"]));
            }
            set {
                this["WindowKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public uint WindowModifiers {
            get {
                return ((uint)(this["WindowModifiers"]));
            }
            set {
                this["WindowModifiers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("51")]
        public uint BoundsKey {
            get {
                return ((uint)(this["BoundsKey"]));
            }
            set {
                this["BoundsKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public uint BoundsModifiers {
            get {
                return ((uint)(this["BoundsModifiers"]));
            }
            set {
                this["BoundsModifiers"] = value;
            }
        }
    }
}
