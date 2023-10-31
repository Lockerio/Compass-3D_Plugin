using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChandelierPlugin.Model;

namespace ChandelierPlugin.View
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        
        private Parameters parameters = new Parameters();

        private Dictionary<ParameterType, Dictionary<string, Control>> parameterFormElements = 
            new Dictionary<ParameterType, Dictionary<string, Control>>();

        private void FormMain_Load(object sender, EventArgs e)
        {
            parameterFormElements.Add(ParameterType.RadiusOuterCircle, new Dictionary<string, Control>
            {
                { "textBox", textBox_RadiusOuterCircle },
                { "label", label_RadiusOuterCircle },
            });
            parameterFormElements.Add(ParameterType.RadiusInnerCircle, new Dictionary<string, Control>
            {
                { "textBox", textBox_RadiusInnerCircle },
                { "label", label_RadiusInnerCircle },
            });
            parameterFormElements.Add(ParameterType.RadiusBaseCircle, new Dictionary<string, Control>
            {
                { "textBox", textBox_RadiusBaseCircle },
                { "label", label_RadiusBaseCircle },
            });
            parameterFormElements.Add(ParameterType.FoundationThickness, new Dictionary<string, Control>
            {
                { "textBox", textBox_FoundationThickness },
                { "label", label_FoundationThickness },
            });
            parameterFormElements.Add(ParameterType.LampsAmount, new Dictionary<string, Control>
            {
                { "textBox", textBox_LampsAmount },
                { "label", label_LampsAmount },
            });
            parameterFormElements.Add(ParameterType.LampRadius, new Dictionary<string, Control>
            {
                { "textBox", textBox_LampRadius },
                { "label", label_LampRadius },
            });

            SetTextFormElements();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string textBoxName = textBox.Name;
                ParameterType parameterType = ParameterType.Unknown;

                string parameterTypeStr = textBoxName.Split('_')[1];

                foreach (var item in parameterFormElements.Keys)
                {
                    if (item.ToString() == parameterTypeStr)
                    {
                        parameterType = item; 
                        break;
                    }
                }

                try
                {
                    parameters.AssertParameter(parameterType, parameters.ParametersDict[parameterType], Convert.ToDouble(textBox.Text));
                    SetTextFormElements();
                    Console.WriteLine(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void SetTextFormElements()
        {
            foreach (var item in parameters.ParametersDict)
            {
                var _key = item.Key;
                var _value = item.Value;

                parameterFormElements[_key]["textBox"].Text = _value.CurrentValue.ToString();
                parameterFormElements[_key]["label"].Text = $"от {_value.MinValue} до {_value.MaxValue}";

                Console.WriteLine(parameterFormElements[_key]["textBox"].Text);
            }
        }
    }
}
