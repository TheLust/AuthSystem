using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AuthSystem.Component
{
    public partial class NumericField : AuthSystem.Component.Field
    {
        public NumericField()
        {
            InitializeComponent();
            Min = 0;
            Max = 10000;
        }

        [
            Category("Validation"),
            Description("Field min value")
        ]
        public long Min { get { return Convert.ToInt32(FieldNumeric.Minimum); } set { FieldNumeric.Minimum = Convert.ToDecimal(value); } }

        [
            Category("Validation"),
            Description("Field max value")
        ]
        public long Max { get { return Convert.ToInt32(FieldNumeric.Maximum); } set { FieldNumeric.Maximum = Convert.ToDecimal(value); } }

        public object FieldValue
        {
            get
            {
                return ValidateField(FieldNumeric.Value) ?
                (object)Convert.ToInt64(FieldNumeric.Value) : new ValidationException(AppConstant.VALIDATION_ERROR_MESSAGE);
            }
            set
            {
                FieldNumeric.Value = value != null ? Convert.ToDecimal(value) : 0;
            }
        }

        private bool ValidateField(object toValidate)
        {
            try
            {
                Validator.Min(Label, toValidate, Min);
                Validator.Max(Label, toValidate, Max);
            }
            catch (ValidationException e)
            {
                Error = e.Message;
                return false;
            }
            return true;
        }

        private void FieldNumeric_ValueChanged(object sender, EventArgs e)
        {
            Error = string.Empty;
            ValidateField(FieldNumeric.Value);
        }
    }
}
