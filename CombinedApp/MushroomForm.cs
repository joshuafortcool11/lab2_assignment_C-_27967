using System;
using System.Drawing;
using System.Windows.Forms;

namespace CombinedApp
{
    public class MushroomForm : Form
    {
        private readonly ComboBox gillsBox;
        private readonly ComboBox forestBox;
        private readonly ComboBox ringBox;
        private readonly ComboBox convexCupBox;
        private readonly Label resultLabel;

        public MushroomForm()
        {
            Text = "Mushroom Identifier";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(470, 390);
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 9F);

            var title = new Label
            {
                Text = "Mushroom Identifier",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 75, 45),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 15),
                Size = new Size(430, 30)
            };

            var subtitle = new Label
            {
                Text = "Answer these questions about your mushroom:",
                ForeColor = Color.DimGray,
                Location = new Point(30, 50),
                Size = new Size(410, 20)
            };

            gillsBox = CreateAnswerBox(85);
            forestBox = CreateAnswerBox(125);
            ringBox = CreateAnswerBox(165);
            convexCupBox = CreateAnswerBox(205);

            var identifyButton = new Button
            {
                Text = "Identify",
                Location = new Point(110, 250),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(45, 75, 45),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };
            identifyButton.FlatAppearance.BorderSize = 0;
            identifyButton.Click += IdentifyButton_Click;

            var resetButton = new Button
            {
                Text = "Reset",
                Location = new Point(240, 250),
                Size = new Size(120, 35),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };
            resetButton.FlatAppearance.BorderSize = 0;
            resetButton.Click += ResetButton_Click;

            resultLabel = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 75, 45),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(30, 300),
                Size = new Size(410, 60)
            };

            Controls.Add(title);
            Controls.Add(subtitle);
            Controls.Add(CreateQuestionLabel("Does your mushroom have gills?", 85));
            Controls.Add(gillsBox);
            Controls.Add(CreateQuestionLabel("Does it grow in a forest?", 125));
            Controls.Add(forestBox);
            Controls.Add(CreateQuestionLabel("Does it have a ring?", 165));
            Controls.Add(ringBox);
            Controls.Add(CreateQuestionLabel("Does it have a convex cup?", 205));
            Controls.Add(convexCupBox);
            Controls.Add(identifyButton);
            Controls.Add(resetButton);
            Controls.Add(resultLabel);
        }

        private static Label CreateQuestionLabel(string text, int top)
        {
            return new Label
            {
                Text = text,
                Location = new Point(30, top),
                Size = new Size(260, 23),
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private static ComboBox CreateAnswerBox(int top)
        {
            var box = new ComboBox
            {
                Location = new Point(300, top),
                Size = new Size(140, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            box.Items.AddRange(new object[] { "Yes", "No" });
            return box;
        }

        private void IdentifyButton_Click(object sender, EventArgs e)
        {
            if (gillsBox.SelectedIndex < 0 || forestBox.SelectedIndex < 0 ||
                ringBox.SelectedIndex < 0 || convexCupBox.SelectedIndex < 0)
            {
                resultLabel.ForeColor = Color.Firebrick;
                resultLabel.Text = "Please answer all four questions.";
                return;
            }

            string gills = gillsBox.SelectedItem.ToString().ToLower();
            string forest = forestBox.SelectedItem.ToString().ToLower();
            string ring = ringBox.SelectedItem.ToString().ToLower();
            string convexCup = convexCupBox.SelectedItem.ToString().ToLower();

            string mushroom;

            if (gills == "no" && forest == "yes" && ring == "no" && convexCup == "no")
            {
                mushroom = "Cepe de bordeaux";
            }
            else if (gills == "yes" && forest == "no" && ring == "yes" && convexCup == "yes")
            {
                mushroom = "Agaric jaunissant";
            }
            else if (gills == "yes" && forest == "yes" && ring == "yes" && convexCup == "yes")
            {
                mushroom = "Amanite tue-mouche";
            }
            else if (gills == "yes" && forest == "no" && ring == "yes" && convexCup == "no")
            {
                mushroom = "Coprin chevelu";
            }
            else if (gills == "yes" && forest == "yes" && ring == "no" && convexCup == "yes")
            {
                mushroom = "Pied bleu";
            }
            else
            {
                mushroom = "Mushroom not found";
            }

            resultLabel.ForeColor = Color.FromArgb(45, 75, 45);
            resultLabel.Text = "Your mushroom is " + mushroom;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            gillsBox.SelectedIndex = -1;
            forestBox.SelectedIndex = -1;
            ringBox.SelectedIndex = -1;
            convexCupBox.SelectedIndex = -1;
            resultLabel.Text = "";
        }
    }
}
