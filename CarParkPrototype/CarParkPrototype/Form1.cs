using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkPrototype
{
    public partial class Form1 : Form
    {


        private int parkingSpace;
        private bool[] floor1 = { true, true, true, true, true, true, true, true };
        private bool[] floor2 = { true, true, true, true, true, true, true, true };

        private const int MAX_ITEMS = 10;
        private double[] numArray = new double[MAX_ITEMS];
        private int index = 0;
        private bool advance;

        private string[] floor1Reg = { "0", "0", "0", "0" };
        private string[] floor2Reg = { "0", "0", "0", "0" };
        private int Attempts;
        private string RegNO;
        private bool coinLost;
        private bool leave;


        private int passPark5, passPark6, passPark7, passPark8;
        private bool s5, s6, s7, s8;
        private int passAttemps;

        

        Form form;

        public Form1()
        {
            InitializeComponent();
            leave = false;
            Reset();
            parkingSpace = 0;
            RegNO = "0";
            form = this;
            btnLeave.Visible = false;


        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

            if (advance)
            {
                btnArriveAtCarPark.Visible = true;
                btnEnter.Visible = false;
                btnLeave.Visible = false;
                leave = true;
            }
            else
            {
                if (Start.advancedBooking)
                {

                    btnArriveAtCarPark.Visible = true;
                    btnEnter.Visible = false;
                    btnLeave.Visible = false;
                    leave = true;
                }
                else
                {
                    btnEnter.Visible = false;
                    btnLeave.Visible = false;
                    btnAdvance.Visible = true;
                }
            }



        }

        private void btnArriveAtCarPark_Click(object sender, EventArgs e)
        {
            btnCoinReceived.Visible = true;
            btnArriveAtCarPark.Visible = false;
        }

        private void btnCoinReceived_Click(object sender, EventArgs e)
        {

            btnCoinReceived.Visible = false;
            btnEnterCarPark.Visible = true;
        }

        private void btnEnterCarPark_Click(object sender, EventArgs e)
        {
            txtInstructions.Text = "Select Floor 2 for Secure Parking";
            btnEnterCarPark.Enabled = false;
            grbxParking.Visible = true;

        }

        private void btnFloor1Parking_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (floor1[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            btnFloor1.Enabled = true;
                            btnFloor1.BackColor = Color.Lime;
                            break;
                        case 2:
                            btnFloor2.Enabled = true;
                            btnFloor2.BackColor = Color.Lime;
                            break;
                        case 3:
                            btnFloor3.Enabled = true;
                            btnFloor3.BackColor = Color.Lime;
                            break;
                        case 4:
                            btnFloor4.Enabled = true;
                            btnFloor4.BackColor = Color.Lime;
                            break;
                    }
                }

                grbxFloor1.Visible = true;
                grbxFloor2.Visible = false;
                grbxParking.Enabled = false;

            }


        }

        private void btnFloor2Parking_Click(object sender, EventArgs e)
        {
            txtInstructions.Text = " ";
            for (int i = 0; i < 4; i++)
            {
                if (floor2[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            btnFloor5.Enabled = true;
                            btnFloor5.BackColor = Color.Lime;
                            break;
                        case 2:
                            btnFloor6.Enabled = true;
                            btnFloor6.BackColor = Color.Lime;
                            break;
                        case 3:
                            btnFloor7.Enabled = true;
                            btnFloor7.BackColor = Color.Lime;
                            break;
                        case 4:
                            btnFloor8.Enabled = true;
                            btnFloor8.BackColor = Color.Lime;
                            break;
                    }
                }

                grbxFloor1.Visible = false;
                grbxFloor2.Visible = true;
                grbxParking.Enabled = false;

            }

        }


        private void btnFloor1_Click(object sender, EventArgs e)
        {

            parkingSpace = 1;
            if (leave)
            {
                selectSpaceFloor1();
            }
            else
            {
                selectLeavingFloor1();
            }
            btnFloor1.BackColor = Color.RoyalBlue;

        }
        private void btnFloor2_Click(object sender, EventArgs e)
        {
            parkingSpace = 2;
            if (leave)
            {
                selectSpaceFloor1();
            }
            else
            {
                selectLeavingFloor1();
            }
            btnFloor2.BackColor = Color.RoyalBlue;
        }

        private void btnFloor3_Click(object sender, EventArgs e)
        {
            parkingSpace = 3;
            if (leave)
            {
                selectSpaceFloor1();
            }
            else
            {
                selectLeavingFloor1();
            }
            btnFloor3.BackColor = Color.RoyalBlue;
        }

        private void btnFloor4_Click(object sender, EventArgs e)
        {
            parkingSpace = 4;
            if (leave)
            {
                selectSpaceFloor1();
            }
            else
            {
                selectLeavingFloor1();
            }
            btnFloor4.BackColor = Color.RoyalBlue;
        }

        private void btnFloor5_Click(object sender, EventArgs e)
        {
            s5 = true;
            s6 = false;
            s7 = false;
            s8 = false;

            parkingSpace = 5;
            if (leave)
            {
                selectSpaceFloor2();
            }
            else
            {
                selectLeavingFloor2();
            }
            btnFloor5.BackColor = Color.RoyalBlue;
        }

        private void btnFloor6_Click(object sender, EventArgs e)
        {
            s5 = false;
            s6 = true;
            s7 = false;
            s8 = false;
            parkingSpace = 6;
            if (leave)
            {
                selectSpaceFloor2();
            }
            else
            {
                selectLeavingFloor2();
            }
            btnFloor6.BackColor = Color.RoyalBlue;
        }

        private void btnFloor7_Click(object sender, EventArgs e)
        {
            s5 = false;
            s6 = false;
            s7 = true;
            s8 = false;

            parkingSpace = 7;
            if (leave)
            {
                selectSpaceFloor2();
            }
            else
            {
                selectLeavingFloor2();
            }
            btnFloor7.BackColor = Color.RoyalBlue;
        }

        private void btnFloor8_Click(object sender, EventArgs e)
        {
            s5 = true;
            s6 = false;
            s7 = false;
            s8 = true;

            parkingSpace = 8;
            if (leave)
            {
                selectSpaceFloor2();
            }
            else
            {
                selectLeavingFloor2();
            }
            btnFloor8.BackColor = Color.RoyalBlue;
        }
        private void selectSpaceFloor1()
        {

            for (int i = 0; i < 4; i++)
            {
                if (floor1[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            btnFloor1.Enabled = true;
                            btnFloor1.BackColor = Color.Lime;
                            break;
                        case 2:
                            btnFloor2.Enabled = true;
                            btnFloor2.BackColor = Color.Lime;
                            break;
                        case 3:
                            btnFloor3.Enabled = true;
                            btnFloor3.BackColor = Color.Lime;
                            break;
                        case 4:
                            btnFloor4.Enabled = true;
                            btnFloor4.BackColor = Color.Lime;
                            break;

                    }
                }
            }

        }
        private void selectSpaceFloor2()
        {

            for (int i = 0; i < 4; i++)
            {
                if (floor1[i])
                {
                    switch (i + 5)
                    {
                        case 5:
                            btnFloor5.Enabled = true;
                            btnFloor5.BackColor = Color.Lime;
                            break;
                        case 6:
                            btnFloor6.Enabled = true;
                            btnFloor6.BackColor = Color.Lime;
                            break;
                        case 7:
                            btnFloor7.Enabled = true;
                            btnFloor7.BackColor = Color.Lime;
                            break;
                        case 8:
                            btnFloor8.Enabled = true;
                            btnFloor8.BackColor = Color.Lime;
                            break;

                    }
                }
            }

        }

        private void btnFloor1Confirm_Click(object sender, EventArgs e)
        {
            txtInstructions.Text = "";
            btnFloor1.Enabled = false;
            btnFloor1.BackColor = Color.Red;
            btnFloor2.Enabled = false;
            btnFloor2.BackColor = Color.Red;
            btnFloor3.Enabled = false;
            btnFloor3.BackColor = Color.Red;
            btnFloor4.Enabled = false;
            btnFloor4.BackColor = Color.Red;

            grbxFloor1.Visible = false;
            if (leave)
            {
                if (parkingSpace > 0)
                    btnConfirmSpace.Visible = true;
                grbxParking.Enabled = true;
            }
            else
            {
                if (parkingSpace > 0)
                    btnConfirmLeave.Visible = true;
                grbxLeaving.Enabled = true;
            }
        }
        private void btnFloor2Confirm_Click(object sender, EventArgs e)
        {
            txtbxReg.Text = "";
            txtInstructions.Text = "";
            btnFloor5.Enabled = false;
            btnFloor5.BackColor = Color.Red;
            btnFloor6.Enabled = false;
            btnFloor6.BackColor = Color.Red;
            btnFloor7.Enabled = false;
            btnFloor7.BackColor = Color.Red;
            btnFloor8.Enabled = false;
            btnFloor8.BackColor = Color.Red;

            grbxFloor2.Visible = false;
            if (leave)
            {
                if (parkingSpace > 0)
                {

                    grbxParking.Enabled = true;
                    grbxSecurity.Visible = true;
                }
            }
            else
            {
                if (parkingSpace > 0)
                {
                    grbxLeaving.Enabled = true;
                    grbxSecurity.Visible = true;
                }
            }
        }
        private void btnConfirmSpace_Click(object sender, EventArgs e)
        {
            txtInstructions.Text = "Please Enter Registration";
            btnConfirmSpace.Enabled = false;
            grbxParking.Enabled = false;
            grbxSecurity.Visible = false;
            grbxPin.Visible = false;
            grbxReg.Visible = true;
            txtbxReg.Text = "";
        }
        private void btnPark_Click(object sender, EventArgs e)
        {
            if ((parkingSpace > 0) && (parkingSpace <= 4))
            {
                floor1[parkingSpace - 1] = false;
                floor1Reg[parkingSpace - 1] = RegNO;
            }
            else if ((parkingSpace >= 5) && (parkingSpace <= 8))
            {
                floor2[parkingSpace - 5] = false;
                floor2Reg[parkingSpace - 5] = RegNO;
            }



            btnPark.Visible = false;
            parkingSpace = 0;
            RegNO = "0";
            Reset();
            txtInstructions.Text = "";

        }

        private void btnLeave_Click(object sender, EventArgs e)
        {

            btnLeave.Visible = false;
            leave = false;
            btnEnter.Visible = false;
            btnInsertCoin.Visible = true;
            coinLost = true;
            btnlostCoin.Visible = true;

        }
        private void btnInsertCoin_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Have you Payed in advance ?", "Adance Pay", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                grbxCodeAdvanceConfirm.Visible = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                btnPayForParking.Visible = true;
            }
            btnInsertCoin.Enabled = false;
            btnlostCoin.Visible = false;
        }

        private void btnPayForParking_Click(object sender, EventArgs e)
        {
            btnFindCar.Visible = true;
            btnPayForParking.Enabled = false;
        }

        private void btnFindCar_Click(object sender, EventArgs e)
        {
            btnFindCar.Enabled = false;
            grbxLeaving.Visible = true;
            btnPayForParking.Enabled = false;
        }
        private void selectLeavingFloor1()
        {
            for (int i = 0; i < 4; i++)
            {
                if (!floor1[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            btnFloor1.Enabled = true;
                            btnFloor1.BackColor = Color.Yellow;
                            break;
                        case 2:
                            btnFloor2.Enabled = true;
                            btnFloor2.BackColor = Color.Yellow;
                            break;
                        case 3:
                            btnFloor3.Enabled = true;
                            btnFloor3.BackColor = Color.Yellow;
                            break;
                        case 4:
                            btnFloor4.Enabled = true;
                            btnFloor4.BackColor = Color.Yellow;
                            break;

                    }
                }
            }
        }
        private void selectLeavingFloor2()
        {
            for (int i = 0; i < 4; i++)
            {
                if (!floor2[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            btnFloor5.Enabled = true;
                            btnFloor5.BackColor = Color.Yellow;
                            break;
                        case 2:
                            btnFloor6.Enabled = true;
                            btnFloor6.BackColor = Color.Yellow;
                            break;
                        case 3:
                            btnFloor7.Enabled = true;
                            btnFloor7.BackColor = Color.Yellow;
                            break;
                        case 4:
                            btnFloor8.Enabled = true;
                            btnFloor8.BackColor = Color.Yellow;
                            break;

                    }
                }
            }
        }
        private void btnFloor1Leaving_Click(object sender, EventArgs e)
        {
            selectLeavingFloor1();
            grbxFloor1.Visible = true;
            grbxLeaving.Enabled = false;
        }
        private void btnFloor2Leaving_Click(object sender, EventArgs e)
        {
            selectLeavingFloor2();
            grbxFloor2.Visible = true;
            grbxLeaving.Enabled = false;
        }

        private void btnConfirmLeave_Click(object sender, EventArgs e)
        {

            if (coinLost)
            {
                btnLeaveCarPark.Visible = true;
            }
            else
            {
                txtbxReg.Text = "";
                grbxReg.Visible = true;
            }
            btnConfirmLeave.Enabled = false;

        }

        private void btnLeaveCarPark_Click(object sender, EventArgs e)
        {
            btnLeaveCarPark.Visible = false;
            if ((parkingSpace > 0) && (parkingSpace <= 4))
            {
                floor1[parkingSpace - 1] = true;

            }
            else if ((parkingSpace >= 5) && (parkingSpace <= 8))
            {
                floor2[parkingSpace - 5] = true;

            }
            txtInstructions.Text = "";
            parkingSpace = 0;
            Reset();

        }


        private void Reset()
        {

            btnEnter.Visible = true;
            btnLeave.Visible = true;

            btnArriveAtCarPark.Enabled = true;
            btnArriveAtCarPark.Visible = false;
            btnCoinReceived.Enabled = true;
            btnCoinReceived.Visible = false;
            btnEnterCarPark.Enabled = true;
            btnEnterCarPark.Visible = false;
            btnConfirmSpace.Enabled = true;
            btnConfirmSpace.Visible = false;
            grbxParking.Visible = false;
            grbxParking.Enabled = true;
            grbxLeaving.Visible = false;
            grbxLeaving.Enabled = true;
            btnPark.Visible = false;
            btnPark.Enabled = true;
            btnPayForParking.Enabled = true;
            btnPayForParking.Visible = false;
            btnFindCar.Enabled = true;
            btnFindCar.Visible = false;
            btnConfirmLeave.Enabled = true;
            btnConfirmLeave.Visible = false;
            btnInsertCoin.Enabled = true;
            btnInsertCoin.Visible = false;
            btnLeaveCarPark.Enabled = true;
            btnLeaveCarPark.Visible = false;
            grbxReg.Enabled = true;
            grbxReg.Visible = false;
            grbxCodeAdvanceConfirm.Visible = false;
            grbxSecurity.Enabled = true;
            grbxSecurity.Visible = false;
            grbxPin.Visible = false;
            grbxPin.Enabled = true;
            btnlostCoin.Enabled = true;
            btnlostCoin.Visible = false;




        }

        private void btnPasscode_Click(object sender, EventArgs e)
        {
            grbxPin.Visible = true;
            if (leave)
            {
                MessageBox.Show("Enter A Pin Number To Secure Your Car", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Enter A Pin Number To release Your Car", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            grbxSecurity.Enabled = false;

        }

        private void btbRegConfirm_Click(object sender, EventArgs e)
        {

            if (leave)
            {
                RegNO = txtbxReg.Text;
                grbxReg.Enabled = false;
                btnPark.Visible = true;
            }
            else if (Attempts < 2)
            {
                if ((parkingSpace > 0) && (parkingSpace <= 4))
                {
                    RegNO = txtbxReg.Text;
                    if (RegNO == floor1Reg[parkingSpace - 1])
                    {
                        grbxReg.Enabled = false;
                        txtInstructions.Text = "Registration Accepted ";
                        txtbxReg.Text = "";
                        btnLeaveCarPark.Visible = true;
                    }
                    else
                    {
                        txtInstructions.Text = "Registration Cant be found " + (Attempts + 1);
                        txtbxReg.Text = "";
                    }
                }
                else if ((parkingSpace > 5) && (parkingSpace <= 8))
                {
                    RegNO = txtbxReg.Text;
                    if (RegNO == floor2Reg[parkingSpace - 5])
                    {
                        grbxReg.Enabled = false;
                        txtInstructions.Text = "Registration Accepted ";
                        txtbxReg.Text = "";
                        btnLeaveCarPark.Visible = true;

                    }
                    else
                    {
                        txtInstructions.Text = "Registration Cant be found " + (Attempts + 1);
                        txtbxReg.Text = "";
                    }
                }
                ++Attempts;

            }
            else
            {
                txtbxReg.Text = "";
                Attempts = 0;
                this.Hide();
                if ((parkingSpace > 0) && (parkingSpace <= 4))
                {
                    floor1[parkingSpace - 1] = true;
                    floor1Reg[parkingSpace - 1] = "0";
                }
                else if ((parkingSpace >= 5) && (parkingSpace <= 8))
                {
                    floor2[parkingSpace - 5] = true;
                    floor2Reg[parkingSpace - 5] = "0";
                }
            }
        }




        private void btnAdvance_Click(object sender, EventArgs e)
        {
            grbxCodeAdvance.Visible = true;

        }

        private void btnCodeConfirmAdvance_Click(object sender, EventArgs e)
        {
            if (this.index < 10)
            {
                numArray[this.index] = int.Parse(txtbxCodeAdvance.Text);
                this.index++;

            }
            txtbxReg.Text = "";
            advance = true;
            btnEnter.Visible = true;
            grbxCodeAdvance.Visible = false;
            btnAdvance.Visible = false;
        }


        private void btnCodeAdvanceConfirm_Click_1(object sender, EventArgs e)
        {

            for (int i = 0; i < 10; i++)
            {
                if (numArray[i] == int.Parse(txtbxCodeAdvanceConfirm.Text))
                {
                    btnFindCar.Visible = true;
                    btnPayForParking.Visible = false;
                }
                else
                {
                    btnPayForParking.Visible = true;
                }
            }

        }





        private void btnPin1_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "1";
        }

        private void btnPin2_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "2";
        }

        private void btnPin3_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "3";
        }

        private void btnPin4_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "4";
        }

        private void btnPin5_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "5";
        }

        private void btnPin6_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "6";
        }

        private void btnPin7_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "7";
        }

        private void grbxPin_Enter(object sender, EventArgs e)
        {

        }

        private void btnPin8_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "8";
        }

        private void btnPin9_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "9";
        }

        private void btnPin0_Click(object sender, EventArgs e)
        {
            if (txtbxPin.Text == "Please Enter Your Pin:")
            {
                txtbxPin.Text = "";
            }
            txtbxPin.Text += "0";
        }
        private void btnPinBack_Click(object sender, EventArgs e)
        {
            string num = txtbxPin.Text.ToString();
            if (num.Length >= 1)
            {
                num = num.Remove(num.Length - 1, 1);
                txtbxPin.Text = num;
            }
        }
        private void btnPinEnter_Click_1(object sender, EventArgs e)
        {
            if (s5 && passAttemps <2)
            {

                if (leave)
                {
                    if (txtbxPin.Text == "")
                    {
                        MessageBox.Show("Please enter a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        passPark5 = Convert.ToInt32(txtbxPin.Text);
                        txtbxPin.Text = "";
                        btnConfirmSpace.Visible = true;
                        s5 = false;
                    }

                }
                else
                {

                    if (passPark5 == Convert.ToInt32(txtbxPin.Text))
                    {
                        if (txtbxPin.Text == "")
                        {
                            MessageBox.Show("Please enter a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Pin Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnFindCar.Visible = false;
                            btnConfirmLeave.Visible = true;
                            txtbxPin.Text = "";
                            passPark5 = 0;
                            s5 = false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Incorrect Pin, Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtbxPin.Text = "";
                        passAttemps++;
                    }
                }
            }

            if (s6)
            {
                if (leave)
                {

                    passPark6 = Convert.ToInt32(txtbxPin.Text);
                    txtbxPin.Text = "";
                    btnConfirmSpace.Visible = true;
                    s6 = false;

                }
                else
                {

                    if (passPark6 == Convert.ToInt32(txtbxPin.Text))
                    {
                        MessageBox.Show("Pin Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnFindCar.Visible = false;
                        btnConfirmLeave.Visible = true;
                        txtbxPin.Text = "";
                        passPark6 = 0;
                        s6 = false;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Pin, Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtbxPin.Text = "";
                    }
                }
            }

            if (s7)
            {
                if (leave)
                {
                    passPark7 = Convert.ToInt32(txtbxPin.Text);
                    txtbxPin.Text = "";
                    btnCoinReceived.Visible = true;
                    s7 = false;
                }
                else
                {


                    if (passPark7 == Convert.ToInt32(txtbxPin.Text))
                    {
                        MessageBox.Show("Pin Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnFindCar.Visible = false;
                        btnConfirmLeave.Visible = true;
                        txtbxPin.Text = "";
                        passPark7 = 0;
                        s7 = false;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Pin, Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtbxPin.Text = "";
                    }
                }
            }

            if (s8)
            {
                if (leave)
                {

                    passPark8 = Convert.ToInt32(txtbxPin.Text);
                    txtbxPin.Text = "";
                    btnConfirmSpace.Visible = true;
                    s8 = false;
                }
                else
                {

                    if (passPark8 == Convert.ToInt32(txtbxPin.Text))
                    {
                        MessageBox.Show("Pin Correct", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnFindCar.Visible = false;
                        btnConfirmLeave.Visible = true;
                        txtbxPin.Text = "";
                        passPark8 = 0;
                        s8 = false;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Pin, Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtbxPin.Text = "";
                    }
                }
            }
            grbxPin.Enabled = false;


        }


        private void btnlostCoin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To Leave the Car you have enter your Registration After Confirming the Space", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult dialogResult = MessageBox.Show("Have you Payed in advance ?", "Adance Pay", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                grbxCodeAdvanceConfirm.Visible = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                btnPayForParking.Visible = true;
            }
            coinLost = false;
            btnlostCoin.Enabled = false;
            btnInsertCoin.Visible = false;
        }


    }
}

