-- SQLite
CREATE TABLE IF NOT EXISTS employees (
  id INTEGER NOT NULL PRIMARY KEY,
  managerId INTEGER, 
  name VARCHAR(30) NOT NULL,
  FOREIGN KEY (managerId) REFERENCES employees(id)
);


-- INSERT INTO employees(id, managerId, name) VALUES(1, NULL, 'John');
-- INSERT INTO employees(id, managerId, name) VALUES(2, 1, 'Mike');
-- INSERT INTO employees (id, name, managerId)
-- VALUES 
-- (3, 'Alice', NULL),
-- (4, 'Bob', 1),
-- (5, 'Charlie', 1),
-- (6, 'David', 2);


-- 1. Write a SQL query to find all employees who directly report to their manager.
SELECT e.name
FROM 'employees' e
LEFT JOIN 'employees' m ON e.id == m.managerId
WHERE m.id IS NULL;
