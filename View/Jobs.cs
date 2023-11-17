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
    public partial class Jobs : Form
    {
        private JobService jobService;

        public Jobs()
        {
            InitializeComponent();
            jobService = new JobService();
            LoadCrud();
        }

        public class Rank
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

        public List<Rank> GetRanks()
        {
            return new List<Rank>()
            {
                new Rank()
                {
                    Name = "JUNIOR"
                },
                new Rank()
                {
                    Name = "MIDDLE"
                },
                new Rank()
                {
                    Name = "SENIOR"
                }
            };
        }

        private void LoadCrud()
        {
            Crud<Job> crud = new Crud<Job>();
            crud.Fields = new List<string>()
            {
                "Name",
                "Rank",
                "BaseSalary"
            };

            crud.FieldConstraints = new Dictionary<string, ValidationConstraint>
            {
                {
                    "Name",
                    new ValidationConstraint()
                    {
                        Unique = true,
                        NotBlank = true,
                        Length = true,
                        Min = 5,
                        Max = 30
                    }
                },
                {
                    "Rank",
                    new ValidationConstraint()
                    {
                        NotNull = true
                    }
                },
                {
                    "BaseSalary",
                    new ValidationConstraint()
                    {
                        Min = 0,
                        Max = 10000
                    }
                }
            };

            crud.FindAllOperation = jobService.FindAll;
            crud.AddOperation = jobService.Add;
            crud.UpdateOperation = jobService.Update;
            crud.DeleteOperation = jobService.Remove;

            crud.AddField(GetRanks, "Name", "DisplayName");

            Controls.Add(crud);
        }
    }
}
