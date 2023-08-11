namespace Bootcamp.Models
{
    public class Questions
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public string question { get; set; }
            public string[] options { get; set; }
            public string correctAnswer { get; set; }
        }

    }
}
