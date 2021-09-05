using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpotifyLyrics
{
    public class BaseForm : Form
    {
        protected void SetColors()
        {

            this.BackColor = ColorConstants.FormBackground;

            var labels = GetAllControlsOfType(this, typeof(Label));
            foreach (var label in labels)
            {
                label.BackColor = ColorConstants.FormBackground;
                label.ForeColor = ColorConstants.LabelText;
            }

            var edits = GetAllControlsOfType(this, typeof(TextBox));
            foreach (var edit in edits)
            {
                edit.BackColor = ColorConstants.LyricBoxBackground;
                edit.ForeColor = ColorConstants.LabelText;
                (edit as TextBox).BorderStyle = BorderStyle.None;
            }

            var buttons = GetAllControlsOfType(this, typeof(Button));
            foreach (var button in buttons)
            {
                button.BackColor = ColorConstants.ButtonBackground;
                button.ForeColor = ColorConstants.ButtonText;
            }

            var groupBoxes = GetAllControlsOfType(this, typeof(GroupBox));
            foreach (var groupBox in groupBoxes)
            {
                groupBox.BackColor = ColorConstants.FormBackground;
                groupBox.ForeColor = ColorConstants.LabelText;
            }

            var menuItems = GetAllControlsOfType(this, typeof(ToolStripMenuItem));
            foreach (var menuItem in menuItems)
            {
                menuItem.BackColor = ColorConstants.FormBackground;
                menuItem.ForeColor = ColorConstants.LabelText;
            }

            var menus = GetAllControlsOfType(this, typeof(ContextMenuStrip));
            foreach (var menuItem in menus)
            {
                menuItem.BackColor = ColorConstants.FormBackground;
                menuItem.ForeColor = ColorConstants.LabelText;
            }
        }
        
        private IEnumerable<Control> GetAllControlsOfType(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>().ToList();

            return controls.SelectMany(ctrl => GetAllControlsOfType(ctrl, type))
                .Concat(controls)
                .Where(c => c.GetType() == type);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);

        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
