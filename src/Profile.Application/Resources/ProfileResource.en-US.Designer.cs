﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Profile.Application.Resources {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ProfileResource_en_US {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ProfileResource_en_US() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Profile.Application.Resources.ProfileResource_en_US", typeof(ProfileResource_en_US).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string Validation_ProfileNameMaximumLengthError {
            get {
                return ResourceManager.GetString("Validation:ProfileNameMaximumLengthError", resourceCulture);
            }
        }
        
        internal static string Validation_ProfileSurnameMaximumLengthError {
            get {
                return ResourceManager.GetString("Validation:ProfileSurnameMaximumLengthError", resourceCulture);
            }
        }
        
        internal static string Validation_ProfileDescriptionMaximumLengthError {
            get {
                return ResourceManager.GetString("Validation:ProfileDescriptionMaximumLengthError", resourceCulture);
            }
        }
    }
}
