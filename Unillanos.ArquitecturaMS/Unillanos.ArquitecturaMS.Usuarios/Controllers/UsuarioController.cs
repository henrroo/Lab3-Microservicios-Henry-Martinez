using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Unillanos.ArquitecturaMS.Usuarios.Objects;

namespace Unillanos.ArquitecturaMS.Usuarios.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("FindUser/{id}")]
        public string Get(int id)
        {
            var l = new Logic.Logic();

            if (!l.Exist(id))
            {
                throw new NotSupportedException("El id no se encuentra registrado.");
            }

            var u = l.GetUsers();
            for (int i = 0; i < u.Count; i++)
            {
                if (u[i].Id == id)
                {
                    return u[i].ToString();
                }
            }

            return null;
        }

        [HttpPost]
        [Route("InsertUser/")]
        public void Post(User u)
        {
            var l = new Logic.Logic();
            l.InsertUser(u);
        }

        [HttpPut]
        [Route("UpdateUser/")]
        public void Put(User u)
        {
            var l = new Logic.Logic();
            l.UpdateUser(u);
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public void Delete(int id)
        {
            var l = new Logic.Logic();
            l.DeleteUser(id);
        }
    }
}