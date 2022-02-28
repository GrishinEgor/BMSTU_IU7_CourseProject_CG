using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WifiSimulation
{
    public partial class Form1 : Form
    {
        Simulation simulation;
        public Form1()
        {
            InitializeComponent();
            simulation = new Simulation(canvas, labelTimeDrawing, labelMaxPowerLoss);
        }

        private void buttonRotateLeft_Click(object sender, EventArgs e)
        {
            simulation.RotateLeft();
        }

        private void buttonRotateRight_Click(object sender, EventArgs e)
        {
            simulation.RotateRight();
        }

        private void radioButtonLightSourceTop_CheckedChanged(object sender, EventArgs e)
        {
            simulation.LightSourceTop();
        }

        private void radioButtonLightSourceLeft_CheckedChanged(object sender, EventArgs e)
        {
            simulation.LightSourceLeft();
        }

        private void radioButtonLightSourceRight_CheckedChanged(object sender, EventArgs e)
        {
            simulation.LightSourceRight();
        }

        private void checkBoxShadows_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShadows.Checked)
                checkBoxZBufferOptimisation.Checked = false;
            simulation.ChangeShadows();
        }

        private void checkBoxZBufferOptimisation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxZBufferOptimisation.Checked)
                checkBoxShadows.Checked = false;
            simulation.ChangeOptimisation();
        }

        private void checkBoxShowIndicatorSlice_CheckedChanged(object sender, EventArgs e)
        {
            simulation.ChangeShowIndicatorSlice();
        }

        private void buttonMoveIndicatorSliceUp_Click(object sender, EventArgs e)
        {
            simulation.MoveIndicatorSliceUp();
        }

        private void buttonMoveIndicatorSliceDown_Click(object sender, EventArgs e)
        {
            simulation.MoveIndicatorSliceDown();
        }

        private void buttonRedrawScene_Click(object sender, EventArgs e)
        {
            simulation.RedrawScene();
        }

        private void buttonStartMovingIndicatorSlice_Click(object sender, EventArgs e)
        {
            simulation.StartMovingIndicatorSlice();
        }

        private void buttonAddBarrier_Click(object sender, EventArgs e)
        {
            int centX = Convert.ToInt32(textBoxCentX.Text);
            int dx = Convert.ToInt32(textBoxDX.Text);
            int centZ = Convert.ToInt32(textBoxCentZ.Text);
            int dz = Convert.ToInt32(textBoxDZ.Text);
            simulation.AddBarrier(centX, dx, centZ, dz);
        }

        private void buttonRemoveAllBarriers_Click(object sender, EventArgs e)
        {
            simulation.RemoveAllBarriers();
        }

        private void buttonSetAntenna_Click(object sender, EventArgs e)
        {
            int antennaX = Convert.ToInt32(textBoxAntennaX.Text);
            int antennaY = Convert.ToInt32(textBoxAntennaY.Text);
            int antennaZ = Convert.ToInt32(textBoxAntennaZ.Text);
            simulation.SetAntenna(antennaX, antennaY, antennaZ);
        }
    }
}
