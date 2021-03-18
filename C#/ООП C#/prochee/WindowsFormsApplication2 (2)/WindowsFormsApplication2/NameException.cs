using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    class NameException: ApplicationException
    {
        public NameException() { }
        public NameException(string message):base(message) { }
    }

    class AgeException: ApplicationException
    {
        public AgeException() { }
        public AgeException(string message):base(message) { }
    }

    class ExperienceException:ApplicationException   
    {
        public ExperienceException() { }
        public ExperienceException(string message):base(message) { }
    }
    class SpecException : ApplicationException
    {
        public SpecException() { }
        public SpecException(string message) : base(message) { }
    }
}
