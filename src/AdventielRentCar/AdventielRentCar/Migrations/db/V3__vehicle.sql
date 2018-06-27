create table vehicle (
	id integer primary key autoincrement,
	manufacturer TEXT not null,
	model TEXT not null,
	description TEXT,
	licence_plate TEXT not null, 
	mileage INT not null,
	vintage INT not null
);

create unique index ix1_vehicle on vehicle (licence_plate);

insert into vehicle (manufacturer, model, description, licence_plate, mileage, vintage ) values ('Kia', 'Carens', null, 'YR-465-LR', 59352, 201406);
insert into vehicle (manufacturer, model, description, licence_plate, mileage, vintage ) values ('Hyundai', 'i30', null, 'YU-465-LR', 96123, 201204);
