using AuthSystem.Util;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AuthSystem.Component
{
    public partial class Crud<T> : UserControl where T : new()
    {
        public Crud()
        {
            InitializeComponent();
        }

        private void Crud_Load(object sender, EventArgs e)
        {
            if (FindAllOperation == null)
            {
                throw new Exception("Could not load the component because FindAllOperation is not provided");
            }

            if (Fields == null)
            {
                throw new Exception("Could not load the component because Fields is not provided");
            }

            InitializeGrid();
            GenerateForm();
            ClearErrors();
        }

        // Properties

        /* 
         * Fields Property are the columns and fields that will be generated
         * by the component to keep in mind that if field is of type object
         * fields should be added manually using addField method
         * 
         * **/

        public List<string> Fields { get; set; }

        /*
         * FieldReferences represents the id of the object field references to
         * this is unnecessarily if the database structure is right defined but if not it
         * requires to specify it, for example if the field is Job the Field Reference
         * will be JobId auto, if T does not have this field it will require to be
         * assigned manually
         * 
         * **/

        public Dictionary<string, string> FieldReferences { get; set; }

        /*
         * FieldConstraints represents the constraints of the given fields
         * 
         * **/

        public Dictionary<string, ValidationConstraint> FieldConstraints { get; set; }

        public Func<List<T>> FindAllOperation { get; set; }

        public Action<T> AddOperation { get; set; }

        public Action<int, T> UpdateOperation { get; set; }

        public Action<T> DeleteOperation { get; set; }

        // Grid

        private T SelectedEntity { get; set; }

        private void InitializeGrid()
        {
            Grid.AutoGenerateColumns = false;

            foreach (var field in Fields)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = field;
                column.HeaderText = field;
                column.ReadOnly = true;
                column.DataPropertyName = field;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                Grid.Columns.Add(column);
                SetGridDataSource();
            }
        }

        private void SetGridDataSource()
        {
            Grid.DataSource = null;
            Grid.Rows.Clear();
            Grid.DataSource = FindAllOperation();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedEntity = (T)Grid.Rows[e.RowIndex >= 0 ? e.RowIndex : 0].DataBoundItem;
            FillForm(SelectedEntity);
            UpdateButton.Enabled = true;
            DeleteButton.Enabled = true;
        }

        // Form

        private bool FormEnabled 
        { 
            set 
            {
                foreach (Control control in Form.Controls)
                {
                    control.Enabled = value;
                }
            }
        }

        private void GenerateForm()
        {
            foreach (var field in Fields)
            {
                if (!Form.Controls.ContainsKey(field))
                {
                    PropertyInfo property = typeof(T).GetProperty(field);
                    if (property.PropertyType == typeof(string))
                    {
                        Form.Controls.Add(GenerateTextField(property));
                    }

                    if (property.PropertyType == typeof(double) || property.PropertyType == typeof(int) || property.PropertyType == typeof(long))
                    {
                        Form.Controls.Add(GenerateNumericField(property));
                    }

                    if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                    {
                        Form.Controls.Add(GenerateDateTimeField(property));
                    }
                }
            }
        }

        private TextField GenerateTextField(PropertyInfo property)
        {
            TextField field = new TextField
            {
                Name = property.Name,
                Label = property.Name,
                Enabled = false
            };

            if (FieldConstraints.ContainsKey(property.Name))
            {
                field.NotBlank = FieldConstraints[property.Name].NotBlank;
                field.Email = FieldConstraints[property.Name].Email;
                field.Length = FieldConstraints[property.Name].Length;
                field.Min = FieldConstraints[property.Name].Min;
                field.Max = FieldConstraints[property.Name].Max;
                field.Pattern = FieldConstraints[property.Name].Pattern;
                field.PatternMessage = FieldConstraints[property.Name].PatternMessage;
            }

            return field;
        }

        private NumericField GenerateNumericField(PropertyInfo property)
        {
            NumericField field = new NumericField
            {
                Name = property.Name,
                Label = property.Name,
                Enabled = false
            };

            if (FieldConstraints.ContainsKey(property.Name))
            {
                field.Min = FieldConstraints[property.Name].Min;
                field.Max = FieldConstraints[property.Name].Max;
            }

            return field;
        }

        private DateTimeField GenerateDateTimeField(PropertyInfo property)
        {
            DateTimeField field = new DateTimeField
            {
                Name = property.Name,
                Label = property.Name,
                Enabled = false
            };

            if (FieldConstraints.ContainsKey(property.Name))
            {
                field.PastOrPresent = FieldConstraints[property.Name].PastOrPresent;
                field.IsLaterThan = FieldConstraints[property.Name].IsLaterThan != null ? 
                    (Form.Controls[FieldConstraints[property.Name].IsLaterThan] as DateTimeField) : null;
            }


            return field;
        }

        public void AddField<G>(Func<List<G>> findAll, string value, string display)
        {
            string typeName = typeof(G).Name;

            if (!GenericUtils.HasProperty<T>(typeName))
            {
                throw new Exception("Trying to add invalid field");
            }

            ComboField<G> field = new ComboField<G>(findAll, value, display);
            field.Name = typeName;
            field.Label = typeName;
            field.Enabled = false;

            if (FieldConstraints != null && FieldConstraints.ContainsKey(typeName))
            {
                field.NotNull = FieldConstraints[typeName].NotNull;
            }

            Form.Controls.Add(field);
        }

        private void ClearErrors()
        {
            foreach (Field field in Form.Controls)
            {
                field.Error = string.Empty;
            }
        }

        private void FillForm(T entity)
        {
            foreach (var field in Fields)
            {
                GenericUtils.SetPropertyValue(
                    Form.Controls[field],
                    "FieldValue",
                    GenericUtils.GetPropertyValue(
                        entity, (GenericUtils.HasProperty<T>(field + "Id") ? (field + "Id") :
                                    (FieldReferences != null && FieldReferences.ContainsKey(field) ? FieldReferences[field] : field)))
                );
            }
        }

        private T GetEntityFromForm()
        {
            T entity = new T();
            ValidationException validationException = null;

            foreach (var field in Fields)
            {
                try {
                    GenericUtils.SetPropertyValue(
                        entity,
                        (GenericUtils.HasProperty<T>(field + "Id") ? (field + "Id") :
                            (FieldReferences != null && FieldReferences.ContainsKey(field) ? FieldReferences[field] : field)),
                        GenericUtils.GetPropertyValue(
                            Form.Controls[field] ??
                                throw new Exception("Field not found, please add it manually"),
                            "FieldValue")
                    );
                } catch (ValidationException ex)
                {
                    if (validationException == null)
                    {
                        validationException = ex;
                    }
                }
            } 

            if (validationException != null)
            {
                throw validationException;
            }

            return entity;
        }

        // Buttons

        private void HideButtons()
        {
            foreach (Control control in ButtonPanel.Controls)
            {
                control.Visible = false;
            }
        }

        private void ViewMode()
        {
            FillForm(SelectedEntity != null ? SelectedEntity : new T());
            ClearErrors();
            HideButtons();
            FormEnabled = false;
            ReloadButton.Visible = true;
            AddButton.Visible = true;
            UpdateButton.Visible = true;
            DeleteButton.Visible = true;

            Grid.CellDoubleClick += Grid_CellDoubleClick;
        }

        // Events

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            SetGridDataSource();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            FillForm(new T());
            ClearErrors();
            HideButtons();
            FormEnabled = true;
            AddSaveButton.Visible = true;
            AddCancelButton.Visible = true;

            Grid.CellDoubleClick -= Grid_CellDoubleClick;
        }

        private void AddSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                T entity = GetEntityFromForm();
                bool unique = true;
                foreach (var field in FieldConstraints.Where(x => x.Value.Unique))
                {
                    string find = (GenericUtils.HasProperty<T>(field.Key + "Id") ? (field.Key + "Id") :
                                    (FieldReferences != null && FieldReferences.ContainsKey(field.Key) ? FieldReferences[field.Key] : field.Key));
                    try
                    {
                        Validator.Unique(find, GenericUtils.GetPropertyValue(entity, find), FindAllOperation(), null);
                    }
                    catch (ValidationException)
                    {
                        ((Field)Form.Controls[field.Key]).Error = AppConstant.GetExceptionMessage(typeof(T).Name, field.Key, AppConstant.ALREADY_EXISTS);
                        unique = false;
                    }
                }

                if (!unique)
                {
                    throw new ValidationException("One or more fields are not unique");
                }

                AddOperation(entity);
            }
            catch (ValidationException)
            {
                return;
            }
            catch (MissingFieldException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            SelectedEntity = default;
            UpdateButton.Enabled = false;
            DeleteButton.Enabled = false;
            ViewMode();
            SetGridDataSource();
        }

        private void AddCancelButton_Click(object sender, EventArgs e)
        {
            ViewMode();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            HideButtons();
            FormEnabled = true;
            UpdateSaveButton.Visible = true;
            UpdateCancelButton.Visible = true;

            Grid.CellDoubleClick -= Grid_CellDoubleClick;
        }

        private void UpdateSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                T entity = GetEntityFromForm();
                bool unique = true;
                foreach (var field in FieldConstraints.Where(x => x.Value.Unique))
                {
                    string find = (GenericUtils.HasProperty<T>(field.Key + "Id") ? (field.Key + "Id") :
                                    (FieldReferences != null && FieldReferences.ContainsKey(field.Key) ? FieldReferences[field.Key] : field.Key));
                    try
                    {
                        Validator.Unique(find, GenericUtils.GetPropertyValue(entity, find), FindAllOperation(), GenericUtils.GetPropertyValue(SelectedEntity, "Id"));
                    }
                    catch (ValidationException)
                    {
                        ((Field)Form.Controls[field.Key]).Error = AppConstant.GetExceptionMessage(typeof(T).Name, field.Key, AppConstant.ALREADY_EXISTS);
                        unique = false;
                    }
                }

                if (!unique)
                {
                    throw new ValidationException("One or more fields are not unique");
                }

                UpdateOperation(Convert.ToInt32(GenericUtils.GetPropertyValue(SelectedEntity, "Id")), entity);
            }
            catch (ValidationException)
            {
                return;
            }

            SelectedEntity = default;
            UpdateButton.Enabled = false;
            DeleteButton.Enabled = false;
            ViewMode();
            SetGridDataSource();
        }

        private void UpdateCancelButton_Click(object sender, EventArgs e)
        {
            ViewMode();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(AppConstant.DELETE_CONFIRMATION, AppConstant.SURE, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    DeleteOperation(SelectedEntity);
                } catch (DbUpdateException) {
                    MessageBox.Show("Could not delete item because another item depends on it");
                    return;
                }
            }

            SelectedEntity = default;
            UpdateButton.Enabled = false;
            DeleteButton.Enabled = false;
            ViewMode();
            SetGridDataSource();
        }
    }
}
