USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
	username varchar(50) NOT NULL,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	email varchar(50) NOT NULL,
	phone varchar(20) NOT NULL,
	billing_street_address varchar(200) NOT NULL,
	billing_city varchar(50) NOT NULL,
	billing_state varchar(50) NOT NULL,
	billing_zip varchar(5) NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)
CREATE TABLE home (
	home_id int IDENTITY(1, 1) NOT NULL,
	user_id int NOT NULL,
	description varchar(1000) NOT NULL,
	type varchar (50) NOT NULL,
	nickname varchar (50),
	street_address varchar(200) NOT NULL,
	city varchar(50) NOT NULL,
	state varchar(50) NOT NULL,
	zip varchar(5) NOT NULL,
	pic_url varchar(400),
	CONSTRAINT PK_home PRIMARY KEY (home_id),
	FOREIGN KEY (user_id) REFERENCES users(user_id)
)
CREATE TABLE userHome (
	home_id int NOT NULL,
	user_id int NOT NULL,
	FOREIGN KEY (user_id) REFERENCES users(user_id),
	FOREIGN KEY (home_id) REFERENCES home(home_id)
)
CREATE TABLE milestones (
	home_id int NOT NULL,
	build_year int,
	purchase_date int,
	FOREIGN KEY (home_id) REFERENCES home(home_id)
)
CREATE TABLE repairs (
	repair_id int IDENTITY(1,1) NOT NULL,
	home_id int NOT NULL,
	user_id int NOT NULL,
	name varchar(80),
	projected_cost money,
	cost money,
	last_repair_date date,
	expected_life int,
	potential_replacement_date date,
	description varchar (1000),
	CONSTRAINT PK_repairs PRIMARY KEY (repair_id),
	FOREIGN KEY (home_id) REFERENCES home(home_id),
	FOREIGN KEY (user_id) REFERENCES users(user_id)
)
CREATE TABLE appliance (
	appliance_id int IDENTITY(1,1) NOT NULL,
	home_id int NOT NULL,
	user_id int NOT NULL,
	name varchar(80) NOT NULL,
	make varchar(80),
	purchase_date date,
	cost money,
	model_number varchar(80),
	serial_number varchar(80),
	warranty_expiration date,
	description varchar(1000),
	estimated_delivery date,
	delivery_date date,
	receipt_url varchar(400),
	CONSTRAINT PK_appliance PRIMARY KEY (appliance_id),
	FOREIGN KEY (home_id) REFERENCES home(home_id),
	FOREIGN KEY (user_id) REFERENCES users(user_id)
)
CREATE TABLE vendor (
	service_id int IDENTITY(1,1) NOT NULL,
	home_id int NOT NULL,
	vendor_name varchar(80),
	phone varchar(20),
	email varchar(50),
	specialty varchar(50),
	notes varchar(1000),
	CONSTRAINT PK_vendor PRIMARY KEY (service_id),
	FOREIGN KEY (home_id) REFERENCES home(home_id)
)

CREATE TABLE store (
	store_id int IDENTITY(1,1) NOT NULL,
	home_id int NOT NULL,
	store_name varchar(50),
	phone varchar(20),
	notes varchar(1000),
	CONSTRAINT PK_store PRIMARY KEY (store_id),
	FOREIGN KEY (home_id) REFERENCES home(home_id)
)

CREATE TABLE reminders (
	home_id int NOT NULL,
	user_id int Not Null,
	repair_id int NULL,
	appliance_id int NULL,
	type varchar(50),
	name varchar(50),
	reminder_date date,
	completed bit default 0,
	FOREIGN KEY (home_id) REFERENCES home(home_id),
	FOREIGN KEY (user_id) REFERENCES users(user_id),
	FOREIGN KEY (repair_id) REFERENCES repairs(repair_id),
	FOREIGN KEY (appliance_id) REFERENCES appliance(appliance_id)
)



--populate default data
INSERT INTO users (username, password_hash, salt, user_role, first_name, last_name, email, phone, billing_street_address, billing_city, billing_state, billing_zip) 
VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'Default', 'User', 'user@gmail.com', '111-222-3333', '1234 Adams St', 'Sandusky', 'OH', '44870');

INSERT INTO users (username, password_hash, salt, user_role, first_name, last_name, email, phone, billing_street_address, billing_city, billing_state, billing_zip) 
VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 'Default', 'Admin', 'admin@gmail.com', '444-555-6666', '4321 Apple St', 'Norwalk', 'TN', '44567');

GO