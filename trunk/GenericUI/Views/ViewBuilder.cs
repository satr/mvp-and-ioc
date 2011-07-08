using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using GenericUI.Interfaces;
using GenericUI.ViewProperties;

namespace GenericUI.Views
{
    public class ViewBuilder: IViewBuilder
    {
        const int DefaultActionControlWidth = 50;
        const int DefaultTextPropertyWidth = 100;
        const int DefaultNumberPropertyWidth = 70;

        public void Build(INestedView nestedView, List<IViewProperty> viewProperties)
        {
            var controls = GetControls(viewProperties);
            if(viewProperties.Count == 0 || controls.Count == 0)
                return;
            var layoutPanel = GetLayoutPanel(controls);
            layoutPanel.SuspendLayout();
            layoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            int verticalMargin = layoutPanel.Margin.Vertical;
            int totalHeight = 0;
            int columnCount = controls.Max(controlSet => controlSet.Count);
            foreach (var controlList in controls)
            {
                int controlHeight = controlList.Max(control => control == null? 0: control.Height + control.Margin.Vertical) + verticalMargin;
                totalHeight += controlHeight;
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, controlHeight));
                for (int controlIndex = 0; controlIndex < columnCount; controlIndex++)
                {
                    var control = controlList.Count > controlIndex && controlList[controlIndex] != null 
                                    ? controlList[controlIndex] 
                                    : new UserControl { Dock = DockStyle.Fill };
                    layoutPanel.SetRow(control, controlIndex);
                    layoutPanel.Controls.Add(control);
                }
            }
            layoutPanel.Height = totalHeight + layoutPanel.RowCount * 1;
            nestedView.AddControl(layoutPanel);
            layoutPanel.ResumeLayout(false);
            layoutPanel.PerformLayout();
        }

        private static TableLayoutPanel GetLayoutPanel(List<List<Control>> controls)
        {
            int columnCount = controls.Max(list => list.Count);
            var layoutPanel = new TableLayoutPanel
                                       {
                                           ColumnCount = columnCount,
                                           RowCount = controls.Count,
                                           Dock = DockStyle.Fill,
                                           Location = new Point(0, 0),
                                           Name = "layoutPanel",
                                           BorderStyle =  BorderStyle.Fixed3D
                                       };
            int horizontalMargin = layoutPanel.Margin.Horizontal;
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                int controlIndex = columnIndex;
                bool columnExists = controls.Count - 1 >= columnIndex;
                try
                {
                    int columnWidth = !columnExists ? 0 : controls.Max(control => control.Count <= controlIndex || control[controlIndex] == null
                                                                                    ? 0 : control[controlIndex].Width 
                                                                                          + control[controlIndex].Margin.Horizontal) 
                                                                                          + horizontalMargin;
                    layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, columnWidth));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return layoutPanel;
        }

        private static List<List<Control>> GetControls(IEnumerable<IViewProperty> viewProperties)
        {
            var controls = new List<List<Control>>();
            foreach (var viewProperty in viewProperties)
            {
                if(viewProperty.Type == typeof(string))
                    controls.Add(AddTextProperty(viewProperty));
                else if (viewProperty.Type == typeof(decimal))
                    controls.Add(AddNumericProperty(viewProperty));
                else if (viewProperty.Type == typeof(object))
                    controls.Add(AddActionProperty(viewProperty));
            }
            return controls;
        }

        private static List<Control> AddActionProperty(IViewProperty viewProperty)
        {
            var property = ((ActionViewProperty) viewProperty);
            var actionControl = new Button()
                                   {
                                       Text = property.Title,
                                   };
            int preferedWidth = actionControl.PreferredSize.Width;
            actionControl.Width = preferedWidth < DefaultActionControlWidth ? DefaultActionControlWidth : preferedWidth;
            actionControl.Dock = property.FixedSize? DockStyle.None : DockStyle.Fill;
            actionControl.Click += (s, e) => property.Perform();
            var controls = new List<Control>();
            for (int i = 0; i < property.ShiftColumnsCount; i++)
                controls.Add(null);
            controls.Add(actionControl);
            return controls;
        }

        private static List<Control> AddTextProperty(IViewProperty viewProperty)
        {
            var property = ((TextViewProperty) viewProperty);
            var valueControl = new TextBox
                                   {
                                       Text = property.Value,
                                       Dock = DockStyle.Fill,
                                       Width = DefaultTextPropertyWidth,
                                       ReadOnly = property.ReadOnly
                                   };
            valueControl.TextChanged += (s, e) => property.Value = valueControl.Text;
            return new List<Control>
                       {
                           GetLabel(viewProperty), 
                           valueControl
                       };
        }

        private static List<Control> AddNumericProperty(IViewProperty viewProperty)
        {
            var hostControl = new UserControl {Width = DefaultNumberPropertyWidth};
            var property = ((NumberViewProperty) viewProperty);
            var valueControl = new NumericUpDown
                                   {
                                       Value = property.Value,
                                       Margin = new Padding(0, 0, 0, 0),
                                       Dock = DockStyle.Fill,
                                       DecimalPlaces = property.Attributes.DecimalPlaces,
                                   };
            hostControl.Controls.Add(valueControl);
            var textControl = new TextBox
                                  {
                                      Text = GetTextValue(property),
                                      Dock = DockStyle.Fill,
                                      Margin = new Padding(0,0,0,0),
                                      ReadOnly = true
                                  };
            hostControl.Controls.Add(textControl);
            valueControl.ValueChanged += delegate
                                             {
                                                 property.Value = valueControl.Value;
                                                 textControl.Text = GetTextValue(property);
                                             };
            ApplyReadOnlyStateToCompositeControl(property.ReadOnly, valueControl, textControl);
            property.ReadOnlyChanged += (s, e) => ApplyReadOnlyStateToCompositeControl(e.Value, valueControl, textControl);
            return new List<Control> {GetLabel(viewProperty), valueControl};
        }

        private static void ApplyReadOnlyStateToCompositeControl(bool readOnly, Control valueControl, Control textControl)
        {
            Control control = (readOnly ? textControl : valueControl);
            control.BringToFront();//TODO - to complete
        }

        private static string GetTextValue(NumberViewProperty viewProperty)
        {
            var formatInfo = new NumberFormatInfo
                                 {
                                     CurrencyDecimalDigits = viewProperty.Attributes.DecimalPlaces
                                 };
            return viewProperty.Value.ToString(formatInfo);
        }

        private static Label GetLabel(IViewProperty viewProperty)
        {
            var label = new Label
            {
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleRight,
                Text = viewProperty.Title,
                Dock = DockStyle.Right
            };
            label.Size = label.PreferredSize;
            viewProperty.TitleChanged += (s, e) =>
                                             {
                                                 label.Text = viewProperty.Title;
                                                 label.Size = label.PreferredSize;
                                             };
            return label;
        }

    }
}