## Содержание

- [Запросы с использованием функции COUNT](#запросы-с-использованием-функции-count)
- [Запросы с использованием функции SUM](#запросы-с-использованием-функции-sum)
- [Запросы с использованием функции UPPER, LOWER](#запросы-с-использованием-функции-upper-lower)
- [Запросы с использованием временных функций](#запросы-с-использованием-временных-функций)
---

## Запросы с использованием функции COUNT

### Подсчет количества факультетов

```
SELECT COUNT(*) AS TotalFaculties
FROM FACULTIES;
```

<img src="images/1.png" alt="SQL запросы" style="border-radius:7px">

---

### Подсчет числа студентов в каждой группе

```
SELECT GROUP_NUMBER, COUNT(*) AS StudentsCount
FROM STUDENTS
GROUP BY GROUP_NUMBER;
```

<img src="images/2.png" alt="SQL запросы" style="border-radius:7px">

--- 

## Запросы с использованием функции SUM

### Подсчет суммы стипендий всех студентов

```
SELECT SUM(STIPEND) AS TotalStipendSum
FROM STUDENT;
```

<img src="images/3.png" alt="SQL запросы" style="border-radius:7px">

---

### Подсчет общего количества оценок по предметам

```
SELECT SUM(MARK) AS TotalMarksSum
FROM PROGRESS;
```

<img src="images/4.png" alt="SQL запросы" style="border-radius:7px">

---

## Запросы с использованием функции UPPER, LOWER

### Вывод всех фамилий студентов в верхнем регистре

```
SELECT UPPER(STUDENT_SURNAME) AS UpperSurname
FROM STUDENTS;
```

<img src="images/5.png" alt="SQL запросы" style="border-radius:7px">

---

### Вывод всех названий предметов в нижнем регистре

```
SELECT LOWER(SUBJECT) AS LowerSubject
FROM PROGRESS;
```

<img src="images/6.png" alt="SQL запросы" style="border-radius:7px">

---

## Запросы с использованием временных функций

### Получение текущей даты

```
SELECT CURRENT_DATE AS TodayDate;
```

<img src="images/7.png" alt="SQL запросы" style="border-radius:7px">

---

### Изменение формата даты рождения студентов

```
SELECT TO_CHAR(BIRTHDAY, 'DD Mon YYYY') AS FormattedBirthday
FROM STUDENT;
```

<img src="images/8.png" alt="SQL запросы" style="border-radius:7px">

---

### Получение возраста преподавателей

```
SELECT NAME_TEACHER, DATE_PART('year', AGE(DATA_HIRE, BIRTHDAY)) AS Age
FROM TEACHER;
```

<img src="images/9.png" alt="SQL запросы" style="border-radius:7px">

### Вычисление возраста студентов на текущую дату

```
SELECT SUTNAME, DATE_PART('year', AGE(CURRENT_DATE, BIRTHDAY)) AS Age
FROM STUDENT;
```

<img src="images/10.png" alt="SQL запросы" style="border-radius:7px">

---