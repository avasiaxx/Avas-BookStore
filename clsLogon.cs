using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static FA21_Final_Project.frmForgotPassword;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    //Login View Status Check
    class clsLogon
    {
        static int intID = 0;

        public static SqlDataReader dataReader = null;
        public static void getDataReader(SqlDataReader rdr)
        {
            //Get DataReader to pass data to another form
            dataReader = rdr;
        }

        public static string strPositionType
        {
            get; set;
        }

        public static void ResetLogin()
        {
            clsFinishOrder.intRows = 0;
            clsSQL.intPersonID = 0;
            strPositionType = "";
        }
        public static bool IsValidUsername(TextBox tbxUsername, Label lblErrorUsername)
        {
            /*Cannot begin with a number or special character
            ● Cannot be less than 8 characters long
            ● Cannot be longer than 20 characters
            ● Cannot contain special Characters
            ● Cannot contain, start with or end with spaces
            */
            bool[] arrValid = new bool[]
            {
                tbxUsername.Text.Length >= 8,
                tbxUsername.Text.Length <= 20,
                !tbxUsername.Text.Any(c => Char.IsSymbol(c)),
                !tbxUsername.Text.Contains(" "),
                Regex.Matches(tbxUsername.Text, "^[A-Za-z]").Count != 0
            };
            bool boolTest1 = arrValid[0];
            bool Test2 = arrValid[1];
            bool Test3 = arrValid[2];
            bool Test4 = arrValid[3];
            if (!arrValid[0])
            {
                clsValidation.getErrorMessage("UserName must be at least 8 characters long");
            } else if (!arrValid[1])
            {
                clsValidation.getErrorMessage("Username cannot be greater than 20 characters");
            }
            else if (!arrValid[2])
            {
                clsValidation.getErrorMessage("Special characters are not allowed in usernames.");
            }
            else if (!arrValid[3])
            {
                clsValidation.getErrorMessage("Spaces are not allowed in usernames.");
            }
            else if (!arrValid[4])
            {
                clsValidation.getErrorMessage("Username cannot begin with a number or special character.");
            }

            int intInvalid = 0;
            for (int i = 0; i < arrValid.Length; i++)
            {
                if (arrValid[i] == false)
                {
                    intInvalid++;
                }
            }
            if (intInvalid != 0)
            {
                lblErrorUsername.Visible = true;
            }
            else
            {
                lblErrorUsername.Visible = false;
            }
            return intInvalid == 0;
        }

        /*Checks if the password is 8 chars, if it's uppercase & lower case*/
        public static bool IsValidPassword(TextBox tbxPassword, Label lblErrorPassword, string strPreviousPassword)
        {
            /*Passwords must be complex passwords. They must contain three of the four types to
            be a valid password:
            ● Upper case characters (A through Z)
            ● Lower case characters (a through z)
            ● Numbers (0 through 9)
            ● Special characters (!@#$%^&*) No spaces allowed
            Passwords must also be:
            ● Case sensitive
            ● Cannot be less than 8 characters long
            ● Cannot be longer than 20 characters*/

            string strSymbols = "(!@#$%^&*)";
            List<char> lstSymbols = new List<char>();
            lstSymbols.AddRange(strSymbols);

            bool[] arrValid = new bool[]
            {
                tbxPassword.Text.Length >= 8,
                tbxPassword.Text.Length <= 20,
                tbxPassword.Text.Any(c => Char.IsUpper(c)),
                tbxPassword.Text.Any(c => lstSymbols.Contains(c)),
                tbxPassword.Text.Any(c => Char.IsLower(c)),
                tbxPassword.Text.Any(c => Char.IsDigit(c))
            };

            if (!arrValid[0])
            {
                clsValidation.getErrorMessage("Password must be at least 8 characters long");
            }
            else if (!arrValid[1])
            {
                clsValidation.getErrorMessage("Password cannot be greater than 20 characters");
            }

            bool bolMatches = tbxPassword.Text == strPreviousPassword;
            if (bolMatches)
            {
                clsValidation.getErrorMessage("New Password cannot match previous password");
            }

            //Check for absolute length requirements
            bool bolLengthValid = arrValid[0] && arrValid[1];

            //Check to make sure three out of the four types of requirements are met to be a valid password
            int intInvalid = 0;
            for (int i = 2; i < arrValid.Length; i++)
            {
                if (arrValid[i] == false)
                {
                    intInvalid++;
                }
            }
            if (intInvalid >= 2)
            {
                lblErrorPassword.Visible = true;
                clsValidation.getErrorMessage("You must have at least one capitalized letter, one lowercase letter,\n a special character and/or a number for your password.");

            }
            else
            {
                lblErrorPassword.Visible = false;
            }
            return intInvalid < 2 && bolLengthValid && !bolMatches;
        }

        /*Checks if the email textbox is empty then converts the string to a MailAddress object to check if it's valid*/
        static public bool IsValidEmail(TextBox tbxEmail, Label lblErrorEmail)
        {
            var _addressRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if ((!Regex.Match(tbxEmail.Text, _addressRegex).Success))
            {
                lblErrorEmail.Visible = true;
                clsValidation.getErrorMessage("Please enter a valid email. Format: youremail@mail.com");
                return false;
            }
            else
            {
                try
                {
                    MailAddress m = new MailAddress(tbxEmail.Text);
                    lblErrorEmail.Visible = false;
                    return true;
                }
                catch (FormatException)
                {
                    lblErrorEmail.Visible = true;
                    return false;
                }
            }
        }

        /*FORGOT PASSWORD COMMAND*/
        public static bool ForgotPassword(TextBox[] arrTbx, ComboBox[] arrCbx, LoginState state, TextBox tbxNewPassword, TextBox tbxConfirmPassword, Label lblErrorPassword, Label[] arrErrors)
        {
            bool bolSuccess = false;
            SqlConnection cnn = null;

            //Check if user exists then retrieve the data reader from inside the function
            clsSQL.CheckIfUserExists(arrTbx[0], lblErrorPassword, cnn = clsSQL.OpenDatabase(), false);

            /*If the dataReader has rows, get the LogonID & begin switch statement for State
            EnterUsername: Display all current security questions associated with UserName
            Enter Answers: Check if answers match existing answers in database
            Finish: Check if passwords entered are valid, match then set the new Password*/
            try
            {
                if (dataReader != null)
                {
                    if (dataReader.HasRows)
                    {
                        intID = dataReader.GetInt32(0);

                        switch (state)
                        {
                            case LoginState.EnterUserName:
                                if (dataReader != null)
                                {
                                    string strSecurityQuestion1 = dataReader["FirstChallengeQuestion"].ToString();
                                    string strSecurityQuestion2 = dataReader["SecondChallengeQuestion"].ToString();
                                    string strSecurityQuestion3 = dataReader["ThirdChallengeQuestion"].ToString();

                                    arrCbx[0].SelectedItem = strSecurityQuestion1;
                                    arrCbx[1].SelectedItem = strSecurityQuestion2;
                                    arrCbx[2].SelectedItem = strSecurityQuestion3;

                                    bolSuccess = true;
                                }
                                break;
                            case LoginState.EnterAnswers:
                                if (dataReader != null)
                                {
                                    bool bolAnswer1Correct = String.Equals(arrTbx[1].Text, dataReader["FirstChallengeAnswer"].ToString(),
                               StringComparison.OrdinalIgnoreCase);
                                    bool bolAnswer2Correct = String.Equals(arrTbx[2].Text, dataReader["SecondChallengeAnswer"].ToString(),
                               StringComparison.OrdinalIgnoreCase);
                                    bool bolAnswer3Correct = String.Equals(arrTbx[3].Text, dataReader["ThirdChallengeAnswer"].ToString(),
                               StringComparison.OrdinalIgnoreCase);
                                    bolSuccess = bolAnswer1Correct && bolAnswer2Correct && bolAnswer3Correct;
                                }
                                if (!bolSuccess)
                                {
                                    lblErrorPassword.Text = "*Security questions are incorrect";
                                    foreach (Label n in arrErrors)
                                    {
                                        n.Visible = true;
                                    }
                                    lblErrorPassword.Visible = true;
                                }
                                break;
                            case LoginState.Finish:
                                string strPreviousPassword = dataReader["Password"].ToString();


                                if (IsValidPassword(tbxNewPassword, lblErrorPassword, strPreviousPassword) == true)
                                {
                                    if (tbxNewPassword.Text == tbxConfirmPassword.Text)
                                    {
                                        dataReader.Close();
                                        bolSuccess = clsSQL.setNewPassword(tbxConfirmPassword, cnn, intID);
                                        clsSQL.CloseDatabase(cnn);
                                        dataReader = null;
                                    }
                                    else
                                    {
                                        lblErrorPassword.Text = "*Passwords do not match";
                                        lblErrorPassword.Visible = true;
                                    }
                                }
                                else
                                {
                                    lblErrorPassword.Text = clsValidation.setErrorMessage();
                                    lblErrorPassword.Visible = true;
                                    clsValidation.resetErrorMessage();
                                    tbxNewPassword.Focus();
                                }
                                break;
                        }
                    }
                }
                else
                {
                    lblErrorPassword.Text = "*Username not found";
                    lblErrorPassword.Visible = true;
                }
            }
            catch (System.NullReferenceException e)
            {
                MessageBox.Show(e.Message, "Null Reference Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Reader Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bolSuccess;
        }

        public static bool Login(TextBox tbxUserName, TextBox tbxPassword)
        {
            SqlConnection cnn = clsSQL.OpenDatabase();
            bool bolSuccess = false;
            DataTable _dtTable = clsSQL.Login(tbxUserName, tbxPassword, cnn);
            int intRows = clsSQL.DTTable.Rows.Count;
            DataRow[] result = new DataRow[] { };

            try {
                foreach(DataRow row in _dtTable.Rows)
                {
                    string strPositionTitle = row["PositionTitle"].ToString();
                    strPositionType = strPositionTitle;
                }
            } 
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Data Row Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //If the loginTable has rows, the login was a success, otherwise display the error and set focus to the Username Tbx
            if (clsSQL.DTTable.Rows.Count == 1)
            {
                bolSuccess = true;
            }
            else
            {
                bolSuccess = false;
                tbxUserName.Focus();
            }
            clsFinishOrder.intRows = intRows;
            _dtTable.Dispose();
            _dtTable.Clear();
            clsSQL.DTTable.Dispose();
            clsSQL.DTTable.Clear();
            clsSQL.CloseDatabase(cnn);
            return bolSuccess;
        }
        public static bool CreateNewUser(TextBox tbxLogonName, string strZip, Label lblLoginError, 
            TextBox[] arrTbxes, ComboBox[] arrCbxes, MaskedTextBox[] arrMaskedTextBoxes)
        {
            //User Creation Function that checks if the user exists and if they don't, then allows user creation
            //If User does exist, retrieve erorr message and display it
            SqlConnection cnn = clsSQL.OpenDatabase();
            if (clsSQL.CheckIfUserExists(tbxLogonName, lblLoginError, cnn, true))
            {
                clsSQL.NewUser(arrTbxes, strZip, arrCbxes, cnn, arrMaskedTextBoxes);
                MessageBox.Show("User Created successfully", "User created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsSQL.CloseDatabase(cnn);
                return true;
            }
            else
            {
                lblLoginError.Text = clsValidation.setErrorMessage();
                lblLoginError.Visible = true;
                clsSQL.CloseDatabase(cnn);
                return false;
            }
        }
    }
}
