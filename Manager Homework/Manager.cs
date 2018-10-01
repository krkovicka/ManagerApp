using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager_Homework
{
    class Manager
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public List<SalesPerson> salesPerson { get; set; }

    }
}
