using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_a_ {
    class StringException : ApplicationException {
        public StringException() { }
        public StringException(string message) : base(message) { }
    }

    class IntException : ApplicationException {
        public IntException() { }
        public IntException(string message) : base(message) { }
    }

    class ExperienceException : ApplicationException {
        public ExperienceException() { }
        public ExperienceException(string message) : base(message) { }
    }
}
