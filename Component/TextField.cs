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
    public partial class TextField : UserControl
    {
        public TextField()
        {
            InitializeComponent();
        }

        [
            Category("Custom"),
            Description("Text of the field label")
        ]
        public string Label { get { return FieldLabel.Text; } set { FieldLabel.Text = value; } }

        public string Error { get { return FieldError.Text; } set { FieldError.Text = value; } }

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

        public string FieldValue { 
            get {
                return ValidateField(FieldTextBox.Text) ?
                FieldTextBox.Text : throw new ValidationException(AppConstant.VALIDATION_ERROR_MESSAGE);
            }
            set { 
                FieldTextBox.Text = value; 
            } 
        }

        private bool ValidateField(string toValidate)
        {
            try {
            
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
            } catch (ValidationException e) 
            { 
                FieldError.Text = e.Message;
                return false;
            }
            return true;
        }

        private void FieldTextBox_TextChanged(object sender, EventArgs e)
        {
            FieldError.Text = string.Empty;
            ValidateField(FieldTextBox.Text);
        }
    }
}
