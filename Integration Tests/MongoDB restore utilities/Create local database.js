// Script for creating a local istance of the database

// It is assumed the database name is "property_wizard"

//### Database and User ###//

// refer to this to create an admin user if you don't have one
// http://www.dba86.com/docs/mongo/2.4/tutorial/add-user-administrator.html


// to create the admin user
use admin
db.createUser({
    user: "pw_user",
    pwd: "pw_1830",
    roles: [{ db: "Property Wizard", role:"userAdminAnyDatabase"}]
});

// authenticate
use admin
db.auth(<username>, <password>)

// create database
use property_wizard

// create user with role "read" and "write"
db.createUser({
    user: "pw_user",
    pwd: "pw_1830",
    roles: [{ db: "property_wizard", role:"read"}]
});


// create indexes

db.getCollection("postcodes").createIndex({code: 1}, {unique: true})
db.getCollection("zoopla-listings").createIndex({listing_id: 1}, {unique: true})
db.getCollection("zoopla-listings").createIndex({postcode: 1}, {unique: false})


// restore database
// in the shell 
// <path> is the path to the "dump" folder (included)


mongorestore --host 127.0.0.1:27017 -u <user> -p <password> --authenticationDAtabase admin -d property_wizard -c postcodes  --drop <path>
mongorestore --host 127.0.0.1:27017 -u <user> -p <password> --authenticationDAtabase admin -d property_wizard -c zoopla-listings  --drop <path>

//// useful commands
// db.grantRolesToUser("root", ["restore"])
//db.grantRolesToUser("root", [{db: "property-wizard", role:"dbAdmin"}])





