using System;
using nehola.gameoflife.Entities;
using nehola.gameoflife.Entities.Logger;

namespace nehola.gameoflife.webapp.Logger
{
    public class WebWorldLogger : IWorldLogger
    {
        public String OutPut { get; set; }

        public WebWorldLogger()
        {
            OutPut = String.Empty;
        }

        private void AppendText(string text, bool newLine = false)
        {
            OutPut = String.Format("{0}{1}{2}", OutPut, newLine ? "<br/>" : String.Empty, text);
        }

        public void PrintGeneration(int generation)
        {
            AppendText(String.Format("Generation #{0}", generation),true);
        }

        public void PrintSeparator()
        {
            AppendText("<hr/>",true);
        }

        public void PrintForCell(Cell cell)
        {
            AppendText(String.Format("<div class=\"{0}\" />", cell.IsAlive ? "alive" : "dead"));
        }

        public void PrintForRowBegin(int row)
        {
            AppendText("<div class=\"row\">", false);
        }

        public void PrintForRowEnd(int row)
        {
            AppendText("</div>", false);
        }
    }
}