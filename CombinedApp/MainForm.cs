using System;
using System.Drawing;
using System.Windows.Forms;

namespace CombinedApp
{
    public class MainForm : Form
    {
        private readonly string currentUser;

        public MainForm(string username)
        {
            currentUser = username;

            Text = "Mushroom & Bicycle System";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ClientSize = new Size(420, 340);
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 9F);

            var title = new Label
            {
                Text = "Mushroom & Bicycle System",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 75, 45),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 20),
                Size = new Size(380, 35)
            };

            var welcome = new Label
            {
                Text = "Welcome, " + currentUser + "! Choose an option:",
                ForeColor = Color.DimGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 60),
                Size = new Size(380, 20)
            };

            var mushroomButton = CreateMenuButton("Mushroom Identifier", 100);
            mushroomButton.Click += (sender, e) => new MushroomForm().ShowDialog(this);

            var bicycleButton = CreateMenuButton("Bicycle Rental", 165);
            bicycleButton.Click += (sender, e) => new BicycleForm().ShowDialog(this);

            var logoutButton = CreateMenuButton("Logout", 250);
            logoutButton.BackColor = Color.FromArgb(150, 60, 60);
            logoutButton.Click += (sender, e) => Close();

            var footer = new Label
            {
                Text = "Logged in as " + currentUser,
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 305),
                Size = new Size(380, 20)
            };

            Controls.Add(title);
            Controls.Add(welcome);
            Controls.Add(mushroomButton);
            Controls.Add(bicycleButton);
            Controls.Add(logoutButton);
            Controls.Add(footer);
        }

        private static Button CreateMenuButton(string text, int top)
        {
            var button = new Button
            {
                Text = text,
                Location = new Point(110, top),
                Size = new Size(200, 45),
                BackColor = Color.FromArgb(45, 75, 45),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }
    }
}
