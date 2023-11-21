## Содержание

- [UNION](#union)
- [EXCEPT](#except)
- [INTERSECT](#intersect)

---

## UNION

### Получение уникальных групп из таблицы STUDY_GROUPS и STUDENT

```
SELECT DEPARTMENT_NAME, CAST(GROUP_NUMBER AS TEXT) AS GROUP_NUMBER
FROM STUDY_GROUPS
UNION
SELECT DEPARTMENT_NAME, "GROUP"
FROM STUDENT;
```

<img src="images/1.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT FACULTY_NAME, DEAN_FIO
FROM FACULTIES
UNION
SELECT DEPARTMENT_NAME, MANAGER_FULL_NAME
FROM DEPARTMENTS;
```

<img src="images/2.png" alt="SQL запросы" style="border-radius:7px">

---

## EXCEPT

### Нахождение групп из STUDY_GROUPS, которые не встречаются в таблице STUDENT

```
SELECT DEPARTMENT_NAME, CAST(GROUP_NUMBER AS TEXT) AS GROUP_NUMBER
FROM STUDY_GROUPS
EXCEPT
SELECT DEPARTMENT_NAME, "GROUP"
FROM STUDENT;
```

<img src="images/3.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT FACULTY_NAME, DEAN_FIO
FROM FACULTIES
EXCEPT
SELECT DEPARTMENT_NAME, MANAGER_FULL_NAME
FROM DEPARTMENTS;
```

<img src="images/4.png" alt="SQL запросы" style="border-radius:7px">

---

## INTERSECT

### Получение групп, присутствующих и в STUDY_GROUPS и в STUDENT

```
SELECT DEPARTMENT_NAME, CAST(GROUP_NUMBER AS TEXT) AS GROUP_NUMBER
FROM STUDY_GROUPS
INTERSECT
SELECT DEPARTMENT_NAME, "GROUP"
FROM STUDENT;
```

<img src="images/5.png" alt="SQL запросы" style="border-radius:7px">

---

```
SELECT FACULTY_NAME, DEAN_FIO
FROM FACULTIES
INTERSECT
SELECT DEPARTMENT_NAME, MANAGER_FULL_NAME
FROM DEPARTMENTS;
```

<img src="images/6.png" alt="SQL запросы" style="border-radius:7px">

---