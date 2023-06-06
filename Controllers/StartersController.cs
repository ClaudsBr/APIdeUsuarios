using System;
using System.Linq;
using DesafioAPI.Data;
using DesafioAPI.DTO;
using DesafioAPI.Models;
using DesafioAPI.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DesafioAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StartersController: ControllerBase
    {
        
        
        private readonly ApplicationDbContext database;
        
        public StartersController(ApplicationDbContext database ){
            this.database = database;                     
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetStarters(){
            var starters = database.Starters.Include(c => c.Categoria).ToList();
            
            return Ok(starters);
        }

        [HttpGet("asc")]
        [Authorize]
        public IActionResult StartersOrdemAlfabetica(){
            var starters = database.Starters.Include(s=> s.Categoria).ToList();
            List<Starter> alfabetica = starters.OrderBy(x=>x.Nome).ToList();
            return Ok(alfabetica);
        }

        [HttpGet("desc")]
        [Authorize]
        public IActionResult StartersOrdemDescendente(){
            var starters = database.Starters.Include(s=> s.Categoria).ToList();
            List<Starter> ordemDesc = starters.OrderByDescending(x=>x.Nome).ToList();
            return Ok(ordemDesc);
        }
                
        [HttpGet("nome/{nome}")]
        [Authorize(Roles = "Admin")]
        public IActionResult StartersByName(string nome){
            try{
                Starter starter = database.Starters.Include(c=> c.Categoria).First(s=> s.Nome.Contains(nome));
                return Ok(starter);
            }catch(Exception e){
                Response.StatusCode = 401;
                return new ObjectResult("");
            }             
            
        }


        [HttpGet("{id}")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetStarterByID(int id){
            try {                
                Starter starter = database.Starters.Include(c=> c.Categoria).First(s => s.Id == id);
                return Ok(starter);
            }catch (Exception e){
                Response.StatusCode = 404;
                return new ObjectResult("");
            }     
            
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteStarter(int id){
            try {
                Starter starter = database.Starters.First(s => s.Id == id);
                database.Starters.Remove(starter);
                database.SaveChanges();
                
                return Ok();
            }catch (Exception e){
                return BadRequest(new {msg = "ID inválida"});
            }    
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult PostStarter([FromBody] StarterDTO starterTemp){
            //Validando CPF
            string cpf = starterTemp.CPF;
            if(ValidandoCPF.ValidaCPF(cpf) == false){

                Response.StatusCode = 400;
                return new ObjectResult(new {msg = "Numero de CPF Invalido"});
            }
            if(starterTemp.Login.Length != 4){
                Response.StatusCode = 400;
                return new ObjectResult(new {msg = "O Login deve ter 4 letras"});
            }
            
            Starter starter = new Starter();
            starter.Nome = starterTemp.Nome;
            starter.CPF = starterTemp.CPF;            
            starter.Login = starterTemp.Login;
            starter.Email = starterTemp.Email;
            starter.CategoriaId = starterTemp.CategoriaID;
            starter.Categoria = database.Categorias.First(cat=> cat.Id == starterTemp.CategoriaID);                        
            database.Starters.Add(starter);
            database.SaveChanges();

            Response.StatusCode = 201;
            return new ObjectResult("");
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public IActionResult PatchStarter([FromBody] Starter starter){
            if(starter.Id > 0){
                try {
                    var st = database.Starters.First(s => s.Id == starter.Id);

                    if(st != null){
                        st.Nome = starter.Nome != null ? starter.Nome : st.Nome;
                        st.CPF = starter.CPF != null ? starter.CPF : st.CPF;
                        st.Login = starter.Login != null ? starter.Login : st.Login;
                        st.Email = starter.Email != null ? starter.Email : st.Email;
                        st.CategoriaId = starter.CategoriaId != 0 ? starter.CategoriaId:st.CategoriaId;
                        st.Categoria = database.Categorias.First(cat=> cat.Id == starter.CategoriaId);
                        database.SaveChanges();
                        return Ok();

                    }else {
                        Response.StatusCode = 400;
                        return new ObjectResult(new {msg = "Categoria não encontrada"});
                    }
                }catch{
                    Response.StatusCode = 400;
                    return new ObjectResult(new {msg = "Categoria não encontrada"});
                }                

            }else {
                Response.StatusCode = 400;
                return new ObjectResult(new {msg = "A ID inválida"});
            }    

        }  
    }
}