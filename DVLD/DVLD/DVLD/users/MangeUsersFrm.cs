using clsUsers;
using DVLD.users;
using PersonServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DVLD
{
    public partial class MangeUsersFrm : Form
    {

        private bool isDataLoadedProperly = false;
        private void _settings()
        {
            if(isDataLoadedProperly)
            dataGridView1.Columns["isActive"].ReadOnly = true;

        }
        public MangeUsersFrm()
        {
            InitializeComponent();
            LoadUsersAsync(); // Call the async method without awaiting, as constructors cannot be async.
        }

        // This is a wrapper to call the async LoadUsers method since constructors cannot be async.
        private void _resetVisibilityAndEventHandlers()
        {

            cbIsActive.Visible = false;
            tbFilter.Visible = false;
            // Detach existing event handlers  cbFilter.KeyPress += cbIsActive_TabIndexChanged;
            tbFilter.KeyPress -= tbIdFilter_KeyPress;
            tbFilter.KeyPress -= tbUserNameFilter_KeyPress;
            tbFilter.KeyPress -= tbPersonIdFilter_KeyPress;
            tbFilter.KeyPress -= tbFullNameFilter_KeyPress;
            cbIsActive.KeyPress -= cbIsActive_SelectedIndexChanged;

        }
        private void _showRecords()
        {
            lbRecord.Text = dataGridView1.Rows.Count.ToString();
        }

        private async void LoadUsersAsync()
        {
            // We don't await here because this is called from the constructor.
            try
            {
                await _loadUsers();
                _settings();
                _showRecords();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as appropriate.
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private async void resetForm()
        {
            await _loadUsers();
        }
        // Changed to async Task for better practice, even though it's a private method.
        private async Task _loadUsers()
        {
            try
            {
                DataTable userDataTable = await clsUserService.GetAllUsers();
                // Now you can use userDataTable as you need, for example, setting it as a DataSource for a DataGridView.
                if(userDataTable.Rows.Count > 0)
                {
                    isDataLoadedProperly = true;
                }
                if (isDataLoadedProperly)
                {
                    dataGridView1.DataSource = userDataTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as appropriate.
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void _userWasUpdateResetForm(object sender ,EventArgs e)
        {
            resetForm();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            addEditNewUserFrm form=new addEditNewUserFrm();
            form.ShowDialog();
            resetForm();
           
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count ==1 ) {

                DataGridViewRow selectedRow=dataGridView1.SelectedRows[0];

                int userID = (int)selectedRow.Cells["ID"].Value;
                
                addEditNewUserFrm form = new addEditNewUserFrm(userID);
                form.evUserUpdated += _userWasUpdateResetForm;
                form.ShowDialog();

            }
            else if (dataGridView1.SelectedRows.Count > 1 || dataGridView1.SelectedRows.Count <1) {
            MessageBox.Show("You need to choose only one row entity to edit","Failed",MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }

        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int userID = (int)selectedRow.Cells["ID"].Value;

                frmShowUserDetails form = new frmShowUserDetails(userID);
                form.ShowDialog();

            }

            else if (dataGridView1.SelectedRows.Count > 1 || dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("You need to choose only one row entity to edit", "Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Hand.Play();
            var confirm=MessageBox.Show("Are you sure you want to delete user(s)", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        List<int> selectedUserIDs = new List<int>();

                        foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                        {

                            int userID = (int)selectedRow.Cells["ID"].Value;

                            selectedUserIDs.Add(userID);

                        }
                        if (deleteUsers(selectedUserIDs))
                            resetForm();

                    }

                    else
                    {
                        MessageBox.Show("You need to choose  a row entity to delete", "Failed", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Couldn't to make the deletion process due, to some problems\n{ex.Message}", "Failed", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                }
            }
        }
        private bool deleteUsers(List<int> userIDs)
        {
            return clsUserService.DeleteUser(userIDs);
        }
        private void _loadFilterdDataTable(DataTable dataTable)
        {
            if(dataTable.Rows.Count>0)
                isDataLoadedProperly = true;
            dataGridView1.DataSource = dataTable;
        }
        private async void _filterData()
        {
            _resetVisibilityAndEventHandlers();//Reset. 

            string filterType= cbFilter.SelectedItem.ToString();
            
            string filterValue= tbFilter.Text;
            
            switch (filterType)
            {

                case "User ID":
                    {
                        tbFilter.KeyPress += tbIdFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }
                case "User Name":
                    {
                        tbFilter.KeyPress += tbUserNameFilter_KeyPress;
                        
                        tbFilter.Visible = true;
                        break;
                    }
                case "Person ID":
                    {
                        tbFilter.KeyPress += tbPersonIdFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }
                case "Full Name":
                    {
                        tbFilter.KeyPress += tbFullNameFilter_KeyPress;
                        tbFilter.Visible = true;
                        break;
                    }
                case "Is Active":
                    {
                        cbFilter.KeyPress += cbIsActive_SelectedIndexChanged;
                        cbIsActive.Visible = true;
                        break;
                    }
                    default://None.
                    {
                        var dataTable = await clsUserService.GetAllUsers();
                        _loadFilterdDataTable(dataTable);
                        break;
                    }
            }

        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filterData();

        }
        private  async void tbIdFilter_KeyPress(object sender, KeyPressEventArgs e)
        {         
            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidIDCharachter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }
       
            else
            {
                epFilter.SetError(tbFilter, "");

                if (int.TryParse(tbFilter.Text+e.KeyChar, out int id))
                {
                    var dataTable = await clsUserService.GetAllUsersByUsersID(id);
                    _loadFilterdDataTable(dataTable);
                }
            }
  
        }
        private async void tbUserNameFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidUserNameCharacter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }

            else
            {
                // Use a small delay to ensure the textbox value is updated
                e.Handled = false;
                epFilter.SetError(tbFilter, "");
                char character = e.KeyChar;
                var dataTable = await clsUserService.GetAllUsersByUserName(tbFilter.Text.Trim()+ character);
                _loadFilterdDataTable(dataTable);
                
            }
        }
        private async void tbPersonIdFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidIDCharachter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }

            else
            {
                e.Handled = false;
                epFilter.SetError(tbFilter, "");

                if (int.TryParse(tbFilter.Text + e.KeyChar, out int personID))
                {
                    var dataTable = await clsUserService.GetAllUsersByPersonID(personID);
                    _loadFilterdDataTable(dataTable);
                }
            }

        }
        private async void tbFullNameFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the entered key is a digit 
            if (!ValidationUtility.IsValidNameCharacter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }

            else
            {
                e.Handled = false;
                epFilter.SetError(tbFilter, "");
                char character = e.KeyChar;

                var dataTable = await clsUserService.GetAllUserByFullName(tbFilter.Text.Trim() + character);


            }
        }     
        private async void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbIsActive.SelectedIndex;
            DataTable dataTable;
            
            
            if (index == 0)//All
            {
                dataTable = await clsUserService.GetAllUserByIsActive(clsUserService.enIsActive.None);//Active & non-Active.
                _loadFilterdDataTable(dataTable);

            }

            else if (index == 1)//No                             
            {
                dataTable = await clsUserService.GetAllUserByIsActive(clsUserService.enIsActive.No);//Non-Active.
                _loadFilterdDataTable(dataTable);

            }

            else if (index == 2)//Yes
            {
                dataTable = await clsUserService.GetAllUserByIsActive(clsUserService.enIsActive.Yes);//Active.
                _loadFilterdDataTable(dataTable);

            }


        }

    
    }
    }

    //Make loading of data like[ paramter %]. keypress. 


