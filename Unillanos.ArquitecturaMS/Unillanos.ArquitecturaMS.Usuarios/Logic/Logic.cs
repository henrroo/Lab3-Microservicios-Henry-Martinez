using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Unillanos.ArquitecturaMS.Usuarios.Objects;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Unillanos.ArquitecturaMS.Usuarios.Logic
{
    public class Logic
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Users.txt");

        public string ListtoJson<T>(IList<User> u)
        {
            var json = JsonSerializer.Serialize(u);
            return json;
        }

        public IList<User> JsontoList<User>(string json)
        {
            var u = JsonConvert.DeserializeObject<IList<User>>(json);
            return u;
        }

        public void InsertUser(User user)
        {
            if (!Exist(user.Id))
            {
                var u = GetUsers();
                var ux = new User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Lastname = user.Lastname,
                    Sex = user.Sex,
                    Email = user.Email,
                    Phone = user.Phone,
                    Age = user.Age
                };
                u.Add(ux);
                var newlist = ListtoJson<User>(u);
                Overread(newlist);
            }
            else
            {
                throw new NotSupportedException("Ya existe un usuario con ese ID.");
            }
        }

        public static void Overread(string newstring)
        {
            File.WriteAllText(path, newstring);
        }

        public IList<User> GetUsers()
        {
            string text = File.ReadAllText(path);
            var u = JsonConvert.DeserializeObject<IList<User>>(text);
            return u;
        }

        public string UsertoJson(User u)
        {
            var json = JsonSerializer.Serialize(u);
            return json;
        }

        public User JsontoUser(string json)
        {
            var u = JsonSerializer.Deserialize<User>(json);
            return u;
        }

        public void UpdateUser(User user)
        {
            var l = new Logic();
            var u = l.GetUsers();
            if (Exist(user.Id))
            {
                for (int i = 0; i < u.Count; i++)
                {
                    if (u[i].Id == user.Id)
                    {
                        u[i].Name = user.Name;
                        u[i].Lastname = user.Lastname;
                        u[i].Sex = user.Sex;
                        u[i].Email = user.Email;
                        u[i].Phone = user.Phone;
                        u[i].Age = user.Age;
                    }
                }

                var newlist = ListtoJson<User>(u);
                Overread(newlist);
            }
            else
            {
                throw new NotSupportedException("No existe un usuario con ese ID, no se puede actualizar.");
            }
        }

        public void DeleteUser(int id)
        {
            var l = new Logic();
            var u = l.GetUsers();
            if (Exist(id))
            {
                for (int i = 0; i < u.Count; i++)
                {
                    if (u[i].Id == id)
                    {
                        u.RemoveAt(i);
                    }
                }

                var newlist = ListtoJson<User>(u);
                Overread(newlist);
            }
            else
            {
                throw new NotSupportedException("No existe el usuario, no se puede borrar.");
            }
        }

        public bool Exist(int id)
        {
            var u = GetUsers();
            for (int i = 0; i < u.Count; i++)
            {
                if (u[i].Id == id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}