select * from users

select * from home



select * from home

select * from repairs

select * from appliance

delete from repairs
where repair_id = 2

INSERT INTO appliance(home_id, user_id, name, purchase_date, cost, model_number, serial_number, warranty_expiration, description, estimated_delivery, delivery_date)
	VALUES (1, 3, 'Washing Machine', '12/9/2020', 325, 'BNJUBGU-4343', '24362235', 2024, 'It washes my shirts', '12/12/2020', '12/11/2020')

delete from home
where home_id = 3