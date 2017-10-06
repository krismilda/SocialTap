namespace SocialTap
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabUploadImage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.errorMessage = new System.Windows.Forms.Label();
            this.lblPercentageText = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblAddressText = new System.Windows.Forms.Label();
            this.lblNameText = new System.Windows.Forms.Label();
            this.lblDateText = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.tabFind = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblZoomText = new System.Windows.Forms.Label();
            this.btnFindMap = new System.Windows.Forms.Button();
            this.cmdZoom = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblImageError = new System.Windows.Forms.Label();
            this.TblNearbyLocation = new System.Windows.Forms.DataGridView();
            this.ColumnNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageBoxMap = new System.Windows.Forms.PictureBox();
            this.tabTOP = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTopList = new System.Windows.Forms.Label();
            this.dataTopList = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMostVisited = new System.Windows.Forms.TabPage();
            this.tabMain.SuspendLayout();
            this.tabUploadImage.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.tabFind.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TblNearbyLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxMap)).BeginInit();
            this.tabTOP.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTopList)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "FileName";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabUploadImage);
            this.tabMain.Controls.Add(this.tabFind);
            this.tabMain.Controls.Add(this.tabTOP);
            this.tabMain.Controls.Add(this.tabMostVisited);
            this.tabMain.Location = new System.Drawing.Point(1, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(788, 573);
            this.tabMain.TabIndex = 5;
            // 
            // tabUploadImage
            // 
            this.tabUploadImage.Controls.Add(this.tableLayoutPanel10);
            this.tabUploadImage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tabUploadImage.Location = new System.Drawing.Point(4, 28);
            this.tabUploadImage.Name = "tabUploadImage";
            this.tabUploadImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabUploadImage.Size = new System.Drawing.Size(780, 541);
            this.tabUploadImage.TabIndex = 0;
            this.tabUploadImage.Text = "Upload Image";
            this.tabUploadImage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.84158F));
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.93985F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.06015F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(774, 532);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.80109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.19891F));
            this.tableLayoutPanel1.Controls.Add(this.btnOpenFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.errorMessage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPercentageText, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPercentage, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblAddressText, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNameText, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDateText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDate, 1, 1);
            this.tableLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 130);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(4, 4);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(68, 26);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "OPEN";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click_1);
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.Cursor = System.Windows.Forms.Cursors.PanNorth;
            this.errorMessage.Location = new System.Drawing.Point(144, 0);
            this.errorMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(0, 19);
            this.errorMessage.TabIndex = 1;
            this.errorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPercentageText
            // 
            this.lblPercentageText.AutoSize = true;
            this.lblPercentageText.Location = new System.Drawing.Point(3, 91);
            this.lblPercentageText.Name = "lblPercentageText";
            this.lblPercentageText.Size = new System.Drawing.Size(134, 19);
            this.lblPercentageText.TabIndex = 2;
            this.lblPercentageText.Text = "Percentage of Liquid";
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(143, 91);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(0, 19);
            this.lblPercentage.TabIndex = 3;
            // 
            // lblAddressText
            // 
            this.lblAddressText.AutoSize = true;
            this.lblAddressText.Location = new System.Drawing.Point(3, 72);
            this.lblAddressText.Name = "lblAddressText";
            this.lblAddressText.Size = new System.Drawing.Size(60, 19);
            this.lblAddressText.TabIndex = 6;
            this.lblAddressText.Text = "Address";
            // 
            // lblNameText
            // 
            this.lblNameText.AutoSize = true;
            this.lblNameText.Location = new System.Drawing.Point(3, 53);
            this.lblNameText.Name = "lblNameText";
            this.lblNameText.Size = new System.Drawing.Size(46, 19);
            this.lblNameText.TabIndex = 4;
            this.lblNameText.Text = "Name";
            // 
            // lblDateText
            // 
            this.lblDateText.AutoSize = true;
            this.lblDateText.Location = new System.Drawing.Point(3, 34);
            this.lblDateText.Name = "lblDateText";
            this.lblDateText.Size = new System.Drawing.Size(38, 19);
            this.lblDateText.TabIndex = 8;
            this.lblDateText.Text = "Date";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(143, 72);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(0, 19);
            this.lblAddress.TabIndex = 7;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(143, 53);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 19);
            this.lblName.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(143, 34);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 19);
            this.lblDate.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.imageBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.imageBox, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 141);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(765, 388);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // imageBox2
            // 
            this.imageBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox2.Location = new System.Drawing.Point(386, 4);
            this.imageBox2.Margin = new System.Windows.Forms.Padding(4);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(375, 380);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox2.TabIndex = 13;
            this.imageBox2.TabStop = false;
            // 
            // imageBox
            // 
            this.imageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox.Location = new System.Drawing.Point(4, 4);
            this.imageBox.Margin = new System.Windows.Forms.Padding(4);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(374, 380);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 12;
            this.imageBox.TabStop = false;
            // 
            // tabFind
            // 
            this.tabFind.Controls.Add(this.tableLayoutPanel3);
            this.tabFind.Location = new System.Drawing.Point(4, 28);
            this.tabFind.Name = "tabFind";
            this.tabFind.Padding = new System.Windows.Forms.Padding(3);
            this.tabFind.Size = new System.Drawing.Size(780, 541);
            this.tabFind.TabIndex = 1;
            this.tabFind.Text = "Find nearby places";
            this.tabFind.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.46362F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblImageError, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.ImageBoxMap, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.TblNearbyLocation, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.0625F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.9375F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 297F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(774, 539);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.41457F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 294F));
            this.tableLayoutPanel4.Controls.Add(this.lblZoomText, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnFindMap, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmdZoom, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmbType, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.13044F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(617, 30);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // lblZoomText
            // 
            this.lblZoomText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblZoomText.AutoSize = true;
            this.lblZoomText.Location = new System.Drawing.Point(275, 5);
            this.lblZoomText.Name = "lblZoomText";
            this.lblZoomText.Size = new System.Drawing.Size(45, 19);
            this.lblZoomText.TabIndex = 2;
            this.lblZoomText.Text = "Zoom";
            // 
            // btnFindMap
            // 
            this.btnFindMap.Location = new System.Drawing.Point(3, 3);
            this.btnFindMap.Name = "btnFindMap";
            this.btnFindMap.Size = new System.Drawing.Size(60, 24);
            this.btnFindMap.TabIndex = 0;
            this.btnFindMap.Text = "FIND";
            this.btnFindMap.UseVisualStyleBackColor = true;
            this.btnFindMap.Click += new System.EventHandler(this.btnFindMap_Click_1);
            // 
            // cmdZoom
            // 
            this.cmdZoom.FormattingEnabled = true;
            this.cmdZoom.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmdZoom.Location = new System.Drawing.Point(326, 3);
            this.cmdZoom.Name = "cmdZoom";
            this.cmdZoom.Size = new System.Drawing.Size(70, 27);
            this.cmdZoom.TabIndex = 3;
            this.cmdZoom.Text = "15";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "restaurant",
            "bar",
            "cafe"});
            this.cmbType.Location = new System.Drawing.Point(78, 3);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(176, 27);
            this.cmbType.TabIndex = 1;
            this.cmbType.Text = "restaurant";
            // 
            // lblImageError
            // 
            this.lblImageError.AutoSize = true;
            this.lblImageError.Location = new System.Drawing.Point(3, 41);
            this.lblImageError.Name = "lblImageError";
            this.lblImageError.Size = new System.Drawing.Size(0, 19);
            this.lblImageError.TabIndex = 7;
            // 
            // TblNearbyLocation
            // 
            this.TblNearbyLocation.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TblNearbyLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TblNearbyLocation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TblNearbyLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TblNearbyLocation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNr,
            this.ColumnName,
            this.ColumnAddress,
            this.ColumnPercentage});
            this.TblNearbyLocation.GridColor = System.Drawing.SystemColors.Control;
            this.TblNearbyLocation.Location = new System.Drawing.Point(3, 67);
            this.TblNearbyLocation.Name = "TblNearbyLocation";
            this.TblNearbyLocation.Size = new System.Drawing.Size(617, 171);
            this.TblNearbyLocation.TabIndex = 5;
            // 
            // ColumnNr
            // 
            this.ColumnNr.HeaderText = "Nr.";
            this.ColumnNr.Name = "ColumnNr";
            this.ColumnNr.Width = 50;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 207;
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.HeaderText = "Address";
            this.ColumnAddress.Name = "ColumnAddress";
            this.ColumnAddress.Width = 220;
            // 
            // ColumnPercentage
            // 
            this.ColumnPercentage.HeaderText = "Percentage";
            this.ColumnPercentage.Name = "ColumnPercentage";
            this.ColumnPercentage.Width = 80;
            // 
            // ImageBoxMap
            // 
            this.ImageBoxMap.Location = new System.Drawing.Point(3, 244);
            this.ImageBoxMap.Name = "ImageBoxMap";
            this.ImageBoxMap.Size = new System.Drawing.Size(768, 285);
            this.ImageBoxMap.TabIndex = 6;
            this.ImageBoxMap.TabStop = false;
            // 
            // tabTOP
            // 
            this.tabTOP.Controls.Add(this.tableLayoutPanel11);
            this.tabTOP.Location = new System.Drawing.Point(4, 28);
            this.tabTOP.Name = "tabTOP";
            this.tabTOP.Size = new System.Drawing.Size(780, 541);
            this.tabTOP.TabIndex = 2;
            this.tabTOP.Text = "TOP";
            this.tabTOP.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Controls.Add(this.lblTopList, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.dataTopList, 0, 1);
            this.tableLayoutPanel11.Location = new System.Drawing.Point(7, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.098592F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.90141F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(770, 284);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // lblTopList
            // 
            this.lblTopList.AutoSize = true;
            this.lblTopList.Location = new System.Drawing.Point(3, 0);
            this.lblTopList.Name = "lblTopList";
            this.lblTopList.Size = new System.Drawing.Size(64, 19);
            this.lblTopList.TabIndex = 7;
            this.lblTopList.Text = "TOP List";
            // 
            // dataTopList
            // 
            this.dataTopList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTopList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Address,
            this.Visible});
            this.dataTopList.Location = new System.Drawing.Point(3, 25);
            this.dataTopList.Name = "dataTopList";
            this.dataTopList.Size = new System.Drawing.Size(348, 198);
            this.dataTopList.TabIndex = 5;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // Visible
            // 
            this.Visible.HeaderText = "Percentage";
            this.Visible.Name = "Visible";
            // 
            // tabMostVisited
            // 
            this.tabMostVisited.Location = new System.Drawing.Point(4, 28);
            this.tabMostVisited.Name = "tabMostVisited";
            this.tabMostVisited.Size = new System.Drawing.Size(780, 541);
            this.tabMostVisited.TabIndex = 3;
            this.tabMostVisited.Text = "Most Visited";
            this.tabMostVisited.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 576);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Social Tap";
            this.tabMain.ResumeLayout(false);
            this.tabUploadImage.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.tabFind.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TblNearbyLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxMap)).EndInit();
            this.tabTOP.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTopList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabUploadImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label lblNameText;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label errorMessage;
        private System.Windows.Forms.Label lblAddressText;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPercentageText;
        private System.Windows.Forms.TabPage tabFind;
        private System.Windows.Forms.TabPage tabTOP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label lblTopList;
        private System.Windows.Forms.DataGridView dataTopList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visible;
        private System.Windows.Forms.TabPage tabMostVisited;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Emgu.CV.UI.ImageBox imageBox2;
        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.Label lblDateText;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblZoomText;
        private System.Windows.Forms.Button btnFindMap;
        private System.Windows.Forms.ComboBox cmdZoom;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.PictureBox ImageBoxMap;
        private System.Windows.Forms.DataGridView TblNearbyLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPercentage;
        private System.Windows.Forms.Label lblImageError;
    }
}

