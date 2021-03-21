using System;

namespace P03.StudentSystem
{
    public class Engine
    {
        private StudentSystem studentSystem;
        private readonly IInputOutputProvider inputOutputProvider;

        public Engine(StudentSystem studentSystem, IInputOutputProvider inputOutputProvider)
        {
            this.studentSystem = studentSystem;
            this.inputOutputProvider = inputOutputProvider;
        }
        public void Process()
        {
            var isTrue = true;
            while (isTrue)
            {
                var line = inputOutputProvider.GetInput();

                var command = Command.Parse(line);

                var name = command.Name;
                var args = command.Arguments;
                switch (name)
                {
                    case "Create":
                        this.studentSystem.AddStudent(
                            args[0],
                            int.Parse(args[1]),
                            double.Parse(args[2]));
                        break;
                    case "Show":
                        var detail = studentSystem.GetDetails(args);
                        inputOutputProvider.ShowOutput(detail);
                        break;
                    case "Exit":
                        isTrue = false;
                        break;
                }
            }
        }
    }
}
