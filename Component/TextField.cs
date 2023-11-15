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
    public partial class TextField : AuthSystem.Component.Field
    {
        public TextField()
        {
            InitializeComponent();
        }

        [
            Category("Validation"),
            Description("Validation for blank input"),
            DefaultValue(false)
        ]
        public bool NotBlank { get; set; }

        [
            Category("Validation"),
            Description("Validation for email"),
            DefaultValue(false)
        ]
        public bool Email { get; set; }

        [
            Category("Validation"),
            Description("Validation for length"),
            DefaultValue(false)
        ]
        public bool Length { get; set; }

        [
            Category("Validation"),
            Description("Field min length")
        ]
        public int Min { get; set; }

        [
            Category("Validation"),
            Description("Field max length")
        ]
        public int Max { get; set; }

        [
            Category("Validation"),
            Description("Field regex pattern")
        ]
        public string Pattern { get; set; }

        [
            Category("Validation"),
            Description("Field pattern violation message"),
            DefaultValue(AppConstant.DEFAULT_PATTERN)
        ]
        public string PatternMessage { get; set; }

        public string FieldValue
        {
            get
            {
                return ValidateField(FieldTextBox.Text) ?
                FieldTextBox.Text : throw new ValidationException(AppConstant.VALIDATION_ERROR_MESSAGE);
            }
            set
            {
                FieldTextBox.Text = value;
            }
        }

        private bool ValidateField(string toValidate)
        {
            try
            {

                if (NotBlank)
                {
                    Validator.NotBlank(Label, toValidate);
                }

                if (Length)
                {
                    Validator.Length(Label, toValidate, Min, Max);
                }

                if (Email && NotBlank)
                {
                    Validator.Email(Label, toValidate);
                }

                if (!string.IsNullOrWhiteSpace(Pattern) && !Email)
                {
                    Validator.Pattern(Label, PatternMessage, toValidate, Pattern);
                }
            }
            catch (ValidationException e)
            {
                Error = e.Message;
                return false;
            }
            return true;
        }

        private void FieldTextBox_TextChanged(object sender, EventArgs e)
        {
            Error = string.Empty;
            ValidateField(FieldTextBox.Text);
        }
    }
}
