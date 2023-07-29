namespace Report_Pro.MyControls
{
    partial class Con_Inv_Row
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Con_Inv_Row));
            this.Ser = new DevComponents.Editors.IntegerInput();
            this.TxtPrice = new DevComponents.Editors.DoubleInput();
            this.TxtDisc = new DevComponents.Editors.DoubleInput();
            this.qty = new DevComponents.Editors.DoubleInput();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.txt_subTOt = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.VatValue = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.KM_TYPE_ITEMS = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.TxtDesc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_Code = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.VatRate = new DevComponents.Editors.DoubleInput();
            this.Txtvalue = new DevComponents.Editors.DoubleInput();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_DP_Ratio = new DevComponents.Editors.DoubleInput();
            this.VatAccRate = new DevComponents.Editors.DoubleInput();
            this.txtUnit = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Ser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDisc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VatRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtvalue)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DP_Ratio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VatAccRate)).BeginInit();
            this.SuspendLayout();
            // 
            // Ser
            // 
            this.Ser.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.Ser.BackgroundStyle.BackColor = System.Drawing.Color.RoyalBlue;
            this.Ser.BackgroundStyle.BackColor2 = System.Drawing.Color.RoyalBlue;
            this.Ser.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Ser.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Ser.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.Ser.BackgroundStyle.TextColor = System.Drawing.SystemColors.Window;
            this.Ser.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(this.Ser, "Ser");
            this.Ser.ForeColor = System.Drawing.Color.White;
            this.Ser.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Ser.Name = "Ser";
            this.Ser.TabStop = false;
            // 
            // TxtPrice
            // 
            this.TxtPrice.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.TxtPrice.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TxtPrice.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.TxtPrice.BackgroundStyle.BorderRightColor = System.Drawing.SystemColors.Highlight;
            this.TxtPrice.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TxtPrice.BackgroundStyle.Class = "TextBoxBorder";
            this.TxtPrice.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.TxtPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.TxtPrice.DisplayFormat = "#,##0.0000 ";
            resources.ApplyResources(this.TxtPrice, "TxtPrice");
            this.TxtPrice.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.TxtPrice.FocusHighlightEnabled = true;
            this.TxtPrice.Increment = 1D;
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPrice_KeyDown);
            this.TxtPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtPrice_KeyUp);
            // 
            // TxtDisc
            // 
            this.TxtDisc.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.TxtDisc.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.TxtDisc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TxtDisc.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.TxtDisc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(this.TxtDisc, "TxtDisc");
            this.TxtDisc.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.TxtDisc.FocusHighlightEnabled = true;
            this.TxtDisc.Increment = 1D;
            this.TxtDisc.Name = "TxtDisc";
            this.TxtDisc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDisc_KeyDown);
            // 
            // qty
            // 
            this.qty.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.qty.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.qty.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.qty.BackgroundStyle.BorderRightColor = System.Drawing.SystemColors.Highlight;
            this.qty.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.qty.BackgroundStyle.Class = "TextBoxBorder";
            this.qty.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.qty.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(this.qty, "qty");
            this.qty.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.qty.FocusHighlightEnabled = true;
            this.qty.Increment = 1D;
            this.qty.Name = "qty";
            this.qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Qty_KeyDown);
            this.qty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Qty_KeyUp);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txt_subTOt
            // 
            this.txt_subTOt.BackColor = System.Drawing.Color.Ivory;
            // 
            // 
            // 
            this.txt_subTOt.Border.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt_subTOt.Border.Class = "TextBoxBorder";
            resources.ApplyResources(this.txt_subTOt, "txt_subTOt");
            this.txt_subTOt.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.txt_subTOt.FocusHighlightEnabled = true;
            this.txt_subTOt.Name = "txt_subTOt";
            this.txt_subTOt.ReadOnly = true;
            // 
            // VatValue
            // 
            this.VatValue.BackColor = System.Drawing.Color.Ivory;
            // 
            // 
            // 
            this.VatValue.Border.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.VatValue.Border.Class = "TextBoxBorder";
            resources.ApplyResources(this.VatValue, "VatValue");
            this.VatValue.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.VatValue.FocusHighlightEnabled = true;
            this.VatValue.Name = "VatValue";
            this.VatValue.ReadOnly = true;
            // 
            // KM_TYPE_ITEMS
            // 
            this.KM_TYPE_ITEMS.BackColor = System.Drawing.Color.Ivory;
            // 
            // 
            // 
            this.KM_TYPE_ITEMS.Border.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.KM_TYPE_ITEMS.Border.Class = "TextBoxBorder";
            resources.ApplyResources(this.KM_TYPE_ITEMS, "KM_TYPE_ITEMS");
            this.KM_TYPE_ITEMS.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.KM_TYPE_ITEMS.FocusHighlightEnabled = true;
            this.KM_TYPE_ITEMS.Name = "KM_TYPE_ITEMS";
            this.KM_TYPE_ITEMS.ReadOnly = true;
            // 
            // txtNote
            // 
            // 
            // 
            // 
            this.txtNote.Border.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtNote.Border.Class = "TextBoxBorder";
            resources.ApplyResources(this.txtNote, "txtNote");
            this.txtNote.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.txtNote.FocusHighlightEnabled = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNote_KeyDown);
            // 
            // TxtDesc
            // 
            this.TxtDesc.BackColor = System.Drawing.Color.Ivory;
            // 
            // 
            // 
            this.TxtDesc.Border.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.TxtDesc.Border.BorderRightColor = System.Drawing.SystemColors.Window;
            this.TxtDesc.Border.Class = "TextBoxBorder";
            resources.ApplyResources(this.TxtDesc, "TxtDesc");
            this.TxtDesc.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.TxtDesc.FocusHighlightEnabled = true;
            this.TxtDesc.Name = "TxtDesc";
            this.TxtDesc.ReadOnly = true;
            // 
            // txt_Code
            // 
            // 
            // 
            // 
            this.txt_Code.Border.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt_Code.Border.Class = "TextBoxBorder";
            resources.ApplyResources(this.txt_Code, "txt_Code");
            this.txt_Code.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.txt_Code.FocusHighlightEnabled = true;
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.TextChanged += new System.EventHandler(this.txt_Code_TextChanged);
            this.txt_Code.DoubleClick += new System.EventHandler(this.txt_Code_DoubleClick);
            this.txt_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Code_KeyDown);
            this.txt_Code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Code_KeyPress);
            // 
            // VatRate
            // 
            this.VatRate.BackColor = System.Drawing.Color.Ivory;
            // 
            // 
            // 
            this.VatRate.BackgroundStyle.BackColor = System.Drawing.Color.Ivory;
            this.VatRate.BackgroundStyle.BackColor2 = System.Drawing.Color.Ivory;
            this.VatRate.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.VatRate.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.VatRate.BackgroundStyle.BorderRightColor = System.Drawing.SystemColors.Highlight;
            this.VatRate.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.VatRate.BackgroundStyle.Class = "TextBoxBorder";
            this.VatRate.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.VatRate.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(this.VatRate, "VatRate");
            this.VatRate.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.VatRate.FocusHighlightEnabled = true;
            this.VatRate.Increment = 1D;
            this.VatRate.Name = "VatRate";
            // 
            // Txtvalue
            // 
            this.Txtvalue.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.Txtvalue.BackgroundStyle.BackColor = System.Drawing.Color.Ivory;
            this.Txtvalue.BackgroundStyle.BackColor2 = System.Drawing.Color.Ivory;
            this.Txtvalue.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Txtvalue.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.Txtvalue.BackgroundStyle.BorderRightColor = System.Drawing.SystemColors.Highlight;
            this.Txtvalue.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Txtvalue.BackgroundStyle.Class = "TextBoxBorder";
            this.Txtvalue.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.Txtvalue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(this.Txtvalue, "Txtvalue");
            this.Txtvalue.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.Txtvalue.FocusHighlightEnabled = true;
            this.Txtvalue.Increment = 1D;
            this.Txtvalue.Name = "Txtvalue";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.txt_DP_Ratio, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtDesc, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNote, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Ser, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_Code, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.qty, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtPrice, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_subTOt, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.VatAccRate, 15, 0);
            this.tableLayoutPanel2.Controls.Add(this.KM_TYPE_ITEMS, 14, 0);
            this.tableLayoutPanel2.Controls.Add(this.VatValue, 13, 0);
            this.tableLayoutPanel2.Controls.Add(this.VatRate, 12, 0);
            this.tableLayoutPanel2.Controls.Add(this.Txtvalue, 11, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtDisc, 10, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtUnit, 5, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // txt_DP_Ratio
            // 
            this.txt_DP_Ratio.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.txt_DP_Ratio.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt_DP_Ratio.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txt_DP_Ratio.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.txt_DP_Ratio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(this.txt_DP_Ratio, "txt_DP_Ratio");
            this.txt_DP_Ratio.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.txt_DP_Ratio.FocusHighlightEnabled = true;
            this.txt_DP_Ratio.Increment = 1D;
            this.txt_DP_Ratio.Name = "txt_DP_Ratio";
            // 
            // VatAccRate
            // 
            this.VatAccRate.BackColor = System.Drawing.Color.Ivory;
            // 
            // 
            // 
            this.VatAccRate.BackgroundStyle.BackColor = System.Drawing.Color.Ivory;
            this.VatAccRate.BackgroundStyle.BackColor2 = System.Drawing.Color.Ivory;
            this.VatAccRate.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.VatAccRate.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.VatAccRate.BackgroundStyle.BorderRightColor = System.Drawing.SystemColors.Highlight;
            this.VatAccRate.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.VatAccRate.BackgroundStyle.Class = "TextBoxBorder";
            this.VatAccRate.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.VatAccRate.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(this.VatAccRate, "VatAccRate");
            this.VatAccRate.FocusHighlightColor = System.Drawing.Color.Yellow;
            this.VatAccRate.FocusHighlightEnabled = true;
            this.VatAccRate.Increment = 1D;
            this.VatAccRate.Name = "VatAccRate";
            // 
            // txtUnit
            // 
            resources.ApplyResources(this.txtUnit, "txtUnit");
            this.txtUnit.FormattingEnabled = true;
            this.txtUnit.Name = "txtUnit";
            // 
            // Con_Inv_Row
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "Con_Inv_Row";
            this.Enter += new System.EventHandler(this.Inv_Row_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.Ser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDisc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VatRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtvalue)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_DP_Ratio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VatAccRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevComponents.Editors.IntegerInput Ser;
        public DevComponents.Editors.DoubleInput TxtPrice;
        public DevComponents.Editors.DoubleInput TxtDisc;
        public DevComponents.Editors.DoubleInput qty;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        public DevComponents.DotNetBar.Controls.TextBoxX txt_subTOt;
        public DevComponents.DotNetBar.Controls.TextBoxX VatValue;
        public DevComponents.DotNetBar.Controls.TextBoxX KM_TYPE_ITEMS;
        public DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        public DevComponents.DotNetBar.Controls.TextBoxX TxtDesc;
        public DevComponents.DotNetBar.Controls.TextBoxX txt_Code;
        public DevComponents.Editors.DoubleInput VatRate;
        public DevComponents.Editors.DoubleInput Txtvalue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public DevComponents.Editors.DoubleInput VatAccRate;
        public DevComponents.Editors.DoubleInput txt_DP_Ratio;
        public System.Windows.Forms.ComboBox txtUnit;
    }
}
