# Hair Salon

#### _View stylists and clients of a hair salon_

#### By _**Katherine Matthews**_

## Description

_This website allows users to enter new stylists that work at a hair salon, as well as new clients of each stylist. Admin can add notes for each client to keep track of clients' needs, etc. Users can also delete and update client information, including which stylist she or he is linked to. https://katherinemat.github.io/salon/_

## Setup/Installation Requirements

#### Create Databases
In SQLCMD:  
    > CREATE DATABASE hair_salon;
    > GO  
    > USE hair_salon;  
    > GO  
    > CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));  
    > GO  
    > CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), name VARCHAR(255), stylist_id INT);  
    > GO

In MSSQL:
1. right-click database > Tasks > Back Up > Ok
- right-click database > Tasks > Restore > Database > in Destination Database replace band_tracker with band_tracker_test > Ok

*_Requires DNU, DNX, MSSQL, and Mono_
* Clone to local machine
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004

## Specifications

Specs:
1. Client's name is correctly added to database; input: Christina; output: Christina
2. User can see all clients in one page; input: See all; output: Christina, Britney, Mariah
3. User can select one client at a time to see information; input: select Mariah; output: Mariah's page
4. Enter a new employee; input: Demi; output: Demi
5. Employees are linked to their clients; input: Kerry; output: Kerry has Britney, Mariah, and Christina
6. View all employees on one page; input: see all; output: Demi, Kerry, Nicole
7. Each employee has her/his own page with list of clients attached; input: Kerry; output: Kerry has Britney, Mariah, and Christina
8. User should be able to link to all pages from each webpage; input: homepage; output: links to add clients, add stylists, delete clients, delete stylists, update client and stylist information, etc.
9. Update client's name; input: Brit -> Britney; output: Britney
10. Delete client from system; input Mariah, delete; output: all clients are Britney and Christina
Icebox:
11. Update stylist information; input: Demi -> De'mi; output: De'mi
12. Delete stylist from system: input: Nicole, delete; output: all stylists are Kerry and Demi
13. Delete all clients from one stylist; input: delete all from Demi; output: Demi has no clients
14. Add phone number information for clients; input: Britney, 123-456-7890; output: Britney, 123-456-7890
15. Add notes section for clients: input: Christina, 098-765-4321, "hair has been dyed many times, be careful using bleach"; output: Christina, 098-765-4321, "hair has been dyed many times, be careful using bleach"
16. Each stylist has her/his own schedule; input: Kerry; output: next Monday at 8am, next Tuesday at 10am, etc.
17. The schedule is also linked to clients; input: Kerry; output: next Tuesday at 10am with Mariah
18. Update time and date of each appointment; input: Kerry with Christina next Tuesday at 10am, Nicole with Christina; output Nicole with Christina next Tuesday at 10am


## Technologies Used

* _C#_
* _SQL_
* _HTML_
* _CSS_

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Katherine Matthews_**
