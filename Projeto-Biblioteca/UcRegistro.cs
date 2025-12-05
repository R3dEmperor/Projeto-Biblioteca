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
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca
{
    public partial class UcRegistro : UserControl
    {
        RegistroBLL registroBLL = new();

        public UcRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var registro = new RegistroDTO()
                {
                    ReservaRegistro = int.Parse(txtUser.Text),
                    DevolucaoRegistro = dtDevolução.Value
                };

                registroBLL.CriarRegistro(registro);
                MessageBox.Show("Registro criado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar registro: " + ex.Message);
            }
        }
    }
}
