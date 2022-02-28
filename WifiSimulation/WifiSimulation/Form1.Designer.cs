namespace WifiSimulation
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxChangeMap = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonSetAntenna = new System.Windows.Forms.Button();
            this.buttonRemoveAllBarriers = new System.Windows.Forms.Button();
            this.textBoxAntennaZ = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxAntennaY = new System.Windows.Forms.TextBox();
            this.textBoxAntennaX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxDZ = new System.Windows.Forms.TextBox();
            this.textBoxDX = new System.Windows.Forms.TextBox();
            this.textBoxCentZ = new System.Windows.Forms.TextBox();
            this.textBoxCentX = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddBarrier = new System.Windows.Forms.Button();
            this.checkBoxShowIndicatorSlice = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonMoveIndicatorSliceUp = new System.Windows.Forms.Button();
            this.buttonMoveIndicatorSliceDown = new System.Windows.Forms.Button();
            this.buttonRedrawScene = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTimeRedraw = new System.Windows.Forms.Label();
            this.checkBoxZBufferOptimisation = new System.Windows.Forms.CheckBox();
            this.groupBoxScene = new System.Windows.Forms.GroupBox();
            this.labelMaxPowerLoss = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTimeDrawing = new System.Windows.Forms.Label();
            this.checkBoxShadows = new System.Windows.Forms.CheckBox();
            this.buttonStartMovingIndicatorSlice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRotateLeft = new System.Windows.Forms.Button();
            this.buttonRotateRight = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonLightSourceTop = new System.Windows.Forms.RadioButton();
            this.radioButtonLightSourceRight = new System.Windows.Forms.RadioButton();
            this.radioButtonLightSourceLeft = new System.Windows.Forms.RadioButton();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.groupBoxChangeMap.SuspendLayout();
            this.groupBoxScene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxChangeMap
            // 
            this.groupBoxChangeMap.Controls.Add(this.label14);
            this.groupBoxChangeMap.Controls.Add(this.buttonSetAntenna);
            this.groupBoxChangeMap.Controls.Add(this.buttonRemoveAllBarriers);
            this.groupBoxChangeMap.Controls.Add(this.textBoxAntennaZ);
            this.groupBoxChangeMap.Controls.Add(this.label12);
            this.groupBoxChangeMap.Controls.Add(this.textBoxAntennaY);
            this.groupBoxChangeMap.Controls.Add(this.textBoxAntennaX);
            this.groupBoxChangeMap.Controls.Add(this.label4);
            this.groupBoxChangeMap.Controls.Add(this.label10);
            this.groupBoxChangeMap.Controls.Add(this.textBoxDZ);
            this.groupBoxChangeMap.Controls.Add(this.textBoxDX);
            this.groupBoxChangeMap.Controls.Add(this.textBoxCentZ);
            this.groupBoxChangeMap.Controls.Add(this.textBoxCentX);
            this.groupBoxChangeMap.Controls.Add(this.label11);
            this.groupBoxChangeMap.Controls.Add(this.label9);
            this.groupBoxChangeMap.Controls.Add(this.label8);
            this.groupBoxChangeMap.Controls.Add(this.label2);
            this.groupBoxChangeMap.Controls.Add(this.label6);
            this.groupBoxChangeMap.Controls.Add(this.buttonAddBarrier);
            this.groupBoxChangeMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxChangeMap.Location = new System.Drawing.Point(1363, 586);
            this.groupBoxChangeMap.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxChangeMap.Name = "groupBoxChangeMap";
            this.groupBoxChangeMap.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxChangeMap.Size = new System.Drawing.Size(381, 304);
            this.groupBoxChangeMap.TabIndex = 22;
            this.groupBoxChangeMap.TabStop = false;
            this.groupBoxChangeMap.Text = "Изменение карты";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(249, 20);
            this.label14.TabIndex = 34;
            this.label14.Text = "Размеры карты: 600x200X600";
            // 
            // buttonSetAntenna
            // 
            this.buttonSetAntenna.Location = new System.Drawing.Point(13, 252);
            this.buttonSetAntenna.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetAntenna.Name = "buttonSetAntenna";
            this.buttonSetAntenna.Size = new System.Drawing.Size(262, 28);
            this.buttonSetAntenna.TabIndex = 33;
            this.buttonSetAntenna.Text = "Установить антенну";
            this.buttonSetAntenna.UseVisualStyleBackColor = true;
            this.buttonSetAntenna.Click += new System.EventHandler(this.buttonSetAntenna_Click);
            // 
            // buttonRemoveAllBarriers
            // 
            this.buttonRemoveAllBarriers.Location = new System.Drawing.Point(13, 161);
            this.buttonRemoveAllBarriers.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemoveAllBarriers.Name = "buttonRemoveAllBarriers";
            this.buttonRemoveAllBarriers.Size = new System.Drawing.Size(261, 28);
            this.buttonRemoveAllBarriers.TabIndex = 32;
            this.buttonRemoveAllBarriers.Text = "Удалить все препятствия";
            this.buttonRemoveAllBarriers.UseVisualStyleBackColor = true;
            this.buttonRemoveAllBarriers.Click += new System.EventHandler(this.buttonRemoveAllBarriers_Click);
            // 
            // textBoxAntennaZ
            // 
            this.textBoxAntennaZ.Location = new System.Drawing.Point(225, 218);
            this.textBoxAntennaZ.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAntennaZ.Name = "textBoxAntennaZ";
            this.textBoxAntennaZ.Size = new System.Drawing.Size(49, 26);
            this.textBoxAntennaZ.TabIndex = 31;
            this.textBoxAntennaZ.Text = "580";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(195, 218);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "z:";
            // 
            // textBoxAntennaY
            // 
            this.textBoxAntennaY.Location = new System.Drawing.Point(138, 218);
            this.textBoxAntennaY.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAntennaY.Name = "textBoxAntennaY";
            this.textBoxAntennaY.Size = new System.Drawing.Size(49, 26);
            this.textBoxAntennaY.TabIndex = 29;
            this.textBoxAntennaY.Text = "180";
            // 
            // textBoxAntennaX
            // 
            this.textBoxAntennaX.Location = new System.Drawing.Point(51, 218);
            this.textBoxAntennaX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAntennaX.Name = "textBoxAntennaX";
            this.textBoxAntennaX.Size = new System.Drawing.Size(49, 26);
            this.textBoxAntennaX.TabIndex = 28;
            this.textBoxAntennaX.Text = "580";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 218);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "y:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 218);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "х:";
            // 
            // textBoxDZ
            // 
            this.textBoxDZ.Location = new System.Drawing.Point(225, 91);
            this.textBoxDZ.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDZ.Name = "textBoxDZ";
            this.textBoxDZ.Size = new System.Drawing.Size(49, 26);
            this.textBoxDZ.TabIndex = 25;
            this.textBoxDZ.Text = "100";
            // 
            // textBoxDX
            // 
            this.textBoxDX.Location = new System.Drawing.Point(225, 55);
            this.textBoxDX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDX.Name = "textBoxDX";
            this.textBoxDX.Size = new System.Drawing.Size(49, 26);
            this.textBoxDX.TabIndex = 24;
            this.textBoxDX.Text = "30";
            // 
            // textBoxCentZ
            // 
            this.textBoxCentZ.Location = new System.Drawing.Point(112, 91);
            this.textBoxCentZ.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCentZ.Name = "textBoxCentZ";
            this.textBoxCentZ.Size = new System.Drawing.Size(49, 26);
            this.textBoxCentZ.TabIndex = 23;
            this.textBoxCentZ.Text = "200";
            // 
            // textBoxCentX
            // 
            this.textBoxCentX.Location = new System.Drawing.Point(112, 55);
            this.textBoxCentX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCentX.Name = "textBoxCentX";
            this.textBoxCentX.Size = new System.Drawing.Size(49, 26);
            this.textBoxCentX.TabIndex = 21;
            this.textBoxCentX.Text = "200";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 91);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Центр z:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(186, 91);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "dz:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 55);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "dx:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Центр х:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 15;
            // 
            // buttonAddBarrier
            // 
            this.buttonAddBarrier.Location = new System.Drawing.Point(13, 125);
            this.buttonAddBarrier.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddBarrier.Name = "buttonAddBarrier";
            this.buttonAddBarrier.Size = new System.Drawing.Size(261, 28);
            this.buttonAddBarrier.TabIndex = 0;
            this.buttonAddBarrier.Text = "Добавить препятствие";
            this.buttonAddBarrier.UseVisualStyleBackColor = true;
            this.buttonAddBarrier.Click += new System.EventHandler(this.buttonAddBarrier_Click);
            // 
            // checkBoxShowIndicatorSlice
            // 
            this.checkBoxShowIndicatorSlice.AutoSize = true;
            this.checkBoxShowIndicatorSlice.Location = new System.Drawing.Point(13, 306);
            this.checkBoxShowIndicatorSlice.Name = "checkBoxShowIndicatorSlice";
            this.checkBoxShowIndicatorSlice.Size = new System.Drawing.Size(305, 24);
            this.checkBoxShowIndicatorSlice.TabIndex = 14;
            this.checkBoxShowIndicatorSlice.Text = "Отобразить индикаторный слой";
            this.checkBoxShowIndicatorSlice.UseVisualStyleBackColor = true;
            this.checkBoxShowIndicatorSlice.CheckedChanged += new System.EventHandler(this.checkBoxShowIndicatorSlice_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(299, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Передвигать индикаторный слой:";
            // 
            // buttonMoveIndicatorSliceUp
            // 
            this.buttonMoveIndicatorSliceUp.Location = new System.Drawing.Point(13, 361);
            this.buttonMoveIndicatorSliceUp.Name = "buttonMoveIndicatorSliceUp";
            this.buttonMoveIndicatorSliceUp.Size = new System.Drawing.Size(120, 30);
            this.buttonMoveIndicatorSliceUp.TabIndex = 16;
            this.buttonMoveIndicatorSliceUp.Text = "Вверх";
            this.buttonMoveIndicatorSliceUp.UseVisualStyleBackColor = true;
            this.buttonMoveIndicatorSliceUp.Click += new System.EventHandler(this.buttonMoveIndicatorSliceUp_Click);
            // 
            // buttonMoveIndicatorSliceDown
            // 
            this.buttonMoveIndicatorSliceDown.Location = new System.Drawing.Point(163, 361);
            this.buttonMoveIndicatorSliceDown.Name = "buttonMoveIndicatorSliceDown";
            this.buttonMoveIndicatorSliceDown.Size = new System.Drawing.Size(120, 30);
            this.buttonMoveIndicatorSliceDown.TabIndex = 17;
            this.buttonMoveIndicatorSliceDown.Text = "Вниз";
            this.buttonMoveIndicatorSliceDown.UseVisualStyleBackColor = true;
            this.buttonMoveIndicatorSliceDown.Click += new System.EventHandler(this.buttonMoveIndicatorSliceDown_Click);
            // 
            // buttonRedrawScene
            // 
            this.buttonRedrawScene.Location = new System.Drawing.Point(13, 479);
            this.buttonRedrawScene.Name = "buttonRedrawScene";
            this.buttonRedrawScene.Size = new System.Drawing.Size(200, 35);
            this.buttonRedrawScene.TabIndex = 18;
            this.buttonRedrawScene.Text = "Перерисовать сцену";
            this.buttonRedrawScene.UseVisualStyleBackColor = true;
            this.buttonRedrawScene.Click += new System.EventHandler(this.buttonRedrawScene_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 517);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Время отрисовки:";
            // 
            // labelTimeRedraw
            // 
            this.labelTimeRedraw.AutoSize = true;
            this.labelTimeRedraw.Location = new System.Drawing.Point(173, 517);
            this.labelTimeRedraw.Name = "labelTimeRedraw";
            this.labelTimeRedraw.Size = new System.Drawing.Size(0, 20);
            this.labelTimeRedraw.TabIndex = 20;
            // 
            // checkBoxZBufferOptimisation
            // 
            this.checkBoxZBufferOptimisation.AutoSize = true;
            this.checkBoxZBufferOptimisation.Location = new System.Drawing.Point(13, 276);
            this.checkBoxZBufferOptimisation.Name = "checkBoxZBufferOptimisation";
            this.checkBoxZBufferOptimisation.Size = new System.Drawing.Size(229, 24);
            this.checkBoxZBufferOptimisation.TabIndex = 21;
            this.checkBoxZBufferOptimisation.Text = "Оптимизация Z-буфера";
            this.checkBoxZBufferOptimisation.UseVisualStyleBackColor = true;
            this.checkBoxZBufferOptimisation.CheckedChanged += new System.EventHandler(this.checkBoxZBufferOptimisation_CheckedChanged);
            // 
            // groupBoxScene
            // 
            this.groupBoxScene.Controls.Add(this.labelMaxPowerLoss);
            this.groupBoxScene.Controls.Add(this.label13);
            this.groupBoxScene.Controls.Add(this.pictureBox1);
            this.groupBoxScene.Controls.Add(this.labelTimeDrawing);
            this.groupBoxScene.Controls.Add(this.checkBoxShadows);
            this.groupBoxScene.Controls.Add(this.buttonStartMovingIndicatorSlice);
            this.groupBoxScene.Controls.Add(this.label1);
            this.groupBoxScene.Controls.Add(this.checkBoxZBufferOptimisation);
            this.groupBoxScene.Controls.Add(this.labelTimeRedraw);
            this.groupBoxScene.Controls.Add(this.buttonRotateLeft);
            this.groupBoxScene.Controls.Add(this.label7);
            this.groupBoxScene.Controls.Add(this.buttonRotateRight);
            this.groupBoxScene.Controls.Add(this.buttonRedrawScene);
            this.groupBoxScene.Controls.Add(this.label3);
            this.groupBoxScene.Controls.Add(this.buttonMoveIndicatorSliceDown);
            this.groupBoxScene.Controls.Add(this.panel1);
            this.groupBoxScene.Controls.Add(this.buttonMoveIndicatorSliceUp);
            this.groupBoxScene.Controls.Add(this.checkBoxShowIndicatorSlice);
            this.groupBoxScene.Controls.Add(this.label5);
            this.groupBoxScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxScene.Location = new System.Drawing.Point(1363, 20);
            this.groupBoxScene.Name = "groupBoxScene";
            this.groupBoxScene.Size = new System.Drawing.Size(381, 559);
            this.groupBoxScene.TabIndex = 4;
            this.groupBoxScene.TabStop = false;
            this.groupBoxScene.Text = "Сцена";
            // 
            // labelMaxPowerLoss
            // 
            this.labelMaxPowerLoss.AutoSize = true;
            this.labelMaxPowerLoss.Location = new System.Drawing.Point(241, 438);
            this.labelMaxPowerLoss.Name = "labelMaxPowerLoss";
            this.labelMaxPowerLoss.Size = new System.Drawing.Size(56, 20);
            this.labelMaxPowerLoss.TabIndex = 27;
            this.labelMaxPowerLoss.Text = "80 дБ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 438);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 20);
            this.label13.TabIndex = 26;
            this.label13.Text = "0 дБ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WifiSimulation.Properties.Resources.DarkblueToRed;
            this.pictureBox1.Location = new System.Drawing.Point(65, 438);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 20);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // labelTimeDrawing
            // 
            this.labelTimeDrawing.AutoSize = true;
            this.labelTimeDrawing.Location = new System.Drawing.Point(173, 517);
            this.labelTimeDrawing.Name = "labelTimeDrawing";
            this.labelTimeDrawing.Size = new System.Drawing.Size(0, 20);
            this.labelTimeDrawing.TabIndex = 24;
            // 
            // checkBoxShadows
            // 
            this.checkBoxShadows.AutoSize = true;
            this.checkBoxShadows.Location = new System.Drawing.Point(13, 246);
            this.checkBoxShadows.Name = "checkBoxShadows";
            this.checkBoxShadows.Size = new System.Drawing.Size(71, 24);
            this.checkBoxShadows.TabIndex = 23;
            this.checkBoxShadows.Text = "Тени";
            this.checkBoxShadows.UseVisualStyleBackColor = true;
            this.checkBoxShadows.Visible = false;
            this.checkBoxShadows.CheckedChanged += new System.EventHandler(this.checkBoxShadows_CheckedChanged);
            // 
            // buttonStartMovingIndicatorSlice
            // 
            this.buttonStartMovingIndicatorSlice.Location = new System.Drawing.Point(13, 397);
            this.buttonStartMovingIndicatorSlice.Name = "buttonStartMovingIndicatorSlice";
            this.buttonStartMovingIndicatorSlice.Size = new System.Drawing.Size(270, 35);
            this.buttonStartMovingIndicatorSlice.TabIndex = 22;
            this.buttonStartMovingIndicatorSlice.Text = "Проход индикаторного слоя";
            this.buttonStartMovingIndicatorSlice.UseVisualStyleBackColor = true;
            this.buttonStartMovingIndicatorSlice.Click += new System.EventHandler(this.buttonStartMovingIndicatorSlice_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вращение:";
            // 
            // buttonRotateLeft
            // 
            this.buttonRotateLeft.Location = new System.Drawing.Point(13, 64);
            this.buttonRotateLeft.Name = "buttonRotateLeft";
            this.buttonRotateLeft.Size = new System.Drawing.Size(90, 30);
            this.buttonRotateLeft.TabIndex = 1;
            this.buttonRotateLeft.Text = "Влево";
            this.buttonRotateLeft.UseVisualStyleBackColor = true;
            this.buttonRotateLeft.Click += new System.EventHandler(this.buttonRotateLeft_Click);
            // 
            // buttonRotateRight
            // 
            this.buttonRotateRight.Location = new System.Drawing.Point(109, 64);
            this.buttonRotateRight.Name = "buttonRotateRight";
            this.buttonRotateRight.Size = new System.Drawing.Size(90, 30);
            this.buttonRotateRight.TabIndex = 2;
            this.buttonRotateRight.Text = "Вправо";
            this.buttonRotateRight.UseVisualStyleBackColor = true;
            this.buttonRotateRight.Click += new System.EventHandler(this.buttonRotateRight_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Источник света:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonLightSourceTop);
            this.panel1.Controls.Add(this.radioButtonLightSourceRight);
            this.panel1.Controls.Add(this.radioButtonLightSourceLeft);
            this.panel1.Location = new System.Drawing.Point(10, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 103);
            this.panel1.TabIndex = 12;
            // 
            // radioButtonLightSourceTop
            // 
            this.radioButtonLightSourceTop.AutoSize = true;
            this.radioButtonLightSourceTop.Checked = true;
            this.radioButtonLightSourceTop.Location = new System.Drawing.Point(3, 3);
            this.radioButtonLightSourceTop.Name = "radioButtonLightSourceTop";
            this.radioButtonLightSourceTop.Size = new System.Drawing.Size(88, 24);
            this.radioButtonLightSourceTop.TabIndex = 4;
            this.radioButtonLightSourceTop.TabStop = true;
            this.radioButtonLightSourceTop.Text = "Сверху";
            this.radioButtonLightSourceTop.UseVisualStyleBackColor = true;
            this.radioButtonLightSourceTop.CheckedChanged += new System.EventHandler(this.radioButtonLightSourceTop_CheckedChanged);
            // 
            // radioButtonLightSourceRight
            // 
            this.radioButtonLightSourceRight.AutoSize = true;
            this.radioButtonLightSourceRight.Location = new System.Drawing.Point(3, 63);
            this.radioButtonLightSourceRight.Name = "radioButtonLightSourceRight";
            this.radioButtonLightSourceRight.Size = new System.Drawing.Size(92, 24);
            this.radioButtonLightSourceRight.TabIndex = 5;
            this.radioButtonLightSourceRight.Text = "Справа";
            this.radioButtonLightSourceRight.UseVisualStyleBackColor = true;
            this.radioButtonLightSourceRight.CheckedChanged += new System.EventHandler(this.radioButtonLightSourceRight_CheckedChanged);
            // 
            // radioButtonLightSourceLeft
            // 
            this.radioButtonLightSourceLeft.AutoSize = true;
            this.radioButtonLightSourceLeft.Location = new System.Drawing.Point(3, 33);
            this.radioButtonLightSourceLeft.Name = "radioButtonLightSourceLeft";
            this.radioButtonLightSourceLeft.Size = new System.Drawing.Size(82, 24);
            this.radioButtonLightSourceLeft.TabIndex = 6;
            this.radioButtonLightSourceLeft.Text = "Слева";
            this.radioButtonLightSourceLeft.UseVisualStyleBackColor = true;
            this.radioButtonLightSourceLeft.CheckedChanged += new System.EventHandler(this.radioButtonLightSourceLeft_CheckedChanged);
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(20, 20);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1300, 800);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 903);
            this.Controls.Add(this.groupBoxScene);
            this.Controls.Add(this.groupBoxChangeMap);
            this.Controls.Add(this.canvas);
            this.MaximumSize = new System.Drawing.Size(1800, 950);
            this.MinimumSize = new System.Drawing.Size(1800, 950);
            this.Name = "Form1";
            this.Text = "Симуляция распространения Wi-Fi";
            this.groupBoxChangeMap.ResumeLayout(false);
            this.groupBoxChangeMap.PerformLayout();
            this.groupBoxScene.ResumeLayout(false);
            this.groupBoxScene.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.GroupBox groupBoxChangeMap;
        private System.Windows.Forms.TextBox textBoxDZ;
        private System.Windows.Forms.TextBox textBoxDX;
        private System.Windows.Forms.TextBox textBoxCentZ;
        private System.Windows.Forms.TextBox textBoxCentX;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddBarrier;
        private System.Windows.Forms.TextBox textBoxAntennaZ;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxAntennaY;
        private System.Windows.Forms.TextBox textBoxAntennaX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonRemoveAllBarriers;
        private System.Windows.Forms.Button buttonSetAntenna;
        private System.Windows.Forms.CheckBox checkBoxShowIndicatorSlice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonMoveIndicatorSliceUp;
        private System.Windows.Forms.Button buttonMoveIndicatorSliceDown;
        private System.Windows.Forms.Button buttonRedrawScene;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTimeRedraw;
        private System.Windows.Forms.CheckBox checkBoxZBufferOptimisation;
        private System.Windows.Forms.GroupBox groupBoxScene;
        private System.Windows.Forms.Button buttonStartMovingIndicatorSlice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRotateLeft;
        private System.Windows.Forms.Button buttonRotateRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonLightSourceTop;
        private System.Windows.Forms.RadioButton radioButtonLightSourceRight;
        private System.Windows.Forms.RadioButton radioButtonLightSourceLeft;
        private System.Windows.Forms.CheckBox checkBoxShadows;
        private System.Windows.Forms.Label labelTimeDrawing;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelMaxPowerLoss;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}

