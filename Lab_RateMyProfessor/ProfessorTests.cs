using RateMyProfessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lab_RateMyProfessor
{
    public class ProfessorTests
    {

        
            [Fact]
            public void TestProfessor()
            {
                using (var consoleOutput = new ConsoleOutput())
                {
                    // Arrange
                    Professor professor = new Professor();

                    // Simulate user input for the Main method
                    string[] userInputs = { "-addProf", "John Doe", "-viewProf", "E" };

                    // Act
                    SimulateUserInput(userInputs);
                    //This is errored currently need some way to access program so that the file can run 
                    //Lab_RateMyProfessor.Program.Main(null);

                    // Assert
                    string output = consoleOutput.GetOutput();
                    Assert.Contains("Please enter a professor's name:", output);
                    Assert.Contains("John Doe", output);
                    Assert.Contains("John Doe", output);
                }
            }

            private void SimulateUserInput(string[] inputs)
            {
                using (var stringReader = new StringReader(string.Join(Environment.NewLine, inputs)))
                {
                    Console.SetIn(stringReader);
                }
            }

            private class ConsoleOutput : IDisposable
            {
                private readonly StringWriter stringWriter;
                private readonly TextWriter originalOutput;

                public ConsoleOutput()
                {
                    stringWriter = new StringWriter();
                    originalOutput = Console.Out;
                    Console.SetOut(stringWriter);
                }

                public string GetOutput()
                {
                    return stringWriter.ToString();
                }

                public void Dispose()
                {
                    stringWriter.Dispose();
                    Console.SetOut(originalOutput);
                }
            }
        }
    }

