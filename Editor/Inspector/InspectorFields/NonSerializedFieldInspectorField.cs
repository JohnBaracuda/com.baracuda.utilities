﻿using Baracuda.Utilities.Helper;
using System;
using System.Reflection;
using UnityEngine;

namespace Baracuda.Utilities.Inspector.InspectorFields
{
    public class NonSerializedFieldInspector : InspectorMember
    {
        private readonly FieldInfo _fieldInfo;
        private readonly object _target;
        private readonly Func<object, object> _editor;


        public NonSerializedFieldInspector(FieldInfo fieldInfo, object target) : base(fieldInfo, target)
        {
            _fieldInfo = fieldInfo;
            _target = target;
            var label = fieldInfo.TryGetCustomAttribute<LabelAttribute>(out var labelAttribute)
                ? labelAttribute.Label
                : fieldInfo.Name.Humanize(Prefixes);

            var tooltip = fieldInfo.TryGetCustomAttribute<TooltipAttribute>(out var tooltipAttribute) ? tooltipAttribute.tooltip : null;

            Label = new GUIContent(label, tooltip);
            _editor = GUIHelper.CreateEditor(Label, _fieldInfo.FieldType);
        }

        protected override void DrawGUI()
        {
            var value = _editor(_fieldInfo.GetValue(_target));
            _fieldInfo.SetValue(_target, value);
        }
    }
}