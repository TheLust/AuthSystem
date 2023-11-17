using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AuthSystem.Component
{
    public partial class DateTimeField : AuthSystem.Component.Field
    {
        public DateTimeField()
        {
            InitializeComponent();
        }

        public bool PastOrPresent { get; set; }

        public DateTimeField IsLaterThan { get; set; }

        public object FieldValue
        {
            get
            {
                return ValidateField(FieldDate.Value) ?
                (object)(FieldDate.Value.Date + FieldTime.Value.TimeOfDay) : new ValidationException(AppConstant.VALIDATION_ERROR_MESSAGE);
            }
            set
            {
                if (value != null && Convert.ToDateTime(value).CompareTo(DateTime.MinValue) > 0)
                {
                    FieldDate.Value = Convert.ToDateTime(value);
                    FieldTime.Value = Convert.ToDateTime(value);
                    return;
                }

                FieldDate.Text = "";
                FieldTime.Text = "";
            }
        }

        private bool ValidateField(object toValidate)
        {
            try
            {
                if (PastOrPresent)
                {
                    Validator.PastOrPresent(Label, toValidate);
                }

                if (IsLaterThan != null)
                {
                    Validator.IsLaterThan(Label, toValidate, IsLaterThan);
                }
            }
            catch (ValidationException e)
            {
                Error = e.Message;
                return false;
            }
            return true;
        }

        private void FieldDateTime_ValueChanged(object sender, EventArgs e)
        {
            Error = string.Empty;
            ValidateField(FieldDate.Value.Date + FieldTime.Value.TimeOfDay);
        }

        private void FieldTime_ValueChanged(object sender, EventArgs e)
        {
            Error = string.Empty;
            ValidateField(FieldDate.Value.Date + FieldTime.Value.TimeOfDay);
        }
    }
}
