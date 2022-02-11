# LeaveRequest App
# Project Description

This is a Microsoft Dynamics CRM Power Apps Canvas application in which a user can register for an account and request time off from their assigned manager. The request includes relevant information such as time off reason category, start and end dates, and available time. User time is accrued incrementally at different rates for different departments. Manager-Administrators are automatically alerted by email of the request by their subordinates and have the ability to log in and approve or reject the request along with a message. All data is stored on the backend with an integrated SharePoint database.

# Technologies Used
Microsoft Powerapps 
Microsoft Sharepoint

# Features

* Create an account and login 
* Take real time photos using your webcam to use as a profile picture
* Update or upload pictures after registration and loging in
* Create a leave request that will email the manager selected with information about your request 
* Manager/Admin Login contains more features than general employee login 
* Manager can check status of all the employees 
* Manager can edit information of all the employee using an employee list of all registered employees
* Employee list and Status list can be filtered by name using search bar 
* Manager can accept or decline any pending leave requests that are directed to them
* Employee will be notified via email that their leave request had been accepted or declined. 
* Manager can filter leave requests based on ones that have been accepted/declined by them or pending for them
* Status details will give more information on the leave request if the leave request card has been selected

# To-do list:

* Improve overall design of the website
* Days off calculator that will notify the user how many days off they have left for the year 
* Popup menu to notify if a leave request has been accepted/declined while they are logged into the app 

# Getting Started
* Download the zip of the app attached to the GitHub
* Log onto Microsoft Powerapps 
* Click on apps on the left hand side
* Click on Import Canvas app 
* Upload the downloaded zip file, rename anything that needs to be renamed
* Go back into apps 
* Go to edit the app 
* Go into data and add data to connect your own outlook and sharepoint lists 
* There should be at least 2 Sharepoint lists a main sharepoint list and one to handle requests 
* Main sharepoint list should contain Title, First Name, Last Name, DOB, Position, Home address, Work Address, Phone Number, Email, Department, Linkedin, UserName, Password, and days off columns.
* Request List should contain Title, CreatedBy, Detail, LeaveType(Choice), From(Date), To(Date), Status(Choice), and Manager columns.
* Refer to the image folder to see screenshots of what the app should look like. 
