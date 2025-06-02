namespace WindowsFormsApp5
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.RichTextBox richTextBoxBody;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonAttach;
        private System.Windows.Forms.Label labelAttachment;

        private void InitializeComponent()
        {
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.richTextBoxBody = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonAttach = new System.Windows.Forms.Button();
            this.labelAttachment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(80, 10);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(300, 22);
            this.textBoxFrom.Text = "your@gmail.com"; // placeholder bằng text tạm
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(400, 10);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(150, 22);
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxTo
            // 
            this.textBoxTo.Location = new System.Drawing.Point(80, 40);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(300, 22);
            this.textBoxTo.Text = "recipient@example.com";
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(80, 70);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(470, 22);
            // 
            // richTextBoxBody
            // 
            this.richTextBoxBody.Location = new System.Drawing.Point(20, 100);
            this.richTextBoxBody.Name = "richTextBoxBody";
            this.richTextBoxBody.Size = new System.Drawing.Size(530, 150);
            // 
            // buttonAttach
            // 
            this.buttonAttach.Location = new System.Drawing.Point(20, 260);
            this.buttonAttach.Name = "buttonAttach";
            this.buttonAttach.Size = new System.Drawing.Size(80, 30);
            this.buttonAttach.Text = "Attach";
            this.buttonAttach.UseVisualStyleBackColor = true;
            // 
            // labelAttachment
            // 
            this.labelAttachment.Location = new System.Drawing.Point(110, 265);
            this.labelAttachment.Name = "labelAttachment";
            this.labelAttachment.Size = new System.Drawing.Size(300, 20);
            this.labelAttachment.Text = "No file selected";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(400, 260);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(150, 30);
            this.buttonSend.Text = "SEND";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(580, 310);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.richTextBoxBody);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonAttach);
            this.Controls.Add(this.labelAttachment);
            this.Name = "Form3";
            this.Text = "SEND VIA GMAIL";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
