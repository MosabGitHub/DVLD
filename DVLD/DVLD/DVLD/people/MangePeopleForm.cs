using PersonClass;
using PersonServiceLibrary;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD
{
    public partial class MangePeopleForm : Form
    {
      //clsPersonService clsPersonService = new clsPersonService();
        public async void loadPeopleFromDataBaseAsync()
        {
            // Asynchronously load data
            DataTable PeopleDataTable = await Task.Run(() => clsPersonService.GetAllPeopleInfo());

            dgvPeople.DataSource = PeopleDataTable;
            _showRecords();


        }
        private void ResetVisibilityAndEventHandlers()
        {

            tbFilter.Visible = false;
            cbNationlity.Visible = false;
            gbGender.Visible = false;

            // Detach existing event handlers
            tbFilter.KeyPress -= PersonIDBoxFilter;
            tbFilter.KeyPress -= PersonNameBoxFilter;
            tbFilter.KeyPress -= PersonNationalityBoxFilter;
            tbFilter.KeyPress -= PersonPhoneNumberBoxFilter;
            tbFilter.KeyPress -= PersonNationalnumberBoxFilter;
            tbFilter.KeyPress -= tbFilter_TextChanged;
        }
        private void _loadCountries()
        {
            DataTable dataTableCountries = clsLoadRandomDataLibrary.AccessData.GetAllCountriesInfo();
            cbNationlity.DataSource = dataTableCountries;
            cbNationlity.DisplayMember = "Name";
            cbNationlity.ValueMember = "ID";
            cbNationlity.SelectedIndex = -1;
        }

        private void _showRecords()
        {
            lbRecord.Text= dgvPeople.Rows.Count.ToString();
        }
        public void resetForm()
        {
            ResetVisibilityAndEventHandlers();
            loadPeopleFromDataBaseAsync();
        }      
        public void LoadFilterdDataTable(DataTable dataTable)
        {

            dgvPeople.DataSource= dataTable;
        }
        public void ResetComboFilter()
        {
            tbFilter.Visible = false;
            cbNationlity.Visible = false;
            gbGender.Visible = false;

        }
        public void InitialSettings()
        {
            
            tbFilter.Visible = false;//Non visbile as statring.
            cbNationlity.Visible = false;//Non visbile as statring.
            gbGender.Visible = false;
            loadPeopleFromDataBaseAsync();//Load add data from data base . 
        }
        public MangePeopleForm()
        {
            InitializeComponent();
            InitialSettings();
        }
        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            if (tbFilter.Text.Length > 10)
            {
                epFilter.SetError(tbFilter, "Max length is 10 digits");
                tbFilter.Text = tbFilter.Text.Substring(0, 10);
                tbFilter.SelectionStart = tbFilter.Text.Length; // Set the cursor position at the end
            }
            else
            {
                // Clear the error if the text length is within the limit
                epFilter.SetError(tbFilter, "");
            }
        }
        private async void PersonIDBoxFilter(object sender, KeyPressEventArgs e)
        {

            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidIDCharachter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                // Cancel the key press
                e.Handled = true;

                if (int.TryParse(tbFilter.Text, out int id))
                {
                    var dataTable = await clsPersonService.GetAllPeopleByID(id);
                    LoadFilterdDataTable(dataTable);
                }
            }

            // Clear error when a valid key is pressed
            else
            {
                e.Handled = false;
                epFilter.SetError(tbFilter, "");

            }
        }
        private async void PersonNameBoxFilter(object sender, KeyPressEventArgs e)
        {

            if (!ValidationUtility.IsValidNameCharacter(e.KeyChar,out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }
            else if (tbFilter.Text.Length > 15)
            {
                // Show error icon and tooltip
                epFilter.SetError(tbFilter, "Maximum length is 15 char.");
                tbFilter.Focus();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                string Filter = cbFilter.SelectedItem as string;
                Filter = Filter.ToLower();

                if (Filter == "first name")          
                    LoadFilterdDataTable(await clsPersonService.GetAllPeopleByFirstName(tbFilter.Text));            
                else if (Filter == "second name")
                    LoadFilterdDataTable(await clsPersonService.GetAllPeopleBySecondName(tbFilter.Text));
                else if (Filter == "third name")
                    LoadFilterdDataTable(await clsPersonService.GetAllPeopleByThirdName(tbFilter.Text));
                else
                    LoadFilterdDataTable(await clsPersonService.GetAllPeopleByLastName(tbFilter.Text));
            }
            else
            {
                // Clear error when a valid key is pressed
                epFilter.SetError(tbFilter, "");
                e.Handled = false;

            }
       
        }
        private async void PersonNationalityBoxFilter(object sender, KeyPressEventArgs e)
        {
            if (!ValidationUtility.IsValidCountry(cbNationlity.SelectedItem as string,out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(cbNationlity, errorMessage);
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                LoadFilterdDataTable(await clsPersonService.GetAllPeopleByNationality(tbFilter.Text));//Load database by Country

            }
            else
            {
                // Clear error when a valid key is pressed
                e.Handled = false;
                epFilter.SetError(cbNationlity, "");
            }

        }
        private async void PersonPhoneNumberBoxFilter(object sender, KeyPressEventArgs e)
        {
            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidPhoneNumberCharater(e.KeyChar,out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                LoadFilterdDataTable(await clsPersonService.GetAllPeopleByPhoneNumber(tbFilter.Text));//Load database by phoneNumber

            }
            else
            {
                // Clear error when a valid key is pressed
                e.Handled = false;
                epFilter.SetError(tbFilter, "");
            }

        }
        private async void PersonNationalnumberBoxFilter(object sender, KeyPressEventArgs e)
        {
            // Check if the entered key is a symbol
            if (!ValidationUtility.IsValidNationalNoCharater(e.KeyChar,out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                LoadFilterdDataTable(await clsPersonService.GetAllPeopleByNationalNumber(tbFilter.Text));//Load database by nationalNo.

            }
            else
            {
                // Clear error when a valid key is pressed
                epFilter.SetError(tbFilter, "");
            }
        }
        private async void cbNationlity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNationlity.SelectedItem != null&&cbNationlity.SelectedIndex!=0)
            {
                DataRowView dataRowView = (DataRowView)cbNationlity.SelectedItem;
                string country = dataRowView["Name"].ToString().Trim();

                LoadFilterdDataTable(await clsPersonService.GetAllPeopleByNationality(country));
            }
        }
        private async void rbtnFemale_Click(object sender, EventArgs e)
        { 
            var genderFilteredData = await clsPersonService.GetAllPeopleByGender('f');
            LoadFilterdDataTable(genderFilteredData);
        }
        private async void rbtnMale_Click(object sender, EventArgs e)
        {
            var genderFilteredData = await clsPersonService.GetAllPeopleByGender('m');
            LoadFilterdDataTable(genderFilteredData);
        }
        public  void filterBasedOn(string Filter)
        {
            ResetVisibilityAndEventHandlers();
            switch (Filter.ToLower())
            {
                case "personid":
                    {
                        tbFilter.Visible = true;
                        tbFilter.KeyPress += PersonIDBoxFilter; // Attach the event handler
                        tbFilter.KeyPress += tbFilter_TextChanged;
                        break;
                    }
              
                case "first name":
                    {
                        tbFilter.Visible = true;
                        tbFilter.KeyPress += PersonNameBoxFilter; // Attach the event handler
                        break;
                    }
              
                case "second name":
                    {
                        tbFilter.Visible = true;
                        tbFilter.KeyPress += PersonNameBoxFilter; // Attach the event handler
                        break;
                    }
             
                case "third name":
                    {
                        tbFilter.Visible = true;
                        tbFilter.KeyPress += PersonNameBoxFilter; // Attach the event handler
                        break;
                    }
             
                case "last name":
                    {
                        tbFilter.Visible = true;
                        tbFilter.KeyPress += PersonNameBoxFilter; // Attach the event handler
                        break;
                    }
                
                case "nationality":
                    {
                        cbNationlity.Visible = true;
                        _loadCountries();
                        break;
                    }
               
                case "email":
                    {

                        tbFilter.Visible = true;
                        break;
                    }
            
                case "phone":
                    {

                        tbFilter.Visible = true;
                        tbFilter.KeyPress += PersonPhoneNumberBoxFilter; // Attach the event handler
                        break;
                    }

                case "national no":
                    {
                        tbFilter.Visible = true;
                        tbFilter.KeyPress += PersonNationalnumberBoxFilter;
                        break;
                    }

                case "gender":
                    {
                        gbGender.Visible = true;        
                        break;
                    }

                default:
                    {
                        InitialSettings();
                        break;
                    }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetComboFilter();
            string Filter = cbFilter.SelectedItem as string;
            filterBasedOn(Filter);
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form form = new frmAddEditPerson();
            form.ShowDialog();
            resetForm();

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvPeople.SelectedRows.Count > 0)
            {

                int rowIdx= dgvPeople.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow= dgvPeople.Rows[rowIdx];

                try
                {
                    if (int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int ID)){

                        Form form = new frmAddEditPerson(ID);
                        form.ShowDialog();
                    }
                }
                catch(Exception ex){
                    Console.WriteLine(ex.Message);
                }

            }
            resetForm();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var confirmResult = MessageBox.Show("Are you sure to delete selected records?",
                "Confirm Delete", MessageBoxButtons.YesNo);

            if(confirmResult == DialogResult.Yes)
            {

            if (dgvPeople.SelectedRows.Count > 0)
            {
               List<int>IDs= new List<int>();

                foreach (DataGridViewRow selectedRow in dgvPeople.SelectedRows)
                {
                    try
                    {
                        if (int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int ID))
                        {
                                if (clsPersonService.IsExist(ID))
                                {
                                    IDs.Add(ID);
                                }
                                else
                                {
                                    continue;
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                if(IDs.Count > 0)
                    {
                        _DeletePerson(ref IDs);
                        resetForm();
                    }
                
            }

            }
            else 
            { 
                return; 
            }

        }
        private void _DeletePerson(ref List<int> IDs)
        {

            if (!clsPersonService.DeletePerson(ref IDs))
                MessageBox.Show($"Person  didn't delete successfully ", "error",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);


        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvPeople.SelectedRows.Count ==1) {
            
                DataGridViewRow selectedRow = dgvPeople.SelectedRows[0];

                try
                {
                    if (int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int ID))
                    {

                        frmPersonDetails form = new frmPersonDetails(ID);
                        subsribeToEvent(ref form);
                        form.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        private void subsribeToEvent(ref frmPersonDetails form) {

            form.evUpdatedPerson += Form_evUpdatedPerson;
        }
        private void Form_evUpdatedPerson(object sender, EventArgs e)
        {
            resetForm();
        }
        private void MangePeopleForm_Load(object sender, EventArgs e)
        {

        }
    }

    }


