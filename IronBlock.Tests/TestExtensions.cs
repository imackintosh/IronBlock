using System.Collections.Generic;
using System.Linq;

namespace IronBlock.Tests
{

    internal static class TestExtensions
    {
        internal class DebugPrint : IBlock
        {
            public List<string> Text { get; set; }

            public DebugPrint()
            {
                this.Text = new List<string>();
            }

            public override object Evaluate(IDictionary<string, object> variables)
            {
                this.Text.Add((this.Values.First(x => x.Name == "TEXT").Evaluate(variables) ?? "").ToString());
                return base.Evaluate(variables);
            }
        }

        internal static DebugPrint AddDebugPrinter(this Parser parser)
        {
            var printer = new DebugPrint();
            parser.AddBlock("text_print", () => printer);
            return printer;
        }

    }
}