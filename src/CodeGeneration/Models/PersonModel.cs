using System.Collections.Generic;

namespace CodeGeneration.Models
{
    public class PersonModel
    {
        public string FullName { get; set;  }
        public string EmailAddress { get; set;  }
        public IEnumerable<string> Skills { get; set;  }
        public string Company { get; set; }
    }
}