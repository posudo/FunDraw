namespace FunDraw.Components
{
    partial class WordButton
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            wordBtn = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // wordBtn
            // 
            wordBtn.CustomizableEdges = customizableEdges1;
            wordBtn.DisabledState.BorderColor = Color.DarkGray;
            wordBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            wordBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            wordBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            wordBtn.Font = new Font("Segoe UI", 9F);
            wordBtn.ForeColor = Color.White;
            wordBtn.Location = new Point(0, 0);
            wordBtn.Name = "wordBtn";
            wordBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            wordBtn.Size = new Size(232, 45);
            wordBtn.TabIndex = 1;
            wordBtn.Text = "Word";
            wordBtn.Click += wordBtn_Click;
            // 
            // WordButton
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(wordBtn);
            Name = "WordButton";
            Size = new Size(232, 45);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button wordBtn;
    }
}
