using FA21_Final_Project.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public partial class frmNewUser : Form
    {
        bool bolIsClicked, bolIsHelp = false;
        string[] arrSavedAnswers = new string[3];
        bool[] arrIsBeingChanged = new bool[3];
        bool bolIsManagerCreation = false;
        List<string> lstMasterList = new List<string>();
        List<string> lstPersonInfo = new List<string>();
        clsManager.Person person = new clsManager.Person();
        string strManagerState = "";

        public frmNewUser()
        {
            InitializeComponent();
            //Create security question lists
            CreateSecurityQuestionLists();
            Label[] arrMandatory = new Label[]{
                lblMandatoryField1,lblMandatoryField2,lblMandatoryField3,lblMandatoryField4,lblMandatoryField5,
                lblMandatoryField6, lblMandatoryField7, lblMandatoryField8, lblMandatoryField9, 
                lblMandatoryField11, lblMandatoryField12, lblMandatoryField15,
                lblMandatoryField16, lblMandatoryField17
            };
            //Set tooltips for Mandatory Fields
            foreach (Label lbl in arrMandatory)
            {
                tipToolTip.SetToolTip(lbl, "Mandatory Field");
            }
        }
        public frmNewUser(bool bolIsManagerCreation, string strManagerState, clsManager.Person person)
        {
            InitializeComponent();
            CreateSecurityQuestionLists();
            this.strManagerState = strManagerState;
            Label[] arrMandatory = new Label[]{
                lblMandatoryField1,lblMandatoryField2,lblMandatoryField3,lblMandatoryField4,lblMandatoryField5,
                lblMandatoryField6, lblMandatoryField7, lblMandatoryField8, lblMandatoryField9,
                lblMandatoryField11, lblMandatoryField12, lblMandatoryField15,
                lblMandatoryField16, lblMandatoryField17
            };
            foreach (Label lbl in arrMandatory)
            {
                tipToolTip.SetToolTip(lbl, "Mandatory Field");
            }
            //Find if the account creation is a manager and/or in edit state and change the form depending on the state
            this.bolIsManagerCreation = bolIsManagerCreation;
            clsSQL.newManager = new clsSQL.NewManager(person.bolIsNewManager, person.strSalary);
            try
            {
                SetControls(person);
                if (bolIsManagerCreation && strManagerState == "Edit")
                {
                    btnCreate.Text = "Edit User";
                    this.Text = "Edit User";
                    arrIsBeingChanged[0] = true;
                    arrIsBeingChanged[1] = true;
                    arrIsBeingChanged[2] = true;
                    UpdateChallengeQuestion1();
                    tbxLogonName.Enabled = false;
                    this.person = person;
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Out of range exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close form and return to login
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                int intAmount = mskPhonePrimary.Text.Length;
                int intAmount2 = mskZip.Text.Length;
                bolIsHelp = false;
                //Declare TextBox & ComboBox Arrays
                //Pass Control Arrays into New User Creation Function
                TextBox[] arrTbxes = new TextBox[]
                {
                tbxFirstName,tbxMiddleName,tbxLastName,tbxAddress1,tbxAddress2,tbxAddress3,tbxCity,tbxEmail,
                tbxLogonName,tbxPassword,tbxFirstChallengeAnswer,
                tbxSecondChallengeAnswer,tbxThirdChallengeAnswer
                };
                ComboBox[] arrCbxes = new ComboBox[]
                {
                cbxFirstChallengeQuestion,cbxSecondChallengeQuestion,cbxThirdChallengeQuestion,cbxTitle,cbxSuffix,cbxStates
                };
                Label[] arrErrorLblsTextBoxes = new Label[]
                {
                lblErrorFirstName, lblErrorMiddleName, lblErrorLastName, lblErrorAddress1,
                lblErrorAddress2, lblErrorAddress3, lblErrorCity, lblErrorEmail,
                lblErrorLogonName, lblErrorPassword,lblErrorFirstAnswer,
                lblErrorSecondAnswer,lblErrorThirdAnswer
                };
                Label[] arrErrorLblsComboBoxes = new Label[]
                {
                lblErrorSecurityQuestion1,lblErrorSecondQuestion,lblErrorThirdQuestion,lblErrorState
                };
                MaskedTextBox[] arrMaskTextBoxes = new MaskedTextBox[]
                {
                mskZip, mskPhonePrimary,mskPhoneSecondary
                };

                //Reset all labels to not visible
                foreach (Label lbl in arrErrorLblsComboBoxes)
                {
                    lbl.Visible = false;
                }
                foreach (Label lbl in arrErrorLblsTextBoxes)
                {
                    lbl.Visible = false;
                }

                //Clear Error Message & Open database connection
                clsValidation.resetErrorMessage();

                /*Validation for:
                 Checking if TextBoxes are empty
                 Checking if required Combo Boxes are selected
                 UserName validation
                 Password validation
                 Address Validation
                 ZipCode validation
                 PhoneNumber validation
                 Checking if user exists */

                string strPhone = mskPhoneSecondary.Text.Replace(" ", "");
                string strPhone2 = mskPhonePrimary.Text.Replace(" ", "");
                int intSize = strPhone.Trim().Length;

                bool[] bolValid = new bool[] {
                clsValidation.CheckIfNewUserTextBoxesEmpty(arrTbxes, arrErrorLblsTextBoxes),
                clsValidation.CheckIfComboBoxesEmpty(arrCbxes, arrErrorLblsComboBoxes),
                clsLogon.IsValidUsername(tbxLogonName, lblErrorLogonName),
                clsLogon.IsValidPassword(tbxPassword, lblErrorPassword, null),
                clsValidation.IsValidAddress(tbxAddress1, lblErrorAddress1),
                String.IsNullOrEmpty(tbxEmail.Text) ||
                clsLogon.IsValidEmail(tbxEmail, lblErrorEmail),
                clsValidation.IsValidCity(tbxCity, lblErrorCity),
                strPhone2 == "()-" ||
                clsValidation.IsValidPhoneNumber(mskPhonePrimary, lblErrorPhonePrimary),
                clsValidation.IsValidZip(mskZip, lblErrorZip),
                strPhone == "()-" ||
                clsValidation.IsValidPhoneNumber(mskPhoneSecondary, lblErrorPhoneSecondary)
            };

                //If any of the validation comes back false, print error message
                int intInvalid = 0;
                for (int intI = 0; intI < bolValid.Length; intI++)
                {
                    if (bolValid[intI] == false)
                    {
                        intInvalid++;
                        lblLoginError.Text = clsValidation.setErrorMessage();
                        lblLoginError.Visible = true;
                        break;
                    }
                }
                SetPersonInfo();
                string strZip = "";
                if (mskZip.Text.Length == 6)
                {
                    strZip = mskZip.Text.Replace("-", "");
                    person.strZip = strZip;
                }
                if (strPhone == "()-")
                {
                    person.strPhoneSecondary = "";
                }
                //If all validation passes, create a new user, close database & show frmLogin/Close NewUserFrm
                if (intInvalid == 0)
                {
                    if (!bolIsManagerCreation && clsLogon.CreateNewUser(tbxLogonName, strZip, lblLoginError, arrTbxes, arrCbxes, arrMaskTextBoxes))
                    {
                        this.Close();
                    }
                    else if (bolIsManagerCreation && strManagerState == "Edit" && clsManager.EditCustomer(person))
                    {
                        MessageBox.Show("User successfully updated.", "User Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else if (bolIsManagerCreation && strManagerState == "Add" && clsLogon.CreateNewUser(tbxLogonName, strZip, lblLoginError, arrTbxes, arrCbxes, arrMaskTextBoxes))
                    {
                        this.Close();
                    }
                }
            }catch(Exception s)
            {
                MessageBox.Show(s.Message, "Error creating user", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Key Press event to only allow digits to be entered to textbox zipcode
        private void tbxZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void SetPersonInfo()
        {
            //Save Person info into a person object when leaving a form
            person.strLogonName = tbxLogonName.Text;
            person.strPassword = tbxPassword.Text;
            person.strFirstChallengeQuestion = cbxFirstChallengeQuestion.Text;
            person.strFirstChallengeAnswer = tbxFirstChallengeAnswer.Text;
            person.strSecondChallengeQuestion = cbxSecondChallengeQuestion.Text;
            person.strSecondChallengeAnswer = tbxSecondChallengeAnswer.Text;
            person.strThirdChallengeQuestion = cbxThirdChallengeQuestion.Text;
            person.strThirdChallengeAnswer = tbxThirdChallengeAnswer.Text;
            person.strTitle = cbxTitle.Text;
            person.strFirstName = tbxFirstName.Text;
            person.strMiddleName = tbxMiddleName.Text;
            person.strLastName = tbxLastName.Text;
            person.strSuffix = cbxSuffix.Text;
            person.strAddress1 = tbxAddress1.Text;
            person.strAddress2 = tbxAddress2.Text;
            person.strAddress3 = tbxAddress3.Text;
            person.strCity = tbxCity.Text;
            person.strStates = cbxStates.Text;
            person.strZip = mskZip.Text;
            person.strEmail = tbxEmail.Text;
            person.strPhonePrimary = mskPhonePrimary.Text;
            person.strPhoneSecondary = mskPhoneSecondary.Text;
        }

        private void SetControls(clsManager.Person person)
        {
            //Set controls to person info
            tbxLogonName.Text = person.strLogonName;
            tbxPassword.Text = person.strPassword;
            cbxFirstChallengeQuestion.SelectedItem = person.strFirstChallengeQuestion;
            tbxFirstChallengeAnswer.Text = person.strFirstChallengeAnswer;
            cbxSecondChallengeQuestion.SelectedItem = person.strSecondChallengeQuestion;
            tbxSecondChallengeAnswer.Text = person.strSecondChallengeAnswer;
            cbxThirdChallengeQuestion.SelectedItem = person.strThirdChallengeQuestion;
            tbxThirdChallengeAnswer.Text = person.strThirdChallengeAnswer;
            cbxTitle.Text = person.strTitle;
            tbxFirstName.Text = person.strFirstName;
            tbxMiddleName.Text = person.strMiddleName;
            tbxLastName.Text = person.strLastName;
            cbxSuffix.Text = person.strSuffix;
            tbxAddress1.Text = person.strAddress1;
            tbxAddress2.Text = person.strAddress2;
            tbxAddress3.Text = person.strAddress3;
            tbxCity.Text = person.strCity;
            cbxStates.Text = person.strStates;
            mskZip.Text = person.strZip;
            tbxEmail.Text = person.strEmail;
            mskPhonePrimary.Text = person.strPhonePrimary;
            mskPhoneSecondary.Text = person.strPhoneSecondary;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            SetPersonInfo();
            //Set Help Boolean to true, create HelpObject, Pass in Form State, set FrmHelp Background to appropriate image, width & height
            //Show FrmHelp & close currrent form
            bolIsHelp = true;
            frmHelp frmHelpObj = new frmHelp("New User", bolIsManagerCreation, strManagerState, person);
            frmHelpObj.BackgroundImage = Resources.frmNewUserHelp;
            frmHelpObj.Width = Resources.frmNewUserHelp.Width + 20;
            frmHelpObj.Height = Resources.frmNewUserHelp.Height;
            frmHelpObj.Show();
            this.Close();
        }

        private void pbxShowPassword_Click(object sender, EventArgs e)
        {
            /*If the button is first clicked, unhide password text and change the color of the image
             If button is clicked once more, hide password text & change the PictureBox back to the previous image*/
            if (!bolIsClicked)
            {
                pbxShowPassword.Image = Resources.HidePasswordBtn;
                bolIsClicked = true;
                tbxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                pbxShowPassword.Image = Resources.ShowPasswordBtn;
                bolIsClicked = false;
                tbxPassword.UseSystemPasswordChar = true;
            }
        }

        private void CreateSecurityQuestionLists()
        {
            //Store all existing security questions into a master list 
            for (int intI = 0; intI < cbxFirstChallengeQuestion.Items.Count; intI++)
            {
                lstMasterList.Add(cbxFirstChallengeQuestion.Items[intI].ToString());
            }
        }

        private void UpdateChallengeQuestion1()
        {
            //Save Selected Questions
            string strSecondQuestion = cbxSecondChallengeQuestion.Text;
            string strThirdQuestion = cbxThirdChallengeQuestion.Text;

            arrIsBeingChanged[1] = !String.IsNullOrEmpty(strSecondQuestion);
            arrIsBeingChanged[2] = (!String.IsNullOrEmpty(strThirdQuestion));

            //Clear ComboBoxes 
            cbxSecondChallengeQuestion.Items.Clear();
            cbxThirdChallengeQuestion.Items.Clear();

            //Reload ComboBoxes with security questions
            cbxSecondChallengeQuestion.Items.AddRange(lstMasterList.ToArray());
            cbxThirdChallengeQuestion.Items.AddRange(lstMasterList.ToArray());

            //Remove selected items from other combo boxes
            cbxSecondChallengeQuestion.Items.Remove(cbxFirstChallengeQuestion.SelectedItem);

            cbxThirdChallengeQuestion.Items.Remove(cbxFirstChallengeQuestion.SelectedItem);

            //Restore saved questions
            if (arrIsBeingChanged[1])
            {
                cbxSecondChallengeQuestion.SelectedItem = strSecondQuestion;
                cbxFirstChallengeQuestion.Items.Remove(cbxSecondChallengeQuestion.SelectedItem);
                cbxThirdChallengeQuestion.Items.Remove(cbxSecondChallengeQuestion.SelectedItem);
            }
            if (arrIsBeingChanged[2])
            {
                cbxThirdChallengeQuestion.SelectedItem = strThirdQuestion;
                cbxFirstChallengeQuestion.Items.Remove(cbxThirdChallengeQuestion.SelectedItem);
                cbxSecondChallengeQuestion.Items.Remove(cbxThirdChallengeQuestion.SelectedItem);
            }
        }

        private void UpdateChallengeQuestion2()
        {
            //Save Selected Questions
            string strFirstQuestion = cbxFirstChallengeQuestion.Text;
            string strThirdQuestion = cbxThirdChallengeQuestion.Text;

            arrIsBeingChanged[0] = (!String.IsNullOrEmpty(strFirstQuestion));
            arrIsBeingChanged[2] = (!String.IsNullOrEmpty(strThirdQuestion));

            //Clear ComboBoxes 
            cbxFirstChallengeQuestion.Items.Clear();
            cbxThirdChallengeQuestion.Items.Clear();

            //Reload ComboBoxes with security questions
            cbxFirstChallengeQuestion.Items.AddRange(lstMasterList.ToArray());
            cbxThirdChallengeQuestion.Items.AddRange(lstMasterList.ToArray());

            //Remove selected items from other combo boxes
            cbxFirstChallengeQuestion.Items.Remove(cbxSecondChallengeQuestion.SelectedItem);
            cbxThirdChallengeQuestion.Items.Remove(cbxSecondChallengeQuestion.SelectedItem);

            //Restore saved questions
            if (arrIsBeingChanged[0])
            {
                cbxFirstChallengeQuestion.SelectedItem = strFirstQuestion;
                cbxSecondChallengeQuestion.Items.Remove(cbxFirstChallengeQuestion.SelectedItem);
                cbxThirdChallengeQuestion.Items.Remove(cbxFirstChallengeQuestion.SelectedItem);
            }
            if (arrIsBeingChanged[2])
            {
                cbxThirdChallengeQuestion.SelectedItem = strThirdQuestion;
                cbxFirstChallengeQuestion.Items.Remove(cbxThirdChallengeQuestion.SelectedItem);
                cbxSecondChallengeQuestion.Items.Remove(cbxThirdChallengeQuestion.SelectedItem);
            }
        }

        private void UpdateChallengeQuestion3()
        {
            //Save Selected Questions
            string strFirstQuestion = cbxFirstChallengeQuestion.Text;
            string strSecondQuestion = cbxSecondChallengeQuestion.Text;

            //Check if comboboxes are empty
            arrIsBeingChanged[0] = (!String.IsNullOrEmpty(strFirstQuestion));
            arrIsBeingChanged[1] = (!String.IsNullOrEmpty(strSecondQuestion));

            //Clear ComboBoxes 
            cbxFirstChallengeQuestion.Items.Clear();
            cbxSecondChallengeQuestion.Items.Clear();

            //Reload ComboBoxes with security questions
            cbxFirstChallengeQuestion.Items.AddRange(lstMasterList.ToArray());
            cbxSecondChallengeQuestion.Items.AddRange(lstMasterList.ToArray());

            //Remove selected items from other combo boxes
            cbxFirstChallengeQuestion.Items.Remove(cbxThirdChallengeQuestion.SelectedItem);
            cbxSecondChallengeQuestion.Items.Remove(cbxThirdChallengeQuestion.SelectedItem);

            //If the comboboxes were not originally empty then restore them
            if (arrIsBeingChanged[0])
            {
                cbxFirstChallengeQuestion.SelectedItem = strFirstQuestion;
                cbxSecondChallengeQuestion.Items.Remove(cbxFirstChallengeQuestion.SelectedItem);
                cbxThirdChallengeQuestion.Items.Remove(cbxFirstChallengeQuestion.SelectedItem);
            }
            if (arrIsBeingChanged[1])
            {
                cbxSecondChallengeQuestion.SelectedItem = strSecondQuestion;
                cbxFirstChallengeQuestion.Items.Remove(cbxSecondChallengeQuestion.SelectedItem);
                cbxThirdChallengeQuestion.Items.Remove(cbxSecondChallengeQuestion.SelectedItem);
            }
        }

        private void cbxFirstChallengeQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Depending on what security question is selected, change the security questions
            if (!arrIsBeingChanged[0])
            {
                UpdateChallengeQuestion1();
            }
            else
            {
                arrIsBeingChanged[0] = false;
            }
        }

        private void cbxSecondChallengeQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Depending on what security question is selected, change the security questions
            if (!arrIsBeingChanged[1])
            {
                UpdateChallengeQuestion2();
            }
            else
            {
                arrIsBeingChanged[1] = false;
            }
        }

        private void cbxThirdChallengeQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Depending on what security question is selected, change the security questions
            if (!arrIsBeingChanged[2])
            {
                UpdateChallengeQuestion3();
            }
            else
            {
                arrIsBeingChanged[2] = false;
            }
        }

        private void tbxCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only allow letters when entering a city
            clsValidation.OnlyAllowLetters(sender, e);
        }

        private void tbxLogonName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only allow Alphanumeric when entering a username
            clsValidation.OnlyAllowAlphaNumeric(sender, e);
        }

        private void frmNewUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If user is not trying to access the form for help, open frmLogin
            //If user is a manager, return to frmManager
            if (!bolIsHelp && !bolIsManagerCreation)
            {
                new frmLogin().Show();
            }
            else if(!bolIsHelp && bolIsManagerCreation)
            {
                new frmManager().Show();
            }
        }
    }
}
