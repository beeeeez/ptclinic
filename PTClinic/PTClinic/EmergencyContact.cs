using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClinic
{
    class EmergencyContact
    {
        private string fullname;
        private string phone;
        private string phoneExtension;
        private string phoneType;
        private string relationship;
        private string feedback;

        public virtual string Feedback
        {
            get { return feedback; }

        }


        public string Fullname
        {
            get { return fullname; }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Enter Emergency Contact Name\n";
                }
                else
                {
                    fullname = value;
                }

            }
        }

        // Public variable for Emegerncy Contact Phone
        public string Phone
        {
            get { return phone; }
            set
            {
                if (string.IsNullOrEmpty(value) || Validation.IsValidLength(value, 14))
                {
                    feedback += "Error: Enter Emergency Contact Phone\n";
                }
                else
                {
                    phone = value;
                }

            }
        }

        // Public variable specifically for Emegerncy Contact Phone Extension
        public string PhoneExtension
        {
            get { return phoneExtension; }
            set
            {
                phoneExtension = value;
            }
        }

        // Public variable specifically for Emegerncy Contact Phone Type
        public string PhoneType
        {
            get { return phoneType; }
            set
            {
                if (value.Equals("Select One"))
                {
                    feedback += "Error: Select Emergency Contact Phone Type\n";
                }
                else
                {
                    phoneType = value;
                }

            }
        }


        public string Relationship
        {
            get { return relationship; }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Enter Emergency Contact Relationship\n";
                }
                else
                {
                    relationship = value;
                }

            }
        }


        public EmergencyContact()
        {
            fullname = "";
            phone = "";
            phoneExtension = "";
            phoneType = "";
            relationship = "";
            feedback = "";
        }

        public EmergencyContact(string fullname, string phone, string phoneExtension, string phoneType, string relationship)
        {
            Fullname = fullname;
            Phone = phone;
            PhoneExtension = phoneExtension;
            PhoneType = phoneType;
            Relationship = relationship;
            feedback = "";

        }


    }
}
