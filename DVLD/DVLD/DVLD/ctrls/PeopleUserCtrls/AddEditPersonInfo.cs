using PersonClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using PersonServiceLibrary;
using DVLD.ctrls;
namespace DVLD.ctrls
{
    public partial class AddEditPersonInfo : UserControl
    {
        // Define an event
        private  clsPersonService clsPersonService= new clsPersonService(clsPersonService.Mode.AddNew);
        public int ID {  get; set; }

        public event EventHandler RequestFormClose;
        
        public event EventHandler UpdatePerson;

        public delegate void AddPersonDelegate(object sender, clsCustomEventArgs e);

        public event AddPersonDelegate evAddPersonCtrl;
        public enum ControlMode
        {
            AddNew,
            Update
        }
        public ControlMode Mode { get; set; }
        private void FreezeButtons()
        {
            tbAddress.Enabled = false;
            tbEmail.Enabled = false;
            tbFirst.Enabled = false;
            tbLast.Enabled = false;
            tbSecond.Enabled = false;
            tbThird.Enabled = false;
            tbNationalNo.Enabled = false;
            dtpBirth.Enabled = false;
            cbCountry.Enabled = false;
            lbRemove.Enabled = false;
            btnSave.Enabled = false;
            pbPersonImage.Enabled = false;
            lbSetImage.Enabled = false;
            btnSave.Enabled = false;
            tbPhone.Enabled = false;
            rbtnFemale.Enabled = false;
            gbGender.Enabled = false;
        }
        private void Reset()
        {
            tbAddress.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbFirst.Text = string.Empty;
            tbLast.Text = string.Empty;
            tbSecond.Text = string.Empty;
            tbThird.Text = string.Empty;
            tbNationalNo.Text = string.Empty;
            dtpBirth.Text = string.Empty;
            resetGenderBtn();
            cbCountry.SelectedValue= 42;//Jordan
            lbRemove.Visible = false;
            btnSave.Enabled = false;
            pbPersonImage.Image = ilPerson.Images["unknown"];
            //Button.
            btnSave.Enabled = false;
        }
        private void resetGenderBtn()
        {
            rbtnMale.Checked = false;
            rbtnFemale.Checked = false;
        }
        private void basicSettings()
        {
            // Set the maximum date to today's date minus 18 years
            dtpBirth.MaxDate = DateTime.Today.AddYears(-18);

            // Set the minimum date to today's date minus 100 years
            dtpBirth.MinDate = DateTime.Today.AddYears(-65);

            //validation settings.
            tbPhone.KeyPress += PhoneNumberTextBoxValidation;
            tbNationalNo.KeyPress += NationalnumberTextBoxValidation;
            tbFirst.KeyPress += NameTextBoxValidation;
            tbLast.KeyPress += NameTextBoxValidation;
            tbSecond.KeyPress += NameTextBoxValidation;
            tbThird.KeyPress += NameTextBoxValidation;

            //Default values .
            
                cbCountry.SelectedValue = 42;//Jordan ID=42
                lbRemove.Visible = false;
                btnSave.Enabled = false;
        }

