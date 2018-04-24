using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models;



namespace Travel.ViewModel
{
    public class MyModel
    {
        public List<Menu> _menu { get; set; }
        public List<Join> _join { get; set; }
        public List<Blog> _blog { get; set; }
        public List<Navbar> _navbar { get; set; }
        public List<Comment> _comment { get; set; }
        public List<Service> _service { get; set; }
        public List<Tra> _travell { get; set; }
        public List<Travel_Type> _travel_type { get; set; }
        public List<Gallery> _gallery { get; set; }
        public List<User> _user { get; set; }
        public List<Contact> _contact { get; set; }
        public List<Gender> _gender { get; set; }
        public List<Postt> _post { get; set; }
    }
}