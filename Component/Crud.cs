using AuthSystem.Util;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

        public Dictionary<string, string> Fields { get; set; }

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
                column.Name = field.Key;
                column.HeaderText = field.Key;
                column.ReadOnly = true;
                column.DataPropertyName = field.Key;

                if (field.Value != null)
                {
                    column.DataPropertyName = field.Key + "." + field.Value;
                }

                Grid.Columns.Add(column);
                SetGridDataSource();
            }
        }

        private void SetGridDataSource()
        {
            Grid.DataSource = FindAllOperation();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedEntity = (T)Grid.Rows[e.RowIndex >= 0 ? e.RowIndex : 0].DataBoundItem;
            FillForm(SelectedEntity);
            UpdateButton.Enabled = true;
            DeleteButton.Enabled = true;
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            DataGridViewColumn col = grid.Columns[e.ColumnIndex];
            if (row.DataBoundItem != null && col.DataPropertyName.Contains("."))
            {
                string[] props = col.DataPropertyName.Split('.');
                PropertyInfo propInfo = row.DataBoundItem.GetType().GetProperty(props[0]);
                object val = propInfo.GetValue(row.DataBoundItem, null);
                for (int i = 1; i < props.Length; i++)
                {
                    propInfo = val.GetType().GetProperty(props[i]);
                    val = propInfo.GetValue(val, null);
                }
                e.Value = val;
            }
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
                if (field.Value == null)
                {
                    // Generate field depending of type
                }
            }
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
                    Form.Controls[field.Key],
                    "FieldValue",
                    GenericUtils.GetPropertyValue(
                        entity, (field.Value == null ? field.Key : 
                            (GenericUtils.HasProperty<T>(field.Key + "Id") ? (field.Key + "Id") :
                                (FieldReferences != null && FieldReferences.ContainsKey(field.Key) ? FieldReferences[field.Key] : 
                                    throw new Exception($"Reference for field '{field.Key}' is required")))))
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
                        (field.Value == null ? field.Key :
                            (GenericUtils.HasProperty<T>(field.Key + "Id") ? (field.Key + "Id") :
                                (FieldReferences != null && FieldReferences.ContainsKey(field.Key) ? FieldReferences[field.Key] :
                                    throw new Exception($"Reference for field '{field.Key}' is required")))),
                        GenericUtils.GetPropertyValue(
                            Form.Controls[field.Key] ??
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
        }

        private void AddSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                T entity = GetEntityFromForm();
                bool unique = true;
                foreach(var field in FieldConstraints.Where(x => x.Value.Unique)) {
                    string find = (field.Value == null ? field.Key :
                                    (GenericUtils.HasProperty<T>(field.Key + "Id") ? (field.Key + "Id") :
                                        (FieldReferences != null && FieldReferences.ContainsKey(field.Key) ? FieldReferences[field.Key] :
                                            throw new Exception($"Reference for field '{field.Key}' is required"))));
                    try
                    {
                        Validator.Unique(find, GenericUtils.GetPropertyValue(entity, find), FindAllOperation(), null);
                    }
                    catch (ValidationException)
                    {
                        ((Field)Form.Controls[field.Key]).Error = AppConstant.GetExceptionMessage(AppConstant.EMPLOYEE.Item1, field.Key, AppConstant.ALREADY_EXISTS);
                        unique = false;
                    }
                }

                if (!unique)
                {
                    throw new ValidationException("One or more fields are not unique");
                }

                AddOperation(entity);
            }
            catch (ValidationException) {
                return;
            }

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
        }

        private void UpdateSaveButton_Click(object sender, EventArgs e)
        {
            
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

            SetGridDataSource();
        }
    }
}
