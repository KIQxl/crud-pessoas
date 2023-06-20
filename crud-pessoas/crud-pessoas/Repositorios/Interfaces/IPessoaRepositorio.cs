using crud_pessoas.Models;
using crud_pessoas.ViewModels;

namespace crud_pessoas.Repositorios.Interfaces
{
    public interface IPessoaRepositorio
    {
        public Task<PessoaModel> getPerson(int Id);
        public Task<List<PessoaModel>> GetPersons();
        public Task<PessoaModel> PostPerson(AddPersonModel addPersonModel);
        public Task<PessoaModel> UpdatePerson(int Id, UpdatePersonModel updatePersonModel);
        public Task<bool> DeletePerson(int Id);

    }
}
