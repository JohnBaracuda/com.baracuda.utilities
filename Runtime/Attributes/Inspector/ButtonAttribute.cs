﻿using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Baracuda.Utilities.Inspector
{
    public enum ButtonType
    {
        Default = 0,
        Center = 1,
        Right = 2,
    }
    
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    [Conditional("UNITY_EDITOR")]
    public class ButtonAttribute : Attribute
    {
        public string Label { get; set; }
        public float SpaceBefore { get; set; }
        public float SpaceAfter { get; set; }
        public ButtonType ButtonType { get; } = ButtonType.Default;
        
        public ButtonAttribute()
        {
        }
        
        public ButtonAttribute(ButtonType buttonType)
        {
            ButtonType = buttonType;
        }
        
        public ButtonAttribute(string label)
        {
            Label = label;
        }
        
        public ButtonAttribute(string label, ButtonType buttonType)
        {
            Label = label;
            ButtonType = buttonType;
        }
    }
}