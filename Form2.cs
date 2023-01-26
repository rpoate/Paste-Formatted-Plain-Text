using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.htmlEditControl1.CancellableUserInteraction += HtmlEditControl1_UserInteraction;
        }

        private void HtmlEditControl1_UserInteraction(object sender, Zoople.CancellableUserInteractionEventsArgs e)
        {
            if (e.InteractionType == Zoople.EditorUIEvents.onbeforepaste )
            {
                if (Clipboard.ContainsText(TextDataFormat.Text) && !Clipboard.ContainsText(TextDataFormat.Html)) 
                {
                    e.Cancel = true; // cancel the paste event

                    // line breaks only
                    //var PlainText = Clipboard.GetText(TextDataFormat.Text).Replace("\r\n", "<br />");
                    //this.htmlEditControl1.InsertAtCursor(PlainText, Zoople.HTMLEditControl.ed_InsertType.ed_InsertReplaceSelection);

                    // paragraph formatted
                    var PlainText = Clipboard.GetText(TextDataFormat.Text).Replace("\r\n", "</p><p>");
                    if (PlainText.EndsWith("<p>")) PlainText.TrimEnd( new char[] { '<', 'p', '>'});

                    this.htmlEditControl1.InsertAtCursor("<p>" + PlainText, Zoople.HTMLEditControl.ed_InsertType.ed_InsertReplaceSelection);
                }
            }
        }
    }
}
