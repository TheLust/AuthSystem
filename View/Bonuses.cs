using AuthSystem.Component;
using AuthSystem.Context;
using AuthSystem.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthSystem.View
{
    public partial class Bonuses : Form
    {
        private BonusService bonusService;
        private EmployeeService employeeService;

        public Bonuses()
        {
            bonusService = new BonusService();
            employeeService = new EmployeeService();
            InitializeComponent();
            LoadCrud();
        }

        public class Type
        {
            public string Name { get; set; }
            public string DisplayName
            {
                get
                {
                    return Name[0] + Name.Substring(1).ToLower();
                }
            }
        }

        public List<Type> GetTypes()
        {
            return new List<Type>()
            {
                new Type()
                {
                    Name = "MONTHLY"
                },
                new Type()
                {
                    Name = "PRIZE"
                }
            };
        }

        private void LoadCrud()
        {
            Crud<ExtraPayment> crud = new Crud<ExtraPayment>();
            crud.Fields = new List<string>()
            {
                "Employee",
                "Type",
                "Achievement",
                "Month",
                "Amount"
            };
            crud.FieldConstraints = new Dictionary<string, ValidationConstraint>
            {
                {
                    "Employee",
                    new ValidationConstraint()
                    {
                        NotNull = true
                    }
                },
                {
                    "Type",
                    new ValidationConstraint()
                    {
                        NotNull = true
                    }
                },
                {
                    "Amount",
                    new ValidationConstraint()
                    {
                        Min = 0,
                        Max = 5000
                    }
                }
            };
            crud.FindAllOperation = bonusService.FindAll;
            crud.AddOperation = bonusService.Add;
            crud.UpdateOperation = bonusService.Update;
            crud.DeleteOperation = bonusService.Remove;
            crud.AddField(employeeService.FindAll, "Id", "Account");
            crud.AddField(GetTypes, "Name", "DisplayName");

            Controls.Add(crud);
        }
    }
}
