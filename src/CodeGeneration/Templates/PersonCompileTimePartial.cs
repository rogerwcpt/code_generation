using CodeGeneration.Models;

namespace CodeGeneration.Templates
{
    public partial class PersonCompileTime
    {
        public readonly PersonModel Model;

        public PersonCompileTime(PersonModel model)
        {
            Model = model;
        }
    }
}