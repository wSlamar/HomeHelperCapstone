select * from home h
left join milestones m on h.home_id = m.home_id
left join vendor v on m.home_id = v.home_id


INSERT INTO home (user_id, description, type, street_address, city, state, zip, nickname)
	VALUES (3, 'A small little place on the lake', 'Apartment', '1234 Adams St', 'Huntington', 'TN', '44657', 'Smoky Mountain')
insert into milestones (home_id, build_year, purchase_date) VALUEs (7, 2020, 2020)
insert into vendor (home_id, vendor_name, phone, email, specialty, notes) VALUEs (7, 'Mike', '333-333-4456', 'mike@mike.com', 'Masonry', 'Really fast respond')
insert into store (home_id, store_name, phone, notes) VALUEs (7, 'Home Depot', '440-440-4400', 'Great neighborhood store')

select * from milestones
select * from vendor
select * from store

delete from store where store_id = 2





update repairs
set name = 'Ceiling', description = 'Get rid of the "popcorn" celing'
where repair_id = 3

select * from repairs

DELETE milestones WHERE home_id = 2
Delete vendor where home_id=2
Delete store where home_id=2

DELETE home WHERE home_id = 2 AND user_id = 3

select * from reminders

update reminders set completed = 0