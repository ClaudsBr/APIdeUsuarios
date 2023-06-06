using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DesafioAPI.Data;
using DesafioAPI.DTO;
using DesafioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DesafioAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController: ControllerBase
    {
        private readonly ApplicationDbContext database;
        public UsuariosController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost("registro")]
        public IActionResult Registro([FromBody] Usuario usuario){  
                                  
            database.Add(usuario);
            database.SaveChanges();
            Response.StatusCode = 201;
            return new ObjectResult("");            
            
        }
        

        [HttpPost("login")]     

        public IActionResult Login([FromBody] LoginDTO credenciais){
            
            try{
                Usuario usuario = database.Usuarios.First(user => user.Login.Equals(credenciais.Login));
                
                if(usuario != null){
                    
                    if(usuario.Senha.Equals(credenciais.Senha)){

                        string chaveDeSeguranca = "GFTBrasil2022";
                        var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(chaveDeSeguranca));
                        var credencialAcesso = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256Signature);
                        
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Role, usuario.Role));
                        
                        var JWT = new JwtSecurityToken(
                            issuer: "GFTBrasil",
                            expires: DateTime.Now.AddMinutes(20),
                            audience: "Usuario",
                            signingCredentials: credencialAcesso,
                            claims: claims
                        );
                        var token = new JwtSecurityTokenHandler().WriteToken(JWT);
                        EmailSender.Send(usuario.Email);
                        return Ok(token);
                    }else{
                        Response.StatusCode = 401;
                        return new ObjectResult("Senha Incorreta");
                    }
                }else{
                    Response.StatusCode = 401;
                    return new ObjectResult("Não há usuario cadastrado com esse login");
                }
            }catch(Exception e){
                Response.StatusCode = 401;
                return new ObjectResult("usuario nao encontrado");
            }
            
        }              
    }
}