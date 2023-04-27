namespace TryThreading
{
  partial class Form1
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.btn_normal = new System.Windows.Forms.Button();
      this.btn_threaded = new System.Windows.Forms.Button();
      this.lbl_executionTime_normal = new System.Windows.Forms.Label();
      this.lbl_lastExecution_threaded = new System.Windows.Forms.Label();
      this.lbl_executionTime_normal_value = new System.Windows.Forms.Label();
      this.lbl_executionTime_threaded_value = new System.Windows.Forms.Label();
      this.btn_reset = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(12, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(798, 598);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // btn_normal
      // 
      this.btn_normal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btn_normal.BackColor = System.Drawing.Color.AliceBlue;
      this.btn_normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_normal.Location = new System.Drawing.Point(12, 616);
      this.btn_normal.Name = "btn_normal";
      this.btn_normal.Size = new System.Drawing.Size(798, 62);
      this.btn_normal.TabIndex = 1;
      this.btn_normal.Text = "Normal";
      this.btn_normal.UseVisualStyleBackColor = false;
      this.btn_normal.Click += new System.EventHandler(this.btn_normal_Click);
      // 
      // btn_threaded
      // 
      this.btn_threaded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btn_threaded.BackColor = System.Drawing.Color.Honeydew;
      this.btn_threaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_threaded.Location = new System.Drawing.Point(12, 684);
      this.btn_threaded.Name = "btn_threaded";
      this.btn_threaded.Size = new System.Drawing.Size(798, 62);
      this.btn_threaded.TabIndex = 2;
      this.btn_threaded.Text = "Threaded";
      this.btn_threaded.UseVisualStyleBackColor = false;
      this.btn_threaded.Click += new System.EventHandler(this.btn_threaded_Click);
      // 
      // lbl_executionTime_normal
      // 
      this.lbl_executionTime_normal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_executionTime_normal.AutoSize = true;
      this.lbl_executionTime_normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_executionTime_normal.Location = new System.Drawing.Point(6, 779);
      this.lbl_executionTime_normal.Name = "lbl_executionTime_normal";
      this.lbl_executionTime_normal.Size = new System.Drawing.Size(324, 31);
      this.lbl_executionTime_normal.TabIndex = 3;
      this.lbl_executionTime_normal.Text = "Last Execution - Normal : ";
      // 
      // lbl_lastExecution_threaded
      // 
      this.lbl_lastExecution_threaded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_lastExecution_threaded.AutoSize = true;
      this.lbl_lastExecution_threaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_lastExecution_threaded.Location = new System.Drawing.Point(6, 845);
      this.lbl_lastExecution_threaded.Name = "lbl_lastExecution_threaded";
      this.lbl_lastExecution_threaded.Size = new System.Drawing.Size(353, 31);
      this.lbl_lastExecution_threaded.TabIndex = 4;
      this.lbl_lastExecution_threaded.Text = "Last Execution - Threaded : ";
      // 
      // lbl_executionTime_normal_value
      // 
      this.lbl_executionTime_normal_value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_executionTime_normal_value.AutoSize = true;
      this.lbl_executionTime_normal_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_executionTime_normal_value.Location = new System.Drawing.Point(365, 779);
      this.lbl_executionTime_normal_value.Name = "lbl_executionTime_normal_value";
      this.lbl_executionTime_normal_value.Size = new System.Drawing.Size(23, 31);
      this.lbl_executionTime_normal_value.TabIndex = 5;
      this.lbl_executionTime_normal_value.Text = "-";
      // 
      // lbl_executionTime_threaded_value
      // 
      this.lbl_executionTime_threaded_value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl_executionTime_threaded_value.AutoSize = true;
      this.lbl_executionTime_threaded_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_executionTime_threaded_value.Location = new System.Drawing.Point(365, 845);
      this.lbl_executionTime_threaded_value.Name = "lbl_executionTime_threaded_value";
      this.lbl_executionTime_threaded_value.Size = new System.Drawing.Size(23, 31);
      this.lbl_executionTime_threaded_value.TabIndex = 6;
      this.lbl_executionTime_threaded_value.Text = "-";
      // 
      // btn_reset
      // 
      this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_reset.Location = new System.Drawing.Point(730, 530);
      this.btn_reset.Name = "btn_reset";
      this.btn_reset.Size = new System.Drawing.Size(80, 80);
      this.btn_reset.TabIndex = 7;
      this.btn_reset.Text = "🔄";
      this.btn_reset.UseVisualStyleBackColor = false;
      this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(822, 899);
      this.Controls.Add(this.btn_reset);
      this.Controls.Add(this.lbl_executionTime_threaded_value);
      this.Controls.Add(this.lbl_executionTime_normal_value);
      this.Controls.Add(this.lbl_lastExecution_threaded);
      this.Controls.Add(this.lbl_executionTime_normal);
      this.Controls.Add(this.btn_threaded);
      this.Controls.Add(this.btn_normal);
      this.Controls.Add(this.pictureBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.Text = "Test Normal vs Threaded Image Updates";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button btn_normal;
    private System.Windows.Forms.Button btn_threaded;
    private System.Windows.Forms.Label lbl_executionTime_normal;
    private System.Windows.Forms.Label lbl_lastExecution_threaded;
    private System.Windows.Forms.Label lbl_executionTime_normal_value;
    private System.Windows.Forms.Label lbl_executionTime_threaded_value;
    private System.Windows.Forms.Button btn_reset;
  }
}

