using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AuthSystem.Component
{
    public partial class Crud<T> : UserControl where T : new()
    {

        // Init

        T backEntity;

        public Crud()
        {
            InitializeComponent();
        }

        private void Crud_Load(object sender, EventArgs e)
        {
            InitializeGrid();
        }

        // Operations

        public Func<List<T>> FindAllOperation { get; set; }

        public Action<T> AddOperation { get; set; }

        public Action<int, T> UpdateOperation { get; set; }

        public Action<T> DeleteOperation { get; set; }

        // Properties

        public Dictionary<string, ValidationConstraint> FieldsConstraints { get; set; }

        public List<string> HiddenFields { get; set; }

        // Operations Methods

        private void Reload()
        {
            Grid.DataSource = FindAllOperation != null ? FindAllOperation() : null;
        }

        // Utils

        private T FindUpdatedEntity(int entityId)
        {
            return FindAllOperation().FirstOrDefault(x => Convert.ToInt32(GetPropertyValue(x, "Id")) ==  entityId);
        }

        private List<PropertyInfo> GetTProperties()
        {
            return typeof(T).GetProperties().Where(x => !HiddenFields.Contains(x.Name)).ToList();
        }

        private List<string> GetTPropertiesNames() 
        {
            return GetTProperties().Select(x => x.Name).ToList();
        }

        private void InitializeGrid()
        {
            Grid.DataSource = FindAllOperation != null ? FindAllOperation() : null;

            if (HiddenFields != null)
            {
                foreach (var field in HiddenFields)
                {
                    if (Grid.Columns.Contains(field))
                    {
                        Grid.Columns[field].Visible = false;
                    }
                }
            }

            GenerateForm();
        }

        private TextField GenerateTextField(string name)
        {
            TextField field = new TextField();
            field.Name = name;
            field.Label = name;
            field.Enabled = false;

            if (FieldsConstraints != null)
            {
                if (FieldsConstraints.ContainsKey(name))
                {
                    ValidationConstraint constraints = FieldsConstraints[name];
                    Console.WriteLine(constraints.ToString());
                    field.NotBlank = constraints.NotBlank;
                    field.Email = constraints.Email;
                    field.Length = constraints.Length;
                    field.Min = constraints.Min;
                    field.Max = constraints.Max;
                    field.Pattern = constraints.Pattern;
                    field.PatternMessage = constraints.PatternMessage;
                }
            }

            return field;
        }

        private UserControl GenerateField(PropertyInfo property)
        {
            if (property.PropertyType == typeof(string))
            {
                return GenerateTextField(property.Name);
            }
            return null;
        }

        private void GenerateForm()
        {
            foreach (PropertyInfo property in GetTProperties())
            {
                if (!HiddenFields.Contains(property.Name))
                {
                    Form.Controls.Add(GenerateField(property));
                }
            }
        }

        private string GetPropertyValue(T entity, string propertyName)
        {
            return typeof(T).GetProperty(propertyName).GetValue(entity)?.ToString();
        }

        private T SetPropertyValue(T entity, string propertyName, string value)
        {
            typeof(T).GetProperty(propertyName).SetValue(entity, Convert.ChangeType(value, typeof(T).GetProperty(propertyName).PropertyType));
            return entity;
        }

        private void FillForm(T entity)
        {
            if (entity == null)
            {
                return;
            }

            List<string> properties = GetTPropertiesNames();

            foreach (TextField control in Form.Controls)
            {
                if (properties.Contains(control.Name))
                {
                    control.FieldValue = GetPropertyValue(entity, control.Name);
                }
            }
        }

        private T GetEntityFromForm()
        {
            T entity = new T();
            List<string> properties = GetTPropertiesNames();

            foreach (Control control in Form.Controls)
            {
                if (properties.Contains(control.Name))
                {
                    if (control.GetType() == typeof(TextField))
                    {
                        entity = SetPropertyValue(
                                entity,
                                control.Name,
                                ((TextField) control).FieldValue
                            );
                    }
                }
            }

            return entity;
        }

        private T GetEntityFromGrid(DataGridViewCellEventArgs e)
        {
            T entity = new T();
            List<string> properties = GetTPropertiesNames();
            properties.Add("Id");

            foreach (DataGridViewColumn column in Grid.Columns)
            {
                if (properties.Contains(column.Name))
                {
                    entity = SetPropertyValue(
                            entity, 
                            column.Name, 
                            Grid.Rows[e.RowIndex >= 0 ? e.RowIndex : 0].Cells[column.Name].Value.ToString()
                        );
                }
            }

            // Set id for selected entity

            backEntity = entity;

            return entity;
        }

        private void EnableForm(bool enable)
        {
            foreach (Control control in Form.Controls)
            {
                control.Enabled = enable;
            }
        }

        private void ClearErrors()
        {
            foreach (Control control in Form.Controls)
            {
                if (control.GetType() == typeof(TextField))
                {
                    ((TextField)control).Error = string.Empty;
                }
            }
        }

        private void HideButtons()
        {
            foreach (Button button in ButtonPanel.Controls)
            {
                button.Visible = false;
            }
        }

        private void AddMode(bool enable)
        {
            HideButtons();

            if (enable)
            {
                FillForm(new T());
                EnableForm(true);
                AddSaveButton.Visible = true;
                AddCancelButton.Visible = true;
            }
            else
            {
                FillForm(backEntity);
                ClearErrors();
                EnableForm(false);
                ReloadButton.Visible = true;
                AddButton.Visible = true;
                UpdateButton.Visible = true;
                DeleteButton.Visible = true;
            }
        }

        private void UpdateMode(bool enable)
        {
            HideButtons();
            if (enable)
            {
                EnableForm(true);
                UpdateSaveButton.Visible = true;
                UpdateCancelButton.Visible = true;
            }
            else
            {
                FillForm(backEntity);
                ClearErrors();
                EnableForm(false);
                ReloadButton.Visible = true;
                AddButton.Visible = true;
                UpdateButton.Visible = true;
                DeleteButton.Visible = true;
            }
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FillForm(GetEntityFromGrid(e));
            UpdateButton.Enabled = true;
            DeleteButton.Enabled = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddMode(true);
        }

        private void AddSaveButton_Click(object sender, EventArgs e)
        {
            if (FieldsConstraints.Values.FirstOrDefault(x => x.Unique) != null)
            {
                foreach (Control control in Form.Controls)
                {
                    if (FieldsConstraints.ContainsKey(control.Name))
                    {
                        if (FieldsConstraints[control.Name].Unique == true)
                        {
                            try 
                            {
                                Validator.Unique(control.Name, GetPropertyValue(GetEntityFromForm(), control.Name), FindAllOperation(), null);
                            } catch (ValidationException ex) 
                            {
                                ((TextField)Form.Controls[control.Name]).Error = ex.Message;
                                return;
                            }
                        }
                    }
                }
            }

            try
            {
                AddOperation(GetEntityFromForm());               
            } catch (ValidationException) 
            { 
                return; 
            }

            Reload();
            AddMode(false);
        }

        private void AddCancelButton_Click(object sender, EventArgs e)
        {
            AddMode(false);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateMode(true);
        }

        private void UpdateSaveButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GetPropertyValue(backEntity, "Id"));
            try
            {
                UpdateOperation(id, GetEntityFromForm());
            }
            catch (ValidationException)
            {
                return;
            }

            backEntity = FindUpdatedEntity(id);
            Reload();
            UpdateMode(false);
        }

        private void UpdateCancelButton_Click(object sender, EventArgs e)
        {
            UpdateMode(false);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteOperation(backEntity);
            }
            catch (ValidationException)
            {
                return;
            }

            backEntity = default;
            FillForm(new T());
            ClearErrors();
            Reload();
        }
    }
}
