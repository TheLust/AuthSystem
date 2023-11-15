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
    public partial class Projects : Form
    {
        private ProjectService projectService;

        public Projects()
        {
            projectService = new ProjectService();
            InitializeComponent();
            LoadCrud();
        }
        private void LoadCrud()
        {

        }

    }
}