         private void _loadCountries()
        {
            DataTable dataTableCountries= clsLoadRandomDataLibrary.AccessData.GetAllCountriesInfo();
            cbCountry.DataSource = dataTableCountries;
            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "ID";
            cbCountry.SelectedItem = 42;
        }
        private void _checkGender(char gender)
        {
            if (gender == 'f')
                rbtnFemale.Checked = true;
            else if (gender == 'm')
                rbtnMale.Checked = true;
            else
                return; 
        }
        private void _LoadPersonInfo(int ID)
        {
            clsPerson person= clsPersonService.Find(ID);
            if (person != null)
            {
                tbFirst.Text = person.FirstName;
                tbSecond.Text = person.SecondName;
                tbThird.Text = person.ThirdName;
                tbLast.Text = person.LastName;
                tbNationalNo.Text = person.NationalNumber;
                dtpBirth.Value= person.Birth;
                _checkGender(person.Gender);
                tbPhone.Text = person.PhoneNumber;
                tbEmail.Text = person.Email;
                tbAddress.Text = person.Address;

                Mode = ControlMode.Update;
                try
                {
                    Image image = Image.FromFile(person.PersonImagePath);
                    pbPersonImage.Image = image;
                    pbPersonImage.Tag = person.PersonImagePath;
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during loading
                    Console.WriteLine("Error loading image: " + ex.Message);
                }
            }
        }       
        private void _LoadData()
        {
            _loadCountries();

        }     
        private char CheckAndReturnFemaleMaleRbtn() 
        {

            if (rbtnFemale.Checked == false)
                return 'm';
            
            else 
                return 'f';

        }
        private string returnImagePath()
        {
            if (pbPersonImage.Tag == null)
                return "";
            else 
                return pbPersonImage.Tag.ToString();
        }
        private bool CheckControlsFiled()
        {
            if (string.IsNullOrEmpty(tbFirst.Text) || string.IsNullOrEmpty(tbSecond.Text)
                || string.IsNullOrEmpty(tbThird.Text) || string.IsNullOrEmpty(tbLast.Text)
                || string.IsNullOrEmpty(tbNationalNo.Text)|| !(rbtnMale.Checked || rbtnFemale.Checked)
               /* || string.IsNullOrEmpty(tbEmail.Text)//Nullable*/|| string.IsNullOrEmpty(tbAddress.Text)
                ||string.IsNullOrEmpty(tbPhone.Text))
                return false;

            return true;
        }
        private void setImageBasedOnGender()
        {
            if (rbtnFemale.Checked == true)

                pbPersonImage.Image = ilPerson.Images["girl"];


            else if (rbtnMale.Checked == true)
                pbPersonImage.Image = ilPerson.Images["boy"];

            else
                pbPersonImage.Image = ilPerson.Images["unknown"];
        }
        private string getSelectedCountry()
        {
            DataRowView selectedRow = (DataRowView)cbCountry.SelectedItem;
            string selectedCountryName = selectedRow["Name"].ToString().Trim();
            return selectedCountryName;
        }      
        private void CheckAllControls()
        {
            btnSave.Enabled = CheckControlsFiled();
        } 
        public AddEditPersonInfo()
        {
            InitializeComponent();
            _LoadData();
            basicSettings();
        }   
        private void NameTextBoxValidation(object sender, KeyPressEventArgs e)
             {
            TextBox textBox = sender as TextBox;
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
            {
                // Cancel the key press
                e.Handled = true;
                textBox.Focus();
                // Show error icon and tooltip
                epFilter.SetError(textBox, "Please enter a letter .");
            }
            else
            {
                // Clear error when a valid key is pressed
                epFilter.SetError(textBox, "");
                e.Handled = false;

            }

        }
        private void PhoneNumberTextBoxValidation(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar)&& e.KeyChar != (char)Keys.Delete&&e.KeyChar!=(char)Keys.Back)
            {
                // Cancel the key press
                e.Handled = true;
                tbPhone.Focus();
                // Show error icon and tooltip
                epFilter.SetError(tbPhone, "Please fill the blank with numbers only.");
            }
            else if (tbPhone.Text.Length >=10 && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
            {   
                // Cancel the key press
                e.Handled = true;
                tbPhone.Focus();
                // Show error icon and tooltip
                epFilter.SetError(tbPhone, "Max numbers is 10 .");
            }
            else
            {
                // Clear error when a valid key is pressed
                e.Handled = false;
                epFilter.SetError(tbPhone, "");
            }

        }
        private void NationalnumberTextBoxValidation(object sender, KeyPressEventArgs e)
        {
            // Check if the entered key is a symbol
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar)
               && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
            {
                // Cancel the key press
                e.Handled = true;
                tbNationalNo.Focus();
                // Show error icon and tooltip
                epFilter.SetError(tbNationalNo, "Please enter a letter or a digit.");
            }
            else if(tbNationalNo.Text.Length >10)
            { 
                // Cancel the key press
                e.Handled = true;
                tbNationalNo.Focus();
                // Show error icon and tooltip
                epFilter.SetError(tbNationalNo, "you can't exceed 10 digits.");

            }

