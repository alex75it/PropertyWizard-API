use property_wizard

db.getCollection("postcodes")
    .createIndex(
        { "code": 1}, {unique: true}
    );
    

db.getCollection("zoopla-listings")
    .createIndex(
        { "listing_id": 1}, {unique: true}
    );

