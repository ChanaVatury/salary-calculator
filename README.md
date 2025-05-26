
אפליקציית מחשבון שכר – Salary Calculator

אפליקציית Full Stack מבוססת Angular 17 ו־ASP.NET Core 8, המדמה מחשבון שכר לעובד.

האפליקציה מאפשרת לחשב שכר לפי פרמטרים כמו:

דרגה מקצועית

דרגה ניהולית

שנות ותק

אחוז משרה

זכאות לתוספות לפי חוק

טכנולוגיות:

צד לקוח (Frontend):
Angular 17, Angular Material, RxJS, Reactive Forms

צד שרת (Backend):
ASP.NET Core 8 (Web API), Entity Framework Core

שפות תכנות:
TypeScript (בצד הלקוח), C# (בצד השרת)

בסיס נתונים:
SQL SERVER

האפליקציה בנויה במודל של שלוש שכבות מופרדות:

הפעלה מקומית:

כדי להפעיל את הפרויקט אצלכם, יש לבצע את הצעדים הבאים:

1. יצירת מסד נתונים:
בתיקיית הפרויקט של ה־API, יש להריץ:
dotnet ef migrations add InitialCreate .1
dotnet ef database update .2  

2. הפעלת השרת (Backend):
dotnet run

3. הפעלת לקוח Angular (Frontend):
cd client
npm install
ng serve

במיקום זה: https://github.com/ChanaVatury/salary-calculator/blob/main/client/SalaryCalculator-Client/src/assets/application-picture.png?raw=true
מצורפת תמונה של האפליקציה עם הדוגמא שהיתה בדף האפיון


