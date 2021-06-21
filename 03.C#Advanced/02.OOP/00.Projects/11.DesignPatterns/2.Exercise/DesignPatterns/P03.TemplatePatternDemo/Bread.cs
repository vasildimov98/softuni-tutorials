using System.Threading;

namespace P03.TemplatePatternDemo
{
    public abstract class Bread
    {
        public abstract void MixIngredients(); 
        public abstract void Bake();
        public virtual void Slice()
        {
            System.Console.WriteLine("Slicing the " + GetType().Name + " bread!");
        }
        //The template method
        public void Make()
        {
            this.MixIngredients();
            this.Bake();
            this.Slice();
        }
    }
}
