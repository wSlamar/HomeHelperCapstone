/* DUMMY DATA */

/* ADD A NEW USER */

INSERT INTO users (username, password_hash, salt, user_role, first_name, last_name, email, phone, billing_street_address, billing_city, billing_state, billing_zip)
	VALUES ('wlamar', 'Jg45HuwT7PZkfuKTz6IB90CtWY4=', 'LHxP4Xh7bN0=', 'user', 'William', 'Lamar', 'wlamar@gmail.com', '431-546-1982', '1234 Walter Ave', 'Wooster', 'OH', '44820')

/* ADD A NEW HOME FOR OUR USER */

INSERT INTO home (user_id, description, type, street_address, city, state, zip)
	VALUES (1, 'A small little place on the lake', 'Apartment', '1234 Adams St', 'Huntington', 'TN', '44657')

			/* This below will also have to be inserted incase a user has another home */

			INSERT INTO userHome(user_id, home_id)
				VALUES (3, 1)

/* ADD A MILESTONE FOR OUR NEW USER */

INSERT INTO milestones (home_id, build_year, purchase_date)
	VALUES (1, 2001, 2002)

/* ADD A REPAIR FOR OUR NEW USER */

INSERT INTO repairs (home_id, user_id, name, projected_cost, cost, last_repair_date, expected_life, potential_replacement_date, description)
	VALUES (1, 1, 'Washing Machine', 100, 250, '02/03/1999', 3, '02/03/2020', 'Sump Pump needed fixed.')

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
	VALUES (1, 3, 'Washing Machine', '12/9/2020', 325, 'BNJUBGU-4343', '24362235', '02/04/2020', 'It washes my shirts', '12/12/2020', '12/11/2020')

/* JOIN OUR NEW USER TO FIND THEIR APPLIANCE NAME AND COST*/

select u.username, a.name, a.cost
	from users u
	JOIN home h on h.user_id = u.user_id
	JOIN appliance a on a.home_id = h.home_id
	where u.user_id = 3

/* ADD AN APPLIANCE FOR OUR NEW USER */

INSERT INTO appliance(home_id, user_id, name, make, purchase_date, cost, model_number, serial_number, warranty_expiration, description, estimated_delivery, delivery_date, receipt_url)
	VALUES (1, 1, 'Dish Washer', 'GE', '02/29/2020', 235, 'NNDLO-423', '453354', '02/04/2020', 'It will clean my dishes', '03/04/2020', '03/03/2020', 'www.google.com')

/* UPDATE OUR USERS NEW USERS APPLIANCE DELIVERY DATE */

UPDATE appliance set delivery_date = '03/05/2021' where appliance_id = 2

delete appliance where appliance_id = 6

/* QUICK SELECTS */

delete repairs where repair_id = 2


select * from vendor v JOIN appliance a on a.home_id = v.home_id JOIN home h on h.home_id = a.home_id where a.appliance_id = 2

INSERT into store(home_id, store_name, phone, notes) VALUES(1, 'yes', '4334', 'gsadsagsda');

INSERT into store(home_id, store_name, phone, notes)
	VALUES (1, 'Lowes', '444-555-6666', 'Good Store')

	DELETE reminders where appliance_id = 6; DELETE appliance where user_id = 1 AND appliance_id = 6


	DELETE reminders where appliance_id = @appliance_id; DELETE appliance where user_id = @user_id AND appliance_id = @appliance_id
	
	insert into reminders(home_id, user_id, appliance_id)
		values (1, 1, 7)
	

--	select * 
--	from home h
--	join reminder r on r.home_id = h.home_id
--	where user_id = @user_id  and r.compeleted is NULL

--	select *  from home h join reminder r on r.home_id = h.home_id where user_id = @user_id  and r.compeleted is NULL and r.date between DATEADD(DAY, -30, GETDATE())and DATEADD(DAY, 30, GETDATE())

--	UPDATE reminders set completed = 1 where user_id = @user_id and repair_id = @repair_id and appliance_id = @appliance_id


--select * from home h join reminders r on r.home_id = h.home_id where h.home_id = 1 and r.completed is null and (r.reminder_date BETWEEN DATEADD(DAY, 30, GETDATE())and DATEADD(DAY, 30, GETDATE())

--	select *  from home h join reminders r on r.home_id = h.home_id where r.user_id = 3  and r.completed is NULL and (r.reminder_date = GETDATE()) AND GETDATE() +30) 

Update repairs set name = @name, projected_cost = @projected_cost, cost = @cost, last_repair_date = @last_repair_date, expected_life = @expected_life, 
potential_replacement_date = @potential_replacement_date , description = @description where repair_id = @repair_id; UPDATE reminders set name = @name where repair_id = @repair_id

Update repairs set name = 'Dryer', projected_cost = 100, cost = 200, last_repair_date = '12/20/2020', expected_life = 5, 
potential_replacement_date = '12/23/2020', description = 'good dryer' where repair_id = 5; UPDATE reminders set name = 'Dryer' where repair_id = 5

select * from users
select * from userHome
select * from repairs
select * from milestones
select * from home
select * from appliance
select * from vendor
Select * from reminders