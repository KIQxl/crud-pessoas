using crud_pessoas.Data;
using crud_pessoas.Models;
using crud_pessoas.Repositorios.Interfaces;
using crud_pessoas.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace crud_pessoas.Repositorios
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly Context _context;

        public PessoaRepositorio(Context context)
        {
            _context = context;
        }

        public async Task<List<PessoaModel>> GetPersons()
        {
            try
            {
                List<PessoaModel> pessoas =  await _context.Pessoas.ToListAsync();

                if (pessoas == null) throw new Exception("Não encontrado");

                return pessoas;
                    
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        public async Task<PessoaModel> getPerson(int Id)
        {
            try
            {
                PessoaModel person = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id == Id);

                if (person == null) throw new Exception("Não Encontrado");

                return person;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        public async Task<PessoaModel> PostPerson(AddPersonModel addPersonModel)
        {
            try
            {
                PessoaModel person = new PessoaModel
                {
                    Nome = addPersonModel.Nome,
                    Sobrenome = addPersonModel.Sobrenome,
                    Sexo = addPersonModel.Sexo,
                    Profissao = addPersonModel.Profissao,
                };

                await _context.Pessoas.AddAsync(person);
                await _context.SaveChangesAsync();
                return person;

            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        public async Task<PessoaModel> UpdatePerson(int Id, UpdatePersonModel updatePersonModel)
        {
            try
            {
                PessoaModel personDb = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id == Id);

                if (personDb == null) throw new Exception("Não Encontrado");

                personDb.Nome = updatePersonModel.Nome;
                personDb.Sexo = updatePersonModel.Sexo;
                personDb.Sobrenome = updatePersonModel.Sobrenome;
                personDb.Profissao = updatePersonModel.Profissao;

                _context.Pessoas.Update(personDb);
                _context.SaveChangesAsync();

                return personDb;

            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        public async Task<bool> DeletePerson(int Id)
        { 
            try
            {
                PessoaModel personDb = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id == Id);

                if (personDb == null) throw new Exception("Não Encontrado");

                _context.Pessoas.Remove(personDb);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
    }
}
