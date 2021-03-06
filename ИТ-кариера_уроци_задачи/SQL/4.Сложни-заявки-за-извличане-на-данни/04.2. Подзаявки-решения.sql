USE soft_uni;

-- 01. Най-ниско платени служители
SELECT e.first_name, e.last_name, e.salary FROM employees e
WHERE e.salary = 
  (SELECT salary FROM employees ORDER BY salary LIMIT 1)
  
-- 02. Служители с близки до най-ниските заплати
SELECT e.first_name, e.last_name, e.salary FROM employees e 
WHERE e.salary < 1.1 * 
  (SELECT salary FROM employees ORDER BY salary LIMIT 1) 
ORDER BY salary

-- 03. Всички мениджъри
SELECT e.first_name, e.last_name, e.job_title FROM employees e 
WHERE e.employee_id in (SELECT DISTINCT manager_id FROM employees)
ORDER BY e.first_name, e.last_name

-- 04. Служителите от San Francisco
SELECT e.first_name, e.last_name, FROM employees e 
WHERE e.address_id in 
  (SELECT address_id FROM addresses
   where town_id = (select town_id from towns where name = "San Francisco"))
ORDER BY e.first_name, e.last_name