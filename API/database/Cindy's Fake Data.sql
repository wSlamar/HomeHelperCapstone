/* DUMMY DATA */

/* ADD A NEW USER */

INSERT INTO users (username, password_hash, salt, user_role, first_name, last_name, email, phone, billing_street_address, billing_city, billing_state, billing_zip)
	VALUES ('test', 'D0j15lxNqebRrXb1lUjMvt0mm88=', 'booNIPr9fF4=', 'user', 'test', 'test', 't@gmail.com', '111-111-1111', '1234 Some Street', 'Cleveland', 'OH', '44118')

/* ADD A NEW HOME FOR OUR USER */

INSERT INTO home (user_id, description, type, street_address, city, state, zip)
	VALUES (1, 'A small little place on the lake', 'Apartment', '1234 Adams St', 'Huntington', 'TN', '44657')

			/* This below will also have to be inserted incase a user has another home */

			INSERT INTO userHome(user_id, home_id)
				VALUES (3, 1)

/* ADD A MILESTONE FOR OUR NEW USER */

INSERT INTO milestones (home_id, build_year, purchase_date)
	VALUES (1, 2001, '02/03/1992')

/* ADD A REPAIR FOR OUR NEW USER */

INSERT INTO repairs (home_id, user_id, projected_cost, cost, description)
	VALUES (1, 3, 100, 250, 'Sump Pump needed fixed.')

/* JOIN OUR NEW USER TO FIND THEIR BUILD YEAR */

select u.username, m.build_year
	from users u
	JOIN home h on h.user_id = u.user_id
	JOIN milestones m on m.home_id = h.home_id
	where u.user_id = 3

/* JOIN OUR NEW USER TO FIND THEIR REPAIRS */

select u.username, r.cost, r.description
	from users u
	JOIN home h on h.user_id = u.user_id
	JOIN repairs r on r.home_id = h.home_id
	where u.user_id = 3

/* JOIN OUR NEW USER TO FIND THEIR ZIP CODE AND USERNAME */

select u.username, zip
	from home h
	JOIN users u on u.user_id = h.user_id
	where h.user_id = 3

/* ADD AN APPLIANCE FOR OUR NEW USER */

INSERT INTO appliance(home_id, user_id, name, purchase_date, cost, model_number, serial_number, warranty_expiration, description, estimated_delivery, delivery_date)
	VALUES (1, 3, 'Washing Machine', '12/9/2020', 325, 'BNJUBGU-4343', '24362235', 'December 2024', 'It washes my shirts', '12/12/2020', '12/11/2020')

/* JOIN OUR NEW USER TO FIND THEIR APPLIANCE NAME AND COST*/

select u.username, a.name, a.cost
	from users u
	JOIN home h on h.user_id = u.user_id
	JOIN appliance a on a.home_id = h.home_id
	where u.user_id = 3

/* ADD AN APPLIANCE FOR OUR NEW USER */

INSERT INTO appliance(home_id, user_id, name, purchase_date, cost, model_number, serial_number, warranty_expiration, description, estimated_delivery)
	VALUES (1, 3, 'Dishwasher', '02/29/2021', 235, 'NNDLO-423', '453354', 'December 2023', 'It will clean my dishes', '03/04/2021')

/* UPDATE OUR USERS NEW USERS APPLIANCE DELIVERY DATE */

UPDATE appliance set delivery_date = '03/05/2021' where appliance_id = 2

/* QUICK SELECTS */

select * from users
select * from userHome
select * from repairs
select * from milestones
select * from home
select * from appliance