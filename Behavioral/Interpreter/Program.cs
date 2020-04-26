using System;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context("Hello World!");
            System.Console.WriteLine($"origin: {context.Text}");
            var translatorA = new ExpressionToUpper();
            translatorA.Interpret(context);
            System.Console.WriteLine($"translatorA: {context.Text}");
            var translatorB = new ExpressionToLower();
            translatorB.Interpret(context);
            System.Console.WriteLine($"translatorB: {context.Text}");
        }
    }

    class Context
    {
        public string Text { get; set; }
        public Context(string text)
        {
            this.Text = text;
        }
    }
    interface IExpression
    {
        void Interpret(Context context);
    }
    class ExpressionToUpper : IExpression
    {
        public void Interpret(Context context)
        {
            context.Text = context.Text.ToUpper();
        }
    }
    class ExpressionToLower : IExpression
    {
        public void Interpret(Context context)
        {
            context.Text = context.Text.ToLower();
        }
    }
}
