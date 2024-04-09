# Write your MySQL query statement below
SELECT employee.name as Employee
FROM employee 
INNER JOIN employee employee_copy ON employee.managerId = employee_copy.id
WHERE employee.salary > employee_copy.salary;