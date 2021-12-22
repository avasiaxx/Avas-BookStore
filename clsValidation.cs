using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    class clsValidation
    {
        static string strError;
        static bool bolErrorEntered = false;
        public static bool CheckIfNewUserTextBoxesEmpty(TextBox[] arrTbxes, Label[] arrErrorTextBoxLabels)
        {
            bool bolIsValid = true;
            //Check if any textboxes are empty except Address2, Address3 and Phone Secondary which are not required
            try
            {
                for (int intI = 0; intI < arrTbxes.Length; intI++)
                {
                    if (arrTbxes[intI].Name != "tbxMiddleName" && arrTbxes[intI].Name != "PhoneSecondary" && arrTbxes[intI].Name != "PhoneSecondary" && arrTbxes[intI].Name != "tbxEmail" && 
                        arrTbxes[intI].Name != "tbxAddress2" && arrTbxes[intI].Name != "tbxAddress3")
                    {
                        if (String.IsNullOrEmpty(arrTbxes[intI].Text))
                        {
                            string strName = arrTbxes[intI].Name;
                            arrErrorTextBoxLabels[intI].Visible = true;
                            bolIsValid = false;
                            getErrorMessage("Please do not leave required inputs empty.");
                        }
                    }
                }
            }catch(Exception e)
            {
                clsManager.ErrorMessageBox(e, "Error loading textboxes", "", true);
            }
            return bolIsValid;
        }

        public static bool CheckIfAcceptableDate(DateTimePicker dtpExpDate, Label lblExpDateError, Label lblFinishOrderError)
        {
            bool bolIsExpired = false;
            bool bolIsAbove5Years = false;
            bool bolIsNotValid = false;
            DateTime dateToday = DateTime.Now;
            DateTime dateSelected = dtpExpDate.Value;
            DateTime dateMax = dateToday.AddYears(5);

            //Find if the selected date is not above 5 years or below the current date, if either are true then return false
            try
            {

                dateToday = new DateTime(dateToday.Year, dateToday.Month, 1);

                dateMax = new DateTime(dateMax.Year, dateMax.Month, 1);

                dateSelected = new DateTime(dateSelected.Year, dateSelected.Month, 1);

                bolIsExpired = dateToday > dateSelected;

                bolIsAbove5Years = dateSelected > dateMax;

                if (bolIsExpired)
                {
                    lblExpDateError.Visible = true;
                    lblFinishOrderError.Visible = true;
                    lblFinishOrderError.Text = "*Card expired";
                    return bolIsNotValid = true;
                }

                if (bolIsAbove5Years)
                {
                    lblExpDateError.Visible = true;
                    lblFinishOrderError.Visible = true;
                    lblFinishOrderError.Text = "*Date is invalid. Cannot have dates older than 5 years.";
                    return bolIsNotValid  = true;
                }
                else if(!bolIsAbove5Years && !bolIsExpired)
                {
                    lblExpDateError.Visible = false;
                    lblFinishOrderError.Visible = false;
                }
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message, "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bolIsExpired = true;
            }
            return bolIsNotValid;
        }
        
        public static bool CheckIfComboBoxesEmpty(ComboBox[] arrCbxes, Label[] arrErrorComboBoxLabels)
        {
            //Check if any required check boxes are selected if not then false
            bool bolIsValid = true;
            try
            {
                for (int intI = 0; intI < 3; intI++)
                {
                    if (String.IsNullOrEmpty(arrCbxes[intI].Text))
                    {
                        arrErrorComboBoxLabels[intI].Visible = true;
                        getErrorMessage("Please select a security question.");
                        bolIsValid = false;
                        break;
                    }
                }
                if (bolIsValid)
                {
                    if (String.IsNullOrEmpty(arrCbxes[5].Text))
                    {
                        arrErrorComboBoxLabels[3].Visible = true;
                        bolIsValid = false;
                        getErrorMessage("Please select a state.");
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Index out of range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bolIsValid;
        }

        public static bool CheckIfPaymentInfoEmpty(MaskedTextBox[] arrMaskedTextBoxes, Label[] arrErrorLabels, DateTimePicker dtpExpDate,
            Label lblExpDateError, Label lblFinishOrderError)
        {
            bool bolIsValid = true;
            string strError = "";

            //Find if the textboxes are empty, if so throw an error
            try
            {
                for (int intI = 0; intI < 2; intI++)
                {
                    if (String.IsNullOrEmpty(arrMaskedTextBoxes[intI].Text.Trim()))
                    {
                        arrErrorLabels[intI].Visible = true;
                        bolIsValid = false;
                        if (intI == 0)
                        {
                            strError = "*Please enter a credit card number";
                            break;
                        }
                        else
                        {
                            strError = "*Please enter a CCV number";
                            break;
                        }
                    }
                    string strCC = arrMaskedTextBoxes[0].Text.Replace(" ", "");
                    string strCCV = arrMaskedTextBoxes[1].Text.Replace(" ", "");
                    //Find if the CC is 16 characters
                    if (strCC.Length < 16)
                    {
                        strError = "*Please enter a valid credit card number";
                        arrErrorLabels[0].Visible = true;
                        bolIsValid = false;
                        break;
                    }
                    //Find if the CCV is 3 characters
                    if (strCCV.Length < 3)
                    {
                        strError = "*Please enter a valid CCV number";
                        bolIsValid = false;
                        arrErrorLabels[1].Visible = true;
                        break;
                    }
                }
                //Make sure that they select an expiration date
                if (String.IsNullOrEmpty(dtpExpDate.Text))
                {
                    lblExpDateError.Visible = true;
                    strError = "*Please select a date";
                    bolIsValid = false;
                }
                //Display the error if it's not empty
                if (!String.IsNullOrEmpty(strError))
                {
                    lblFinishOrderError.Visible = true;
                    lblFinishOrderError.Text = strError;
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error in checking if payment information is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bolIsValid;
        }

        static public bool IsValidAddress(TextBox tbxAddress, Label lblErrorAddress)
        {
            //Check if address is valid by matching the regex code
            bool bolValidAddress = true;
            var _addressRegex = @"^[A-Za-z0-9]+(?:\s[A-Za-z0-9'_-]+)+$";

            try
            {
                if ((!Regex.Match(tbxAddress.Text, _addressRegex).Success))
                {
                    bolValidAddress = false;
                    lblErrorAddress.Visible = true;
                    getErrorMessage("Please enter a valid address. Format: 123 First St");
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Regex Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bolValidAddress;
        }

        static public bool IsValidCity(TextBox tbxCity, Label lblErrorCity)
        {
            //Make sure the city entered is above 2 characters
            if(tbxCity.Text.Length < 2)
            {
                lblErrorCity.Visible = true;
                getErrorMessage("Please enter a valid city. Must be greater than 2 characters.");
                return false;
            }
            else
            {
                return true;
            }
        }

        static public bool IsValidPhoneNumber(MaskedTextBox mskPhoneNumber, Label lblPhoneNumber)
        {
            try
            {
                mskPhoneNumber.Text = mskPhoneNumber.Text.Replace(" ", "");
                //Make sure the entered phone number is the length of 14
                if (mskPhoneNumber.Text.Length < 14)
                {
                    lblPhoneNumber.Visible = true;
                    getErrorMessage("Please enter a valid phone number.");
                    return false;
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Argument Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        static public bool IsValidZip(MaskedTextBox mskZip, Label lblZip)
        {
            //Make sure the zipcode is 5 characters or more
            string strZip = mskZip.Text;
            if(mskZip.Text.Length == 6)
            {
                strZip = strZip.Replace("-", "");
            }
            bool bolIsValid = false;
            string pattern = @"^\d{5}(?:[-\s]\d{4})?$";
            Regex regex = new Regex(pattern);
            try
            {
                bolIsValid = regex.IsMatch(strZip);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Regex Match Timeout Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!bolIsValid)
            {
                lblZip.Visible = true;
                getErrorMessage("Please enter a valid ZipCode.");
            }
            return bolIsValid;
        }

        static public void resetErrorMessage()
        {
            //Clear error message
            bolErrorEntered = false;
            strError = "";
        }
        static public void getErrorMessage(string strErrorMessage)
        {
            //Get the error message
            if (!bolErrorEntered)
            {
                strError = strErrorMessage;
                bolErrorEntered = true;
            }
        }

        static public string setErrorMessage()
        {
            //Return the error message
            return strError;
        }

        static public bool CheckIfMoney(TextBox tbxMoney)
        {
            //Check if the money entered is in a correct money format
            try {
                if (tbxMoney.Text.Contains("."))
                    {
                        decimal num;
                        bool bolIsValid = decimal.TryParse(tbxMoney.Text,
                        NumberStyles.Currency,
                        CultureInfo.GetCultureInfo("en-US"), // cached
                        out num);
                        Exception e = new Exception();

                        if (!bolIsValid)
                        {
                            clsManager.ErrorMessageBox(e, "Invalid Money Format", "Please enter a proper price", false);
                            tbxMoney.Focus();
                        }
                        return bolIsValid;
                    }
                } catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Argument Out of Range Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            return true;
        }

        static public void OnlyAllowDigits(object sender, KeyPressEventArgs e)
        {
            //Only allow digit characters to be typed
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        static public void OnlyAllowDigitsAndDecimal(object sender, KeyPressEventArgs e)
        {
            //Only allow digits and a decimal to be typed
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        static public void OnlyAllowLetters(object sender, KeyPressEventArgs e)
        {
            //Only allow letters to be typed
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        static public void OnlyAllowAlphaNumeric(object sender, KeyPressEventArgs e)
        { 
            //Only allow letters and digits be allowed
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        static public bool CheckIfEmpty(TextBox[] arrTextBoxes)
        {
            //Check if text boxes are empty 
            Exception e = new Exception();
            try
            {
                foreach (TextBox tbx in arrTextBoxes)
                {
                    if (String.IsNullOrEmpty(tbx.Text))
                    {
                        clsManager.ErrorMessageBox(e, "TextBox Empty", "Please do not leave textboxes empty.", false);
                        tbx.Focus();
                        return false;
                    }
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message, "Error checking if textboxes are empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
    }
}
