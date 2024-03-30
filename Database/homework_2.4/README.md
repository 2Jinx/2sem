## Содержание

- [Создание базы данных](#создание-базы-данных)
- [Задание 1.2](#задание-12)
- [Задание 2.1](#задание-21)
- [Задание 3.6](#задание-36)
- [Задание 4.1](#задание-41)
- [Задание 5.1](#задание-51)
- [Задание 6.4](#задание-64)
- [Задание 7.2](#задание-72)
- [Задание 8.1](#задание-81)
- [Задание 9.4](#задание-94)
- [Задание 10](#задание-10)

## Создание базы данных

### 10 Вариант 

Структура базы данных «Университет»:   

- `Students`(StudentId, StudentName, GroupId)  

- `Groups` (GroupId, GroupName)   

- `Courses` (CourseId, CourseName)   

- `Lecturers` (LecturerId, LecturerName)   

- `Plan` (GroupId, CourseId, LecturerId)   

- `Marks` (StudentId, CourseId, Mark)   

<br>

#### Таблица "Students"

```sql
CREATE TABLE Students (
    StudentId SERIAL PRIMARY KEY,
    StudentName VARCHAR(50),
    GroupId INT,
    FOREIGN KEY (GroupId) REFERENCES Groups(GroupId)
);
```

#### Таблица "Groups"

```sql
CREATE TABLE Groups (
    GroupId SERIAL PRIMARY KEY,
    GroupName VARCHAR(50)
);
```

#### Таблица "Courses"

```sql
CREATE TABLE Courses (
    CourseId SERIAL PRIMARY KEY,
    CourseName VARCHAR(50)
);
```

#### Таблица "Lecturers"

```sql
CREATE TABLE Lecturers (
    LecturerId SERIAL PRIMARY KEY,
    LecturerName VARCHAR(50)
);
```

#### Таблица "Plan"

```sql
CREATE TABLE Plan (
    GroupId INT,
    CourseId INT,
    LecturerId INT,
    PRIMARY KEY (GroupId, CourseId),
    FOREIGN KEY (GroupId) REFERENCES Groups(GroupId),
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId),
    FOREIGN KEY (LecturerId) REFERENCES Lecturers(LecturerId)
);
```

#### Таблица "Marks"

```sql
CREATE TABLE Marks (
    StudentId INT,
    CourseId INT,
    Mark INT,
    PRIMARY KEY (StudentId, CourseId),
    FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);
```

## Задание 1.2

#### SQL

```sql
SELECT
    s.studentid,
    s.studentname,
    s.groupid
FROM students s JOIN public.groups g
ON s. groupid = g. groupid
```

#### Реляционная алгебра

```
π StudentId, StudentName, GroupId (σ s.GroupId = g.GroupId (Students ⨝ Groups))
```

## Задание 2.1

#### SQL

```sql
SELECT
    Students. Studentid,
    Students. StudentName,
    Groups. GroupName
FROM Students JOIN Groups 
ON Students.GroupId = Groups. GroupId
WHERE Students.StudentId = 123;
```

#### Реляционная алгебра

```
π StudentId, StudentName, GroupId (σ s.GroupId = g.GroupId (Students ⨝ Groups))
```

## Задание 3.6

#### SQL

```sql
SELECT s.StudentId, s.StudentName, s.GroupId, m.Mark, l.LecturerName
FROM Students s
JOIN Marks m ON s.StudentId = m.StudentId
JOIN Courses c ON m.CourseId = c.CourseId
JOIN Plan p ON c.CourseId = p.CourseId
JOIN Lecturers l ON p.LecturerId = l.LecturerId
WHERE l.LecturerName = 'Иванов И.И' AND m.Mark = 5;
```

#### Реляционная алгебра

```
π StudentId, StudentName, GroupId, Mark, LecturerName(σ l.LecturerName = 'Иванов И.И'  m.Mark = 5(
Students ⋈ Marks ⋈ Courses ⋈ Plan ⋈ Lecturers ) )
```

## Задание 4.1

#### SQL

```sql
SELECT
    Students. StudentId,
    Students. StudentName,
    Students.Groupld
FROM 
    Students 
CROSS JOIN 
    Groups
WHERE 
    Students. StudentId NOT IN (
            SELECT DISTINCT Marks. StudentId
            FROM Marks 
            JOIN
                Courses ON Marks.Courseld = Courses.Courseld
            WHERE           
                Courses. CourseName = 'Mathematics'
    )
```

#### Реляционная алгебра

```
π StudentId, StudentName, GroupId ( Students ⨯ Groups - π StudentId ( σ CourseName = 'Mathematics' ( Marks ⨝ Courses ) ) )
```

## Задание 5.1

#### SQL

```sql
SELECT
    Students. StudentName,
    Courses. CourseName
FROM
    Students
CROSS JOIN
    Courses
WHERE
    (Students.StudentId, Courses.Courseld) NOT IN (
        SELECT Marks.StudentId, Marks.Courseld
        FROM
            Marks
    )
```

#### Реляционная алгебра

```
π StudentName, CourseName (σ Students ⨯ Courses - π StudentId, CourseId ( Marks ))
```

## Задание 6.4

#### SQL

```sql
SELECT s.StudentId
FROM Students s
JOIN Marks m ON s.StudentId = m.StudentId
JOIN Courses c ON m.CourseId = c.CourseId
JOIN Plan p ON c.CourseId = p.CourseId
JOIN Lecturers l ON p.LecturerId = l.LecturerId
WHERE l.LecturerName = 'Ваше_ФИО_лектора'
GROUP BY s.StudentId
HAVING COUNT(DISTINCT c.CourseId) = (SELECT COUNT(DISTINCT c2.CourseId)
    FROM Courses c2
    WHERE c2.LecturerId = l.LecturerId);
```

#### Реляционная алгебра

```
π_s.StudentId( 
σ_count(DISTINCT c.CourseId) = count(DISTINCT m.CourseId)( 
γ_s.StudentId, c.CourseId(COUNT(DISTINCT c.CourseId)) ⋈
γ_s.StudentId, m.CourseId(COUNT(DISTINCT m.CourseId)) ) ⋈
σ_l.LecturerName = 'Ваше_ФИО_лектора'(Students ⋈ Marks ⋈ Courses ⋈ Plan ⋈ Lecturers)
```

## Задание 7.2

#### SQL

```sql
SELECT g.GroupName, c.CourseName
FROM Groups g
JOIN Students s ON g.GroupId = s.GroupId
JOIN Marks m ON s.StudentId = m.StudentId
JOIN Courses c ON m.CourseId = c.CourseId
GROUP BY g.GroupName, c.CourseName
HAVING COUNT(DISTINCT s.StudentId) = (SELECT COUNT(*) FROM Students WHERE GroupId = g.GroupId);
```

#### Реляционная алгебра

```
π GroupName, CourseName (σ StudentCount = GroupStudentCount (ρ StudentCount (π GroupId, COUNT(StudentId) AS StudentCount (σ CourseCount = GroupCourseCount (ρ CourseCount (π CourseId, COUNT(StudentId) AS CourseCount (σ GroupId = GroupId (Students ⨝ Marks)))))) ⨝ Courses)
```

#### SQL

```sql
SELECT
    Groups.GroupName,
    Courses.CourseName
FROM
    Groups
CROSS JOIN
    Courses
WHERE 
    NOT EXISTS (
        SELECT *
        FROM
            Students
        WHERE
            Students.Groupld = Groups.GroupId
            AND Students.StudentId NOT IN C
            SELECT
                Marks.Studentld
            FROM
                Marks
            JOIN
                Courses ON Marks.Courseld = Courses.Courseld
            WHERE
                Courses.CourseName =Courses.CourseName
```

#### Реляционная алгебра

```
π GroupName, CourseName ( Groups ⨯ Courses - π GroupId, CourseId ( Students ⨝ Marks ) ÷ π StudentId ( Students ))
```

## Задание 8.1

#### SQL

```sql
SELECT StudentId, SUM(Mark) AS SumMark
FROM Marks
WHERE StudentId = :StudentId
GROUP BY StudentId;
```

#### Реляционная алгебра

```
π StudentId, SUM(Mark) AS SumMark (σ StudentId = :StudentId (Marks))
```

## Задание 9.4

#### SQL

```sql
SELECT GroupName, AVG(AvgMark) AS AvgAvgMark
FROM (
    SELECT GroupName, AVG(Mark) AS AvgMark
    FROM Students
    GROUP BY GroupName
) AS AvgMarks
GROUP BY GroupName;
```

#### Реляционная алгебра

```
π GroupName, AVG(AvgMark) AS AvgAvgMark (γ GroupName; AVG(Mark) AS AvgMark (ρ GroupName, Mark (π GroupName, Mark (Students))))
```

## Задание 10

#### SQL

```sql
SELECT
    Students. StudentId,
    COUNT(DISTINCT Marks. Courseld) AS Total, COUNTDISTINCT CASE WHEN Marks.Mark IS NOT NULL THEN Marks.Courseld END) AS Passed,
    COUNT(DISTINCT CASE WHEN Marks.Mark IS NULL THEN Marks.CourseId END) AS Failed
FROM
    Students
LEFT JOIN
    Marks ON Students.Studentld = Marks. Studentld
GROUP BY
    Students.StudentId;
```

#### Реляционная алгебра

```
π StudentId, Total, Passed, Failed (
   Students ⨝ σ Mark IS NOT NULL (π StudentId, COUNT(CourseId) AS Passed (Marks)) ⨝
   σ Mark IS NULL (π StudentId, COUNT(CourseId) AS Failed (Marks)) ⨝
   π StudentId, COUNT(CourseId) AS Total (Marks)
)
```