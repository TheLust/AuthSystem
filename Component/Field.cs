using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthSystem.Component
{
    public partial class Field : UserControl
    {
        public Field()
        {
            InitializeComponent();
        }

        [
            Category("Custom"),
            Description("Text of the field label")
        ]
        public string Label { get { return FieldLabel.Text; } set { FieldLabel.Text = value; } }

        public string Error { get { return FieldError.Text; } set { FieldError.Text = value; } }
    }
}
