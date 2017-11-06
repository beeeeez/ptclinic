using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClinic
{
    class PatientInfo
    {
        // Private variables only the class can access.

        // Patient variables
        private string fName;
        private string mInitial;
        private string lName;
        private string gender;
        private DateTime dob;
        private string address;
        private string address2;
        private string city;
        private string state;
        private string zip;
        // Unsure if this should be string or boolean
        private Boolean hasInsurance;
        private string insurer;
        private string otherInsurance;
        private string phone;
        private string phoneExtension;
        private string phoneType;
        private string phone2;
        private string phone2Extension;
        private string phone2Type;
        // Unsure if this should be string or boolean.
        private Boolean leaveMessage;
        private string email;

        /* 
         * Caregiver given own class
         * since it has its own table in the Database
         * 
         */

        // Creating the public variables that are the front end to the private variables

        // Public variable specifically for First Name
        public string Fname
        {
            get { return fName; }
            set
            {
                // TODO -- error handling goes here?
                fName = value;
            }
        }

        // Public variable specifically for Middle Initial
        public string MInitial
        {
            get { return mInitial; }
            set
            {
                // TODO -- error handling goes here? (or we could limit the character value of the textbox for only 1 character)
                mInitial = value;
            }
        }

        // Public variable specifically for Last Name
        public string Lname
        {
            get { return lName; }
            set
            {
                // TODO -- error handling goes here~
                lName = value;
            }
        }

        // Public variable specifically for Gender
        public string Gender
        {
            get { return gender; }
            set
            {
                // TODO -- error handling goes here~
                gender = value;
            }
        }

        //Public variable for Date of Birth
        public DateTime Birthdate
        {
            get { return dob; }
            set { dob = value; }
        }

        // Public variable specifically for Address
        public string Address
        {
            get { return address; }
            set
            {
                // TODO -- error handling goes here?
                address = value;
            }
        }

        // Public variable specifically for Address2
        public string Address2
        {
            get { return address2; }
            set
            {
                // TODO -- error handling goes here?
                address2 = value;
            }
        }

        // Public variable specifically for City
        public string City
        {
            get { return city; }
            set
            {
                // TODO -- error handling goes here?
                city = value;
            }
        }

        // Public variable specifically for State
        public string State
        {
            get { return state; }
            set
            {
                // TODO -- error handling goes here?
                state = value;
            }
        }

        // Public variable specifically for Zipcode
        public string Zip
        {
            get { return zip; }
            set
            {
                // TODO -- error handling goes here?
                zip = value;
            }
        }

        // Public variable specifically for HasInsurance
        // May change?
        public Boolean HasInsurance
        {
            get { return hasInsurance; }
            set
            {
                hasInsurance = value;
            }
        }

        // Public variable specifically for Insurer
        public string Insurer
        {
            get { return insurer; }
            set
            {
                // TODO >> is validation needed here?
                // Can we make a "select one" in the dropdown disabled?
                insurer = value;
            }
        }

        // Public variable specifically for OtherInsurance
        public string OtherInsurance
        {
            get { return otherInsurance; }
            set
            {
                // TODO >> is validation needed here?
                // Since they may have an insurance provided in the drop down.
                otherInsurance = value;
            }
        }

        // Public variable specifically for Phone
        public string Phone
        {
            get { return phone; }
            set
            {
                // TODO -- error handling goes here?
                phone = value;
            }
        }

        // Public variable specifically for Phone Extension
        public string PhoneExtension
        {
            get { return phoneExtension; }
            set
            {
                // TODO -- error handling goes here?
                phoneExtension = value;
            }
        }

        // Public variable specifically for Phone Type
        public string PhoneType
        {
            get { return phoneType; }
            set
            {
                // TODO -- error handling goes here?
                phoneType = value;
            }
        }

        // Public variable specifically for Phone2
        public string Phone2
        {
            get { return phone2; }
            set
            {
                // TODO -- error handling goes here?
                phone2 = value;
            }
        }

        // Public variable specifically for Phone2 Extension
        public string Phone2Extension
        {
            get { return phone2Extension; }
            set
            {
                // TODO -- error handling goes here?
                phone2Extension = value;
            }
        }

        // Public variable specifically for Phone2 Type
        public string Phone2Type
        {
            get { return phone2Type; }
            set
            {
                // TODO -- error handling goes here?
                phone2Type = value;
            }
        }
        
        // Public variable for LeaveMessage
        public Boolean LeaveMessage
        {
            get { return leaveMessage; }
            set
            {
                leaveMessage = value;
            }
        }

        // Public variable specifically for Email
        public string Email
        {
            get { return email; }
            set
            {
                // TODO >> Email validation here--
                email = value;
            }
        }


    } // End of PatientInfo
}
