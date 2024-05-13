using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonClass;
namespace DVLD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NationalNumber = "N1",
                   First = "Mohamed",
                   second = "Hatim",
                   third = "samar",
                   Last = "ibrahim",
                   PhoneNumber = "0780842828",
                   Email = "M@gamil.com",
                   Address = "No address",
                   Nationality = "Jordanian",
                   PersonalImagePath = "";
            DateTime birth = new DateTime(2001, 2, 5);
            char Gender = 'M';

            clsPerson person = new clsPerson(NationalNumber, First, second,third, Last, Gender, birth,
                PhoneNumber, Email,Address, Nationality, PersonalImagePath);

            //if (person.save())
            //{
            //    MessageBox.Show($"Data saved successfully with ID: {person.ID}","Information",MessageBoxButtons.OK);
            //}
            //else
            //{
            //    MessageBox.Show("Couldn't add a new person","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        //private void btnFindPerson_Click(object sender, EventArgs e)
        //{
        //    int ID = 1;
        //    if(clsPerson.IsExist(ID))
        //    {
        //        //Delete 
        //        if (clsPerson.DeletePerson(ID))
        //        {
        //            MessageBox.Show("It was deleted succesffuly", "Info", MessageBoxButtons.OK);
        //        }
        //        else
        //        {
        //            MessageBox.Show("error","error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        //        }
        //    }
          

        //}

    }
}
