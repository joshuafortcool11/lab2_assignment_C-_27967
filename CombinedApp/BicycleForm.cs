using System;
using System.Drawing;
using System.Windows.Forms;

namespace CombinedApp
{
    public class BicycleForm : Form
    {
        private readonly NumericUpDown startBox;
        private readonly NumericUpDown endBox;
        private readonly Label errorLabel;
        private readonly Label resultLabel;

        public BicycleForm()
        {
            Text = "Bicycle Rental";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(430, 330);
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 9F);

            var title = new Label
            {
                Text = "Bicycle Rental Calculator",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 75, 45),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 15),
                Size = new Size(390, 30)
            };

            var startLabel = new Label
            {
                Text = "Starting time (0-23):",
                Location = new Point(40, 80),
                Size = new Size(160, 23),
                TextAlign = ContentAlignment.MiddleLeft
            };

            startBox = new NumericUpDown
            {
                Location = new Point(220, 80),
                Size = new Size(80, 23),
                Minimum = 0,
                Maximum = 23,
                Value = 8
            };

            var endLabel = new Label
            {
                Text = "Ending time (1-24):",
                Location = new Point(40, 120),
                Size = new Size(160, 23),
                TextAlign = ContentAlignment.MiddleLeft
            };

            endBox = new NumericUpDown
            {
                Location = new Point(220, 120),
                Size = new Size(80, 23),
                Minimum = 1,
                Maximum = 24,
                Value = 17
            };

            var calculateButton = new Button
            {
                Text = "Calculate",
                Location = new Point(150, 165),
                Size = new Size(130, 35),
                BackColor = Color.FromArgb(45, 75, 45),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };
            calculateButton.FlatAppearance.BorderSize = 0;
            calculateButton.Click += CalculateButton_Click;

            errorLabel = new Label
            {
                ForeColor = Color.Firebrick,
                Location = new Point(40, 210),
                Size = new Size(350, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            resultLabel = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 75, 45),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(30, 240),
                Size = new Size(370, 50)
            };

            var rates = new Label
            {
                Text = "Rates: night 500 | day 1000 | peak 1500 RWF per hour",
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 300),
                Size = new Size(390, 20)
            };

            Controls.Add(title);
            Controls.Add(startLabel);
            Controls.Add(startBox);
            Controls.Add(endLabel);
            Controls.Add(endBox);
            Controls.Add(calculateButton);
            Controls.Add(errorLabel);
            Controls.Add(resultLabel);
            Controls.Add(rates);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            int startTime = (int)startBox.Value;
            int endTime = (int)endBox.Value;

            if (endTime <= startTime)
            {
                errorLabel.Text = "Ending time must be greater than starting time.";
                resultLabel.Text = "";
                return;
            }

            errorLabel.Text = "";
            int total = 0;

            for (int hour = startTime; hour < endTime; hour++)
            {
                if (hour < 7 || hour >= 21)
                {
                    total = total + 500;
                }
                else if (hour < 14 || hour >= 19)
                {
                    total = total + 1000;
                }
                else
                {
                    total = total + 1500;
                }
            }

            resultLabel.Text = "Total rental cost = " + total + " RWF";
        }
    }
}
