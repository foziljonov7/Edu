# Edu - O'quv markazlar uchun CRM sistema loyihasi.

- Edu loyihasi asosiy 2-qismdan tashkil topadi
  
- Edu.API - backend qismi

- Edu.Dashboard - Desktop app qismi


## Loyiha .NET 8 versiyada ishlab chiqilmoqda

## Clone qilib olish uchun 

```git clone https://github.com/foziljonov7/Edu.git```

### Clone qilib olgach AppSettings.json fayli ichidagi ConnectionStrings o'zingizga to'g'irlang

``` json
"ConnectionStrings": {
  "localhost": "Host=localhost;Port=5432;Database=EduDB;User Id=YourUsername;Password=YourPassword;"
},
```


Keyin Developer powershell orqali quyidagi buyruqlarni amalga oshiring


loyihani qayta ishga yuklash uchun

```
dotnet restore
```
loyihani kamchilik va error larini tekshirish uchun

```
dotnet test
```
loyihani build qilish uchun

```
dotnet build
```
loyihadagi migration larni update qilish


```
dotnet ef database update
```


So'ngra loyihani ishga tushuring

```
dotnet run
```




## Loyihaning Database qismining ko'rinishi: 

![image](https://github.com/foziljonov7/Edu/blob/master/Edu.API/wwwroot/Images/Edu.png)
