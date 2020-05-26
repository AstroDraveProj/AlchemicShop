-- astroUser
CREATE LOGIN astroUser WITH PASSWORD = 'qwerty';

CREATE USER astroUser FOR LOGIN astroUser;

--adminUser
CREATE LOGIN adminUser WITH PASSWORD = '123456';

CREATE USER adminUser FOR LOGIN  adminUser;

drop login astroUser

drop user astroUser