using crud_pessoas.Models;
using crud_pessoas.Repositorios.Interfaces;
using crud_pessoas.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace crud_pessoas.Controllers
{   
    [ApiController]
    [Route("v1")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        [HttpGet]
        [Route("pessoas")]
        public async Task<IActionResult> GetPersons()
        {
            List<PessoaModel> persons = await _pessoaRepositorio.GetPersons();

            try
            {
                if (persons != null)
                {
                    return Ok(persons);
                }

                return BadRequest("Registros não encontrados");
            }
            catch (System.Exception erro)
            {
                throw erro;
            }
        }

        [HttpGet]
        [Route("pessoas/{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            try
            {
                PessoaModel person = await _pessoaRepositorio.getPerson(id);

                if (person != null)
                {
                    return Ok(person);
                }

                return BadRequest("Registro não encontrado");
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        [HttpPost]
        [Route("pessoas")]
        public async Task<IActionResult> PostPerson([FromBody] AddPersonModel addPersonModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    PessoaModel person = await _pessoaRepositorio.PostPerson(addPersonModel);

                    return Created($"v1/pessoas/{person.Id}", person);
                }

                return BadRequest("Registro não adicionado");
            }
            catch(System.Exception erro)
            {
                throw erro;
            }
        }

        [HttpPut]
        [Route("pessoas/{id}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] UpdatePersonModel updatePersonModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PessoaModel personDb = await _pessoaRepositorio.UpdatePerson(id, updatePersonModel);

                    return Created($"v1/pessoas/{personDb.Id}" ,personDb);
                }

                return BadRequest("Registro não alterado");
            }
            catch (System.Exception erro)
            {

                throw erro;
            }
        }

        [HttpDelete]
        [Route("pessoas/{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {

            try
            {
                bool apagado = await _pessoaRepositorio.DeletePerson(id);

                if (apagado)
                {
                    return Ok("Apagado com sucesso");
                }

                return BadRequest();

            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
    }
}
