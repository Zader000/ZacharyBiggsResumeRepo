#include <stdio.h>
#include <string.h>
#include <stdbool.h>
#include "SQLite/sqlite3.h"

// Prints out the results of the query and returns true if there were results in the query false otherwise.
bool executeQuery(char query[])
{
    sqlite3 *db;
    sqlite3_stmt *stmt;

    sqlite3_open("../SQLite/Data/grading_system.db", &db);
    if (db == NULL)
    {
        printf("Database not found.\n");
    }
    sqlite3_prepare_v2(db, query, -1, &stmt, NULL);
    if (sqlite3_step(stmt) == SQLITE_DONE)
    {
        return false;
    }
    do
    {
        int i;
        int num_cols = sqlite3_column_count(stmt);
        for (i = 0; i < num_cols; i++)
        {
            switch (sqlite3_column_type(stmt, i))
            {
                case (SQLITE3_TEXT):
                    printf("%s ", sqlite3_column_text(stmt, i));
                    break;
                case (SQLITE_INTEGER):
                    printf("%d ", sqlite3_column_int(stmt, i));
                    break;
                case (SQLITE_FLOAT):
                    printf("%g ", sqlite3_column_double(stmt, i));
                    break;
                default:
                    break;
            }
        }
        printf("\n");
    }while(sqlite3_step(stmt) != SQLITE_DONE);

    printf("\n");
    sqlite3_finalize(stmt);
    sqlite3_close(db);
    return true;
}

int displayMenu()
{
    printf("----------------------------------------------------\n");
    printf("Database Report Tool\n");
    printf("----------------------------------------------------\n");
    printf("1. List of GPA 4.0 Students\n");
    printf("2. List Classes by Department\n");
    printf("3. Display Faculty History\n");
    printf("4. Display Student History\n");
    printf("5. Exit\n");
    printf("----------------------------------------------------\n");
    printf("Choose and Option:  ");
    int output;
    scanf("%d", &output);
    printf("\n");
    return output;
}

int main()
{
    int input;
    do
    {
        input = displayMenu();

        switch(input)
        {
            case 1:
                executeQuery("select student_id, first_name, last_name from students where cumulative_gpa = 4.0 order by last_name;");
                break;
            case 2:
                printf("Department ID:  ");
                char departmentID[2];
                scanf("%s", &departmentID);
                printf("\n");
                char query[500] = "select d.department_name, c.course_name, c.course_number "
                               "from course_catalog c, departments d "
                               "where d.department_id = c.department_id and d.department_id = ";

                strcat(query, departmentID);
                strcat(query, " order by d.department_name;");
                executeQuery(query);
                break;
            case 3:
                printf("Faculty List: \n");
                printf("----------------------------------------------------\n");
                char facultyListQuery[] = "select * from faculty order by last_name, first_name";
                executeQuery(facultyListQuery);
                char facId[2];
                printf("Faculty ID:  ");
                scanf("%s", &facId);
                printf("\n");
                char nameQuery[500] = "select faculty_id, first_name, last_name from faculty where faculty_id = ";
                strcat(nameQuery, facId);
                strcat(nameQuery, ";");

                char facHistoryQuery[500] = "select cls.class_id, cat.course_name, s.semester\n"
                                            "from classes cls, course_catalog cat, semesters s\n"
                                            "where cls.catalog_id = cat.catalog_id and\n"
                                            "      cls.semester_id = s.semester_id and\n"
                                            "      cls.faculty_id = ";
                strcat(facHistoryQuery, facId);
                strcat(facHistoryQuery, ";");
                if (!executeQuery(facHistoryQuery))
                {
                    printf("Faculty member has no teaching history.\n");
                }
                break;
            case 4:
                printf("----------------------------------------------------\n");
                printf("Student Number:  ");
                char sNumber[12];
                scanf("%s", &sNumber);
                printf("\n");
                char studentHeaderQuery[500] = "select s.school_id, s.first_name, s.last_name, s.class_standing, m.major_name\n"
                                            "from students s, majors m\n"
                                            "where s.major_id = m.major_id and school_id = '";
                strcat(studentHeaderQuery, sNumber);
                strcat(studentHeaderQuery, "';");

                printf("----------------------------------------------------\n");
                char studentHistoryQuery[500] = "select sm.semester, cc.dept_abbrv, cc.course_number, cc.course_name, r.grade\n"
                                                "from registration r, classes cs, course_catalog cc, students s, semesters sm\n"
                                                "where r.class_id = cs.class_id\n"
                                                "and cs.catalog_id = cc.catalog_id\n"
                                                "and r.student_id = s.student_id\n"
                                                "and r.semester_id = sm.semester_id\n"
                                                "and s.school_id = '";
                strcat(studentHistoryQuery, sNumber);
                strcat(studentHistoryQuery, "';");

                if (!executeQuery(studentHeaderQuery))
                {
                    printf("Student was not found or has no history\n");
                }
                else
                {
                    executeQuery(studentHistoryQuery);
                }
                break;
            default:
                break;
        }
    }
    while (input != 5);
    return 0;
}
