using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca.BLL
{
    public class FuncionarioBLL
    {
        // Instância da DAL que conversa com o banco ou lista
        private readonly FuncionarioDAL dal = new();

     
        //                  CADASTRAR FUNCIONÁRIO
       
        public void CadastrarFuncionario(FuncionarioDTO funcionario)
        {
            ValidarFuncionario(funcionario);

            dal.Create(funcionario);
        }

       
        //                    LISTAR FUNCIONÁRIOS
      
        public List<FuncionarioDTO> ListarFuncionarios()
        {
            return dal.Listar();
        }


        //                    BUSCAR POR ID
    
        public FuncionarioDTO BuscarPorId(int id)
        {
            if (id <= 0)
                throw new Exception("Id inválido.");

            var func = dal.BuscarPorId(id);

            if (func == null)
                throw new Exception("Funcionário não encontrado.");

            return func;
        }

 
        //                      ATUALIZAR
        
        public void AtualizarFuncionario(FuncionarioDTO funcionario)
        {
            ValidarFuncionario(funcionario);

            dal.Update(funcionario);
        }

       
        //                      REMOVER
     
        public void RemoverFuncionario(int id)
        {
            if (id <= 0)
                throw new Exception("Id inválido.");

            dal.Delete(id);
        }

   
        //                VALIDAÇÃO DAS REGRAS
       
        private void ValidarFuncionario(FuncionarioDTO funcionario)
        {
            if (string.IsNullOrWhiteSpace(funcionario.DescricaoTipoUsuario))
                throw new Exception("A descrição do funcionário é obrigatória.");

            if (funcionario.DescricaoTipoUsuario.Length > 100)
                throw new Exception("A descrição não pode passar de 100 caracteres.");
        }
    }
}
