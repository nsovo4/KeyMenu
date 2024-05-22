private System.Windows.Forms.Button buttonDisable;
private System.Windows.Forms.Button buttonEnable;

private void InitializeComponent()
{
    this.buttonDisable = new System.Windows.Forms.Button();
    this.buttonEnable = new System.Windows.Forms.Button();
    this.SuspendLayout();
    // 
    // buttonDisable
    // 
    this.buttonDisable.Location = new System.Drawing.Point(50, 50);
    this.buttonDisable.Name = "buttonDisable";
    this.buttonDisable.Size = new System.Drawing.Size(200, 50);
    this.buttonDisable.TabIndex = 0;
    this.buttonDisable.Text = "Disable Keyboard";
    this.buttonDisable.UseVisualStyleBackColor = true;
    this.buttonDisable.Click += new System.EventHandler(this.buttonDisable_Click);
    // 
    // buttonEnable
    // 
    this.buttonEnable.Location = new System.Drawing.Point(50, 150);
    this.buttonEnable.Name = "buttonEnable";
    this.buttonEnable.Size = new System.Drawing.Size(200, 50);
    this.buttonEnable.TabIndex = 1;
    this.buttonEnable.Text = "Enable Keyboard";
    this.buttonEnable.UseVisualStyleBackColor = true;
    this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
    // 
    // Form1
    // 
    this.ClientSize = new System.Drawing.Size(300, 250);
    this.Controls.Add(this.buttonDisable);
    this.Controls.Add(this.buttonEnable);
    this.Name = "Form1";
    this.Text = "Keyboard Lock";
    this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
    this.Load += new System.EventHandler(this.Form1_Load);
    this.ResumeLayout(false);
}
