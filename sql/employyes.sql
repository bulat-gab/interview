-- SQLite
-- CREATE TABLE IF NOT EXISTS employees (
--   id INTEGER NOT NULL PRIMARY KEY,
--   managerId INTEGER, 
--   name VARCHAR(30) NOT NULL,
--   FOREIGN KEY (managerId) REFERENCES employees(id)
-- );


-- INSERT INTO employees(id, managerId, name) VALUES(1, NULL, 'John');
-- INSERT INTO employees(id, managerId, name) VALUES(2, 1, 'Mike');
-- INSERT INTO employees (id, name, managerId)
-- VALUES 
-- (3, 'Alice', NULL),
-- (4, 'Bob', 1),
-- (5, 'Charlie', 1),
-- (6, 'David', 2);


-- 1. Write a SQL query to find all employees who directly report to their manager.
-- SELECT e.name
-- FROM 'employees' e
-- LEFT JOIN 'employees' m ON e.id == m.managerId
-- WHERE m.id IS NULL;


-- Example case create statement:
DROP TABLE IF EXISTS usersRoles;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS roles;

CREATE TABLE IF NOT EXISTS users (
  id INTEGER NOT NULL PRIMARY KEY,
  userName VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS roles (
  id INTEGER NOT NULL PRIMARY KEY,
  role VARCHAR(20) NOT NULL
);


INSERT INTO users(id, userName) VALUES(1, 'Steven Smith');
INSERT INTO users(id, userName) VALUES(2, 'Brian Burns');

INSERT INTO roles(id, role) VALUES(1, 'Project Manager');
INSERT INTO roles(id, role) VALUES(2, 'Solution Architect');

-- Improve the create table statement below:
CREATE TABLE IF NOT EXISTS usersRoles (
  userId INTEGER NOT NULL,
  roleId INTEGER NOT NULL,
  PRIMARY KEY(userId, roleId),
  FOREIGN KEY (userId) REFERENCES users(id) ON DELETE CASCADE,
  FOREIGN KEY (roleId) REFERENCES roles(id) ON DELETE CASCADE
);

-- -- The statements below should pass.
INSERT INTO usersRoles(userId, roleId) VALUES(1, 1);
INSERT INTO usersRoles(userId, roleId) VALUES(1, 2);
INSERT INTO usersRoles(userId, roleId) VALUES(2, 2);

-- -- The statement below should fail.
INSERT INTO usersRoles(userId, roleId) VALUES(2, NULL);