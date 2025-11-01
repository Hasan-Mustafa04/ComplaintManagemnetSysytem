# Complaint Management System (ASP.NET Web Forms)

## Overview
This is a web-based **Complaint Management System** developed using **ASP.NET Web Forms** with C# and SQL Server.  
The system allows **Faculty** to submit complaints, **Admin** to manage and assign complaints, and **IT Staff** to update complaint statuses.

---

## Features

### Faculty
- Register and login
- Submit new complaints
- View status of previously submitted complaints
- Logout securely

### Admin
- Login using admin credentials
- View all complaints
- Assign complaints to IT Staff
- Monitor progress and update remarks

### IT Staff
- Login using IT Staff credentials
- View complaints assigned by Admin
- Update complaint status (Pending, In Progress, Resolved)
- Logout securely

---

## Database

### Users Table
| Field      | Type       | Description                     |
|------------|-----------|---------------------------------|
| UserID     | int (PK)  | Unique ID for user              |
| Username   | varchar   | User’s name                     |
| Password   | varchar   | Encrypted password (SHA256)     |
| Role       | varchar   | 'Admin', 'Faculty', 'ITStaff'   |
| Email      | varchar   | User’s email address             |

### Complaints Table
| Field        | Type       | Description                         |
|--------------|-----------|-------------------------------------|
| ComplaintID  | int (PK)  | Unique complaint ID                  |
| UserID       | int (FK)  | Submitted by (Faculty)              |
| Title        | varchar   | Complaint title                      |
| Description  | text      | Complaint details                    |
| DateSubmitted| datetime  | Date of submission                   |
| Status       | varchar   | 'Pending', 'In Progress', 'Resolved'|
| AssignedTo   | int (FK)  | IT Staff user ID                     |
| Remarks      | varchar   | IT Staff/Admin remarks               |

---

## Default Users (for testing)

| Role      | Username   | Password     | Email                  |
|-----------|-----------|-------------|-----------------------|
| Admin     | admin1    | admin123    | admin@example.com      |
| IT Staff  | itstaff1  | itstaff123  | it1@example.com        |
| IT Staff  | itstaff2  | itstaff123  | it2@example.com        |

> Faculty users can register themselves via the registration page.

---

## Setup Instructions

1. **Clone the Repository**

```bash
git clone https://github.com/Hasan-Mustafa04/ComplaintManagemnetSysytem.git
