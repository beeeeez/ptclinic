# PTClinic

## Project Todos
- Please make the Evaluation Visit printable. **WIP - Format issues**
- Once the Follow Up form is saved, please make it visible by other users (not editable, but just viewable) **WIP**
  - Pull visit data `WHERE patient_id = @ID AND visit_date = @VisitDate` and populate view only fields
- Update tab index on followup visit form
- Update tab index on patient demographic
- **Test the program!**
- **Clear out DB - Make copy of empty DB to have on standby / future**
- Think about making a guide to help other people control the program in the future with relation to using the program in another setting without having to have us "set up the DB". Instruct how to add an empty (new) `PTCLinic.accdb` file. 



### COMPLETED UPDATES 
- [x] For the Appointment section, just allow another address possible: 1240 Park Avenue Cranston, RI  
- [x] For “Constant attendance” please remove option CPT 97036.
- [x] Remove the “Unselected Therapeutic Procedure” field.
- [x] Remove the “Follow up treatment” field at the bottom.
- [x] For the “Provider ID” they want to keep the field, but rename it as “PT of Record”, which is usual in the field.
- [x] Since we already removed the fields “Diagnose”, and merged it with “Medical history” and moved the “Medications” to the Demographics section, those fields will NOT appear here.
- [x] For the “Patient Visit Information” screen, which is the first visit that appears when you create a patient, please call it “PT Evaluation” – we think it is clear this way. Also,
- [x] Add the fields a) Medical History/Diagnosis, and b) Medications to be entered after the Demographics information. Maybe it would be to add another screen after the Emergency Contact and Caregiver Name info.  The goal is to get someone to enter that info from the agency’s records when they create a new patient record.
- [x] The second request related to this is to make these 2 fields above appear on the “Patient Profile” screen, under Diagnosis and PT Goals. See the attachment for clarification.
- [x] On the Emergency Contact and Caregiver name, make the address and information optional. Not everyone has all the info and the agency thinks the Caregiver in this situation is the nurse from APRI, so no need to track all of the info.
- [x] For the Demographic screen, allow 2 addresses. One address maybe the one at the site the patient is seen, but from time to time the PT will go to the patient’s home, and in that case an address would be needed.
- [x] For the “Therapeutic Procedures (15 minutes each)” they would like to modify the choices because they could use the same choice more than once, and they also need the number of units. I think in the end we are looking at something like this:
 97110 Therapeutic Ex                        Units:    1           2          3             4
  97112 Neuromuscular Re-ed            Units:    1           2          3             4
- [x] Repeat the “Therapeutic Procedures” changes detailed in literal e) above.
- [x] Include a new field to enter “Visit date” at the beginning of the form.  The PTs say that even though the database has an automatic date, it is important to have a “visit date”, and have the ability to do data entry after the visit took place.
- [x] Add a “Date of Service” at the beginning of the form. (Sometimes this form is filled out after the visit, so they need the flexibility to data enter a past visit, so the date should allow entering a past date.
- [x] Remove the “Patient Re-assessment next visit?” field and the “Need to complete PSFS” field.
- [x] Make sure that everyone can VIEW everything on the patient (not edit, just view).
- [x] Remove the ‘Unselected Therapeutic Procedure” field.
- [x] Allow to SAVE the information (not sure the “is the form complete” is needed…..)
- [x] Since this will be the second visit, after the Evaluation visit is complete, we’d like to see if we can transfer the “PT of Record” name to this form in the place of the “Provider ID” field.
- [x] Please make the font on the forms larger than it is now – we are getting old and need larger font 

### Intial Visit Form
- [x] Add spacing at bottom of form so you can actually scroll a bit down, and aren't right up on the bottom of the panel.
- [x] Adds to the Patient Info table which visit it is
- [x] Set form window to scrollable for smaller size windows
- [x] Seperate box for Assessment
- [x] Put new box for DME (Durable Medical Equipment) put under Medical History
- [x] Put new box for DME Needs under Treatment Plan
- [x] Get Assessment, DME, and DME needs adding to the DB
- [x] Update flow of forms - remove automatic PSFS form load after successful visit save
- [x] Drop down menu under PT Diagnosis where they can select more than one option
- [x] Add save if they X out of form
- [x] Add save/update ability so they can save and come back to form later
- [x] Add save/update ability when they click Home or Logout Buttons

### Follow Up Visit Form
- [x] Based on Visit Type change label of forms to their respective text ex: 'Re-assessment Visit' , 'Follow Up Visit'
- [x] Add button to get to PSFS form (if it needs to be filled out) if it doesn't just have a NO label populate
- [x] Fix the missing validation in FollowUpVisit class
- [x] Set form window to scrollable for smaller size windows
- [x] Change Visit Type in Patient Information Table when Follow Up Form adds a record to DB
- [x] Follow Up Visit Class - Constructor + DB functionality 
- [x] Get rid of discharge button
- [x] Make what is pulled over from Initial Visit uneditable
- [x] Add Section for displaying information selected in the new multi-select Drop Down Menu on the Initial Visit Form
- [x] Update flow of forms - remove automatic PSFS form load after successful follow-visit save
- [x] Get Multi-Select Section displaying Information from the multi-select dropdown on the Initial Visit Form
- [x] Add save if they X out of form
- [x] Add save/update ability so they can save and come back to form later 
- [x] Add save/update ability when they click Home or Logout Buttons

### Patient Profile Form
- [x] Print patient info capability
- [x] Set Patient Visit button to go to correct Form based off patient status
- [x] Pull Diagnosis from Initial Visit DB Table - populate field
- [x] Pull Patient Goals from Initial Visit DB Table - populate field
- [x] Add Panel Label to Display when PSFS needs to be updated (pull Patient Goals last update time and calculate 30 days)
- [x] **Patient Class** Update statement

### Patient Information Form
- [x] Get working functionality to Update for patient information 
- [x] Add patient status when new patient is added 
- [x] Add button to make Caregiver name / 1st phone number the same as the Emergency Contact

### Patient Goals
- [x] PT Goals pull last updated goals
- [x] Change bottom box to 'Notes & Observations'
- [x] Add a drop down box after every score 'Score Interpreted By: '  -dropdown options 'Patient, Caregiver, Provider'
- [x] Add Score Interpreted to DB, and check that it's saving
- [x] Add error checking to Score Interpreted Field


### Schedule Appointment Form
- [x] Print Appointment Details capability
- [x] Make Appointment class to handle validation and calls
- [x] Add option to select which of the two clinics the appointment is at

### Finalization TODO's
- Get rid of the spaghetti code involving sending multiple forms over to other forms.
- Backup DB **In Progress**
- Check tab indexes
- Check validation


#### Extras
- Backup DB

