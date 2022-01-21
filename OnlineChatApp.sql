CREATE TABLE IF NOT EXISTS user_roles(
    user_role_id SERIAL PRIMARY KEY NOT NULL,
    user_role_name TEXT
);

INSERT INTO user_roles (user_role) VALUES ("admin"), ("user");

CREATE TABLE IF NOT EXISTS users(
    user_id serial PRIMARY KEY NOT NULL,
    firstname VARCHAR(50) NOT NULL,
    lastname VARCHAR(50) NOT NULL,
    username VARCHAR(50) UNIQUE NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    created_on TIMESTAMP,
    user_role INTEGER REFERENCES user_roles (user_role_id)
);

CREATE TABLE IF NOT EXISTS friend_requests(
    friend_request_id SERIAL PRIMARY KEY NOT NULL,
    friend_1 INTEGER REFERENCES users (user_ID),
    friend_2 INTEGER REFERENCES users (user_ID),
    friend_request_status BOOLEAN DEFAULT FALSE,
    created_on TIMESTAMP
);