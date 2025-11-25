using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_Biblioteca.BLL;

namespace Projeto_Biblioteca
{
    public partial class ucFuncinarios : UserControl
    {
        FuncionarioBLL funcionarioBLL = new();
        public ucFuncinarios()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            funcionarioBLL.CadastrarFuncionario(funcionario);
        }
    }
}
