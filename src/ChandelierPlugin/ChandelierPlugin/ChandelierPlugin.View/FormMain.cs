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

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string textBoxName = textBox.Name;
                string[] textBoxNameParts = textBoxName.Split('_');
                string parameterName = textBoxNameParts[1];

                var parameter = parameters.GetParametersAsDict()[parameterName];

            }
        }

        
    }
}
