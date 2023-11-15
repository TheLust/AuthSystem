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
    public partial class ComboField<T> : AuthSystem.Component.Field
    {
        public ComboField(Func<List<T>> findAll, string value, string display)
        {
            InitializeComponent();
            FindAllOperation = findAll;
            FieldComboBox.ValueMember = value;
            FieldComboBox.DisplayMember = display;
        }

        private void ComboField_Load(object sender, EventArgs e)
        {
            FieldComboBox.DataSource = FindAllOperation();
            FieldComboBox.SelectedItem = null;
        }

        public Func<List<T>> FindAllOperation { get; set; }

        public object FieldValue 
        { 
            get
            {
                return ValidateField(FieldComboBox.SelectedValue) ?
                    FieldComboBox.SelectedValue : new ValidationException(AppConstant.VALIDATION_ERROR_MESSAGE);
            }
            set 
            { 
                FieldComboBox.SelectedValue = value; 
            }
        }

        [
            Category("Validation"),
            Description("Validation for null input"),
            DefaultValue(false)
        ]
        public bool NotNull { get; set; }

        private bool ValidateField(object toValidate)
        {
            try
            {

                if (NotNull)
                {
                    Validator.NotNull(Label, toValidate);
                }
            }
            catch (ValidationException e)
            {
                Error = e.Message;
                return false;
            }
            return true;
        }

        private void FieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Error = string.Empty;
            ValidateField(FieldComboBox.SelectedValue);
        }
    }
}
