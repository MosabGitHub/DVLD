using PersonClass;
using PersonServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class PersonInfoCtrl : UserControl
    {
        clsPersonService clsPersonService = new clsPersonService(clsPersonService.Mode.AddNew);
      
        public event EventHandler PersonUpdated;

        private int _ID = -1;
        public PersonInfoCtrl(int PersonID)
        {
            InitializeComponent();
            _ID = PersonID;
            _loadPersonInfo();
        }
        private void _fillData(clsPerson person)
        {
            lbID.Text= person.ID.ToString();
            lbName.Text = person.FullName;
            lbNationalNo.Text = person.NationalNumber;
            lbGender.Text = person.Gender.ToString();
            lbEmail.Text = person.Email.Trim();
            lbAddress.Text = person.Address;
            lbBirth.Text=person.Birth.ToString();
            lbPhone.Text = person.PhoneNumber;
            lbCountry.Text = person.Nationality;
            if (!string.IsNullOrEmpty(person.PersonImagePath) && File.Exists(person.PersonImagePath))
            {
                pbPersonImage.Image = Image.FromFile(person.PersonImagePath);
                pbPersonImage.Tag= person.PersonImagePath;
            }
      


        }
        private void _loadPersonInfo()
        {
            clsPerson person = clsPersonService.Find(_ID);

            if (person != null)
            {
                _fillData(person);

            }
            else
            {
                _ID = -1;
                return;
            }
        }
        private void subscribeToTheEvent(ref frmAddEditPerson form)
        {
            form.evPersonUpdated += OnUpdated;
        }
        protected virtual void OnUpdated(object sender,bool isUpdated)
        {
            if(isUpdated)
            PersonUpdated?.Invoke(this, EventArgs.Empty);

        }
        private void lbEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson form = new frmAddEditPerson(_ID);
            subscribeToTheEvent(ref form);
            form.ShowDialog();
            _loadPersonInfo();

        }

    }
}