            {
                // Clear error when a valid key is pressed
                epFilter.SetError(tbNationalNo, "");
                e.Handled = false;

            }
        }
        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {

            string email = tbEmail.Text;

            // Define a regular expression pattern for email validation
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(?:\.[a-zA-Z]{2,})?$";
            Regex regex = new Regex(emailPattern);
            if (!string.IsNullOrEmpty(email))
            {

                if (!regex.IsMatch(email)) // Adjust the maximum length as needed
                {
                    // Email does not match the pattern or exceeds the maximum length
                    e.Cancel = false;

                    tbEmail.Focus();
                    // Show error icon and tooltip
                    epFilter.SetError(tbEmail, "Please enter a valid email address.");

                }
                else
                {
                    e.Cancel = false;

                    // Clear error when a valid email is entered
                    epFilter.SetError(tbEmail, "");
                }
            }

        }
        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string nationalNumber=tbNationalNo.Text;
                if (!string.IsNullOrEmpty(nationalNumber))
                {
                  
                     if (ID!=-1 && clsPersonService.IsExist(ID,nationalNumber))
                    {
                        e.Cancel = false;
                        epFilter.SetError(tbNationalNo, "");

                    }
                   else if (clsPersonService.IsExist(nationalNumber))// I want you to check if current NatioNo used is either my old one or new one .
                    {
                        e.Cancel=true;
                        tbNationalNo.Focus();
                        epFilter.SetError(tbNationalNo, "This natioanal number was already used.");
                    }
                    else
                    {
                        e.Cancel = false;
                        epFilter.SetError(tbNationalNo, "");
                    }
                }
                else
                {
                    e.Cancel = true;
                    tbNationalNo.Focus();
                    // Show error icon and tooltip for empty National number
                    epFilter.SetError(tbNationalNo, "Please enter a National number.");
                }
            }
            catch(Exception ex) {

            Console.WriteLine($"Error:\t{ex.Message}");

            }

        }
        private void rbtnFemale_Click(object sender, EventArgs e)
        {
            CheckAllControls();
            if (pbPersonImage.Tag == null)
            pbPersonImage.Image = ilPerson.Images["girl"];
        }
        private void rbtnMale_Click(object sender, EventArgs e)
        {
            CheckAllControls();
            if (pbPersonImage.Tag == null)
                pbPersonImage.Image = ilPerson.Images["boy"];
        } 
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            CheckAllControls();

        }     
        private void _FillPersonWithNewDataToUpdate(clsPerson UpdatePerson)
        {

            UpdatePerson.NationalNumber=tbNationalNo.Text;
            UpdatePerson.SetName(tbFirst.Text, tbSecond.Text, tbThird.Text, tbLast.Text);
            UpdatePerson.Gender = CheckAndReturnFemaleMaleRbtn();
            UpdatePerson.Birth=dtpBirth.Value;
            UpdatePerson.PhoneNumber = tbPhone.Text;
            UpdatePerson.Email = tbEmail.Text;
            UpdatePerson.Address=tbAddress.Text;
            UpdatePerson.Nationality = getSelectedCountry();
            UpdatePerson.PersonImagePath = returnImagePath();
            
        } 
        private void btnClose_Click(object sender, EventArgs e)
        {

            RequestFormClose?.Invoke(this, EventArgs.Empty);
        }
        public void lbSetImage_Click(object sender, EventArgs e)
        {


            // Create an instance of the OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to only allow image files (you can customize this based on your needs)
            openFileDialog.Filter = "Images Files(*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";

            // Set the title of the dialog
            openFileDialog.Title = "Select an image";

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Get the selected file name
                    string selectedFileName = openFileDialog.FileName;

                    // Set the image of the PictureBox to the selected image
                    pbPersonImage.Image = Image.FromFile(selectedFileName);

                    // Optionally, you can store the file path or other information for later use
                    // For example, you might want to save the path to the image in your database
                    string imagePath = selectedFileName;

                    pbPersonImage.Tag = imagePath;//Save image path at Tag.

                    lbRemove.Visible = true;

                }

                catch (Exception ex)
                {
                    // Handle any exceptions that might occur when loading the image
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void lbRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.Image = null;
            pbPersonImage.Tag = null;
            lbRemove.Visible = false;
            setImageBasedOnGender();

        } 
        public void btnSave_Click(object sender, EventArgs e)
        {

            if (this.Mode == ControlMode.AddNew)
            {
               clsPersonService clsPersonService = new clsPersonService(clsPersonService.Mode.AddNew);
                clsPerson newPerson = new clsPerson(tbNationalNo.Text, tbFirst.Text, tbSecond.Text, tbThird.Text
                        , tbLast.Text, CheckAndReturnFemaleMaleRbtn(), dtpBirth.Value, tbPhone.Text,
                        tbEmail.Text, tbAddress.Text, getSelectedCountry(),
                        returnImagePath());
                if (clsPersonService.save(newPerson))
                {
                    MessageBox.Show("Person was added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ID = newPerson.ID;
                    FreezeButtons();
                    clsCustomEventArgs clsCustomEventArgs = new clsCustomEventArgs(newPerson.ID);//Return ID to users (Filter Ctrl).
                    evAddPersonCtrl?.Invoke(this, clsCustomEventArgs);
                }

                else
                {
                    MessageBox.Show("Person didn't save, proccess termainated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                }
            }
            
            else//Update
            {
                clsPersonService clsPersonService = new clsPersonService(clsPersonService.Mode.Update);

                clsPerson person = clsPersonService.Find(this.ID);//This from Database. 


                if (person!=null){
                   
                    //Fill new data 
                    _FillPersonWithNewDataToUpdate(person);

                    if (clsPersonService.save(person))
                    {
                        MessageBox.Show($"Person ID:\'{ID}\' was Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FreezeButtons();
                        UpdatePerson?.Invoke(this, EventArgs.Empty);

                    }

                    else
                    {
                        MessageBox.Show("Person didn't Update, proccess termainated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Reset();
                    } 
                }
                else
                {
                    MessageBox.Show($"Person ID:\'{ID}\' didn't Found, proccess termainated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();

                }
            }

        }    
        public void loadPersonInfo(int ID)
        {
            if (clsPersonService.IsExist(ID))
                _LoadPersonInfo(ID);

            else
                return;
        }
        private void AddEditPersonInfo_Load(object sender, EventArgs e)
        {

        }
    }

}

