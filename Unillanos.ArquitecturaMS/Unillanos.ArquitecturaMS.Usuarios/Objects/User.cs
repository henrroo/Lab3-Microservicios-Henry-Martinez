namespace Unillanos.ArquitecturaMS.Usuarios.Objects
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }

        public string ToString()
        {
            return "User: " + Name + ", " + Lastname + ", " + Sex + ", " + Email + ", " + Phone + ", " + Age;
        }
    }
}