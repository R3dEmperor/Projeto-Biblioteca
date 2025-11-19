using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Biblioteca.BLL
{
    public class ReservaBLL
    {
        // Cria uma instância do DAL, que é a camada responsável por conversar com o SQL
        ReservaDAL dal = new();

        // Método responsável pelas regras quando criamos uma nova reserva
        public void CriarReserva(ReservaDTO reserva)
        // Antes de qualquer operação, verifico se os campos obrigatórios estão corretos
        {
            ValidarCamposObrigatorios(reserva);


            // A data da reserva é sempre a data atual
            reserva.DataReserva = DateTime.Now;

            // Marca a reserva como ativa (não cancelada, não finalizada)
            reserva.Ativa = true;

            // Aqui de fato salva no banco (chamando o DAL)
            dal.Create(reserva);

        }

        // Método que retorna uma lista de todas as reservas existentes no banco
        public List<ReservaDTO> ListarReservas()
        {
            // Pede para o DAL fazer o SELECT * FROM Reserva
            return dal.Listar();
        }

        // Remove uma reserva específico pelo ID
        public void RemoverReserva(int id)
        {
            // DAL executa DELETE FROM Reserva WHERE Id = @Id
            dal.Remover(id);
        }

        // Regra de validação básica que todas as operações precisam cumprir
        private void ValidarCamposObrigatorios(ReservaDTO reserva)
        {
            // A reserva precisa ter algum usuário válido
            if (reserva.UsuarioReserva <= 0)
                throw new Exception("Usuário inválido.");

            // E também deve estar associada a um livro válido
            if (reserva.ProdutoReserva <= 0)
                throw new Exception("Livro inválido.");
        }
    }

}
