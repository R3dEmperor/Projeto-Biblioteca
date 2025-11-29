using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NuGet.Frameworks;
using Projeto_Biblioteca.BLL;
using static System.Collections.Specialized.BitVector32;

namespace Projeto_Biblioteca
{
    public partial class frmIntro : Form
    {
        private readonly FuncionarioBLL funcionarioBLL = new();
        public frmIntro()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            login obj = new();
            obj.ShowDialog();
        }

      
        
    }
}
