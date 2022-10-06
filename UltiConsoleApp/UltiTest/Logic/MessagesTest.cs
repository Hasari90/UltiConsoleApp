using Library.Logic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltiTest.Logic
{
    public class MessagesTest
    {
        [Fact]
        public void Greeting_InEnglish()
        {
            ILogger<Messages> logger = new NullLogger<Messages>();
            Messages messages = new(logger);

            string expected = "Hi";
            string actual = messages.Greeting("en");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Greeting_InPolish()
        {
            ILogger<Messages> logger = new NullLogger<Messages>();
            Messages messages = new(logger);

            string expected = "Cześć";
            string actual = messages.Greeting("pl");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Greeting_InSpanish()
        {
            ILogger<Messages> logger = new NullLogger<Messages>();
            Messages messages = new(logger);

            string expected = "Hola";
            string actual = messages.Greeting("es");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Greeting_InFrench()
        {
            ILogger<Messages> logger = new NullLogger<Messages>();
            Messages messages = new(logger);

            string expected = "Salut";
            string actual = messages.Greeting("fr");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Greeting_Invalid()
        {
            ILogger<Messages> logger = new NullLogger<Messages>();
            Messages messages = new(logger);

            Assert.Throws<InvalidOperationException>(
                () => messages.Greeting("de")
                );
        }


    }
}
