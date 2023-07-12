using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace Synth
{
    public class Oscillator : GroupBox
    {
        public Oscillator()
        {
            this.Controls.Add(new Button()
            {
                Name = "Sine",
                Location = new Point(10, 15),
                Text = "Sine",
                BackColor = Color.Yellow
            });
            this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new Point(65, 15),
                Text = "Square"
            });
            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new Point(120, 15),
                Text = "Saw"
            });
            this.Controls.Add(new Button()
            {
                Name = "Triangle",
                Location = new Point(10, 50),
                Text = "Triangle"
            });
            this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new Point(65, 50),
                Text = "Noise"
            });
            foreach (Control control in Controls)
            {
                control.Size = new Size(50, 30);
                control.Font = new Font("Microsfoft Sans Sefif", 6.25f);
                control.Click += WaveButton_Click;
            }
            this.Controls.Add(new CheckBox()
            {
                Name = "OscillatorOn",
                Location = new Point(210, 10),
                Size = new Size(40, 30),
                Text = "On",
                Checked = true
            });
        }

        public WaveForm WaveForm { get; private set; }
        public bool On => ((CheckBox)this.Controls["OscillatorOn"]).Checked;

        private void WaveButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.WaveForm = (WaveForm)Enum.Parse(typeof(WaveForm), button.Text);
            foreach (Button otherButtons in this.Controls.OfType<Button>())
            {
                otherButtons.UseVisualStyleBackColor = true;
            }

            button.BackColor = Color.Yellow;
        }
    }
}