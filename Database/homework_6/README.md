## Содержание

- [Выполнение запросов SQL при помощи SELECT](#выполнение-запросов-sql-при-помощи-select)
    - [Запросы с использованием операторов сравнения и логических операторов AND, OR и NOT](#запросы-с-использованием-операторов-сравнения-и-логических-операторов-and-or-и-not)
    - [Запрос на использование комбинаций логических операций](#запросы-с-использованием-операторов-сравнения-и-логических-операторов-and-or-и-not)

---

## Выполнение запросов SQL при помощи SELECT

> Для получения данных применяется команда SELECT. Подробнее можно почитать [тут](https://metanit.com/sql/sqlserver/4.2.php "select sql").
>  
> Запросы будем выполнять для ранее созданной базы данных *"Университет"*.  
> 
> Для фильтрации в команде SELECT применяется оператор WHERE. 
 После этого оператора ставится условие, которому должна соответствовать строка. Если условие истинно, то строка попадает в результирующую выборку. 
 >
 > В качестве условия можно использовать операции сравнения. Эти операции сравнивают два выражения.  Подробнее можно прочитать [тут](https://metanit.com/sql/sqlserver/4.5.php "where").
> - <span style="color: orange">= </span> : сравнение на равенство  
> - <span style="color: orange"><> </span> : сравнение на неравенство 
> - <span style="color: orange">< </span> : меньше чем
> - <span style="color: orange">> </span> : больше чем
> - <span style="color: orange">!< </span> : не меньше чем
> - <span style="color: orange">!> </span> : не больше чем 
> - <span style="color: orange"><= </span> : меньше чем или равно
> - <span style="color: orange">>= </span> : больше чем или равно    

### Запросы с использованием операторов сравнения и логических операторов AND, OR и NOT

- Выведем факультеты с номером кабинета < 400. Для этого необходимо выполнить следующий запрос:

```
SELECT * FROM FACULTIES WHERE ROOM_NUMBER < 400;
```
В результате должна получиться такая таблица:

<img src="images/1.png" alt="SQL запросы" style="border-radius:7px">

---

- Теперь выведем кафедры факультета физики, где число преподавателей не превышает пяти: 

```
SELECT * FROM DEPARTMENTS WHERE FACULTY = 'PHYSICS' AND TEACHER_COUNT <= 5;
```

Результат выполнения запроса:

<img src="images/2.png" alt="SQL запросы" style="border-radius:7px">

---

- Напоследок выведем группы студентов, с годом поступления раньше 2022 года, либо с числом студентов, превышающим 30: 

```
SELECT * FROM STUDY_GROUPS WHERE ADMISSION_YEAR < 2022 OR STUDENTS_NUMBER > 30;
```

В результате выполнения такого запроса получится такая таблица: 

<img src="images/3.png" alt="SQL запросы" style="border-radius:7px">

- Остальные запросы. Они похожи на предыдущие, поэтому просто покажу запрос и резульат выполнения:

```
SELECT * FROM STUDENT WHERE COURSE = 4 AND STIPEND > 300;
```

Результат: 

<img src="images/4.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM TEACHER WHERE SALARY + RISE > 1500;
```

<img src="images/6.png" alt="SQL запросы" style="border-radius:7px">

---
 
 ### Запрос на использование комбинаций логических операций

```
SELECT * FROM TEACHER WHERE ZVANIE = 'нет' OR ZVANIE = 'д.ф.м.н';
```

<img src="images/5.png" alt="SQL запросы" style="border-radius:7px">  

---

```
SELECT * FROM STUDY_GROUPS WHERE GROUP_NUMBER IN (208, 143);
```

<img src="images/7.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM STUDENTS WHERE GROUP_NUMBER BETWEEN 100 AND 200;
```

<img src="images/8.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM PROGRESS WHERE MARK IS NULL;
```

<img src="images/9.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM STUDENTS WHERE ADDRESS LIKE '%AVENUE%';
```

<img src="images/10.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM FACULTIES WHERE NOT BUILDING_NUMBER = 2;
```

<img src="images/11.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM DEPARTMENTS WHERE FACULTY = 'HISTORY' OR FACULTY = 'PHYSICS';
```

<img src="images/12.png" alt="SQL запросы" style="border-radius:7px">

---

<img src="images/13.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM PROGRESS WHERE SUBJECT LIKE '%GEOMETRY%';
```

<img src="images/14.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM STUDENTS WHERE GENDER = 'MALE' AND CITY = 'KAZAN';
```

<img src="images/15.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM FACULTIES WHERE PHONE_NUMBER = 89175328132;
```

<img src="images/16.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM DEPARTMENTS WHERE ROOM_NUMBER = NULL;
```

<img src="images/17.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM STUDENT WHERE COURSE = 4 AND STIPEND > 300;
```

<img src="images/18.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM TEACHER WHERE SALARY + RISE > 1500;
```

<img src="images/19.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT * FROM STUDENT WHERE BIRTHDAY BETWEEN '1995-01-01' AND '2000-12-31';
```

<img src="images/20.png" alt="SQL запросы" style="border-radius:7px">

---