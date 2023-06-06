using System;
using System.Collections.Generic;
using System.Linq;
using DesafioAPI.Data;
using DesafioAPI.DTO;
using DesafioAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioAPI.HATEOAS;

namespace DesafioAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        private HATEOAS.HATEOAS HATEOAS;
        
        public CategoriasController(ApplicationDbContext database){
            this.database = database;
            HATEOAS = new HATEOAS.HATEOAS("localhost:5001/api/v1/Categorias");
            HATEOAS.AddAction("GET_CATEGORIA", "GET");
            HATEOAS.AddAction("DELETE_CATEGORIA", "DELETE");
            HATEOAS.AddAction("EDIT_CATEGORIA", "PATCH");
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetCategoria(){
            var categorias =database.Categorias.Include(s=>s.Starters).ToList();
            List<CategoriaContainer> categoriasHATEOAS = new List<CategoriaContainer>();
            foreach(var cat in categorias){
                CategoriaContainer categoriaHATEOAS = new CategoriaContainer();
                categoriaHATEOAS.categoria = cat;
                categoriaHATEOAS.links = HATEOAS.GetActions(cat.Id.ToString());
                categoriasHATEOAS.Add(categoriaHATEOAS);
            }
            return Ok(categoriasHATEOAS);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetCategoriaByID(int id){
            try {
                Categoria categoria = database.Categorias.First(c => c.Id == id);
                CategoriaContainer categoriaHATEOAS = new CategoriaContainer();
                categoriaHATEOAS.categoria = categoria;
                categoriaHATEOAS.links = HATEOAS.GetActions(categoria.Id.ToString());
                return Ok(categoriaHATEOAS);
            }catch (Exception e){
                return BadRequest(new {msg = "ID inválida"});
            }          
            
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult PostCategoria([FromBody] CategoriaDTO categoriaTemp){
            Categoria categoria = new Categoria();
            categoria.Nome = categoriaTemp.Nome;
            categoria.Tecnologia = categoriaTemp.Tecnologia;
            categoria.Starters = new List<Starter>();
            database.Categorias.Add(categoria);
            database.SaveChanges();

            Response.StatusCode = 201;
            return new ObjectResult("");
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategoria(int id){
            try {
                Categoria categoria = database.Categorias.First(c => c.Id == id);
                database.Categorias.Remove(categoria);
                database.SaveChanges();
                return Ok();
            }catch (Exception e){
                return BadRequest(new {msg = "ID inválida"});
            }    
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public IActionResult PatchCategoria([FromBody] Categoria categoria){
            if(categoria.Id > 0){
                try {
                    var cat = database.Categorias.First(c => c.Id == categoria.Id);

                    if(cat != null){
                        cat.Nome = categoria.Nome != null ? categoria.Nome : cat.Nome;
                        cat.Tecnologia = categoria.Tecnologia != null ? categoria.Tecnologia : cat.Tecnologia;
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