# PTClinic

## Project Todos

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

